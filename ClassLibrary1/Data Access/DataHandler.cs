using SmartHomeSystem.DAL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace SmartHomeSystem.DAL.Data_Access
{
    public class DataHandler
    {
         //private static string connString = ConfigurationManager.ConnectionStrings["SmartHomeSystemConnection"].ToString();
        private static string connString= "Data Source=.;Initial Catalog=SmartHomeSystemDb;Integrated Security=True";
        SqlConnection conn = new SqlConnection(connString);
        private bool IsSuccess = false;

        #region lists
        public List<Employee> Employees = new List<Employee>();
        public List<Client> Clients = new List<Client>();
        public List<Department> Departments = new List<Department>();
        public List<Supplier> Suppliers = new List<Supplier>();
        public List<Invoices> Invoices = new List<Invoices>();
        public List<Orders> Orders = new List<Orders>();
        public List<Product> Products = new List<Product>();
        public List<Category> Categories = new List<Category>();
        public List<TechnicalSupport> supports = new List<TechnicalSupport>();
        public List<Component> Components = new List<Component>();
        public List<Calls> Calls = new List<Calls>();
        public List<Schedule> Schedules = new List<Schedule>();
        #endregion

        #region Employee
        public List<Employee> GetEmployees()
        {
            try
            {
                //open connection
                conn.Open();

                //check if connection is opened
                if (conn.State == ConnectionState.Open)
                {
                   // MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = "select * from Employee e inner join Department d on e.DeptId = d.id ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Employees.Add(new Employee(int.Parse(item[0].ToString()),item[1].ToString(),item[2].ToString(),int.Parse(item[3].ToString()),item[4].ToString(),DateTime.Parse(item[5].ToString()),item[6].ToString(), item[7].ToString(), item[8].ToString(), item[9].ToString(),int.Parse(item[10].ToString()), item[11].ToString(),
                            new Department(int.Parse(item[15].ToString()),item[16].ToString(),item[17].ToString()),item[13].ToString(),item[14].ToString()));
                    }
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Employees;
        }
        public List<Employee> GetEmployee(int id)
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                   // MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = $"select *from Employee e inner join Department d on e.DeptId = d.id where e.Id={id} ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Employees.Add(new Employee(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString(), int.Parse(item[3].ToString()), item[4].ToString(), DateTime.Parse(item[5].ToString()), item[6].ToString(), item[7].ToString(), item[8].ToString(), item[9].ToString(), int.Parse(item[10].ToString()), item[11].ToString(),
                            new Department(int.Parse(item[15].ToString()), item[16].ToString(), item[17].ToString()), item[13].ToString(), item[14].ToString()));
                    }
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Employees;
        }

        public bool CreateNewEmployee(string name,string surname,int age, string idno, DateTime dob,string cellno,string address1,string address2,string city, int postalcode,string country,int deptid,string username,string password)
        {
            try
            {
                string query = @"insert into Employee
                             (FirstName,LastName,Age,IDNumber,DateOfBirth,CellNumber,AddressLine1,AddressLine2,City,
                                PostalCode,Country,DeptId,UserName,Password)
                                 values
                                (@name,@surname,@age,@idno,@dob,@cellno,@address1,@address2,@city,
                                @code,@country,@deptid,@username,@password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@age", age));
                    cmd.Parameters.Add(new SqlParameter("@idno", idno));
                    cmd.Parameters.Add(new SqlParameter("@dob", dob));
                    cmd.Parameters.Add(new SqlParameter("@cellno", cellno));
                    cmd.Parameters.Add(new SqlParameter("@address1", address1));
                    cmd.Parameters.Add(new SqlParameter("@address2", address2));
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.Parameters.Add(new SqlParameter("@code", postalcode));
                    cmd.Parameters.Add(new SqlParameter("@country", country));
                    cmd.Parameters.Add(new SqlParameter("@deptid", deptid));
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Employee has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool UpdateEmployee(string name, string surname, int age, string cellno, string address1, string address2, string city, int postalcode, string country, int deptid, string username, string password,int id)
        {
            try
            {
                string query = @"update Employee
                        set FirstName=@name,LastName=@surname,Age=@age,CellNumber=@cellno,AddressLine1=@address1,
                        AddressLine2=@address2,City=@city,PostalCode=@code,Country=@country,DeptId=@deptid,
                        UserName=@username,Password=@password
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@age", age));
                    cmd.Parameters.Add(new SqlParameter("@cellno", cellno));
                    cmd.Parameters.Add(new SqlParameter("@address1", address1));
                    cmd.Parameters.Add(new SqlParameter("@address2", address2));
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.Parameters.Add(new SqlParameter("@code", postalcode));
                    cmd.Parameters.Add(new SqlParameter("@country", country));
                    cmd.Parameters.Add(new SqlParameter("@deptid", deptid));
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Employee has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                string query = "delete Employee where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Employee has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Clients
        public List<Client> GetClients()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = "select * from Client";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Clients.Add(new Client(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString(), int.Parse(item[3].ToString()), item[4].ToString(), DateTime.Parse(item[5].ToString()), item[6].ToString(), item[7].ToString(), item[8].ToString(), item[9].ToString(), int.Parse(item[10].ToString()), item[11].ToString()));
                    }
                }
                else
                {
                    throw new CustomException("Database not connnected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Clients;
        }

        public bool CreateNewClient(string name, string surname, int age, string idno, DateTime dob, string cellno, string address1, string address2, string city, int postalcode, string country)
        {
            try
            {
                string query = @"insert into Client
                             (FirstName,LastName,Age,IDNumber,DateOfBirth,CellNumber,AddressLine1,AddressLine2,City,
                                PostalCode,Country)
                                 values
                                (@name,@surname,@age,@idno,@dob,@cellno,@address1,@address2,@city,
                                @code,@country)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@age", age));
                    cmd.Parameters.Add(new SqlParameter("@idno", idno));
                    cmd.Parameters.Add(new SqlParameter("@dob", dob));
                    cmd.Parameters.Add(new SqlParameter("@cellno", cellno));
                    cmd.Parameters.Add(new SqlParameter("@address1", address1));
                    cmd.Parameters.Add(new SqlParameter("@address2", address2));
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.Parameters.Add(new SqlParameter("@code", postalcode));
                    cmd.Parameters.Add(new SqlParameter("@country", country));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Client has been saved into database");
                    IsSuccess= true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool UpdateClient(string name, string surname, int age, string cellno, string address1, string address2, string city, int postalcode, string country, int id)
        {
            try
            {
                string query = @"update Client
                        set FirstName=@name,LastName=@surname,Age=@age,CellNumber=@cellno,AddressLine1=@address1,
                        AddressLine2=@address2,City=@city,PostalCode=@code,Country=@country
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@surname", surname));
                    cmd.Parameters.Add(new SqlParameter("@age", age));
                    cmd.Parameters.Add(new SqlParameter("@cellno", cellno));
                    cmd.Parameters.Add(new SqlParameter("@address1", address1));
                    cmd.Parameters.Add(new SqlParameter("@address2", address2));
                    cmd.Parameters.Add(new SqlParameter("@city", city));
                    cmd.Parameters.Add(new SqlParameter("@code", postalcode));
                    cmd.Parameters.Add(new SqlParameter("@country", country));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Client has been updated into database");
                    IsSuccess = true;

                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteClient(int id)
        {
            try
            {
                string query = "delete Client where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Client has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Department
        public List<Department> GetDepartments()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = "select * from Department";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Departments.Add(new Department(int.Parse(item[0].ToString()),item[1].ToString(),item[2].ToString()));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Departments;
        }

        public bool CreateNewDepartment(string name, string description)
        {
            try
            {
                string query = @"insert into Department
                                (Name,Description)
                                values
                                (@name,@desc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }

        public bool UpdateDepartment(int id, string name, string description)
        {
            try
            {
                string query = @"update Department
                        set Name =@name,Description=@desc
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteDepartment(int id)
        {
            try
            {
                string query = "delete Department where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region products
        public List<Product> Getproducts()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"select *from Product p inner join Category c on p.Category = c.Id inner join Supplier s on p.Supplier = s.id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Products.Add(new Product(int.Parse(item[0].ToString()),item[1].ToString(),decimal.Parse(item[2].ToString()),item[3].ToString(),DateTime.Parse(item[4].ToString()),new Category(int.Parse(item[7].ToString()),item[8].ToString(),item[9].ToString()),new Supplier(int.Parse(item[10].ToString()),item[11].ToString(),item[12].ToString(),item[13].ToString(),item[14].ToString(),item[15].ToString(),int.Parse(item[16].ToString()),item[17].ToString())));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Products;
        }
        public bool CreateNewProduct(string name, decimal price, string description,DateTime datecreated, int category, int supplier)
        {
            try
            {
                string query = @"insert into Product
                                (Name,Price,Description,DateCreated,Category,Supplier)
                                values
                                (@name,@price,@desc,@date,@category,@supplier)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    cmd.Parameters.Add(new SqlParameter("@date", datecreated));
                    cmd.Parameters.Add(new SqlParameter("@category", category));
                    cmd.Parameters.Add(new SqlParameter("@supplier", supplier));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }
        public bool UpdateProduct(int id, decimal price, int supplier)
        {
            try
            {
                string query = @"update Product
                        set Price =@price, Supplier=@supplier
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@supplier", supplier));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }
        public bool DeleteProduct(int id)
        {
            try
            {
                string query = "delete Product where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Orders
        public List<Orders> GetOrders()
        {
            try
            {
                //conn.Open();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"select * from Orders o inner join Product p on o.Product = p.Id inner join Category ct on ct.Id = p.Category inner join Supplier s on s.Id = p.Supplier inner join Client c on o.Client = c.Id inner join Employee e on o.Employee = e.Id inner join Department d on e.DeptId = d.Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Orders.Add(new Orders(int.Parse(item[0].ToString()),DateTime.Parse(item[1].ToString()),int.Parse(item[2].ToString()),decimal.Parse(item[3].ToString()),new Product(int.Parse(item[7].ToString()),item[8].ToString(),decimal.Parse(item[9].ToString()),item[10].ToString(),DateTime.Parse(item[11].ToString()),new Category(int.Parse(item[14].ToString()),item[15].ToString(),item[16].ToString()),new Supplier(int.Parse(item[17].ToString()),item[18].ToString(),item[19].ToString(),item[20].ToString(),item[21].ToString(),item[22].ToString(),int.Parse(item[23].ToString()),item[24].ToString())),new Client(int.Parse(item[25].ToString()),item[26].ToString(),item[27].ToString(),int.Parse(item[28].ToString()),item[29].ToString(),DateTime.Parse(item[30].ToString()),item[31].ToString(),item[32].ToString(),item[33].ToString(),item[34].ToString(),int.Parse(item[35].ToString()),item[36].ToString()),new Employee(int.Parse(item[37].ToString()), item[38].ToString(), item[39].ToString(), int.Parse(item[40].ToString()), item[41].ToString(), DateTime.Parse(item[42].ToString()), item[43].ToString(), item[44].ToString(), item[45].ToString(), item[46].ToString(), int.Parse(item[47].ToString()), item[48].ToString(),
                            new Department(int.Parse(item[52].ToString()), item[53].ToString(), item[54].ToString()), item[50].ToString(), item[51].ToString())));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Orders;
        }
        public bool CreateNewOrder(DateTime orderedDate, int quantity, decimal totalPrice, int prodId, int clientId, int employee)
        {
            try
            {
                string query = @"insert into Orders
                                (OrderedDate,Quantity,TotalPrice,Product,Client,Employee)
                                values
                                (@date,@quantity,@price,@prod,@client,@emp)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@date", orderedDate));
                    cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                    cmd.Parameters.Add(new SqlParameter("@price", totalPrice));
                    cmd.Parameters.Add(new SqlParameter("@prod", prodId));
                    cmd.Parameters.Add(new SqlParameter("@client", clientId));
                    cmd.Parameters.Add(new SqlParameter("@emp", employee));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }
        public bool UpdateOrders(int id,int quantity, decimal price, int supplier)
        {
            try
            {
                string query = @"update Orders
                        set Quantity=@quantity, TotalPrice=@price, Product = @prodId
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@quantity", quantity));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@supplier", supplier));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }
        public bool DeleteOrders(int id)
        {
            try
            {
                string query = "delete Orders where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region invoices 
        public List<Invoices> GetInvoices()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"select * from Invoices i inner join Orders o on i.Orders_Id = o.Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Invoices.Add(new Invoices(int.Parse(item[0].ToString()),DateTime.Parse(item[1].ToString()),new Orders(int.Parse(item[3].ToString()),DateTime.Parse(item[4].ToString()),int.Parse(item[5].ToString()),decimal.Parse(item[6].ToString()), new Product(int.Parse(item[10].ToString()), item[11].ToString(), decimal.Parse(item[12].ToString()), item[13].ToString(), DateTime.Parse(item[14].ToString()), new Category(int.Parse(item[14].ToString()), item[15].ToString(), item[16].ToString()), new Supplier(int.Parse(item[17].ToString()), item[18].ToString(), item[19].ToString(), item[20].ToString(), item[21].ToString(), item[22].ToString(), int.Parse(item[23].ToString()), item[24].ToString())), new Client(int.Parse(item[25].ToString()), item[26].ToString(), item[27].ToString(), int.Parse(item[28].ToString()), item[29].ToString(), DateTime.Parse(item[30].ToString()), item[31].ToString(), item[32].ToString(), item[33].ToString(), item[34].ToString(), int.Parse(item[35].ToString()), item[36].ToString()), new Employee(int.Parse(item[37].ToString()), item[38].ToString(), item[39].ToString(), int.Parse(item[40].ToString()), item[41].ToString(), DateTime.Parse(item[42].ToString()), item[43].ToString(), item[44].ToString(), item[45].ToString(), item[46].ToString(), int.Parse(item[47].ToString()), item[48].ToString(),
                            new Department(int.Parse(item[52].ToString()), item[53].ToString(), item[54].ToString()), item[50].ToString(), item[51].ToString()))));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Invoices;
        }
        public bool CreateNewInvoice(string name, decimal price, string description, DateTime datecreated, int category, int supplier)
        {
            try
            {
                string query = @"insert into Product
                                (Name,Price,Description,DateCreated,Category,Supplier)
                                values
                                (@name,@price,@desc,@date,@category,@supplier)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    cmd.Parameters.Add(new SqlParameter("@date", datecreated));
                    cmd.Parameters.Add(new SqlParameter("@category", category));
                    cmd.Parameters.Add(new SqlParameter("@supplier", supplier));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }
        public bool UpdateInvoice(int id, decimal price, int supplier)
        {
            try
            {
                string query = @"update Product
                        set Price =@price, Supplier=@supplier
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@supplier", supplier));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }
        public bool DeleteInvoice(int id)
        {
            try
            {
                string query = "delete Product where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Category
        public List<Category> GetCategories()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = "select * from Category";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Categories.Add(new Category(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString()));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Categories;
        }

        public bool CreateNewCategory(string name, string description)
        {
            try
            {
                string query = @"insert into Category
                                (Name,Description)
                                values
                                (@name,@desc)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));

                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }

        public bool UpdateCategory(int id, string name, string description)
        {
            try
            {
                string query = @"update Category
                        set Name =@name,Description=@desc
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                string query = "delete Category where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Tech Support
        public List<TechnicalSupport> GetTechSupport()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"select * from Employee e 
                                    inner join Department d
                                    on d.Id = e.DeptId
                                    inner join TechnicalSupport s
                                    on e.Id = s.Employee";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        supports.Add(new TechnicalSupport(int.Parse(item[0].ToString()), item[1].ToString(), item[2].ToString(), int.Parse(item[3].ToString()), item[4].ToString(), DateTime.Parse(item[5].ToString()), item[6].ToString(), item[7].ToString(), item[8].ToString(), item[9].ToString(), int.Parse(item[10].ToString()), item[11].ToString(),
                            new Department(int.Parse(item[15].ToString()), item[16].ToString(), item[17].ToString()),item[13].ToString(), item[14].ToString(),int.Parse(item[18].ToString()),item[19].ToString(),int.Parse(item[20].ToString())));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return supports;
        }

        public bool CreateNewTech(string name, string surname, int age, string idno, DateTime dob, string cellno, string address1, string address2, string city, int postalcode, string country, int deptid, string username, string password, int yearsExperience, string specialty)
        {
            try
            {
                bool success = CreateNewEmployee(name, surname, age, idno, dob, cellno, address1, address2, city, postalcode, country, deptid, username, password);

                if (success)
                {
                    string query = @"insert into TechnicalSupport(Speciality,yearsOfExperience,Employee) 
                                    values
                                    (@specialty,@years,
                                    (select e.Id
                                    from Employee e
                                    where FirstName = @name and LastName = @surname))";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        cmd.Parameters.Add(new SqlParameter("@specialty", specialty));
                        cmd.Parameters.Add(new SqlParameter("@years", yearsExperience));
                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@surname", surname));

                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Department has been saved into database");
                        IsSuccess = true;
                    }
                    else
                    {
                        throw new CustomException("Database not connected");
                    }
                }
                
               
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }

        public bool UpdateTech(int id, string specialty, int years)
        {
            try
            {
                string query = @"update TechnicalSupport
                        set Speciality =@specialty,yearsOfExperience=@years
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@specialty", specialty));
                    cmd.Parameters.Add(new SqlParameter("@years", years));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteTech(int id)
        {
            try
            {
                string query = "delete TechnicalSupport where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Componets
        public List<Component> GetComponents()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"select * from Components c
inner join Product p
on c.Id = p.Id
inner join Category ct 
on p.Category = ct.Id
inner join Supplier s
on p.Supplier = s.Id";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Components.Add(new Component(int.Parse(item[0].ToString()), item[1].ToString(),item[2].ToString(),decimal.Parse(item[3].ToString()), new Product(int.Parse(item[5].ToString()), item[6].ToString(), decimal.Parse(item[7].ToString()), item[8].ToString(), DateTime.Parse(item[9].ToString()), new Category(int.Parse(item[12].ToString()), item[13].ToString(), item[14].ToString()), new Supplier(int.Parse(item[15].ToString()), item[16].ToString(), item[17].ToString(), item[18].ToString(), item[19].ToString(), item[20].ToString(), int.Parse(item[21].ToString()), item[22].ToString()))));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Components;
        }

        public bool CreateNewComponent(string name, string description, decimal price,int product)
        {
            try
            {
                string query = @"insert into Components
                                (Name,Description,Price,Product)
                                values
                                (@name,@desc,@price,@prod)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@name", name));
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@prod", product));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }

        public bool UpdateComponent(int id ,string description,decimal price)
        {
            try
            {
                string query = @"update Components
                        set Description=@desc, Price = @price
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@desc", description));
                    cmd.Parameters.Add(new SqlParameter("@price", price));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteComponent(int id)
        {
            try
            {
                string query = "delete Components where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Calls
        public List<Calls> GetCalls()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"SELECT * 
                                    FROM Calls c
                                    inner join Client cs
                                    on cs.Id = c.Client";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Calls.Add(new Calls(int.Parse(item[0].ToString()),item[2].ToString(), item[3].ToString(),new Client(int.Parse(item[4].ToString()), item[5].ToString(), item[6].ToString(), int.Parse(item[7].ToString()), item[8].ToString(), DateTime.Parse(item[9].ToString()), item[10].ToString(), item[11].ToString(), item[12].ToString(), item[13].ToString(), int.Parse(item[14].ToString()), item[15].ToString())));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Calls;
        }

        public bool CreateNewCall(int clientt, string duration, string reason)
        {
            try
            {
                string query = @"insert into Calls
                                (Client,Duration,reasonForCall)
                                values
                                (@client,@duration,@reason)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@client", clientt));
                    cmd.Parameters.Add(new SqlParameter("@duration", duration));
                    cmd.Parameters.Add(new SqlParameter("@reason", reason));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }

        public bool UpdateCall(int id, string reason)
        {
            try
            {
                string query = @"update Calls
                        set reasonForCall=@reason
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@reason", reason));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteCall(int id)
        {
            try
            {
                string query = "delete Calls where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

        #region Schedules
        public List<Schedule> GetSchedules()
        {
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("connected to database");
                    SqlCommand cmd = new SqlCommand(connString, conn);
                    DataSet ds = new DataSet();
                    string query = @"SELECT *
  FROM [SmartHomeSystemDb].[dbo].[Schedule] s
  inner join Calls c
  on c.Id = s.Call
  inner join Client cl
  on cl.Id = c.Client
  inner join TechnicalSupport t
  on t.Id = s.technician
  inner join Employee e
  on e.Id = t.Employee
  inner join Department d
  on d.Id = e.DeptId";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    adapter.Fill(ds);

                    DataTable dt = ds.Tables[0];
                    foreach (DataRow item in dt.Rows)
                    {
                        Schedules.Add(new Schedule(int.Parse(item[0].ToString()),DateTime.Parse(item[3].ToString()),item[1].ToString(),new Calls(int.Parse(item[5].ToString()),item[7].ToString(),item[8].ToString(),new Client(int.Parse(item[9].ToString()), item[10].ToString(), item[11].ToString(), int.Parse(item[12].ToString()), item[13].ToString(), DateTime.Parse(item[14].ToString()), item[15].ToString(), item[16].ToString(), item[17].ToString(), item[18].ToString(), int.Parse(item[19].ToString()), item[20].ToString())),new TechnicalSupport(int.Parse(item[25].ToString()), item[26].ToString(), item[27].ToString(), int.Parse(item[28].ToString()), item[29].ToString(), DateTime.Parse(item[30].ToString()), item[31].ToString(), item[32].ToString(), item[33].ToString(), item[34].ToString(), int.Parse(item[35].ToString()), item[36].ToString(),
                            new Department(int.Parse(item[40].ToString()), item[41].ToString(), item[42].ToString()), item[38].ToString(), item[39].ToString(), int.Parse(item[4].ToString()),item[22].ToString(),int.Parse(item[23].ToString()))));
                    }
                }
                else
                {
                    throw new CustomException("connection to database not opened");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return Schedules;
        }

        public bool CreateNewSchedule(DateTime date, string time, int callId, int techId)
        {
            try
            {
                string query = @"insert into [Schedule]
                                (StartDate,StartTime,Call,Technician)
                                values
                                (@date,@time,@call,@tech)";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@date", date));
                    cmd.Parameters.Add(new SqlParameter("@time", time));
                    cmd.Parameters.Add(new SqlParameter("@call", callId));
                    cmd.Parameters.Add(new SqlParameter("@tech", techId));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been saved into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return IsSuccess;
        }

        public bool UpdateSchedule(int id,DateTime date,string time, int techId)
        {
            try
            {
                string query = @"update Schedule
                        set StartDate=@date, StartTime=@time, Technician = @tech
                        where Id=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@date", date));
                    cmd.Parameters.Add(new SqlParameter("@time", time));
                    cmd.Parameters.Add(new SqlParameter("@tech", techId));
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    //MessageBox.Show("Department has been updated into database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("Database not connected");
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

            return IsSuccess;
        }

        public bool DeleteSchedule(int id)
        {
            try
            {
                string query = "delete Schedule where Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    cmd.ExecuteNonQuery();

                    // MessageBox.Show("Department has been deleted from database");
                    IsSuccess = true;
                }
                else
                {
                    throw new CustomException("database not connected");
                }
            }
            catch (CustomException e)
            {

                MessageBox.Show(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return IsSuccess;
        }
        #endregion

    }
}
