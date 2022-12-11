using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace eBuyAntiquesStore2.admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\jk\source\repos\eBuyAntiquesStore2\App_Data\ebuyantiques_db.mdf;Integrated Security=True");
        int i;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {
            i = 0;
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText="select * from UserMaster where userName='"+t1.Text+"' and userPassword='"+t2.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt= new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 1)
            {
                Response.Redirect("AdminDashboard.aspx");
            }
            else {
                l1.Text = "Invalid username or password.";

            }
            sqlcon.Close();
        }
    }
}