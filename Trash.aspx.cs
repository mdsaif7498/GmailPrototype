using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Trash : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridTrash();
        }
    }

    private void BindGridTrash()
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConnection.Open();

        SqlCommand objCommand = new SqlCommand("spGetTrashMail", objConnection);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objUserEmailId = new SqlParameter();
        objUserEmailId.ParameterName = "@EmailId";
        objUserEmailId.SqlDbType = SqlDbType.VarChar;
        objUserEmailId.Value = Session["UserId"].ToString();
        objCommand.Parameters.Add(objUserEmailId);


        SqlDataAdapter objAdap = new SqlDataAdapter(objCommand);
        DataSet ds = new DataSet();
        objAdap.Fill(ds);
        gvTrash.DataSource = ds.Tables[0];
        gvTrash.DataBind();
        objConnection.Close();
    }

   
    protected void gvTrash_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvTrash.PageIndex = e.NewPageIndex;
      
    }

    
    protected void gvTrash_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName=="delMail")
        {
            object dataKeyValue = gvTrash.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
            objConn.Open();

            SqlCommand objCommand = new SqlCommand("spDeleteTrash1", objConn);
            objCommand.CommandType = CommandType.StoredProcedure;
            gvTrash.EditIndex = -1;
            objCommand.Parameters.Add("@MailId", SqlDbType.Int).Value = dataKeyValue;

            SqlParameter objUserEmailId = new SqlParameter();
            objUserEmailId.ParameterName = "@EmailId";
            objUserEmailId.SqlDbType = SqlDbType.VarChar;
            objUserEmailId.Value = Session["UserId"].ToString();
            objCommand.Parameters.Add(objUserEmailId);
            objCommand.ExecuteNonQuery();
            objConn.Close();
            gvTrash.DataBind();
        }
    }
  

   
}