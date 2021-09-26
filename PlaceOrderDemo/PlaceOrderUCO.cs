using System;

namespace PlaceOrderDemo
{
    //UCO = Use Case Conroller 功能性控制物件
    public class PlaceOrderUCO
    {
        //處理訂單資訊,計算訂購總金額
        public OrderDTO ProcOrder(OrderDTO orderInfo)
        {
            int totalAmount = 0;
            totalAmount = CalcBaseOrderAmount(orderInfo, totalAmount);
            totalAmount = CalcOrderAmountByDiscount(orderInfo, totalAmount);

            //折扣後的訂購總金額
            orderInfo.TotalPrice = totalAmount;

            return orderInfo;
        }

        private static int CalcOrderAmountByDiscount(OrderDTO orderInfo, int totalAmount)
        {
            //依據折扣類型,計算折扣費用
            switch (orderInfo.Discoount.DiscountType)
            {
                case DiscountEnum.None: //None
                    break;

                case DiscountEnum.Bonus: //Bonus
                    totalAmount = ((IDiscountPrice)new BonusDiscount()).ClacTotalAmountByDiscount(orderInfo.Discoount, totalAmount);
                    break;

                case DiscountEnum.Coupon: //Coupon
                    totalAmount = ((IDiscountPrice)new CouponDiscount()).ClacTotalAmountByDiscount(orderInfo.Discoount, totalAmount);
                    break;

            }

            return totalAmount;
        }

        private static int CalcBaseOrderAmount(OrderDTO orderInfo, int totalAmount)
        {
            //for 每一筆訂購商品項目,計算分項金額
            foreach (OrderItemDTO itemInfo in orderInfo.Items)
            {
                int subTotal;

                subTotal = itemInfo.Quanity * itemInfo.UnitPrice;
                totalAmount += subTotal;
            }

            return totalAmount;
        }
    }
}
