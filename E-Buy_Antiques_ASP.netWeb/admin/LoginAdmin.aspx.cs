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
                Response.Redirect("AddItem.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Login Unsuccessfull";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}