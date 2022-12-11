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
    public partial class ViewCart : System.Web.UI.Page
    {
        string s, t;
        string[] a = new string[6];
        int tot = 0;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("itemName"), new DataColumn("itemPrice"), new DataColumn("itemImage"), new DataColumn("quantity"), new DataColumn("pos"), new DataColumn("item_id") });
        if(Request.Cookies["cart_items"]!=null)
            {

                s = Convert.ToString(Request.Cookies["cart_items"].Value);
               string[] strArr = s.Split('|');
               
                
                for(int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strArr1 = t.Split(',');
                    for (int j = 0; j < strArr1.Length; j++)
                    {
                      a[j]=strArr1[j].ToString();
                        

                    }
                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(),i.ToString(), a[4].ToString());
                    tot +=( Convert.ToInt32(a[1].ToString()) * Convert.ToInt32(a[3].ToString()));
                
                }
            }
            d2.DataSource = dt;
            d2.DataBind();

            carttotprice.Text = "Cart Total(with 18% tax):" + (Convert.ToInt32(tot.ToString())+ Convert.ToInt32(tot.ToString())*(0.18));
            Session["totalPrice"] = (Convert.ToInt32(tot.ToString()) + Convert.ToInt32(tot.ToString()) * (0.18));
            if (carttotprice.Text.ToString()=="0")
            {
                carttotprice.Visible = false;
                cout.Visible = false;

            }
        }

        protected void cout_Click(object sender, EventArgs e)
        {
            Session["checkoutbtn"] = "yes";
            Response.Redirect("Checkout.aspx");
        }
    }
}