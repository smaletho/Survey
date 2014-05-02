using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ThreeSixSafety
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string runScript = "<script>alert('";
            if (nameBox.Text == "")
            {
                runScript += "Please enter your name.');</script>";
            }
            else
            {
                Session["Name"] = nameBox.Text;
                Response.Redirect("~/Survey.aspx", false);
            }
            ClientScript.RegisterClientScriptBlock(this.GetType(), "response", runScript);

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            if (loginBox.Text != "barry" && passwordBox.Text != "hull")
            {
                string al = "<script>alert('Username or password are incorrect. Try again.');</script>";
                ClientScript.RegisterClientScriptBlock(this.GetType(), "response", al);
            }
            else
            {
                Response.Redirect("~/Admin.aspx");
                Session["loggedIn"] = "yes";
            }
        }
    }
}