using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QueenLocalDataHandling
{
    internal class Order
    {
        public string CustomerCNIC { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public int ProductID { get; set; }
        public int ProductPrice { get; set; }
        public string SizeOfProduct { get; set; }
        
        //public Default Constructor
        public Order() 
        {
        }
        //public parameterized Constructor

        public Order(string cnic, string n, string p, string a, int pid, int price, string s)
        {
            CustomerCNIC = cnic;
            CustomerName = n;
            CustomerPhone = p;
            CustomerAddress = a;
            ProductID = pid;
            ProductPrice = price;
            if (SizeOfProduct != "Small" && SizeOfProduct != "Medium" && SizeOfProduct != "Large")
            {
                Console.WriteLine("Sorry Your size is not correct");
                SizeOfProduct = "0";
            }
            else
            {
                SizeOfProduct = s;
            }
        }

        //Function override
        public override string ToString()
        {
            return $"Customer CNIC:{CustomerCNIC}\nCustomer Name:{CustomerName}\nCustomer Phone:{CustomerPhone}\nCustomer Address:{CustomerAddress}" +
                $"\nProduct ID:{ProductID}\nProduct price: {ProductPrice}\nSize Of Product:{SizeOfProduct}";
        }
    }
}
