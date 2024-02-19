using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Server;


namespace QueenLocalDataHandling
{
    internal class Program
    {
        static void Main()
        {
           Order order = new Order();
            CRUDOperation operation = new CRUDOperation();
            int opt;
            do
            {
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("                           OPERATIONS ");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("\n");
                Console.WriteLine("Enter The Option for the following operation");
                Console.WriteLine("1.Insertion in order");
                Console.WriteLine("2.Updation in order ");
                Console.WriteLine("3.View Order");
                Console.WriteLine("4.Delete from the order");
                Console.WriteLine("5. Prevention from hackers in updation");
                Console.WriteLine("6.Exit from the operations");
                Console.WriteLine("\n");
                Console.WriteLine("----------------------------------------------------------");
                opt = int.Parse(Console.ReadLine());
                while (opt < 1 || opt > 6)
                {
                    Console.WriteLine("Incorrect!Enter a valid Option");
                    opt = int.Parse(Console.ReadLine());
                }
                if (opt == 1)
                {
                    //insertion 
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("           Insertion In Order");
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("Enter the CNIC of Customer");
                    order.CustomerCNIC = Console.ReadLine();
                    Console.WriteLine("Enter the Customer Name");
                    order.CustomerName = Console.ReadLine();
                    Console.WriteLine("Enter Customer Phone No");
                    order.CustomerPhone = Console.ReadLine();
                    Console.WriteLine("Enter the Customer Address");
                    order.CustomerAddress = Console.ReadLine();
                    Console.WriteLine("Enter the product ID");
                    order.ProductID = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Product price");
                    order.ProductPrice = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the Product Size");
                    order.SizeOfProduct = Console.ReadLine();
                    while (order.SizeOfProduct != "Large" && order.SizeOfProduct != "Medium" 
                        && order.SizeOfProduct != "Small" && order.SizeOfProduct != "large" && order.SizeOfProduct != "medium"
                        && order.SizeOfProduct != "small")
                    {
                        Console.WriteLine("Incorrect! Enter again the value");
                        order.SizeOfProduct = Console.ReadLine();
                    }
                    /*Console.WriteLine(order);*/
                    operation.insert(order);
                    Console.WriteLine("\n");
                }
                else if (opt == 2)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("              Updation");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Enter the Phone no whose address you want to change");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter the address you want to update");
                    string add = Console.ReadLine();
                    operation.updateAddress(add, phone);
                    Console.WriteLine("\n");
                }
                else if (opt == 3)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("                Get All Data");
                    Console.WriteLine("---------------------------------------------------");
                    operation.getAllOrders();
                    Console.WriteLine("\n");
                }
                else if (opt == 4)
                {
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("               Deletion");
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Enter the Order Id you want to delete");
                    int id = int.Parse(Console.ReadLine());
                    operation.deleteOrder(id);
                    Console.WriteLine("\n");
                }
                else if(opt==5)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("              Updation");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Enter the Phone no whose address you want to change");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter the address you want to update");
                    string add = Console.ReadLine();
                    operation.PreventedUpdateAddress(add, phone);
                    Console.WriteLine("\n");
                }
                else if(opt==6)
                {
                    opt = 0;
                }
            } while (opt > 0 && opt < 7);
        }
    }
}
