using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ShadyBusiness
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
   
            if (!this.IsPostBack)
            {
                Debug.WriteLine("role = " + User.IsInRole("Admin"));
                this.BindPurchaseGrid("1");//purchase details
                this.BindStockoutGrid("item_name"); //out of stock
                this.BindInactiveCustomersGrid(); // inactive customers
                this.BindTopItemsGrid(@"SELECT * FROM (select top 5 i.item_code, i.item_name, sum(pitem.purchase_unit) as [items_sold] 
                from item i 
                join purchase_item pitem on i.item_code = pitem.item_code
                join purchase p on p.purchase_id= pitem.purchase_id
                where p.purchase_date  > CURRENT_TIMESTAMP -31
                group by i.item_code, i.item_name 
                order by items_sold desc) as d;");//top items
                this.BindUnpopularItemsGrid();//unpopular items
                dashboardCards();
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CDKNK8O;Integrated Security=SSPI;Initial Catalog=sb");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM item WHERE quantity <= 10", con);
            var reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-CDKNK8O;Integrated Security=SSPI;Initial Catalog=sb");
                con1.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT count(item_code) as [count] FROM item WHERE quantity <= 10", con1);
                var dr = cmd1.ExecuteReader();
                string val = "";
                if (dr.Read())
                {
                    val = dr["count"].ToString();
                }
                con1.Close();
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                if (!IsPostBack)
                {
                    ScriptManager.RegisterStartupScript(Page, this.GetType(), "Exception", "alert('ALERT: " + val + " item has less than 10 units in stock')", true);
                }
            }
            con.Close();
        }

        private void dashboardCards()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-CDKNK8O;Integrated Security=SSPI;Initial Catalog=sb");
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(member_number) as [count] from customer c", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Label1.Text = dr["count"].ToString();
            }
            con.Close();

            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-CDKNK8O;Integrated Security=SSPI;Initial Catalog=sb");
            con2.Open();
            SqlCommand cmd2 = new SqlCommand("select count(quantity) as count from item", con2);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                Label3.Text = dr2["count"].ToString();
            }
            con2.Close();

            SqlConnection con3 = new SqlConnection("Data Source=DESKTOP-CDKNK8O;Integrated Security=SSPI;Initial Catalog=sb");
            con3.Open();
            SqlCommand cmd3 = new SqlCommand("select count(purchase_id) as [count] from purchase where purchase_date > CURRENT_TIMESTAMP - 31", con3);
            SqlDataReader dr3 = cmd3.ExecuteReader();
            if (dr3.Read())
            {
                Label2.Text = dr3["count"].ToString();
            }
            con3.Close();

            SqlConnection con4 = new SqlConnection("Data Source=DESKTOP-CDKNK8O;Integrated Security=SSPI;Initial Catalog=sb");
            con4.Open();
            SqlCommand cmd4 = new SqlCommand("select sum(p.total_amount) as [count] from purchase p where p.purchase_date > CURRENT_TIMESTAMP - 31", con4);
            SqlDataReader dr4 = cmd4.ExecuteReader();
            if (dr4.Read())
            {
                Label4.Text = dr4["count"].ToString();
            }
            con4.Close();
        }

        private void BindPurchaseGrid(string val) //purchase details
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT p.purchase_id AS [Purchase ID], p.purchase_date AS [Purchased Date], p.total_amount AS [Total Amount], c.customer_name AS [Customer]
            FROM customer c JOIN purchase p ON c.member_number=p.member_number 
            WHERE p.purchase_date > CURRENT_TIMESTAMP - 31 and c.member_number=" + val + " ORDER BY p.purchase_date";
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

        private void BindStockoutGrid(string val) // out of stock
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT item_name AS [Item Name], price AS [Price], quantity AS [Quantity], stocked_date AS [Stocked Date]
            FROM item
            WHERE quantity <= 10 order by " + val;
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("item");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView2.DataSource = dt;
            GridView2.DataBind();

        }

        private void BindInactiveCustomersGrid()// inactive customers
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT c.member_number AS [Customer ID], c.customer_name AS [Customer Name], c.customer_number AS [Phone Number], customer_email AS [Email Address], member_type AS [Membership Type] 
            FROM Customer c
            WHERE c.member_number NOT IN(
            SELECT p.member_number FROM purchase p
            WHERE p.purchase_date >= CURRENT_TIMESTAMP - 31
            )
            ";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("item");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView3.DataSource = dt;
            GridView3.DataBind();

        }
        private void BindTopItemsGrid(string query) // top items
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("item");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView4.DataSource = dt;
            GridView4.DataBind();

        }

        private void BindUnpopularItemsGrid() // unpopular items
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT item_code AS [ID], item_name AS [Item Name], price AS [Price], quantity AS [Quantity], stocked_date AS [Stocked Date] FROM Item i
                                WHERE i.item_code NOT IN (
                                SELECT it.item_code FROM item it
                                join purchase_item pit on it.item_code=pit.item_code
                                join purchase p on pit.purchase_id=p.purchase_id
                                WHERE p.purchase_date >= CURRENT_TIMESTAMP - 31
                                )";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("item");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView5.DataSource = dt;
            GridView5.DataBind();

        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)//top items
        {

            string selectedValue = DropDownList2.SelectedItem.Value;
            Console.WriteLine(selectedValue);
            System.Diagnostics.Debug.WriteLine(selectedValue);
            if (selectedValue.Equals("Year"))
            {
                string query = @"SELECT * FROM (select top 5 i.item_code, i.item_name, sum(pitem.purchase_unit) as [items_sold] 
                from item i 
                join purchase_item pitem on i.item_code = pitem.item_code
                join purchase p on p.purchase_id= pitem.purchase_id
                where p.purchase_date  > CURRENT_TIMESTAMP -356
                group by i.item_code, i.item_name 
                order by items_sold desc) as d;";
                BindTopItemsGrid(query);
            }
            else
            {
                string query = @"SELECT * FROM (select top 5 i.item_code, i.item_name, sum(pitem.purchase_unit) as [items_sold] 
                from item i 
                join purchase_item pitem on i.item_code = pitem.item_code
                join purchase p on p.purchase_id= pitem.purchase_id
                where p.purchase_date  > CURRENT_TIMESTAMP -31
                group by i.item_code, i.item_name 
                order by items_sold desc) as d";
                BindTopItemsGrid(query);
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)// purchase details
        {
            string selectedValue = DropDownList1.SelectedItem.Value;
            BindPurchaseGrid(selectedValue);
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e) // out of stock
        {
            string selectedValue = DropDownList3.SelectedItem.Value;
            if (selectedValue.Equals("name"))
            {
                string val = "item_name asc";
                BindStockoutGrid(val);
            }
            else if (selectedValue.Equals("quantity"))
            {
                string val = "quantity desc";
                BindStockoutGrid(val);
            }
            else
            {
                string val = "stocked_date desc";
                BindStockoutGrid(val);
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String pid = GridView1.SelectedRow.Cells[1].Text;

            Session["pid"] = pid;

            Debug.WriteLine("purchase id = " + pid);

            Response.Redirect("PurchaseDetails.aspx");
        }

        protected void GridView5_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
       
                String ID = GridView5.DataKeys[e.RowIndex].Values[0].ToString();
                Debug.WriteLine("item id = " + ID);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("DELETE FROM [item] WHERE item_code=" + ID + ";"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindUnpopularItemsGrid();
        }


        protected void GridView5_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView5.EditIndex)
            {
                (e.Row.Cells[0].Controls[0] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }
    }
}