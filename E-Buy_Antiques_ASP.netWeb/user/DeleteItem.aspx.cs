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
    public partial class DeleteItem : System.Web.UI.Page
    {

        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        int qty;
        int cart_qty = 0;
        string s, t;
        string[] a = new string[6];
        int item_id,pos;
        string quantity, categoryId, itemWeight, itemPrice, itemName, itemDescription, itemImage, itemAge;
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            pos = Convert.ToInt32(Request.QueryString["pos"].ToString());
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt.Columns.AddRange(new DataColumn[6] { new DataColumn("itemName"), new DataColumn("itemPrice"), new DataColumn("itemImage"), new DataColumn("quantity"), new DataColumn("pos"),new DataColumn("item_id") });
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
                    dt.Rows.Add(a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), i.ToString(), a[4].ToString());
                }
            }
            count = 0;
            foreach(DataRow dr in dt.Rows)
            {
                if (count ==pos)//position of the deleted item ,
                {
                    item_id = Convert.ToInt32(dr["item_id"].ToString());
                    qty= Convert.ToInt32(dr["quantity"].ToString());
                    break;
                }
                count += 1;
            }
            count = 0;
            sqlcon.Open();
            SqlCommand cmd1 = sqlcon.CreateCommand();
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = "Update ItemMaster set quantity=quantity+" + qty +" where itemId="+item_id.ToString();
            cmd1.ExecuteNonQuery();
           sqlcon.Close();
            
            
            dt.Rows.RemoveAt(pos);//position of the row and not itemid it
            Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(-1);

            foreach (DataRow dr in dt.Rows)
            {
                itemName = dr["itemName"].ToString();

                itemPrice = dr["itemPrice"].ToString();


                itemImage = dr["itemImage"].ToString();
                quantity = dr["quantity"].ToString();
                item_id = Convert.ToInt32(dr["item_id"].ToString());
                count += 1;


                if (count == 1)
                {
                    Response.Cookies["cart_items"].Value = itemName.ToString() + "," + itemPrice.ToString() + "," + itemImage.ToString() + "," + quantity.ToString() + "," + item_id.ToString();
                    Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(1);


                }
                //for multiple records seperate records using pipe sign.
                else
                {
                    Response.Cookies["cart_items"].Value = Response.Cookies["cart_items"].Value + "|" + itemName.ToString() + "," + itemPrice.ToString() + "," + itemImage.ToString() + "," + quantity.ToString() + "," + item_id.ToString();
                    Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(1);


                }
            }
            Response.Redirect("ViewCart.aspx");
        }
    }
}