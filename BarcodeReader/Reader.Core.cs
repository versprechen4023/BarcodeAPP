using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DirectShowLib;

namespace Reader
{
	public partial class Reader
	{
		/// <summary>
		/// 카메라 목록 호출 함수
		/// </summary>
		/// <returns></returns>
		private List<String> GetCameraList()
		{
			// 디바이스 데이터를 가져온다
			var devices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));

			// 카메라명을 담기위한 변수
			List<string> cameraList = new List<string>();

			// 콤보박스에 카메라명 추가
			foreach (var list in devices)
			{
				cameraList.Add(list.Name);
			}

			return cameraList;
		}

		/// <summary>
		/// 바코드에 인식된 상품목록 업데이트 함수
		/// </summary>
		/// <param name="proNo"></param>
		private void UpdateProList(string proNo)
		{
			try
			{
				// db에 접근해 해당되는 상품의 정보를 가져옴
				var proData = db.GetProductNo(proNo);

				if (proData == null) { MessageBox.Show("해당하는 상품정보가 데이터베이스에 없습니다"); return; }

				// 리스트 뷰에 상품정보 업데이트
				ListViewItem item = new ListViewItem();
				item.Text = proData.ProNo;
				item.SubItems.Add(proData.ProName);
				item.SubItems.Add(proData.ProPrice.ToString());

				lvProList.Items.Add(item);

				// 항상 상품목록 가장 마지막이 선택되게 함
				if (lvProList.Items.Count > 0)
				{
					lvProList.TopItem = lvProList.Items[lvProList.Items.Count - 1];
				}
			}
			catch (Exception)
			{
				// db 에러 발생시 프로그램 종료
				MessageBox.Show("데이터 베이스에 연결 할 수 없습니다 프로그램을 종료합니다");
				Close();
			}

		}
	}
}
