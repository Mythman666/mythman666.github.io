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
    public class DogBedProduct
    {
        private string _dogBedName;
        private decimal _price;
        private int _quantityOnHand;

        public DogBedProduct()
        {

        }

        public DogBedProduct(string dogBedName, decimal price, int quantityOnHand)
        {
            _dogBedName = dogBedName;
            _price = price;
            _quantityOnHand = quantityOnHand;
        }

        public string DogBedName { get; set; }
        public decimal Price { get; set; }
        public int QuantityOnHand { get; set; }

        public virtual string GetDisplayText()
        {
            string dogBedString = $"{DogBedName}{"|"}{Price}{"|"}{QuantityOnHand}";
            return dogBedString;
        }
    }
}
