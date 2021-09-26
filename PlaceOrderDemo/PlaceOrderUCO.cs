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
            foreach (OrderItemDTO itemInfo in orderInfo.Items)
            {
                int subTotal;

                subTotal = itemInfo.Quanity * itemInfo.UnitPrice;
                totalAmount += subTotal;
            }

            switch (orderInfo.Discoount.DiscountType)
            {
                case 0: //None
                    break;

                case 1: //Bonus
                        //根據訂購總額 依序扣除Bonus 點數費用
                        //1.1000元(含)以下,折抵最大點數50
                        //2.5000元(含)以下,折抵最大點數300
                        //3.5000元(含)以下,折抵最大點數1000

                    int bonus = orderInfo.Discoount.Bonus;
                    if(totalAmount <= 1000) 
                    {
                        totalAmount -= Math.Min(bonus, 50);
                    }
                    else if(totalAmount <= 5000)
                    {
                        totalAmount -= Math.Min(bonus, 300);
                    }
                    else 
                    {
                        totalAmount -= Math.Min(bonus, 1000);
                    }
                    //TODO:未處理未扣除與消費點數還回給原消費者
                    break;

                case 2: //Coupon
                        //訂購總額*Coupon 折扣%數(以最接近整數計)
                    totalAmount = Convert.ToInt32(totalAmount * orderInfo.Discoount.Coupon);
                    break;

            }

            //折扣後的訂購總金額
            orderInfo.TotalPrice = totalAmount;

            return orderInfo;
        } 
    }
}
