using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShadyBusiness
{
    public partial class PurchaseDetails : System.Web.UI.Page
    {
        int pid;
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "SELECT p.member_number, c.customer_name, c.customer_address, c.customer_email, p.purchase_date, p.total_amount FROM item i JOIN purchase_item pd ON i.item_code = pd.item_code JOIN purchase p ON p.purchase_id = pd.purchase_id JOIN customer c ON  p.member_number = c.member_number WHERE pd.purchase_id = 15";

            OleDbCommand val = new OleDbCommand(query);

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                val.Connection = con;
                con.Open();

                OleDbDataReader sdr = val.ExecuteReader();
                while (sdr.Read())
                {
                    lblMeme.Text = sdr.GetValue(0).ToString();
                    lblCus.Text = sdr.GetValue(1).ToString();
                    lblAddress.Text = sdr.GetValue(2).ToString();
                    lblEmail.Text = sdr.GetValue(3).ToString();
                    lblDate.Text = sdr.GetValue(4).ToString();
                    lblTotal.Text = sdr.GetValue(5).ToString();
                }

                con.Close();
            }

            // default load data
            if (!this.IsPostBack)
            {
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT i.item_name, i.description, i.price, p.purchase_unit AS PurchasedUnit, p.line_total AS LineTotal FROM item i JOIN purchase_item p ON i.item_code = p.item_code WHERE p.purchase_id = 15";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("item");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
    }
}