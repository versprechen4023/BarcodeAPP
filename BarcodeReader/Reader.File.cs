using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Reader
{
	public partial class Reader
	{
		/// <summary>
		/// 엑셀저장 처리 비동기
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		private async Task GenerateExcelFile(string filePath)
		{
			await Task.Run(() =>
			{
				// 객체 생성
				Excel.Application app = new Excel.Application();
				Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
				Worksheet ws = app.ActiveSheet as Worksheet;

				// 엑셀창 안보이기
				app.Visible = false;

				// 리스트뷰의 컬럼제목을 엑셀파일에쓰기
				for (var i = 0; i < lvProList.Columns.Count; i++)
				{
					ws.Cells[1, i + 1] = lvProList.Columns[i].Text;
				}

				// 리스트뷰의 각 행을 엑셀 파일에 쓰기
				for (var i = 0; i < lvProList.Items.Count; i++)
				{
					for (var j = 0; j < lvProList.Items[i].SubItems.Count; j++)
					{
						ws.Cells[i + 2, j + 1] = lvProList.Items[i].SubItems[j].Text;
					}
				}

				// 엑셀 파일저장 인자 값은 다음과 같음 파일명, 파일형식, 암호, 수정제한파일저장암호, 읽기전용(false), 백업생성(false), 엑세스모드(기본값), 충돌제어(중간에 데이터 변경될경우 우선저장)
				wb.SaveAs(filePath, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges);

				// 종료
				wb.Close();
				app.Quit();

				MessageBox.Show("엑셀 파일이 저장되었습니다");
			});
		}
	}
}
