using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceOrderDemo
{
    public class CouponDiscount : IDiscountPrice
    {
        public int ClacTotalAmountByDiscount(DiscountDTO discountDTO, int totalAmount)
        {
            //訂購總額*Coupon 折扣%數(以最接近整數計)
            return totalAmount = Convert.ToInt32(totalAmount * discountDTO.Coupon);
        }
    }
}
