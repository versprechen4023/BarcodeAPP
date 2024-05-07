using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using ZXing;

namespace Reader
{
	public partial class Reader
	{
		/// <summary>
		/// 바코드 인식 범위 표시
		/// </summary>
		/// <param name="result"></param>
		/// <param name="mat"></param>
		/// <returns></returns>
		private Bitmap BoundROILine(Result result, Mat mat)
		{
			// 이미지에 선그리기
			Cv2.Line(mat, new OpenCvSharp.Point((int)result.ResultPoints[0].X, (int)result.ResultPoints[0].Y), new OpenCvSharp.Point((int)result.ResultPoints[1].X, (int)result.ResultPoints[1].Y), Scalar.Red, 2, LineTypes.Link4);

			return mat.ToBitmap();

		}
	}
}
