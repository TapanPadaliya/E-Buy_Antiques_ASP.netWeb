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
    public partial class product_desc : System.Web.UI.Page
    {

        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        int itemId, qty;
        int cart_qty = 0;
        string quantity, categoryId, itemWeight, itemPrice, itemName, itemDescription, itemImage, itemAge;



        protected void buy_now(object sender, EventArgs e)
        {

        }


        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["itemId"].ToString() == null)
            {
                Response.Redirect("ProductViewUser.aspx");

            }
            else
            {
                itemId = Convert.ToInt32(Request.QueryString["itemId"].ToString());
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from ItemMaster where itemId=" + itemId;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                d1.DataSource = dt;
                d1.DataBind();
                sqlcon.Close();

            }
            qty = get_qty(itemId);
            if (qty == 0) {
                l2.Visible = false;
                t1.Visible = false;
                addToCartBtn.Visible=false;
                
                l1.Text = "OUT OF STOCK";
            }

        }

        protected void add_to_cart(object sender, EventArgs e)
        {
            if (sqlcon.State == ConnectionState.Open)
            {
                sqlcon.Close();
            }
                itemId = Convert.ToInt32(Request.QueryString["itemId"].ToString());
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select itemName,itemPrice,itemImage,quantity from ItemMaster where itemId=" + itemId;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    itemName = dr["itemName"].ToString();

                    itemPrice = dr["itemPrice"].ToString();


                    itemImage = dr["itemImage"].ToString();
                    quantity = dr["quantity"].ToString();
                    //cookie to contain names of items already added so that duplicate items not  added to the cart.

                }
                sqlcon.Close();

                if (Convert.ToInt32(t1.Text) > Convert.ToInt32(quantity))
                {
                    l1.Text = "Please enter valid quantity!!";
                }
                else
                {
                    cart_qty = Convert.ToInt32(t1.Text);
                    l1.Text = "Item Added to Cart.";
                    if (Request.Cookies["cart_items"] != null)
                    {
                        Response.Cookies["cart_items"].Value = Request.Cookies["cart_items"].Value + "|" + itemName.ToString() + "," + itemPrice.ToString() + "," + itemImage.ToString() + "," + cart_qty.ToString() + "," + itemId.ToString();
                        Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(1);
                    }
                    //for multiple records seperate records using pipe sign.
                    else
                    {
                        Response.Cookies["cart_items"].Value = itemName.ToString() + "," + itemPrice.ToString() + "," + itemImage.ToString() + "," + cart_qty.ToString() + "," + itemId.ToString();
                        Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(1);
                    }
                    sqlcon.Open();
                    SqlCommand cmd1 = sqlcon.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd1.CommandText = "Update ItemMaster set quantity=quantity-" + cart_qty+ "where itemId=" + itemId;
                    cmd1.ExecuteNonQuery();
                    Response.Redirect("product_desc.aspx?itemId=" + itemId.ToString());
                }
                //addToCartBtn.Text = "Remove From Cart";
                //upd_qty.Visible = true;

          /* else if (addToCartBtn.Text == "Remove From Cart")
            {
                itemId = Convert.ToInt32(Request.QueryString["itemId"].ToString());
                sqlcon.Open();
                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select itemName,itemPrice,itemImage,quantity from ItemMaster where itemId=" + itemId;
                cmd.ExecuteNonQuery();
                addToCartBtn.Text = "Add to Cart";
            }
            */
            
        }

        public int get_qty(int itemId)
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select quantity from ItemMaster where itemId=" + itemId;
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                qty = Convert.ToInt32(dr["quantity"].ToString());
            }
            return qty;
        }
    }
}