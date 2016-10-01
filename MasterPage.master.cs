using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class MasterPage : System.Web.UI.MasterPage
{
    string name;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserId"] == null)
        {
            name = Session["UserId"].ToString();
            Session["EmailId"] = name;
        }
        else
        {
            lblUserName.Text = "Welcome: " + Session["UserId"].ToString();
        }
    }
    protected void btnComposeMail_Click(object sender, EventArgs e)
    {
        Response.Redirect("ComposeMail.aspx");
    }
    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("~/Login.aspx");
    }
   
}
