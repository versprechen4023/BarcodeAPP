using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Generator
{
	public partial class Generator
	{
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

				if (ProList.Count > 0)
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

			if (!Regex.IsMatch(proPrice, "^[0-9]+$"))
			{
				MessageBox.Show("상품 가격은 숫자여야 합니다");
				return false;
			}

			return true;
		}
	}
}
