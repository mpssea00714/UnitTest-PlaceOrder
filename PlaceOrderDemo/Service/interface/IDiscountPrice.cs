using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceOrderDemo
{
    public interface IDiscountPrice
    {
        int ClacTotalAmountByDiscount(DiscountDTO discountDTO, int totalAmount);
    }
}
