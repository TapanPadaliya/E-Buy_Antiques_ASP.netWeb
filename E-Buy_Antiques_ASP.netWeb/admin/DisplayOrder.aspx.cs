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
    public partial class DisplayOrder : System.Web.UI.Page
    {

        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from Orders order by id desc ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            r1.DataSource = dt;
            r1.DataBind();
            sqlcon.Close();
        }
    }
}