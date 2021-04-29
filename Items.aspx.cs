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
    public partial class Items : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            cmd.CommandText = "SELECT * FROM [item]";
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

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string item = txtItem.Text.ToString();
            string desc = txtDescription.Text.ToString();
            string price = txtPrice.Text.ToString();
            string category = ddlCategory.SelectedValue.ToString();
            string quantity = txtQuantity.Text.ToString();
            string date = DateTime.Now.ToString("MM/dd/yyyy");

            string query = "INSERT INTO [item] values ('" + item + "', '" + desc + "', '" + price + "','" + category + "', '" + quantity + "','" + date + "')";
            OleDbCommand cmd = new OleDbCommand(query);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                cmd.Connection = con;
                con.Open();
                int affected = cmd.ExecuteNonQuery();
                con.Close();

                txtItem.Text = "";
                txtDescription.Text = "";
                txtPrice.Text = "";
                txtQuantity.Text = "";
            }

            this.BindGrid();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex != GridView1.EditIndex)
            {
                (e.Row.Cells[0].Controls[2] as LinkButton).Attributes["onclick"] = "return confirm('Do you want to delete this row?');";
            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using(OleDbCommand cmd = new OleDbCommand("DELETE FROM [item] WHERE item_code=" + ID + ";"))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            this.BindGrid();
        }
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            this.BindGrid();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string name = (row.Cells[2].Controls[0] as TextBox).Text;
            string desc = (row.Cells[3].Controls[0] as TextBox).Text;
            string price = (row.Cells[4].Controls[0] as TextBox).Text;
            string category = (row.Cells[5].Controls[0] as TextBox).Text;
            string quantity = (row.Cells[6].Controls[0] as TextBox).Text;
            string date = (row.Cells[7].Controls[0] as TextBox).Text;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("update [item] set item_name = '" + name + "', description = '" + desc + "', price = '" + price + "', category_id = '" + category + "', quantity = '" + quantity + "', stocked_date = '" + date + "' where item_code = " + ID + ";"))
                {

                    cmd.Connection = con;
                    con.Open();

                    var affected = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }

            GridView1.EditIndex = -1;
            this.BindGrid();
        }

    
        protected void btnFilter_Click(object sender, EventArgs e)
        {
            string itemID = ddlItem.SelectedValue.ToString();

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM [item] WHERE item_code = " + itemID + " ";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("Dish_detail");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.BindGrid();
        }

    }
}