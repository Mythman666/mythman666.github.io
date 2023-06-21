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
using System.IO;

namespace DogBedFinalExam
{
    public static class DogBedDB
    {
        private const string _customersFileName = @"F:\C#\Final lab\final lab\Fall 2022 Lab Final Exam\Customers.txt";
        private const string _dogBeds = @"F:\C#\Final lab\final lab\Fall 2022 Lab Final Exam\DogBeds.txt";
        private const string _dogBedOrders = @"F:\C#\Final lab\final lab\Fall 2022 Lab Final Exam\DogBedOrders.txt";

        public static List<Customers> GetCustomers()
        {
            StreamReader textIn = new StreamReader(new FileStream(_customersFileName, FileMode.OpenOrCreate, FileAccess.Read));

            List<Customers> customersList = new List<Customers>();

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                Customers customers = new Customers();
                customers.Name = columns[0];
                customers.Email = columns[1];
                customers.Phone = columns[2];
                customersList.Add(customers);
            }
            textIn.Close();
            return customersList;
        }

        public static List<DogBedProduct> GetDogBedProducts()
        {
            StreamReader textIn = new StreamReader(new FileStream(_dogBeds, FileMode.OpenOrCreate, FileAccess.Read));

            List<DogBedProduct> dogBedProductList = new List<DogBedProduct>();

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                string[] price_columns = columns[1].Split('$');
                DogBedProduct dogBedProduct = new DogBedProduct();
                dogBedProduct.DogBedName = columns[0];
                dogBedProduct.Price = Convert.ToDecimal(price_columns[1]);
                dogBedProduct.QuantityOnHand = Convert.ToInt16(columns[2]);
                dogBedProductList.Add(dogBedProduct);
            }
            textIn.Close();
            return dogBedProductList;
        }

        public static List<DogBedOrders> GetDogBedOrders()
        {
            StreamReader textIn = new StreamReader(new FileStream(_dogBedOrders, FileMode.OpenOrCreate, FileAccess.Read));

            List<DogBedOrders> dogBedOrders = new List<DogBedOrders>();

            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split('|');
                DogBedOrders dogBedOrder = new DogBedOrders();
                dogBedOrder.OrderName = columns[0];
                dogBedOrder.OrderEmail = columns[1];
                dogBedOrder.OrderPhone = columns[2];
                dogBedOrder.OrderDogBedProduct = columns[3];
                dogBedOrder.QuantityBought = Convert.ToInt16(columns[4]);
                dogBedOrder.OrderPrice = Convert.ToDecimal(columns[5]);
                dogBedOrder.Subtotal = Convert.ToDecimal(columns[6]);
                dogBedOrder.SalesTax = Convert.ToDecimal(columns[7]);
                dogBedOrder.OrderTotal = Convert.ToDecimal(columns[8]);
                dogBedOrders.Add(dogBedOrder);
            }
            textIn.Close();
            return dogBedOrders;
        }

        public static void SaveDogBedOrders(List<DogBedOrders> dogBedOrders)
        {
            StreamWriter textOut = new StreamWriter(new FileStream(_dogBedOrders, FileMode.Create, FileAccess.Write));
            foreach (DogBedOrders dogBedOrder in dogBedOrders)
            {
                textOut.WriteLine(dogBedOrder.GetDisplayText());
            }
            textOut.Close();
        }


    }
}
