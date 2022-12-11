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
    public partial class payment_success : System.Web.UI.Page
    {
		string order = "";
		string order_id;
		string s;
		string t;
		string[] a = new string[6];
		SqlConnection con = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

		protected void Page_Load(object sender, EventArgs e)
		{
			con.Open();
			order = Request.QueryString["order"].ToString();
			int totalPrice = 0;//with tax
			
			if (order == Session["order_no"].ToString())
			{

				//this is for getting user details and storing it on order_details table

				SqlCommand cmd = con.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "select * from UserMaster where userEmail='"+ Session["UserEmail"].ToString() + "'";
				cmd.ExecuteNonQuery();
				DataTable dt = new DataTable();
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				da.Fill(dt);
				foreach (DataRow dr in dt.Rows)
				{
					SqlCommand cmd1 = con.CreateCommand();
					cmd1.CommandType = CommandType.Text;
					cmd1.CommandText = "insert into Orders(custName,custAddr,custEmail,custCity,custState,orderDateTime) values('" + dr["userName"].ToString() + "','" + dr["userAddress"].ToString() + "','" + dr["userEmail"].ToString() + "','" + dr["userCity"].ToString() + "','" + dr["userState"].ToString() + "','"+ TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time")) + "')";
					cmd1.ExecuteNonQuery();
				}

				//end storing user details


				// now we are going to get order id form orders table

				SqlCommand cmd2 = con.CreateCommand();
				cmd2.CommandType = CommandType.Text;
				cmd2.CommandText = "select top 1 * from Orders where custEmail='" + Session["UserEmail"].ToString() + "' order by id desc ";//get last record
				cmd2.ExecuteNonQuery();
				DataTable dt2 = new DataTable();
				SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
				da2.Fill(dt2);
				foreach (DataRow dr2 in dt2.Rows)
				{
					order_id = dr2["id"].ToString();//last record's id
				}

				//ending of getting order id

				// this is for getting ordered items form cookies

				if (Request.Cookies["cart_items"] != null)
				{
					s = Convert.ToString(Request.Cookies["cart_items"].Value);
					string[] strArr = s.Split('|');
					for (int i = 0; i < strArr.Length; i++)
					{
						t = Convert.ToString(strArr[i].ToString());
						string[] strArr1 = strArr[i].Split(',');
						for (int j = 0; j < strArr1.Length; j++)
						{
							a[j] = strArr1[j].ToString();
						}
					
						SqlCommand cmd3 = con.CreateCommand();
						cmd3.CommandType = CommandType.Text;
						cmd3.CommandText = "insert into OrderDetails(orderID,itemName,itemPrice,itemImage,quantity) values('" + order_id.ToString() + "','" + a[0].ToString() + "','" + a[1].ToString() + "','" + a[2].ToString() + "','" + a[3].ToString() + "')";
						cmd3.ExecuteNonQuery();
						
						
					}
					con.Close();
				}

				// end of getting items from cookies


			}
			else
			{
				Response.Redirect("Login.aspx");
			}

			con.Close();

			//Session["UserEmail"] = "";
			Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(-1);
			Response.Cookies["cart_items"].Expires = DateTime.Now.AddDays(-1);
			Session["order_no"] = null;
			Response.Redirect("ProductViewUser.aspx");
		}
	}
}
/*
 using System;
using System.Collection.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.webControls;
using System.Data;
using System.Data.sqlClient;

public Partial class user/payment_sucess : System.Web.UI.page
{
	SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\shooping.mdf;Integrated Security=True;User Instance=True");
	string order = "";
	string order_id;
	string s;
	string t;
	string[] a = new string[6];
	protected void Page_Load(object sender, EventArgs e)
	{
		con.Open();
		order = Request.QueryString["order"].ToString();
		
		if (order == Session["order_no"].ToString())
		{
			
			//this is for getting user details and storing it on order_details table
			
			SqlCommand cmd = con.CreateCommand();
			cmd.CommandType = CommandType.Text;
			cmd.CommandText = "select * from registration where email="" + Session["user"].ToString() + "'";
			cmd.ExecuteNonQuery();
			DataTable dt = new DataTable();
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(dt);
			foreach (DataRow dr in dt.Rows)
			{
				SqlCommand cmd1 = con.CreateCommand();
				cmd1.CommandType = CommandType.Text();
				cmd1.CommandText = "insert into orders values('" + dr["firstname"].ToString() + "','" + dr["lastname"].ToString() + "','" + dr["email"].ToString() + "','" + dr["address"].ToString() + "','" + dr["city"].ToString() + "','" + dr["state"].ToString() + "','" + dr["pincode"].ToString() + "','" + dr["mobile"].ToString() + "')";
				cmd1.ExecuteNonQuery();
			}	
			
			//end storing user details
		
		
			// now we are going to get order id form orders table
			
			SqlCommand cmd2 = con.CreateCommand();
			cmd2.CommandType = CommandType.Text;
			cmd2.CommandText = "select top 1 * from orders where email="" + Session["user"].ToString() + "' order by id desc ";
			cmd2.ExecuteNonQuery();
			DataTable dt2 = new DataTable();
			SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
			da2.Fill(dt2);
			foreach (DataRow dr2 in dt2.Rows)
			{
				order_id = dr2["id"].ToString();
			}
			
			//ending of getting order id
			
			// this is for getting ordered items form cookies
			
			if (Request.Cookies["aa"] != null)
			{
				s = Convert.ToString(Request.Cookies["aa"].Value);
				string[] strArr = s.Split('|');
				for (int i = 0; i < strArr.Length; i++)
				{
					t = Convert.ToString(strArr[i].ToString());
					string[] strArr1 = s.Split(',');
					for (int j = 0; j < strArr1.Length; j++)
					{
						a[j] = strArr1.ToString();
					}
					
					SqlCommand cmd3 = con.CreateCommand();
					cmd3.CommandType = CommandType.Text;
					cmd3.CommandText = "insert into order_details values('" + oder_id.ToString() + "','" + a[0].ToString() + "','" + a[2].ToString() + "','" + a[3].ToString() + "','" + a[4].ToString() + "')";
					
				}
			}
			
			// end of getting items from cookies
			
			
		}
		else
		{
			Response>Redirect("login.aspx");
		}
		
		con.Close();
		
		Session["user"] = "";
		Response.Cookies["aa"].Expires = DateTime.Now,AddDays(-1);
		Response.Cookies["aa"].Expires = DateTime.Now,AddDays(-1);

		Response.Redirect("display_item.aspx");
	}
}*/