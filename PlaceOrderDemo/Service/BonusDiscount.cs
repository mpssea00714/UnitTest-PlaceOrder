using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceOrderDemo
{
    public class BonusDiscount : IDiscountPrice
    {
        public int ClacTotalAmountByDiscount(DiscountDTO discountDTO, int totalAmount)
        {
            //根據訂購總額 依序扣除Bonus 點數費用
            //1.1000元(含)以下,折抵最大點數50
            //2.5000元(含)以下,折抵最大點數300
            //3.5000元(含)以下,折抵最大點數1000

            int bonus = discountDTO.Bonus;
            if (totalAmount <= 1000)
            {
                totalAmount -= Math.Min(bonus, 50);
            }
            else if (totalAmount <= 5000)
            {
                totalAmount -= Math.Min(bonus, 300);
            }
            else
            {
                totalAmount -= Math.Min(bonus, 1000);
            }

            return totalAmount;
        }
    }
}
