using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace eBuyAntiquesStore2.admin
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
    public partial class AddItem : System.Web.UI.Page
    {
         string a, b;
        string catID="";
        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                sqlcon.Open();
                SqlCommand com = new SqlCommand("select *from CategoryMaster", sqlcon);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);  // fill dataset  
                pdropdown.DataTextField = ds.Tables[0].Columns["categoryName"].ToString(); // text field name of table dispalyed in dropdown       
                pdropdown.DataValueField = ds.Tables[0].Columns["categoryId"].ToString();
                // to retrive specific  textfield name   
                pdropdown.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
                pdropdown.DataBind();  //binding dropdownlist 

            }
        }
        
        
        
       
        protected void Sbtbtn_Click(object sender, EventArgs e)
        {
            try
            {
                sqlcon.Open();
                catID = pdropdown.SelectedItem.Value;
                
                a = Class1.GetRandomPassword(10).ToString();
                pimg.SaveAs(Request.PhysicalApplicationPath + "./Images/" + a + pimg.FileName.ToString());
                b = "Images/" + a + pimg.FileName.ToString();

                SqlCommand cmd = sqlcon.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into ItemMaster(itemName,categoryId,itemDescription,itemWeight,itemAge,itemImage,addedDate,itemPrice,quantity) values('" + pname.Text + "'," + catID.ToString() + ",'" + pdesc.Text + "'," + pweight.Text + ",'" + page.SelectedDate.ToShortDateString() + "','" + b.ToString() + "','" + DateTime.Now.ToString("M/d/yyyy") + "'," + pprice.Text + "," + pquan.Text + ")";
               
               int i= cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    l2.Text = "cat:"+ catID;
                    l3.Text = "name   :" + pdropdown.SelectedItem.Text;
                    l4.Text = "date:" + DateTime.Now.ToString("M/d/yyyy");
                   
                    


                }
                else {
                    Response.Write("<script>alert('Error')</script>");
                }
               
                
                
            }
            
            finally
            {
                sqlcon.Close();
            }
        }
        
    }
}