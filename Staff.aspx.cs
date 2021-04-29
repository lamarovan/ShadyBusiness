using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShadyBusiness
{
    public partial class Staff : System.Web.UI.Page
    {
        string userType, userId = "";
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid();
                getAuthenticatedUserType();
                if (userType.Equals("staff"))
                {
                    Response.Redirect("Dashboard.aspx");
                }
            }

        }

        private void getAuthenticatedUserType()
        {
            userId = HttpContext.Current.User.Identity.Name;
            string query = "SELECT user_type FROM [user] WHERE user_id = " + userId;
            OleDbCommand val = new OleDbCommand(query);
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                val.Connection = con;
                con.Open();
                OleDbDataReader sdr = val.ExecuteReader();
                while (sdr.Read())
                {
                    userType = sdr.GetValue(0).ToString();
                }

                Debug.WriteLine("user type = " + userType);
                con.Close();
            }
        }

            private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM [user]";
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable("user");

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
            string email = txtEmail.Text.ToString();
            string password = txtPassword.Text.ToString();
            string name = txtName.Text.ToString();
            string type = ddlUserType.SelectedValue;


            string query = "INSERT INTO [user] values ('" + email + "', '" + password + "', '" + name + "','" + type  + "')";
            OleDbCommand cmd = new OleDbCommand(query);

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                txtEmail.Text = "";
                txtPassword.Text = "";
                txtName.Text = "";

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
                using (OleDbCommand cmd = new OleDbCommand("DELETE FROM [user] WHERE user_id=" + ID + ";"))
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
            string email = (row.Cells[2].Controls[0] as TextBox).Text;
            string password = (row.Cells[3].Controls[0] as TextBox).Text;
            string name = (row.Cells[4].Controls[0] as TextBox).Text;
            string type = (row.Cells[5].Controls[0] as TextBox).Text;


            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand cmd = new OleDbCommand("update [user] set user_email = '" + email + "', user_password = '" + password + "', user_name = '" + name + "', user_type = '" + type + "' where user_id = " + ID + ";"))
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

    }
}