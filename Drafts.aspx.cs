using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Drafts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (!IsPostBack)
        {
            BindGridDraft();
        }
    }

    private void BindGridDraft()
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConnection.Open();

        SqlCommand objCommand1 = new SqlCommand("spGetDraftsMails", objConnection);
        objCommand1.CommandType = CommandType.StoredProcedure;

        SqlParameter objUserEmailId = new SqlParameter();
        objUserEmailId.ParameterName = "@EmailId";
        objUserEmailId.SqlDbType = SqlDbType.VarChar;
        objUserEmailId.Value = Session["UserId"].ToString();
        objCommand1.Parameters.Add(objUserEmailId);

        SqlDataAdapter objAdap = new SqlDataAdapter(objCommand1);

        DataSet ds = new DataSet();
        objAdap.Fill(ds);
        gvDrafts.DataSource = ds.Tables[0];
        gvDrafts.DataBind();
        objConnection.Close();
    }

    protected void gvDrafts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDrafts.PageIndex = e.NewPageIndex;
     
    }
    protected void gvDrafts_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int rowNo = e.RowIndex;
        string id = ((LinkButton)gvDrafts.Rows[rowNo].Cells[0].FindControl("lnkBtnSubject")).Text;
        SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConn.Open();

        SqlCommand objCommand1 = new SqlCommand("spDeleteDrafts", objConn);
        objCommand1.CommandType = CommandType.StoredProcedure;

        SqlParameter objMailId = new SqlParameter();
        objMailId.ParameterName = "@MailId";
        objMailId.SqlDbType = SqlDbType.Int;
        objMailId.Value = id;
        objCommand1.Parameters.Add(objMailId);
        objCommand1.ExecuteNonQuery();
        objConn.Close();
     
    }
   


    protected void gvDrafts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "delMail")
        {
            object dataKeyValue = gvDrafts.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
            objConn.Open();

            SqlCommand objCommand = new SqlCommand("spDeleteDrafts", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;
            gvDrafts.EditIndex = -1;
            objCommand.Parameters.Add("@MailId", SqlDbType.Int).Value = dataKeyValue;
            objCommand.ExecuteNonQuery();
            objConn.Close();
            gvDrafts.DataBind();
        }
    }
}