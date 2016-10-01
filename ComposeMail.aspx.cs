using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;




public partial class ComposeMail : System.Web.UI.Page
{
   

    protected void Page_Load(object sender, EventArgs e)
    {
        string name;
        if (Session["UserId"] == null)
        {
            name = Session["New"].ToString();
        }
        else
        {
            name = Session["UserId"].ToString();
        } 
    }

    
    protected void btnSend_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConn.Open();

     
        lblSenderId.Text = Session["UserId"].ToString();
        

        SqlCommand objCommand = new SqlCommand("spComposeMail", objConn);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objMailFrom = new SqlParameter();
        objMailFrom.ParameterName = "@MailFrom";
        objMailFrom.SqlDbType = SqlDbType.VarChar;
        objMailFrom.Size = 50;
        objMailFrom.Value = lblSenderId.Text;
        objCommand.Parameters.Add(objMailFrom);

        SqlParameter objMailTo = new SqlParameter();
        objMailTo.ParameterName = "@MailTo";
        objMailTo.SqlDbType = SqlDbType.VarChar;
        objMailTo.Size = 50;
        objMailTo.Value = txtTo.Text;
        objCommand.Parameters.Add(objMailTo);

        SqlParameter objSubject = new SqlParameter();
        objSubject.ParameterName = "@Subject";
        objSubject.SqlDbType = SqlDbType.VarChar;
        objSubject.Size = 50;
        objSubject.Value = txtSubject.Text;
        objCommand.Parameters.Add(objSubject);

        SqlParameter objMessage = new SqlParameter();
        objMessage.ParameterName = "@Message";
        objMessage.SqlDbType = SqlDbType.VarChar;
        objMessage.Size = 100;
        objMessage.Value = txtMessage.Text;
        objCommand.Parameters.Add(objMessage);

        SqlParameter objDate = new SqlParameter();
        objDate.ParameterName = "@Date";
        objDate.SqlDbType = SqlDbType.DateTime;
        objDate.Value = DateTime.Now;
        objCommand.Parameters.Add(objDate);

        SqlParameter objSend = new SqlParameter();
        objSend.ParameterName = "@insertion";
        objSend.SqlDbType = SqlDbType.Int;
        objSend.Value = 0;
        objCommand.Parameters.Add(objSend);


        objCommand.ExecuteNonQuery();
        objConn.Close();


        lblResult.Text = "Email has been successfully sent..!!";
        
    }
       
        

      

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("Inbox.aspx");
    }
    protected void btnDraft_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConn.Open();


            SqlCommand objCommand = new SqlCommand("spComposeMail", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter objMailFrom = new SqlParameter();
            objMailFrom.ParameterName = "@MailFrom";
            objMailFrom.SqlDbType = SqlDbType.VarChar;
            objMailFrom.Size = 50;
            objMailFrom.Value = lblSenderId.Text;
            objCommand.Parameters.Add(objMailFrom);

            SqlParameter objMailTo = new SqlParameter();
            objMailTo.ParameterName = "@MailTo";
            objMailTo.SqlDbType = SqlDbType.VarChar;
            objMailTo.Size = 50;
            objMailTo.Value = txtTo.Text;
            objCommand.Parameters.Add(objMailTo);

            SqlParameter objSubject = new SqlParameter();
            objSubject.ParameterName = "@Subject";
            objSubject.SqlDbType = SqlDbType.VarChar;
            objSubject.Size = 50;
            objSubject.Value = txtSubject.Text;
            objCommand.Parameters.Add(objSubject);

            SqlParameter objMessage = new SqlParameter();
            objMessage.ParameterName = "@Message";
            objMessage.SqlDbType = SqlDbType.VarChar;
            objMessage.Size = 100;
            objMessage.Value = txtMessage.Text;
            objCommand.Parameters.Add(objMessage);

            SqlParameter objDate = new SqlParameter();
            objDate.ParameterName = "@Date";
            objDate.SqlDbType = SqlDbType.DateTime;
            objDate.Value = DateTime.Now;
            objCommand.Parameters.Add(objDate);

            SqlParameter objDraft = new SqlParameter();
            objDraft.ParameterName = "@insertion";
            objDraft.SqlDbType = SqlDbType.Int;
            objDraft.Value = 1;
            objCommand.Parameters.Add(objDraft);


            objCommand.ExecuteNonQuery();
            objConn.Close();
            lblResult.Text = "Email saved successfully..!!";
      
        
   }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtTo.Text = string.Empty;
        txtSubject.Text = string.Empty;
        txtMessage.Text = string.Empty;
    }
}