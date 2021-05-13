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
    public partial class CategoryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // default load data
            if (!this.IsPostBack)
            {
                Console.WriteLine("inside post back");
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
            cmd.CommandText = "SELECT * FROM [category]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("category");

            using (OleDbDataReader sdr = cmd.ExecuteReader())
            {
                dt.Load(sdr);
            }

            con.Close();

            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string category = txtCategory.Text.ToString();  
            string query = "INSERT INTO [category] values ('"+ category +"')";
            OleDbCommand cmd = new OleDbCommand(query);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                cmd.Connection = con;
                con.Open();
                int affected = cmd.ExecuteNonQuery();
                con.Close();

                txtCategory.Text = "";
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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int ID = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                //using (OleDbCommand cmd = new OleDbCommand("UPDATE [item] SET category_id = null WHERE category_id =" + ID + ";"))
                //{
                //    cmd.Connection = con;
                //    con.Open();
                //    cmd.ExecuteNonQuery();
                //    con.Close();
                //}
                using (OleDbCommand cmd = new OleDbCommand("DELETE FROM [category] WHERE category_id =" + ID + ";"))
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
            string Name = (row.Cells[2].Controls[0] as TextBox).Text;
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("update [category] set category_name = '" + Name + "' where category_id = " + ID))
                {

                    cmd.Connection = con;
                    con.Open();

                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }

            GridView1.EditIndex = -1;
            this.BindGrid();
        }
  


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }
    }
}