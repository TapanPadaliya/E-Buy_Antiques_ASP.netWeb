using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace eBuyAntiquesStore2.user
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=ebuyAntiquesStore;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from userMaster where userEmail='" + TextBox1.Text + "'and userPassword='" + TextBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                if (Session["checkoutbtn"] == "yes")//means user has come from checkout button 
                {
                    Session["User"] = dt.Rows[0]["userName"].ToString();
                    Session["UserEmail"] = TextBox1.Text;
                    Response.Redirect("UpdateOrderDetails.aspx");
                }
                else
                {
                    Session["User"] = dt.Rows[0]["userName"].ToString();
                    Session["UserEmail"] = TextBox1.Text;
                    Response.Redirect("OrderDetails.aspx");
                }
            }
            else
            {
                Label1.Text = "Login Unsuccessfull";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}