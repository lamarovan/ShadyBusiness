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
    public partial class SiteMaster : MasterPage
    {
        string userType, userId = "";
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getAuthenticatedUserType();
                if (userType.Equals("staff"))
                {
                    lnkStaff.Visible = false;
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

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}