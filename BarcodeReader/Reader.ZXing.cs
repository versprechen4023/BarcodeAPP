using System.Linq;
using ZXing;

namespace Reader
{
	public partial class Reader
	{
		/// <summary>
		/// ZXING 바코드 리더 설정 함수
		/// </summary>
		/// <returns></returns>
		private ZXing.BarcodeReader ZxingReaderOption()
		{
			ZXing.BarcodeReader reader = new ZXing.BarcodeReader
			{
				Options = new ZXing.Common.DecodingOptions
				{
					// 조금더 높은 정확도로 디코드 시도
					TryHarder = true,
					// 읽어 내지 못하는경우 흑색반전해서 인식 디코드 정확성은 높아지나 속도 저하
					TryInverted = true,
					// CODE 128 형태의 바코드만 인식하게 하여 속도와 정확성 증가
					PossibleFormats = new[] { BarcodeFormat.CODE_128 }.ToList()
				}
			};

			return reader;
		}
	}
}
