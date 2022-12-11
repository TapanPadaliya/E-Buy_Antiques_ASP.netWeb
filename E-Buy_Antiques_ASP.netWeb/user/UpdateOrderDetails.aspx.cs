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
    public partial class UpdateOrderDetails : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (IsPostBack) {
                //IsPostBack will be true when the page is again loaded.. so return statement prevents the page gets reinitialized again in page load event....
                return; }
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from UserMaster where userEmail='"+Session["UserEmail"].ToString()+"'";
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                uname.Text = dr["userName"].ToString();

                uaddr.Text = dr["userAddress"].ToString();
                ustate.Text = dr["userState"].ToString();
                ucity.Text = dr["userCity"].ToString();
            }

            sqlcon.Close();
        }

        protected void cout_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update UserMaster set userName='"+uname.Text+"',userAddress='"+uaddr.Text+"',userState='"+ustate.Text+ "',userCity='" + ucity.Text + "' where userEmail='" + Session["UserEmail"].ToString() + "'";
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            Response.Redirect("PaymentGateway.aspx");
        }
    }
}