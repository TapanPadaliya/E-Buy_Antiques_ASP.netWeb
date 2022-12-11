using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace eBuyAntiquesStore2.admin
{
    
    public partial class ProductCRUD : System.Web.UI.Page
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
        SqlConnection con = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        String path,a,b;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                BindGridView();

            }
        }
        //method for binding GridView

        protected void BindGridView()

        {

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select itemName, itemDescription,itemWeight,itemAge,addedDate,categoryId,itemImage,quantity,itemPrice from ItemMaster", con);

            con.Open();

            da.Fill(dt);

            con.Close();



            if (dt.Rows.Count > 0)

            {

               // GridView1.DataSource = dt;

                GridView1.DataBind();

            }

        }
        protected void Insert_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        /*
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Control control = e.Row.Cells[0].Controls[0];
                if (control is LinkButton)
                {
                    ((LinkButton)control).OnClientClick =
                        "return confirm('Are you sure you want to delete? This cannot be undone.');";
                }
            }
        }
        */
       /* protected void insert_Click1(object sender, EventArgs e)
        {//itmDesc,itmWeight,itmAge,itmQuan,itmPrice,itmCC,itmBfc,
            SqlDataSource3.InsertParameters["addedDate"].DefaultValue = DateTime.Now.ToString();
            SqlDataSource3.InsertParameters["itemName"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("itmName")).Text;
            SqlDataSource3.InsertParameters["itemDescription"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("itmDesc")).Text;
            SqlDataSource3.InsertParameters["itemWeight"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("itmWeight")).Text;
            SqlDataSource3.InsertParameters["itemAge"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("itmAge")).Text;
            SqlDataSource3.InsertParameters["itemPrice"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("itmPrice")).Text;
            SqlDataSource3.InsertParameters["quantity"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("itmQuan")).Text;

            SqlDataSource3.Insert();
        }
       */
        // edit event

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)

        {

            GridView1.EditIndex = e.NewEditIndex;

            BindGridView();



        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        /*protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(GridView1.EditIndex == -1) return;
        FileUpload fileUpLoad = GridView1.Rows[GridView1.EditIndex].FindControl("FileUpload1") as FileUpload;
            Label oldfile1 = GridView1.Rows[GridView1.EditIndex].FindControl("oldfile") as Label;
            if (fileUpLoad.HasFile)
            {
                string fileName = fileUpLoad.FileName;
                string fullPath = Path.GetFullPath(fileName);
                fileUpLoad.SaveAs(Request.PhysicalApplicationPath + "./Images/"+fileUpLoad.FileName.ToString());
                SqlDataSource3.UpdateParameters["itemImage"].DefaultValue = fileUpLoad.FileName;
                
            }
            else
            SqlDataSource3.UpdateParameters["itemImage"].DefaultValue = oldfile1.Text;
    }
        */

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)

        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            // find values for update

            TextBox name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1");
            TextBox desc = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");
            TextBox weight = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3");
            TextBox age = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox4");
            TextBox qty = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox8");
            TextBox cat = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox6");
            TextBox price = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox9");
            FileUpload FileUpload1 = (FileUpload)GridView1.Rows[e.RowIndex].FindControl("FileUpload1");

            if (FileUpload1.HasFile)
            {
                a = Class1.GetRandomPassword(10).ToString();
                FileUpload1.SaveAs(Request.PhysicalApplicationPath + "./Images/" + a + FileUpload1.FileName.ToString());
                b = "Images/" + a + FileUpload1.FileName.ToString();
               // path += FileUpload1.FileName;

               // .SaveAs(Request.PhysicalApplicationPath + path);
            }
            else

            {

                // use previous user image if new image is not changed

                Image img = (Image)GridView1.Rows[e.RowIndex].FindControl("img_user");

                path = img.ImageUrl;
            } 
            SqlCommand cmd = new SqlCommand("update ItemMaster set itemName='" + name.Text + "',itemDescription='" + desc.Text + "',itemAge='" + age.Text + "',itemWeight='" + weight.Text + "',quantity='" + qty.Text + "',itemImage = '" + b.ToString() + "'  where itemId = " + id + "", con);
                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();



                GridView1.EditIndex = -1;

                BindGridView();
            }
        
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)

        {

            GridView1.EditIndex = -1;

            BindGridView();

        }
    }
}