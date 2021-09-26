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
            int expected = 550; //���浲�G��(600-50)
            int actual;         //��ڵ��G��

            OrderDTO orderDTO = PrepareBaseOrderData();
            SetDiscountOfBonus(orderDTO, 100);
            orderDTO = uco.ProcOrder(orderDTO);

            actual = orderDTO.TotalPrice;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void TestPlaceOrderWithDiscountOfBonus_2()
        {
            int expected = 1120; //���浲�G��(1400-280)
            int actual;          //��ڵ��G��

            OrderDTO orderDTO = PrepareBaseOrderData();

            //set additional items
            OrderItemDTO item3 = new OrderItemDTO
            {
                Name = "�Ȼ��x�M����",
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
            int expected = 540; //���浲�G��
            int actual;         //��ڵ��G��

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
                Name = "�@�̦�ʹq��",
                Quanity = 2,
                UnitPrice = 100
            };

            OrderItemDTO item2 = new OrderItemDTO
            {
                Name = "�L������",
                Quanity = 1,
                UnitPrice = 400
            };

            List<OrderItemDTO> items = new List<OrderItemDTO>();
            items.Add(item1);
            items.Add(item2);
            orderDTO.Items = items;  //�ʶR�ӫ~

            //�w�]�馩����: No Discount
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
