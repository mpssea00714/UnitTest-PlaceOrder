using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlaceOrderDemo;
using System.Collections.Generic;

namespace PlaceOrderTest
{
    [TestClass]
    public class PlaceOrderUCOTest
    {
        private PlaceOrderUCO uco;


        [TestInitialize]
        public void Setup()
        {
            uco = new PlaceOrderUCO();
        }

        [TestMethod]
        public void TestPlaceOrderNoAnyDiscount()
        {
            int expected = 600;
            int actual;

            OrderDTO orderDTO = PrepareBaseOrderData();
            orderDTO = uco.ProcOrder(orderDTO);

            actual = orderDTO.TotalPrice;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlaceOrderWithDiscountOfBonus_1()
        {
            int expected = 550; //期望結果值(600-50)
            int actual;         //實際結果值

            OrderDTO orderDTO = PrepareBaseOrderData();
            SetDiscountOfBonus(orderDTO, 100);
            orderDTO = uco.ProcOrder(orderDTO);

            actual = orderDTO.TotalPrice;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlaceOrderWithDiscountOfBonus_2()
        {
            int expected = 1120; //期望結果值(1400-280)
            int actual;          //實際結果值

            OrderDTO orderDTO = PrepareBaseOrderData();

            //set additional items
            OrderItemDTO item3 = new OrderItemDTO
            {
                Name = "玄鳳鸚鵡玩偶",
                Quanity = 1,
                UnitPrice = 800
            };
            orderDTO.Items.Add(item3);

            //set Discount of Bonus
            SetDiscountOfBonus(orderDTO, 280);
            orderDTO = uco.ProcOrder(orderDTO);
            actual = orderDTO.TotalPrice;

            Assert.AreEqual(actual, expected);
        }

        public void TestPlaceOrderWithDiscountOfCoupon()
        {
            int expected = 540; //期望結果值
            int actual;         //實際結果值

            OrderDTO orderDTO = PrepareBaseOrderData();
            SetDiscountOfCoupon(orderDTO, 0.9F);
            orderDTO = uco.ProcOrder(orderDTO);
            actual = orderDTO.TotalPrice;

            Assert.AreEqual(actual, expected);
        }

        public OrderDTO PrepareBaseOrderData()
        {
            OrderDTO orderDTO = new OrderDTO();
            OrderItemDTO item1 = new OrderItemDTO
            {
                Name = "毫米行動電源",
                Quanity = 2,
                UnitPrice = 100
            };

            OrderItemDTO item2 = new OrderItemDTO
            {
                Name = "微笑鋼筆",
                Quanity = 1,
                UnitPrice = 400
            };

            List<OrderItemDTO> items = new List<OrderItemDTO>();
            items.Add(item1);
            items.Add(item2);
            orderDTO.Items = items;  //購買商品

            //預設折扣類型: No Discount
            DiscountDTO discountDTO = new DiscountDTO
            {
                DiscountType = 0 // No Discount
            };

            orderDTO.Discoount = discountDTO;

            return orderDTO;
        }

        private void SetDiscountOfBonus(OrderDTO orderDTO, int bonus)
        {
            //PrepareBaseOrderData();

            DiscountDTO discount = new DiscountDTO
            {
                DiscountType = 1,
                Bonus = bonus
            };

            orderDTO.Discoount = discount;
        }

        private void SetDiscountOfCoupon(OrderDTO orderDTO, float coupon)
        {
            //PrepareBaseOrderData();

            DiscountDTO discount = new DiscountDTO
            {
                DiscountType = 2,
                Coupon = coupon
            };

            orderDTO.Discoount = discount;
        }
    }
}
