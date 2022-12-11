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
    public partial class ViewFullOrder : System.Web.UI.Page
    {
        int id,tot=0;
        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            id= Convert.ToInt32(Request.QueryString["id"].ToString());


            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Orders where id= '" + id.ToString() + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            r2.DataSource = dt;
            r2.DataBind();
            sqlcon.Close();


            sqlcon.Open();
            SqlCommand cmd2 = sqlcon.CreateCommand();
            cmd2.CommandType = CommandType.Text;
            cmd2.CommandText = "Select * from OrderDetails where OrderID= '"+id.ToString()+"'" ;
            cmd2.ExecuteNonQuery();
            DataTable dt2 = new DataTable();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(dt2);
            r1.DataSource = dt2;
            r1.DataBind();
            foreach(DataRow dr in dt2.Rows)
            {
                tot += Convert.ToInt32(dr["itemPrice"].ToString()) * Convert.ToInt32(dr["quantity"].ToString());
            }
            sqlcon.Close();
            l1.Text = "Total Amount Paid:Rs" + (Convert.ToInt32(tot.ToString()) + Convert.ToInt32(tot.ToString()) * (0.18));
        }
    }
}