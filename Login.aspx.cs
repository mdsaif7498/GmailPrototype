using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie objCookie = Request.Cookies["IsAuthenticated"];
        if (objCookie != null)
        {
            Session["UserId"] = objCookie["UserId"];

        }

        //if (this.IsPostBack == false)
        //{
        //    if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
        //    {
        //        Session["New"] = Request.Cookies["UserName"].Value;
        //        //Response.Redirect(string.Format("~/Inbox.aspx"));
        //    }
        //}
        
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {

        if (cbRememberMe.Checked)
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(1);
        }
        else
        {
            Response.Cookies["UserName"].Expires = DateTime.Now.AddMinutes(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddMinutes(-1);
        }
        Response.Cookies["UserName"].Value = txtUserName.Text.Trim();
        Response.Cookies["Password"].Value = txtPassword.Text.Trim();

        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConnection.Open();
        SqlCommand objCommand = new SqlCommand("select count(*) from GRDetails where UserName='"+txtUserName.Text+"' and Password='"+txtPassword.Text+"'");
        objCommand.Connection = objConnection;
        int OBJ=Convert.ToInt32(objCommand.ExecuteScalar());
        if (OBJ > 0)
        {
            Session["UserId"] = txtUserName.Text;
            Response.Redirect("Inbox.aspx");
        }
        else
        {
            Response.Write("Invalid Username or Password");
        }
    }
    //protected void cbRememberMe_CheckedChanged(object sender, EventArgs e)
    //{
    //    HttpCookie objCookie = new HttpCookie("IsAuthenticated");
    //    objCookie["UserId"] = txtUserName.Text;
    //    objCookie["Password"] = txtPassword.Text;
    //    objCookie.Expires = DateTime.Now.AddDays(2);
    //    Response.Cookies.Add(objCookie);
    //    Response.Redirect("Inbox.aspx");
    //}
}