using SQLCommon;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace Generator
{
	public partial class Generator : Form
	{
		/// <summary>
		/// 쿼리 사용을 위한 변수
		/// </summary>
		private readonly CommonQuery db;

		public Generator()
		{
			InitializeComponent();

			// 초기 기동시 객체할당
			db = new CommonQuery();
		}

		private void Generator_Load(object sender, EventArgs e)
		{
			// 폼 로드시 데이터베이스 연결 유무 확인
			if (!db.DbConnectionCheck())
			{
				MessageBox.Show("데이터 베이스에 연결 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}

			// DB에서 초기 상품목록 로드
			loadProductList();
		}

		/// <summary>
		/// 리스트 뷰 이벤트 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvProList_SelectedIndexChanged(object sender, EventArgs e)
		{
			// 상품이 선택되었는지 체크
			if(lvProList.SelectedItems.Count > 0)
			{
				ListViewItem selectedItem = lvProList.SelectedItems[0];
				// 선택된 상품번호를 기반으로 바코드를 생성한다
				pbBarcode.Image = GenerateBarcodeImage(selectedItem.Text);
			}
		}

		/// <summary>
		/// 바코드 이미지 저장 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveBarcode_Click(object sender, EventArgs e)
		{
			// 이미지가 없는경우 상품목록이 없는것으로 확인 에러 메시지 출력
			if(pbBarcode.Image == null) { MessageBox.Show("저장할 바코드 이미지가 없습니다"); return; }

			// 저장을 위한 파일 다이얼로그 생성
			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				// 다이얼로그 로드시 최초로 보여주는 저장위치(C드라이브)
				saveFileDialog.InitialDirectory = @"C:\";
				// 초기 저장이름
				saveFileDialog.FileName = "barcode.png";
				// 파일 필터
				saveFileDialog.Filter = "PNG 파일 (*.png)|*.png|모든 파일 (*.*)|*.*";
				// 파일명 유효성 검증
				saveFileDialog.ValidateNames = true;

				// 사용자가 저장 버튼을 누르면 PNG형태의 파일로 저장
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					var savePath = saveFileDialog.FileName;
					Image barcodeImage = pbBarcode.Image;
					barcodeImage.Save(savePath, System.Drawing.Imaging.ImageFormat.Png);
				}
			}
		}

		/// <summary>
		/// 바코드 이미지 일괄 저장 처리
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSaveAllBarcode_Click(object sender, EventArgs e)
		{
			try
			{
				// 상품목록이 없으면 에러 출력
				if (lvProList.Items.Count == 0) { MessageBox.Show("저장할 바코드 이미지가 없습니다"); return; }

				// 저장을 위한 파일 다이얼로그 생성
				using (SaveFileDialog saveFileDialog = new SaveFileDialog())
				{
					// 다이얼로그 로드시 최초로 보여주는 저장위치(C드라이브)
					saveFileDialog.InitialDirectory = @"C:\";
					// 초기 저장이름
					saveFileDialog.FileName = "barcode.zip";
					// 파일 필터
					saveFileDialog.Filter = "압축 파일 (*.zip)|*.zip|모든 파일 (*.*)|*.*";
					// 파일명 유효성 검증
					saveFileDialog.ValidateNames = true;

					// 사용자가 저장 버튼을 누르면 Zip형태의 파일로 저장
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						// 압축 파일 이미 있으면 삭제처리
						if (File.Exists(saveFileDialog.FileName))
						{
							File.Delete(saveFileDialog.FileName);
						}

						using (var archive = ZipFile.Open(saveFileDialog.FileName, ZipArchiveMode.Create))
						{
							for (var i = 0; i < lvProList.Items.Count; i++)
							{
								var pngName = lvProList.Items[i].SubItems[0].Text;
								var bitmap = GenerateBarcodeImage(pngName);

								// 임시 폴더에 이미지 파일 저장
								var pngPath = $"{Path.GetTempPath()}{pngName}.png";
								bitmap.Save(pngPath, System.Drawing.Imaging.ImageFormat.Png);

								archive.CreateEntryFromFile(pngPath, $"{pngName}.png");
							}

							// 임시 파일 삭제
							for (var i = 0; i < lvProList.Items.Count; i++)
							{
								var pngName = lvProList.Items[i].SubItems[0].Text;

								if (File.Exists($"{Path.GetTempPath()}{pngName}.png"))
								{
									File.Delete($"{Path.GetTempPath()}{pngName}.png");
								}
							}
						}
					}
				}
			}
			catch(Exception)
			{
				MessageBox.Show("파일 처리중에 에러가 발생했습니다");
			}
		}

		/// <summary>
		/// 상품 정보 저장 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCreate_Click(object sender, EventArgs e)
		{
			var proName = textProName.Text.Trim();
			var proPrice = textProPrice.Text.Trim();

			// 상품 정보가 올바르게 입력되었는지 체크
			if (!CheckProductInfo(proName, proPrice)) return;

			// 상품 번호를 생성한다
			var proNo = GenerateProNo().Trim();

			// db에 저장처리
			var result = db.PutProduct(proNo, proName, Int32.Parse(proPrice));

			// 완료되면 상품목록을 다시 로드 한다
			if (result)
			{
				loadProductList();
			}
			else
			{
				// db 에러 발생시 프로그램 종료
				MessageBox.Show("데이터 베이스에 연결 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}
		}

		/// <summary>
		/// 상품 정보 삭제 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDelete_Click(object sender, EventArgs e)
		{
			// 삭제할 상품 정보가 선택되었는지 체크한다
			if (lvProList.SelectedItems.Count == 0) return;

			// 체크된 상품의 상품 번호를 가져온다
			ListViewItem selectedItem = lvProList.SelectedItems[0];

			var proNo = selectedItem.Text;

			// db에서 삭제처리
			var result = db.DeleteProduct(proNo);

			// 완료되면 상품목록을 다시 로드 한다
			if (result)
			{
				loadProductList();
			}
			else
			{
				// db 에러 발생시 프로그램 종료
				MessageBox.Show("데이터 베이스에 연결 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}
		}

		/// <summary>
		/// 상품 정보 수정 액션
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Click(object sender, EventArgs e)
		{
			// 수정할 상품 정보가 선택되었는지 체크한다
			if (lvProList.SelectedItems.Count == 0) return;

			var proName = textProName.Text.Trim();
			var proPrice = textProPrice.Text.Trim();

			// 수정할 상품 정보가 올바르게 입력되었는지 체크
			if (!CheckProductInfo(proName, proPrice)) return;

			// 체크된 상품의 상품 번호를 가져온다
			ListViewItem selectedItem = lvProList.SelectedItems[0];

			var proNo = selectedItem.Text;

			// db에서 수정 처리
			var result = db.UpdateProduct(proNo, proName, Int32.Parse(proPrice));

			// 완료되면 상품목록을 다시 로드 한다
			if (result)
			{
				loadProductList();
			}
			else
			{
				// db 에러 발생시 프로그램 종료
				MessageBox.Show("데이터 베이스에 연결 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}
		}
	}
}
