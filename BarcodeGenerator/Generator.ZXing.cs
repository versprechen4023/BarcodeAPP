using ZXing;
using System.Drawing;

namespace Generator
{
	public partial class Generator
	{
		/// <summary>
		/// 바코드 생성 함수 파일 처리 비트맵 반환
		/// </summary>
		/// <param name="proNo"></param>
		private Bitmap GenerateBarcodeImage(string proNo)
		{
			// CODE128 타입으로 바코드 생성
			BarcodeWriter writer = new BarcodeWriter() { Format = BarcodeFormat.CODE_128 };
			// 이미지 반환
			return writer.Write(proNo);
		}
	}
}
