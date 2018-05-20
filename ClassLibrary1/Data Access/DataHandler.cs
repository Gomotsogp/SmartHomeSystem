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
                    MessageBox.Show("connected to database");
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
                    MessageBox.Show("connected to database");
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
                        set FirstName='@name',LastName='@surname',Age=@age,CellNumber='@cellno',AddressLine1='@address1',
                        AddressLine2='@address2',City='@city',PostalCode=@code,Country='@country',DeptId=@deptid,
                        UserName='@username',Password='@password'
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
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MessageBox.Show("connected to database");
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
                        set FirstName='@name',LastName='@surname',Age=@age,CellNumber='@cellno',AddressLine1='@address1',
                        AddressLine2='@address2',City='@city',PostalCode=@code,Country='@country'
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
                    MessageBox.Show("connected to database");
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
                string query = @"update Employee
                        set Name ='@name',Description='@desc'
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


    }
}
