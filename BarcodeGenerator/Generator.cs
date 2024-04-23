﻿using SQLCommon;
using ZXing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.Entity.Infrastructure;
using System.Text.RegularExpressions;

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
		/// 바코드 생성 함수
		/// </summary>
		/// <param name="proNo"></param>
		private void GenerateBarcode(string proNo)
		{
			// CODE128 타입으로 바코드 생성
			BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
			// 픽처박스에 등록
			pbBarcode.Image = writer.Write(proNo);
		}

		/// <summary>
		/// 리스트뷰에 상품목록 로드
		/// </summary>
		private void loadProductList()
		{
			try
			{
				// 로드전 리스트뷰 초기화
				lvProList.Items.Clear();

				// 모든 상품목록을 가져온다
				var ProList = db.GetAllProducts();

				if(ProList.Count > 0)
				{
					// 리스트뷰에 값을 넣는다
					foreach (var list in ProList)
					{
						ListViewItem item = new ListViewItem();
						item.Text = list.ProNo;
						item.SubItems.Add(list.ProName);
						item.SubItems.Add(list.ProPrice.ToString());

						lvProList.Items.Add(item);
					}

					// 항상 상품목록 가장 마지막이 선택되게 함
					if (lvProList.Items.Count > 0)
					{
						lvProList.Items[lvProList.Items.Count - 1].Selected = true;
					}
				}
				else
				{
					// 값 없을경우 바코드 이미지 초기화
					pbBarcode.Image = null;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("데이터베이스에 접근 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}
		}

		/// <summary>
		/// 고유 상품번호 계산을 위한 함수
		/// </summary>
		/// <returns></returns>
		private string GenerateProNo()
		{
			// 상품번호 계산을 위해 가장 마지막 상품번호를 가져온다
			var lastNo = db.GetProductNo();

			int number;

			// 상품목록이 없으면 초기값은1 아니라면 마지막 상품번호에서 1을 더한다
			if (lastNo == null)
			{
				number = 1;
			}
			else
			{
				number = Int32.Parse(Regex.Replace(lastNo.ProNo, "[^0-9]", "")) + 1;
			}

			string result = number.ToString();

			// 최종적으로 상품번호는 P0000X의 형태가 된다
			return "P" + result.PadLeft(5, '0');
		}

		/// <summary>
		/// 상품 정보 입력값 정규식 검증
		/// </summary>
		/// <param name="proName"></param>
		/// <param name="proPrice"></param>
		/// <returns></returns>
		private bool CheckProductInfo(string proName, string proPrice)
		{
			if (string.IsNullOrEmpty(proName) || string.IsNullOrEmpty(proPrice))
			{
				MessageBox.Show("상품명 혹은 가격정보를 입력해주십시오");
				return false;
			}

			if(!Regex.IsMatch(proPrice, "^[0-9]+$"))
			{
				MessageBox.Show("상품 가격은 숫자여야 합니다");
				return false;
			}

			return true;
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
				GenerateBarcode(selectedItem.Text);
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

		}
	}
}
