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
    public partial class User : System.Web.UI.MasterPage
    {
        string s, t;
        string[] a = new string[6];
        int totprice = 0;
        int itemcount = 0; 
        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from categoryMaster";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dd.DataSource = dt;
            dd.DataBind();
            sqlcon.Close();

            if (Request.Cookies["cart_items"] != null)
            {

                s = Convert.ToString(Request.Cookies["cart_items"].Value);
                string[] strArr = s.Split('|');
                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split(',');
                    for (int j = 0; j < strArr1.Length; j++)
                    {
                        a[j] = strArr1[j].ToString();


                    }
                    totprice += (Convert.ToInt32(a[1].ToString()) * Convert.ToInt32(a[3].ToString()));
                    itemcount += 1;
                }
            }
            carttotitem.Text = itemcount.ToString();
            carttotprice.Text = totprice.ToString();
        }
    }
}