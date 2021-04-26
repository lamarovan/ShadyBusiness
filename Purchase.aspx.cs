using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Configuration;
using System.Data.OleDb;
using System.Data;

namespace ShadyBusiness
{
    public partial class Purchase : System.Web.UI.Page
    {
        static List<Dictionary<string,int>> itemList = new List<Dictionary<string, int>>();
        private int purchaseUnit, item, customer;
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnPurchase_Click(object sender, EventArgs e)
        {
            customer = int.Parse(ddlMember.SelectedValue.ToString());
            Debug.WriteLine(""+itemList.Count);

            int totalAmount = 0;

            foreach (Dictionary<string, int> purchaseItem in itemList)
            {
                int item = purchaseItem["item"];
                int purchaseUnit = purchaseItem["purchaseUnit"];

                OleDbCommand cmd = new OleDbCommand();
                OleDbConnection con = new OleDbConnection(constr);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT "+ purchaseUnit +"*price AS line_total FROM [item] WHERE item_code =" + item;
                OleDbDataReader sdr = cmd.ExecuteReader();
                string lineTotal="";
                while (sdr.Read())
                {
                   lineTotal = sdr.GetValue(sdr.GetOrdinal("line_total")).ToString();
                }
                con.Close();
               int intLineTotal = int.Parse(lineTotal);
                totalAmount += intLineTotal;
                Debug.WriteLine("item = " + purchaseItem["item"].ToString());
                Debug.WriteLine("unit = " + purchaseItem["purchaseUnit"].ToString());
            }
            Debug.WriteLine(totalAmount);
        }
        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            item = int.Parse(ddlItem.SelectedValue.ToString());
            purchaseUnit = int.Parse(txtPurchaseUnit.Text);

            Dictionary<string, int> itemDetails = new Dictionary<string, int>();
            itemDetails.Add("item", item);
            itemDetails.Add("purchaseUnit", purchaseUnit);
            Debug.WriteLine(itemDetails["item"]);
            Debug.WriteLine(itemDetails["purchaseUnit"]);
            itemList.Add(itemDetails);
            Debug.WriteLine("" + itemList.Count);

            this.BindGrid();
        }
        private void BindGrid()
        {
            //string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataTable dt = new DataTable("item");
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            foreach (Dictionary<string, int> itemDetails in itemList)
            {
                int item = itemDetails["item"];
                int purchaseUnit = itemDetails["purchaseUnit"];
              
                cmd.CommandText = @"SELECT item_name, description, price, "+purchaseUnit+" AS unit, " + purchaseUnit +"*price AS line_total FROM [item] WHERE item_code ="+item;
                cmd.CommandType = CommandType.Text;
                using (OleDbDataReader sdr = cmd.ExecuteReader())
                {
                    dt.Load(sdr);
                }
            }
            con.Close();

            itemsGrid.DataSource = dt;
            itemsGrid.DataBind();

        }
    }
}