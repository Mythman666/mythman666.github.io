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
    public class Customers
    {
        private string _name;
        private string _email;
        private string _phone;

        public Customers()
        {

        }

        public Customers(string name, string email, string phone)
        {
            _name = name;
            _email = email;
            _phone = phone;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual string GetDisplayText()
        {
            string customerString = $"{Name}{"|"}{Email}{"|"}{Phone}";
            return customerString;
        }
    }
}
