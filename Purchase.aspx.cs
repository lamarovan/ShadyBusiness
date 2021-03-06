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
        static List<int> ids = new List<int>();
        private int purchaseUnit, item, customer, quantity;
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        string pid = "";
        int totalAmount = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindGrid();
        }
        protected void btnPurchase_Click(object sender, EventArgs e)
        {

        
            getTotalAmount();

            if (itemList.Count != 0)
            {
                createPurchase();
                getPurchaseID();
                createPurchaseDetails();
                ids.Clear();
                itemList.Clear();
                this.BindGrid();
                Session["pid"] = pid;
                Response.Redirect("PurchaseDetails.aspx");
       
            }
            else
            {
                Debug.WriteLine("no data");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Add Items First!')", true);
            }
        }

        private void getPurchaseID()
        {
            string queryID = "SELECT TOP 1 purchase_id FROM purchase ORDER BY purchase_id DESC ";
            OleDbCommand id = new OleDbCommand(queryID);

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                id.Connection = con;
                con.Open();

                OleDbDataReader sdr = id.ExecuteReader();
                while (sdr.Read())
                {
                    pid = sdr.GetValue(0).ToString();
                }

                Debug.WriteLine("id = " + pid);
                con.Close();
            }
        }



        private void createPurchaseDetails()
        {
            foreach (Dictionary<string, int> purchaseItem in itemList)
            {
                int item = purchaseItem["item"];
                int purchaseUnit = purchaseItem["purchaseUnit"];

                OleDbCommand cmd = new OleDbCommand();
                OleDbConnection con = new OleDbConnection(constr);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT " + purchaseUnit + "*price AS line_total FROM [item] WHERE item_code =" + item;
                OleDbDataReader sdr = cmd.ExecuteReader();
                string lineTotal = "";
                while (sdr.Read())
                {
                    lineTotal = sdr.GetValue(sdr.GetOrdinal("line_total")).ToString();
                }
                con.Close();
                int intLineTotal = int.Parse(lineTotal);
                totalAmount += intLineTotal;
                Debug.WriteLine("item = " + purchaseItem["item"].ToString());
                Debug.WriteLine("unit = " + purchaseItem["purchaseUnit"].ToString());

                //string query = "INSERT INTO [purchase_item] values ('" + pid + "', '" + item + "', '" + purchaseUnit + "','" + intLineTotal + "')";
                //OleDbCommand insert = new OleDbCommand(query);
                using (con)
                {
                    using (OleDbCommand ins = new OleDbCommand("INSERT INTO [purchase_item] values ('" + pid + "', '" + item + "', '" + purchaseUnit + "','" + intLineTotal + "')"))
                    {
                        ins.Connection = con;
                        con.Open();
                        ins.ExecuteNonQuery();
                        con.Close();
                    }
                    //insert.Connection = conn;
                    //conn.Open();
                    //int affected = insert.ExecuteNonQuery();
                    //conn.Close();
                    using (OleDbCommand ins = new OleDbCommand("UPDATE item SET quantity = quantity - " + purchaseUnit + " WHERE item_code = " + item + ";"))
                    {
                        ins.Connection = con;
                        con.Open();
                        int affected = ins.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
        }

        private void createPurchase()
        {
            customer = int.Parse(ddlMember.SelectedValue.ToString());
            String date = DateTime.Now.ToString("yyyy.MM.dd");
            string query = "INSERT INTO [purchase] values ('" + date + "', '" + totalAmount + "', '" + customer + "','" + User.Identity.Name + "')";
            OleDbCommand ins = new OleDbCommand(query);
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                ins.Connection = con;
                con.Open();
                int affected = ins.ExecuteNonQuery();
                con.Close();
            }

        }

        private void getTotalAmount()
        {
            foreach (Dictionary<string, int> purchaseItem in itemList)
            {
                int item = purchaseItem["item"];
                int purchaseUnit = purchaseItem["purchaseUnit"];

                OleDbCommand cmd = new OleDbCommand();
                OleDbConnection con = new OleDbConnection(constr);
                con.Open();
                cmd.Connection = con;
                cmd.CommandText = @"SELECT " + purchaseUnit + "*price AS line_total FROM [item] WHERE item_code =" + item;
                OleDbDataReader sdr = cmd.ExecuteReader();
                string lineTotal = "";
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
        }

        protected void ddlItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.getQuantity();
        }

        protected void itemsGrid_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(itemsGrid.DataKeys[e.RowIndex].Values[0]);
            foreach (Dictionary<string, int> purchaseItem in itemList)
            {
                Debug.WriteLine("ID: " + ID);
                Debug.WriteLine("item: " + purchaseItem["item"]);
                if (purchaseItem["item"] == ID)
                {
                    itemList.Remove(purchaseItem);
                    ids.Remove(purchaseItem["item"]);
                    break;
                }

            }

            this.BindGrid();
        }

        protected void getQuantity()
        {
            string itemID = ddlItem.SelectedValue.ToString();
            string queryID = "SELECT quantity FROM item WHERE item_code = " + itemID;
            OleDbCommand idd = new OleDbCommand(queryID);
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                idd.Connection = con;
                con.Open();

                OleDbDataReader sdr = idd.ExecuteReader();
                while (sdr.Read())
                {
                    quantity = Convert.ToInt32(sdr.GetValue(0).ToString());
                }

                Debug.WriteLine("quantity of item = " + quantity);
                con.Close();
            }

            IEnumerable<int> numbers = Enumerable.Range(1, quantity);
            ddlPurchaseUnit.DataSource = numbers;
            ddlPurchaseUnit.DataBind();
        }

 

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            item = int.Parse(ddlItem.SelectedValue.ToString());
            purchaseUnit = int.Parse(ddlPurchaseUnit.SelectedValue.ToString());

            if (ids.Contains(item))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('The item already exists in cart.');", true);
            }
            else
            {
      
                ids.Add(item);

                Dictionary<string, int> itemDetails = new Dictionary<string, int>();
                itemDetails.Add("item", item);
                itemDetails.Add("purchaseUnit", purchaseUnit);

                itemList.Add(itemDetails);

                this.BindGrid();
            }
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
              
                cmd.CommandText = @"SELECT item_code AS [ID], item_name, description, price, "+purchaseUnit+" AS unit, " + purchaseUnit +"*price AS line_total FROM [item] WHERE item_code ="+item;
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