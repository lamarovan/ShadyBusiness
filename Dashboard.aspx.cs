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
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindGrid1();
                this.BindGrid2();
                this.BindGrid3();
                this.BindGrid4(@"SELECT * FROM [item]");
            }
        }

        private void BindGrid1()
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

        private void BindGrid2()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT item_code, item_name, price FROM [item]";
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

        private void BindGrid3()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "SELECT item_code, item_name, price FROM [item]";
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
        private void BindGrid4(string query)
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

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string selectedValue = DropDownList2.SelectedItem.Value;
            Console.WriteLine(selectedValue);
            System.Diagnostics.Debug.WriteLine(selectedValue);
            if (selectedValue.Equals("Year"))
            {
                string query = @"SELECT * FROM [category]";
                BindGrid4(query);
            }
            else
            {
                string query = @"SELECT * FROM [item]";
                BindGrid4(query);
            }
        }
    }
}