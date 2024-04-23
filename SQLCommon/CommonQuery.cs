using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SQLCommon
{
    public class CommonQuery
    {
		private readonly BarcodeDBEntities db = new BarcodeDBEntities();

        /// <summary>
        /// 데이터베이스 연결 유무 확인 함수
        /// </summary>
        /// <returns></returns>
        public bool DbConnectionCheck()
        {
			try
			{
                db.Database.Connection.Open();
                db.Database.Connection.Close();
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}
        /// <summary>
        /// 전체 상품 정보를 가져온다
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts() 
        { 
            return db.Products.ToList();
        }

        /// <summary>
        /// 상품 정보를 입력한다
        /// </summary>
        /// <param name="proNo"></param>
        /// <param name="proName"></param>
        /// <param name="proPrice"></param>
        /// <returns></returns>
        public bool PutProduct(string proNo, string proName, int proPrice)
        {
            db.Products.Add(new Product {ProNo = proNo, ProName = proName, ProPrice = proPrice });

            return db.SaveChanges() > 0;
        }

        /// <summary>
        /// 상품 정보를 삭제한다
        /// </summary>
        /// <param name="proNo"></param>
        /// <returns></returns>
        public bool DeleteProduct(string proNo)
        {
            var result = db.Products.FirstOrDefault(p => p.ProNo == proNo);

            db.Products.Remove(result);

            return db.SaveChanges() > 0;

		}

        /// <summary>
        /// 상품 정보를 수정한다
        /// </summary>
        /// <param name="proNo"></param>
        /// <param name="proName"></param>
        /// <param name="proPrice"></param>
        /// <returns></returns>
        public bool UpdateProduct(string proNo, string proName, int proPrice)
        {
			var result = db.Products.FirstOrDefault(p => p.ProNo == proNo);

            result.ProName = proName;
            result.ProPrice = proPrice;

			return db.SaveChanges() > 0;

		}

		/// <summary>
		/// 단일 상품 정보를 가져온다
		/// </summary>
		/// <returns></returns>
		public Product GetProductNo(string proNo)
		{
			return db.Products.FirstOrDefault(p => p.ProNo == proNo);
		}

        /// <summary>
        /// 상품 번호를 계산하기 위한 쿼리문 @오버로드
        /// </summary>
        /// <returns></returns>
		public Product GetProductNo()
		{
			return db.Products.OrderByDescending(p => p.ProNo).FirstOrDefault();
		}
	}
}
