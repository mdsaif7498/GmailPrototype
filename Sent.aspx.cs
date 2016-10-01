using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Text;


public partial class Sent : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridSent();
        }
    }

    private void BindGridSent()
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConnection.Open();
        SqlCommand objCommand = new SqlCommand("spGetSentMails", objConnection);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objUserEmailId = new SqlParameter();
        objUserEmailId.ParameterName = "@EmailId";
        objUserEmailId.SqlDbType = SqlDbType.VarChar;
        objUserEmailId.Value = Session["UserId"].ToString();
        objCommand.Parameters.Add(objUserEmailId);

        SqlDataAdapter objAdap = new SqlDataAdapter(objCommand);
        DataSet ds = new DataSet();
        objAdap.Fill(ds);
        gvSent.DataSource = ds.Tables[0];
        gvSent.DataBind();
    }


    protected void gvSent_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSent.PageIndex = e.NewPageIndex;
    }

  
   
    protected void gvSent_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "delMail")
        {
            object dataKeyValue = gvSent.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
            objConn.Open();

            SqlCommand objCommand = new SqlCommand("spDeleteSent", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;
            gvSent.EditIndex = -1;
            objCommand.Parameters.Add("@MailId", SqlDbType.Int).Value = dataKeyValue;
            objCommand.ExecuteNonQuery();
            objConn.Close();
            gvSent.DataBind();
        }
        else
        {
            if (e.CommandName == "Select")
            {
                int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
                gvSent.SelectRow(rowIndex);
                SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
                objConnection.Open();
                SqlCommand objCommand = new SqlCommand("spGetSelectedSentRow", objConnection);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.Add("@MailId", SqlDbType.Int).Value = gvSent.SelectedDataKey.Value;
                SqlDataReader rdr = objCommand.ExecuteReader();
                while (rdr.Read())
                {
                    lblSentMail.Text = "<br><b>MailTo:</b> " + rdr["MailTo"].ToString() + " <br><b>Subject:</b> " + rdr["Subject"].ToString() + " <br><b>Message:</b> " + rdr["Message"].ToString() + " <br><b>Date:</b> " + rdr["Date"].ToString();
                }

               
            }
        }
     
        
    }

   


  
}


