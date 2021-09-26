using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceOrderDemo
{
    public class OrderDTO
    {
        public string Id { set; get; } //訂購單號
        public int TotalPrice { set; get; } //訂購交易總額
        public List<OrderItemDTO> Items { set; get; } //訂購商品項目
        public DiscountDTO Discoount { set; get; } //折扣項目
    }

    public class OrderItemDTO
    {
        public string Name { set; get; } //商品名稱
        public int Quanity { set; get; } //購買數量
        public int UnitPrice { set; get; } //商品單價
    }

    public class DiscountDTO
    {
        public DiscountEnum DiscountType { get; set; } //折扣類型
        public int Bonus { get; set; } //紅利點數
        public float Coupon { get; set; } //電子優惠
    }

    public enum DiscountEnum
    {
        None, Bonus, Coupon
    }
}
