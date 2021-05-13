using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShadyBusiness
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string inputEmail = txtEmail.Text.ToString();
            string inputPassword = txtPassword.Text.ToString();
            string email="";
            string password="";
            string userType = "";
            string userId = "";
            string userName;

            string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            string query = "SELECT * FROM [user] WHERE user_email='" + inputEmail +"'";
            OleDbCommand cmd = new OleDbCommand(query);
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            cmd.Connection = con;
            int affected = cmd.ExecuteNonQuery();
            OleDbDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                email = sdr.GetValue(sdr.GetOrdinal("user_email")).ToString();
                password = sdr.GetValue(sdr.GetOrdinal("user_password")).ToString();
                userType = sdr.GetValue(sdr.GetOrdinal("user_type")).ToString();
                userId = sdr.GetValue(sdr.GetOrdinal("user_id")).ToString();
                userName = sdr.GetValue(sdr.GetOrdinal("user_name")).ToString();


                Session["AuthenticatedUser"] = userType;

            }



            if (inputEmail == email && inputPassword == password)
            {
                FormsAuthentication.RedirectFromLoginPage(userId, true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Login failed", "alert('Incorrect User Credentials')", true);
            }
        }
    }
}