using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace eBuyAntiquesStore2.user
{

    public partial class ProductViewUser : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (Request.QueryString["category"] == null)
            {
                cmd.CommandText = "Select * from ItemMaster";

            }
            else
            {
                cmd.CommandText = "Select * from ItemMaster where categoryId='" + Request.QueryString["category"].ToString() + "'";
                
            }
            if (Request.QueryString["category"] == null && Request.QueryString["search"] != null)
                {
                cmd.CommandText = "Select * from ItemMaster where itemName like('%" + Request.QueryString["search"].ToString() + "%')";

            }

            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            d1.DataSource = dt;
            d1.DataBind();
          
            sqlcon.Close();




        }
        protected int get_category_id(String Category)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select categoryId from CategoryMaster where categoryName='" + Category + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                sqlcon.Close();

                return Convert.ToInt32(dt.Rows[0]["categoryId"].ToString());
            }
            return 0;
        }
    }
}