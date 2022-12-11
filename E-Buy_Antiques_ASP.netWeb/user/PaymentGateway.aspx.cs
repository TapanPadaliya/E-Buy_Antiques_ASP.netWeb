using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using paytm;

namespace eBuyAntiquesStore2.user
{
	class Class1
	{

		public static string GetRandomPassword(int length)
		{
			char[] chars = "abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			string password = string.Empty;
			Random random = new Random();

			for (int i = 0; i < length; i++)
			{
				int x = random.Next(1, chars.Length);
				//For avoiding Repetation of Characters
				if (!password.Contains(chars.GetValue(x).ToString()))
					password += chars.GetValue(x);
				else
					i = i - 1;
			}
			return password;
		}

	}
	public partial class PaymentGateway : System.Web.UI.Page
	{
		int totprice = 0;
		string s;
		string t;
		string[] a = new string[6];
		string order_no;
		protected void Page_Load(object sender, EventArgs e)
		{
			Session["createSession"] = true;
			if (Session["UserEmail"] == null)
			{
				Response.Redirect("Login.aspx");
			}
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

				}
				Session["totprice"] = totprice.ToString();
			}

			// Here We Have To Implement PayPal

			order_no = Class1.GetRandomPassword(10).ToString();
			Session["order_no"] = order_no.ToString();
			Session.Timeout = 50000;
			String merchantKey = "3EmP94RHgNFoVfs!";
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("MID", "KhCBhO77413667070068");
			parameters.Add("CHANNEL_ID", "WEB");
			parameters.Add("INDUSTRY_TYPE_ID", "Retail");
			parameters.Add("WEBSITE", "WEBSTAGING");
			parameters.Add("EMAIL", "jainbirds@gmail.com");
			parameters.Add("MOBILE_NO", "8000881444");
			parameters.Add("CUST_ID", "cust_001");
			parameters.Add("ORDER_ID", order_no.ToString());
			parameters.Add("TXN_AMOUNT", Convert.ToString(totprice + (totprice * (0.18))));
			parameters.Add("CALLBACK_URL", "https://localhost:44383/user/payment_success.aspx?order=" + order_no.ToString()); //This parameter is not mandatory. Use this to pass the callback url dynamically.

			string checksum = CheckSum.generateCheckSum(merchantKey, parameters);
			string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction?orderid="+order_no.ToString() ;
			string outputHTML = "<html>";
			outputHTML += "<head>";
			outputHTML += "<title>Merchant Check Out Page</title>";
			outputHTML += "</head>";
			outputHTML += "<body>";
			outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
			outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
			outputHTML += "<table border='1'>";
			outputHTML += "<tbody>";
			foreach (string key in parameters.Keys)
			{
				outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
			}
			outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
			outputHTML += "</tbody>";
			outputHTML += "</table>";
			outputHTML += "<script type='text/javascript'>";
			outputHTML += "document.f1.submit();";
			outputHTML += "</script>";
			outputHTML += "</form>";
			outputHTML += "</body>";
			outputHTML += "</html>";
			Response.Write(outputHTML);
			/*
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

						}
						Session["totprice"] = totprice.ToString();
					}

					// Here We Have To Implement PayPal

					order_no = Class1.GetRandomPassword(10).ToString();
						Session["order_no"] = order_no.ToString();

						Response.Write("<form action='https://www.sandbox.paypal.com/cgi-bin/webscr' method='post' name='buyCredits' id='buyCredits'>");
						Response.Write("<inpute type='hidden' name='cmd' value='_xclick'>");
						Response.Write("<inpute type='hidden' name='business' value='sb-upz0v5874604@business.example.com'>");
						Response.Write("<inpute type='hidden' name='currency_code' value='INR'>");
						Response.Write("<inpute type='hidden' name='item_name' value='Payment for Purchase'>");
						Response.Write("<inpute type='hidden' name='item_number' value='0'>");
						Response.Write("<inpute type='hidden' name='amount' value='" + Session["totprice"].ToString() + "'>");
						Response.Write("<inpute type='hidden' name='return' value='https://localhost:44383/user/payment_sucess.aspx?order=" + order_no.ToString() + "'>"); //show product page after payment , returning
						Response.Write("</form>");

						Response.Write("<script type='text/javascript'>");
						Response.Write("document.getElementById('buyCredits').submit();");
						Response.Write("</script>");

		*/                // End Imelementation
		}
		}
	}
