using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace assisment
{
    class Program
    {
        class Customer
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Product_id { get; set; }
            public int Quantity { get; set; }
            public int Supplier_id { get; set; }
            public double price { get; set; }
        }

        static string connectionString = "data source = IN5CG9292KMT; database= ADOassisment; integrated security = true";
        static void Main(string[] args)
        {
            bool status = true;
            int choice;
            while (status)
            {
                Console.WriteLine("Enter your Choice \n [1] Insert New Customer\n [2] Update Existing Customer\n [3] Delete Customer \n [4] View Customers \n [0] Exit ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1: InsertcustomerDetails();
                        break;
                    case 2: UpdateCustomerDetails();
                        break;
                    case 3: DeleteDetails();
                        break;
                    case 4: display();
                        break;
                    case 0: status = false;
                        break;
                    default: Console.WriteLine("Enter valid option");
                        break;
                
                }
            }


        }
        public static void InsertcustomerDetails()
        {
            Console.WriteLine("Enter name of the customer");
            Customer customer = new Customer();
            customer.Name = Console.ReadLine();
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            //cmd.Parameters.AddWithValue("@name", customer.Name);
            
            cmd.CommandText = "select * from product";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("product_ID\tname");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t\t{rdr[1]}");
            }
            con.Close();
            Console.WriteLine("Enter the product Id customer wants to purchase");
            customer.Product_id = int.Parse(Console.ReadLine());
            cmd.Parameters.AddWithValue("Product_id", customer.Product_id);

            cmd.CommandText = "select * from suppliers where product_id = @Product_id";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr2 = cmd.ExecuteReader();
            Console.WriteLine("Id\tName\tLocation\tPrice");
            while (rdr2.Read())
            {
                Console.WriteLine($"{rdr2[0]}\t{rdr2[1]}\t{rdr2[3]}\t{rdr2[4]}");
            }
            con.Close();
            Console.WriteLine("Enter the Sellers Id customer wants to purchase from");
            customer.Supplier_id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Quantity of product");
            customer.Quantity = int.Parse(Console.ReadLine());
            cmd.Parameters.AddWithValue("@Supplier_id", customer.Supplier_id);

            cmd.CommandText = "select price from suppliers where id = @Supplier_id ";
            cmd.Connection = con;
            con.Open();
            // price;
           int price = int.Parse(Convert.ToString(cmd.ExecuteScalar()));

            customer.price = (customer.Quantity) * ((int)price);
            con.Close();
            cmd.Parameters.AddWithValue("@name", customer.Name);
            cmd.Parameters.AddWithValue("@product_id2", customer.Product_id);
            cmd.Parameters.AddWithValue("@quantity2", customer.Quantity);
            cmd.Parameters.AddWithValue("@suppliers_id2", customer.Supplier_id);
            cmd.Parameters.AddWithValue("@totalprice", customer.price);


            cmd.CommandText = "insert into customer values(@name,@product_id2,@quantity2,@suppliers_id2,@totalprice)";
            cmd.Connection = con;
            con.Open();
            int rowcount = cmd.ExecuteNonQuery();
            if (rowcount > 0)
            {
                Console.WriteLine("Record inserted sucessfully");
            }
            con.Close();
        }
        public static void display()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from customer";
            cmd.Connection = con;
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("ID\tNAME\t\tPRODUCT_ID\t\tQUANTITY\t\tSUPPLIER\t\tTOTAL BILL");
            while (rdr.Read())
            {
                Console.WriteLine($"{rdr[0]}\t{rdr[1]}\t\t{rdr[2]}\t\t{rdr[3]}\t\t{rdr[4]}\t\t{rdr[5]}");
            }
            con.Close();
        }
        public static void UpdateCustomerDetails()
        {
            Console.WriteLine("Enter the ID");
            Customer customer = new Customer();
            customer.Id = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("id", customer.Id);
            cmd.CommandText = "select Id from customer where Id=@id";
            cmd.Connection = con;
            con.Open();
            object rowcount = cmd.ExecuteScalar();
            int updateid = (int)rowcount;
            con.Close();
            if (updateid > 0)
            {
                Console.WriteLine("Enter name of the customer");
               
                customer.Name = Console.ReadLine();

               
               

                cmd.CommandText = "select * from product";
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine("product_ID\tname");

                while (rdr.Read())
                {
                    Console.WriteLine($"{rdr[0]}\t{rdr[1]}");
                }
                con.Close();
                Console.WriteLine("Enter the product Id customer wants to purchase");
                customer.Product_id = int.Parse(Console.ReadLine());
                cmd.Parameters.AddWithValue("Product_id", customer.Product_id);

                cmd.CommandText = "select * from suppliers where product_id = @Product_id";
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr2 = cmd.ExecuteReader();
                Console.WriteLine("Id\tName\tLocation\tPrice");

                while (rdr2.Read())
                {
                    Console.WriteLine($"{rdr2[0]}\t{rdr2[1]}\t{rdr2[3]}\t{rdr2[4]}");
                }
                con.Close();
                Console.WriteLine("Enter the Sellers Id customer wants to purchase from");
                customer.Supplier_id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Quantity of product");
                customer.Quantity = int.Parse(Console.ReadLine());
                cmd.Parameters.AddWithValue("@Supplier_id", customer.Supplier_id);

                cmd.CommandText = "select price from suppliers where id = @Supplier_id ";
                cmd.Connection = con;
                con.Open();
                int price = int.Parse(Convert.ToString(cmd.ExecuteScalar()));

                customer.price = (customer.Quantity) * ((int)price);
                con.Close();
                cmd.Parameters.AddWithValue("@name", customer.Name);
                cmd.Parameters.AddWithValue("@product_id2", customer.Product_id);
                cmd.Parameters.AddWithValue("@quantity2", customer.Quantity);
                cmd.Parameters.AddWithValue("@suppliers_id2", customer.Supplier_id);
                cmd.Parameters.AddWithValue("@totalprice", customer.price);
//                Product_id int,
//Quantity int,
//Supplier_Id int,
//totalBill bigint
                cmd.CommandText = "update customer set Name = @name,Product_id=@product_id2,Quantity = @quantity2, Supplier_Id=@suppliers_id2, totalBill=@totalprice where Id = @id";
                cmd.Connection = con;
                con.Open();
                int rowcount1 = cmd.ExecuteNonQuery();
                if (rowcount1 > 0)
                {
                    Console.WriteLine("Record inserted sucessfully");
                }
                con.Close();
                
            }
        }
        public static void DeleteDetails()
        {
            Console.WriteLine("Enter the id you want to delete");
            Customer customer = new Customer();
            customer.Id = int.Parse(Console.ReadLine());
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("id", customer.Id);
            cmd.CommandText = "select id from customer where Id=@id";
            cmd.Connection = con;
            con.Open();
            object rowcount = cmd.ExecuteScalar();
            int updateid = (int)rowcount;


            if (updateid > 0)
            {
                cmd.CommandText = "delete from customer where Id=@id";
                int updatedrowcount = cmd.ExecuteNonQuery();
                if (updatedrowcount > 0)
                {
                    Console.WriteLine("Row deleted successfully!");
                }
                con.Close();
            }

        }


    }
}
