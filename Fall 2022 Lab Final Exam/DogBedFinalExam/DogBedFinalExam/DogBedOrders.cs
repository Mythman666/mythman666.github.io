//Xinhua Zhou
//xzhou1
//Due time:12/01/2022
//Final lab exam
//national dog bed order application

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogBedFinalExam
{
    public class DogBedOrders
    {
        private string _orderName;
        private string _orderEmail;
        private string _orderPhone;
        private string _orderDogBedProduct;
        private int _quantityBought;
        private decimal _orderPrice;
        private decimal _subtotal;
        private decimal _salesTax;
        private decimal _orderTotal;

        public DogBedOrders() { }

        public DogBedOrders(string orderName, string orderEmail, string orderPhone, string orderDogBedProduct, int quantityBought, decimal orderPrice, decimal subtotal, decimal salesTax, decimal orderTotal)
        {
            _orderName = orderName;
            _orderEmail = orderEmail;
            _orderPhone = orderPhone;
            _orderDogBedProduct = orderDogBedProduct;
            _quantityBought = quantityBought;
            _orderPrice = orderPrice;
            _subtotal = subtotal;
            _salesTax = salesTax;
            _orderTotal = orderTotal;
        }

        public string OrderName { get; set; }
        public string OrderEmail { get; set; }
        public string OrderPhone { get; set; }
        public string OrderDogBedProduct { get; set; }
        public int QuantityBought { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal SalesTax { get; set; }
        public decimal OrderTotal { get; set; }


        public virtual string GetDisplayText()
        {
            string dogBedOrder = OrderName + "|" + OrderEmail + "|" + OrderPhone + "|" + OrderDogBedProduct + "|" + QuantityBought + "|" + OrderPrice + "|" + Subtotal + "|" + SalesTax + "|" + OrderTotal;
            return dogBedOrder;
        }
    }
}
