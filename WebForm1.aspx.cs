using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static AddStudent_UsingDelegate.WebForm1; // Importing the delegate from the same namespace

namespace AddStudent_UsingDelegate
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Defining a delegate to add a student
        public delegate void AddStudentDelegate(string name, int age, string email);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty as we don't have any initial setup or loading activity
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Creating an instance of DatabaseHandler to handle database operations
            DatabaseHandler dbhandler = new DatabaseHandler();
            // Creating an instance of StudentManager to manage student-related operations
            StudentManager studentManager = new StudentManager();
            // Subscribing the AddStudentRecord method to the delegate
            studentManager.AddStudentHandler += dbhandler.AddStudentRecord;
            // Calling the AddStudent method to add a new student
            studentManager.AddStudent(txtName.Text,Convert.ToInt32(txtAge.Text),txtEmail.Text);
            // Displaying a success message
            Response.Write("Student Record Added Successfully");
        }
    }

    public class DatabaseHandler // Class to handle database operations
    {
        public void AddStudentRecord(string name, int age, string email)
        {
            string cs = @"Server=DESKTOP-I69OQPV\SQLEXPRESS;Database=ORG;Integrated Security=True;"; // Connection string for SQL Server
            using (SqlConnection con = new SqlConnection(cs))// Creating a SQL connection
            {
                // SQL query to insert a new student record
                string qr = "INSERT INTO Students (Name, Age, Email) VALUES (@Name, @Age, @Email)";
                // Creating a SQL command

                SqlCommand cmd = new SqlCommand(qr, con);
                // Adding parameters to the SQL command
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                // Opening the SQL connection
                con.Open();
                // Executing the SQL command to insert the student record
                cmd.ExecuteNonQuery();
            }
        }
    }

    public class StudentManager // Class to manage student-related operations
    {
        public AddStudentDelegate AddStudentHandler; // Delegate instance to add a student
        public void AddStudent(string name, int age, string email)// Method to add a new student
        {
            if(AddStudentHandler!=null)// Checking if the delegate has any subscribers
            {
                AddStudentHandler(name, age, email);  // Invoking the delegate to add a new student

            }
        }
    }

}