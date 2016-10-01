using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Collections.Specialized;
using System.Drawing;

public partial class Inbox : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridInbox();
            mvInbox.ActiveViewIndex = 0;
        }
    }

    


    private void BindGridInbox()
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConnection.Open();
        SqlCommand objCommand = new SqlCommand("spGetInboxMail", objConnection);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objUserEmailId = new SqlParameter();
        objUserEmailId.ParameterName = "@EmailId";
        objUserEmailId.SqlDbType = SqlDbType.VarChar;
        objUserEmailId.Value = Session["UserId"].ToString();
        objCommand.Parameters.Add(objUserEmailId);

        SqlDataAdapter objAdap = new SqlDataAdapter(objCommand);
        DataSet ds = new DataSet();
        objAdap.Fill(ds);
        gvInbox.DataSource = ds.Tables[0];
        gvInbox.DataBind();
            
    }

    

    protected void gvInbox_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            foreach (TableCell cell in e.Row.Cells)
            {
                HiddenField hifId = (HiddenField)e.Row.Cells[0].FindControl("hfSeenFlag"); //The hidden field is a control that stores a value but does not display that value to the user. It would be similar to using a label that had a value, but was hidden.
                if (Convert.ToInt16(hifId.Value) == 0)
                {
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
            }
        }
    }

   

    protected void gvInbox_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delMail")
        {
            object dataKeyValue = gvInbox.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
            objConn.Open();
            SqlCommand objCommand = new SqlCommand("spInboxToTrash", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;
            gvInbox.EditIndex = -1;
            objCommand.Parameters.Add("@MailId", SqlDbType.Int).Value = dataKeyValue;
            objCommand.ExecuteNonQuery();
        }
        else if (e.CommandName == "Select")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                gvInbox.SelectRow(rowIndex);
                SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("spGetSelectedInboxRow", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("@MailId", SqlDbType.Int).Value = gvInbox.SelectedDataKey.Value;
                SqlDataReader rdr = objCommand.ExecuteReader();
                while (rdr.Read())
                {
                    lblInboxMail.Text = "<br><b>MailFrom:</b> " + rdr["MailFrom"].ToString() + " <br><b>Subject:</b> " + rdr["Subject"].ToString() + " <br><b>Message:</b> " + rdr["Message"].ToString() + " <br><b>Date:</b> " + rdr["Date"].ToString();
                }
                btnForward.Visible = true;
                btnReply.Visible = true;
            }
      
    }

    

    protected void gvInbox_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvInbox.PageIndex = e.NewPageIndex;
    }
   
    protected void gvInbox_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblSenderFrom.Text = gvInbox.SelectedRow.Cells[0].Text;
        lblSenderSubject.Text = (gvInbox.SelectedRow.FindControl("lnkBtnSubject") as LinkButton).Text;
        lblSenderMessage.Text = gvInbox.SelectedRow.Cells[2].Text;
        lblSenderDate.Text = gvInbox.SelectedRow.Cells[3].Text;
        lblReplySenderFrom.Text = Session["UserId"].ToString();
        lblReplySenderTo.Text = gvInbox.SelectedRow.Cells[0].Text;
    }
    protected void btnForward_Click(object sender, EventArgs e)
    {
        mvInbox.ActiveViewIndex = 1;
    }
    protected void btnSendForward_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConn.Open();
        SqlCommand objCommand = new SqlCommand("spComposeMail", objConn);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objMailFrom = new SqlParameter();
        objMailFrom.ParameterName = "@MailFrom";
        objMailFrom.SqlDbType = SqlDbType.VarChar;
        objMailFrom.Size = 50;
        objMailFrom.Value = lblSenderFrom.Text;
        objCommand.Parameters.Add(objMailFrom);

        SqlParameter objMailTo = new SqlParameter();
        objMailTo.ParameterName = "@MailTo";
        objMailTo.SqlDbType = SqlDbType.VarChar;
        objMailTo.Size = 50;
        objMailTo.Value = txtSenderTo.Text;
        objCommand.Parameters.Add(objMailTo);

        SqlParameter objSubject = new SqlParameter();
        objSubject.ParameterName = "@Subject";
        objSubject.SqlDbType = SqlDbType.VarChar;
        objSubject.Size = 50;
        objSubject.Value = lblSenderSubject.Text;
        objCommand.Parameters.Add(objSubject);

        SqlParameter objMessage = new SqlParameter();
        objMessage.ParameterName = "@Message";
        objMessage.SqlDbType = SqlDbType.VarChar;
        objMessage.Size = 100;
        objMessage.Value = lblSenderMessage.Text;
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
    protected void btnReply_Click(object sender, EventArgs e)
    {
        mvInbox.ActiveViewIndex = 2;
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConn.Open();
        SqlCommand objCommand = new SqlCommand("spComposeMail", objConn);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objMailFrom = new SqlParameter();
        objMailFrom.ParameterName = "@MailFrom";
        objMailFrom.SqlDbType = SqlDbType.VarChar;
        objMailFrom.Size = 50;
        objMailFrom.Value = lblReplySenderFrom.Text;
        objCommand.Parameters.Add(objMailFrom);

        SqlParameter objMailTo = new SqlParameter();
        objMailTo.ParameterName = "@MailTo";
        objMailTo.SqlDbType = SqlDbType.VarChar;
        objMailTo.Size = 50;
        objMailTo.Value = lblReplySenderTo.Text;
        objCommand.Parameters.Add(objMailTo);

        SqlParameter objSubject = new SqlParameter();
        objSubject.ParameterName = "@Subject";
        objSubject.SqlDbType = SqlDbType.VarChar;
        objSubject.Size = 50;
        objSubject.Value = txtReplySenderSubject.Text;
        objCommand.Parameters.Add(objSubject);

        SqlParameter objMessage = new SqlParameter();
        objMessage.ParameterName = "@Message";
        objMessage.SqlDbType = SqlDbType.VarChar;
        objMessage.Size = 100;
        objMessage.Value = txtReplySenderMessage.Text;
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


        lblResultShow.Text = "Email has been successfully sent..!!";
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        mvInbox.ActiveViewIndex = 0;
    }
    protected void btBacktoMailView_Click(object sender, EventArgs e)
    {
        mvInbox.ActiveViewIndex = 0;
    }
}
