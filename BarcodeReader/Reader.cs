﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using SQLCommon;
using ZXing;
using System.IO;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog; // 줄임처리


namespace Reader
{
	public partial class Reader : Form
	{
		/// <summary>
		/// 쿼리 사용을 위한 변수
		/// </summary>
		private readonly CommonQuery db;

		/// <summary>
		/// 영상처리 루프문 제어 함수
		/// </summary>
		private bool IsRunning = false;
		/// <summary>
		/// 쿼리문에 사용되는 상품번호
		/// </summary>
		private string proNo;
		/// <summary>
		/// opencv가 접근하는 카메라에 대한 번호
		/// </summary>
		private int camera_divice_num = 0;

		public Reader()
		{
			InitializeComponent();

			// 초기기동시 객체할당
			db = new CommonQuery();
		}

		private void Reader_Load(object sender, EventArgs e)
		{
			// 폼 로드시 데이터베이스 연결 유무 확인
			if (!db.DbConnectionCheck()) 
			{
				MessageBox.Show("데이터 베이스에 연결 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}

			// 카메라 리스트 콤보박스에 설정
			cbCameraList.DataSource = GetCameraList();

		}

		/// <summary>
		/// 영상인식 비동기 처리를 위한 백그라운드 워커
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			// openCV 객체 생성
			using (VideoCapture capture = new VideoCapture(camera_divice_num))
			{
				// 카메라를 인식 할 수 없는 경우 쓰레드 강제 종료
				if (!capture.IsOpened())
				{
					MessageBox.Show("카메라를 인식 할 수 없습니다 카메라 설정을 확인해주십시오");
					backgroundWorker1.CancelAsync();
					return;
				}
				using (Mat mat = new Mat())
				{
					// 영상처리 무한 루프 진입
					while(IsRunning)
					{
						// 카메라에 캡쳐된 이미지를 읽어냄
						capture.Read(mat);

						// 이미지 해독 시도
						if (!mat.Empty())
						{
							// 사용자가 영상을 볼 수 있게끔 비트맵 형식으로 픽쳐박스에 할당
							pbBarcode.Image = mat.ToBitmap();

							// 바코드 리더 옵션 로드
							ZXing.BarcodeReader reader = ZxingReaderOption();

							// 바코드 해독 실시
							Result result = reader.Decode(mat.ToBitmap());

							// 바코드 해독에 성공한 경우 ProgressChanged 이벤트 발생
							if (result != null)
							{
								this.backgroundWorker1.ReportProgress(0, result);
							}

;						}
					}
				}
			}
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// 워커 루프 종료
			IsRunning = false;

			// 워커에서 넘겨받은 결과값 변수에 할당
			Result result = e.UserState as Result;

			// 이미지 데이터를 안전하게 가져오기위해 메모리 스트림 사용
			using (MemoryStream ms = new MemoryStream())
			{
				// 픽쳐박스로 부터 이미지를 가져옴
				var oriImage = pbBarcode.Image;

				// 메모리에 작성 및 이진 데이터 가져오기
				oriImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
				var imageData = ms.ToArray();

				// Mat데이터 가져옴
				var mat = Mat.FromImageData(imageData);

				// 바코드 인식 범위 표시
				pbBarcode.Image = BoundROILine(result, mat);
			}

			// 전역 변수에 바코드 해독 결과 값 할당
			proNo = result.Text;

		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// 작업이 완전히 완료되면 리스트뷰 목록 업데이트
			if (!string.IsNullOrEmpty(proNo))
			{
				UpdateProList(proNo);
			}

			btnStart.Enabled = true;
			btnStop.Enabled = false;

			// 상품번호 초기화
			proNo = string.Empty;
		}

		/// <summary>
		/// 바코드 영상인식 시작 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStart_Click(object sender, EventArgs e)
		{
			btnStart.Enabled = false;
			btnStop.Enabled = true;

			// 가끔 여전히 쓰레드가 실행중인 경우가 있으므로 충돌을 방지하기위한 코드
			if (!backgroundWorker1.IsBusy)
			{
				IsRunning = true;
				backgroundWorker1.RunWorkerAsync();
			}
		}

		/// <summary>
		/// 바코드 영상인식 정지 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnStop_Click(object sender, EventArgs e)
		{
			btnStart.Enabled = true;
			btnStop.Enabled = false;

			IsRunning = false;
			// 쓰레드 강제 종료
			backgroundWorker1.CancelAsync();

			pbBarcode.Image = null;
		}

		/// <summary>
		/// 바코드 이미지 업로드 해독 함수
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpload_Click(object sender, EventArgs e)
		{
			// 영상 처리가 실행중인경우 쓰레드 강제 종료
			if (backgroundWorker1.IsBusy)
			{
				btnStart.Enabled = true;
				btnStop.Enabled = false;

				IsRunning = false;
				backgroundWorker1.CancelAsync();
			}

			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				// 파일 필터 png와 jpg 파일 처리
				openFileDialog.Filter = "PNG 파일 (*.png)|*.png|JPG파일 (*.jpg)|*.jpg";

				if(openFileDialog.ShowDialog() == DialogResult.OK)
				{
					// 이미지 처리를 위한 변수 선언
					var oriImage = Image.FromFile(openFileDialog.FileName);

					Bitmap bitmap = new Bitmap(oriImage);

					// 바코드 리더 옵션 로드
					ZXing.BarcodeReader reader = ZxingReaderOption();

					// 이미지 해독 실행
					var result = reader.Decode(bitmap);

					// 정상적으로 해독된경우 상품목록 정보 업데이트 및 인식 범위 표시
					if(result != null)
					{
						// 이미지 데이터를 안전하게 가져오기위해 메모리 스트림 사용
						using(MemoryStream ms = new MemoryStream())
						{
							// 메모리에 작성 및 이진 데이터 가져오기
							oriImage.Save(ms, oriImage.RawFormat);
							var imageData = ms.ToArray();

							// Mat데이터 가져옴
							var mat = Mat.FromImageData(imageData);

							// 바코드 인식 범위 표시
							pbBarcode.Image = BoundROILine(result, mat);
						}
						// 인식된 상품목록 업데이트
						UpdateProList(result.Text);
					}
					else
					{
						// 인식 되지 않았을경우 그냥 이미지 표시
						pbBarcode.Image = oriImage;
					}
				}
			}
		}

