using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace eBuyAntiquesStore2.admin
{
    public partial class Register : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int flag = 1;
            flag = check_email(email.Text.ToString());
            if (flag == 1)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into UserMaster" + "(userName,userEmail,userAddress,userPassword,userRegistered,userCity,userState) values (@Fname,@Email,@Address,@Password,'" + DateTime.Now.ToString("M/d/yyyy") + "','" + city.Text + "','" + state.Text + "')", con);
                cmd.Parameters.AddWithValue("@Fname", TextBox1.Text);
                //cmd.Parameters.AddWithValue("@Lname", TextBox2.Text);
                cmd.Parameters.AddWithValue("@Email", email.Text);
                //cmd.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@Address", TextBox4.Text);
                //cmd.Parameters.AddWithValue("@Phone", TextBox5.Text);
                cmd.Parameters.AddWithValue("@Password", TextBox6.Text);
                cmd.ExecuteNonQuery();//execute and command and save into database
                con.Close();
                Label1.Text = "Register Successfully! ";
            }
            else if (flag == 0)
            {
                Label1.Text = "Email already exists! ";
            }
            else
            {

            }
        }

        protected int check_email(String email)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from UserMaster where userEmail = '" + email + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                con.Close();
                return 0;
            }
            else
            {
                con.Close();
                return 1;
            }



        }
    }
}