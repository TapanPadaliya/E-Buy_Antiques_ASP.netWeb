using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;

namespace eBuyAntiquesStore2.admin
{
    public partial class ItemReports : System.Web.UI.Page
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=JK-PC;Initial Catalog=ebuyAntiquesStore;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }
        void LoadData()
        {
            sqlcon.Open();
            SqlCommand cmd = sqlcon.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select itemName,sum(quantity) as TotQuantity from OrderDetails group by itemName";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            sqlcon.Close();
            string []x = new string[dt.Rows.Count];
            int[] y=new int[dt.Rows.Count];
            for(int i=0; i < dt.Rows.Count; i++)
            {
                x[i] = dt.Rows[i][0].ToString();
                y[i] = Convert.ToInt32(dt.Rows[i][1]);
            }
            Chart1.Series[0].Points.DataBindXY(x, y);
            Chart1.Series[0].ChartType = SeriesChartType.StackedColumn;
        }
    }
}