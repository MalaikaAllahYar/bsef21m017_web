using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QueenLocalDataHandling
{
    internal class CRUDOperation
    {
        public CRUDOperation() 
        { 
        }
        public void getAllOrders()
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueenDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            string querry = $"select * from Orders";
            SqlCommand cmd = new SqlCommand(querry, connection);
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Console.WriteLine("Order ID     Customer CNIC       Customer Name   Phone No    Address     Product ID     Price   Size");
            while (dr.Read())
            {
                Console.WriteLine($" {dr.GetValue(0)}         {dr.GetValue(1)}       {dr.GetValue(2)}      {dr.GetValue(3)}       {dr.GetValue(4)}         {dr.GetValue(5)}    {dr.GetValue(6)}    {dr.GetValue(7)}");
            }
            connection.Close();
        }

        public void PreventedUpdateAddress(string add,string phone)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueenDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            string querry = $"update Orders set CustomerAddress= @a where CustomerPhone=@p";
            SqlParameter p1 = new SqlParameter("a", add);
            SqlParameter p2=new SqlParameter("p", phone);
            SqlCommand cmd = new SqlCommand(querry, connection);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            connection.Open();
            int inserted = cmd.ExecuteNonQuery();
            if (inserted > 0)
            {
                Console.WriteLine("Data is updated successfully");
            }
            else
            {
                Console.WriteLine("Updation Failed");
            }
            connection.Close();
        }
        public void updateAddress(string add,string phone)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueenDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            string querry = $"update Orders set CustomerAddress= '{add}' where CustomerPhone='{phone}'"; 
            SqlCommand cmd = new SqlCommand(querry, connection);
            connection.Open();
            int inserted = cmd.ExecuteNonQuery();
            if (inserted > 0)
            {
                Console.WriteLine("Data is updated successfully");
            }
            else
            {
                Console.WriteLine("Updation Failed");
            }
            connection.Close();
        }

        public void deleteOrder(int id)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueenDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            string querry = $"delete from  Orders where OrderID='{id}'";
            SqlCommand cmd = new SqlCommand(querry, connection);
            connection.Open();
            int inserted = cmd.ExecuteNonQuery();
            if (inserted > 0)
            {
                Console.WriteLine("Data is updated successfully");
            }
            else
            {
                Console.WriteLine("Deletion Failed");
            }
            connection.Close();
        }
        public void insert(Order order)
        {
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QueenDB;Integrated Security=True";
            SqlConnection connection = new SqlConnection(constr);
            string querry = $"insert into Orders( CustomerCNIC, CustomerName, CustomerPhone, CustomerAddress, ProductID, price, SizeOfProduct) " +
                $"values ('{order.CustomerCNIC}', '{order.CustomerName}', '{order.CustomerPhone}', '{order.CustomerAddress}', {order.ProductID}, {order.ProductPrice},  '{order.SizeOfProduct}')";
            SqlCommand cmd = new SqlCommand(querry, connection);
            connection.Open();
            int inserted=cmd.ExecuteNonQuery();
            if(inserted > 0) 
            {
                Console.WriteLine("Data is inserted successfully");
            }
            else
            {
                Console.WriteLine("Insertion Failed");
            }
            connection.Close();
        }
    }
}
