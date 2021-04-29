using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShadyBusiness
{
    public partial class Profile : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.displayInfo();
            }

        }

        private void displayInfo()
        {
            string query = "SELECT user_name, user_email, user_password FROM [user] WHERE user_id = " + User.Identity.Name;

            OleDbCommand val = new OleDbCommand(query);

            using (OleDbConnection con = new OleDbConnection(constr))
            {
                val.Connection = con;
                con.Open();

                OleDbDataReader sdr = val.ExecuteReader();
                while (sdr.Read())
                {
                    txtName.Text = sdr.GetValue(0).ToString();
                    txtEmail.Text = sdr.GetValue(1).ToString();
                    txtPassword.Text = sdr.GetValue(2).ToString();
                }

                con.Close();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text.ToString();
            Debug.WriteLine("new pas = " + password);
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                using (OleDbCommand ins = new OleDbCommand("UPDATE [user] SET user_password = '" + password + "' WHERE user_id = " + User.Identity.Name + ";"))
                {
                    ins.Connection = con;
                    con.Open();
                    ins.ExecuteNonQuery();
                    con.Close();
                }
            }
    
                ScriptManager.RegisterStartupScript(Page, this.GetType(), "Exception", "alert('User Password Changed')", true);
            
            displayInfo();
        }
    }
}