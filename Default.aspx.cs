using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShadyBusiness
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //Dictionary<string, string> userDetail = (Dictionary<string, string>)Session["Authenticateduser"];
                //(Dictionary<string, string>)Session["Authenticateduser"].Add(DictKey, true);
                //Debug.WriteLine(userDetail.Count());
                String userType = (String) Session["Authenticateduser"];
                Debug.WriteLine("user iden"+User.Identity.Name);
                Debug.WriteLine("user type = " +userType);

            }


        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}