		/// <summary>
		/// 리스트뷰 내역 초기화 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnlvClear_Click(object sender, EventArgs e)
		{
			lvProList.Items.Clear();
		}

		/// <summary>
		/// 콤보박스 카메라 선택 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbCameraList_SelectedIndexChanged(object sender, EventArgs e)
		{
			camera_divice_num = cbCameraList.SelectedIndex;

			// 영상 처리가 실행중인경우 쓰레드 강제 종료
			if (backgroundWorker1.IsBusy)
			{
				btnStart.Enabled = true;
				btnStop.Enabled = false;

				IsRunning = false;
				// 쓰레드 강제 종료
				backgroundWorker1.CancelAsync();

				pbBarcode.Image = null;
			}
		}

		/// <summary>
		/// 리스트뷰 데이터 내보내기 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnlvExport_Click(object sender, EventArgs e)
		{
			if(lvProList.Items.Count == 0) { MessageBox.Show("내보내기 할 리스트가 없습니다"); return; }

			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				// 다이얼로그 로드시 최초로 보여주는 저장위치(C드라이브)
				saveFileDialog.InitialDirectory = @"C:\";
				// 초기 저장이름
				saveFileDialog.FileName = "prolist.xlsx";
				// 파일 필터
				saveFileDialog.Filter = "엑셀 파일 (*.xlsx)|*.xlsx";
				// 파일명 유효성 검증
				saveFileDialog.ValidateNames = true;

				// 사용자가 저장위치를 선택하면 엑셀화 시작
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					_ = GenerateExcelFile(saveFileDialog.FileName);
				}
			}
		}
	}
}
