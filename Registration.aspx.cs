using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Registration : System.Web.UI.Page
{

    int number = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["AppSettings"]);
    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            BindGridRegister();
        }
    }

    private void BindGridRegister()
    {
        SqlConnection objConnection = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        SqlCommand objCommand = new SqlCommand("spSelectGRDetails", objConnection);
        objCommand.CommandType = CommandType.StoredProcedure;
        SqlDataAdapter objAdap = new SqlDataAdapter(objCommand);
        DataSet ds = new DataSet();
        objAdap.Fill(ds);
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtFirstName.Text = string.Empty;
        txtLastName.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txtConfirmPassword.Text = string.Empty;
        txtMobile.Text = string.Empty;
        txtUserName.Text = string.Empty;
        txtCalender.Text = string.Empty;
        ddlGender.SelectedIndex = 0;

    }

    private bool CheckDuplicate(string firstName, string lastName, string userName, string passWord, string mobile, SqlConnection objConnection, string type = null, string id = null)
    {
        //return false;
        string ssql = " ";
        if (type == null)
        {
            ssql = "select COUNT(*) from GRDetails where FirstName='" + firstName.Trim() + "'and LastName='" + lastName.Trim() + "' and UserName='" + userName.Trim() + "' and Password='" + passWord.Trim() + "' and Mobile='"+ mobile.Trim() +"'";
        }
        else
        {
            ssql = "select COUNT(*) from GRDetails where FirstName='" + firstName.Trim() + "'and LastName='" + lastName.Trim() + "' and UserName='" + userName.Trim() + "' and Password='" + passWord.Trim() + "' and Mobile='" + mobile.Trim() +"' and ID<>'" + id.Trim() + "'";
        }
        SqlCommand objCommand = new SqlCommand(ssql, objConnection);

        int result = Convert.ToInt16(objCommand.ExecuteScalar());
        objCommand.Dispose();

        if (result >= 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
        SqlConnection objConn = new SqlConnection(@"Data Source=SAIF-PC\SQLEXPRESS;Initial Catalog=GmailDatabase;Integrated Security=True");
        objConn.Open();
        bool IsDuplicateRecord = CheckDuplicate(txtFirstName.Text, txtLastName.Text, txtUserName.Text, txtPassword.Text,txtMobile.Text, objConn);
        if (IsDuplicateRecord)
        {
            Response.Write("!!! Duplicate record found");
            objConn.Close();
            return;
        }
        SqlCommand objCommand = new SqlCommand("SpInsertGRDetails", objConn);
        objCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter objFirstName = new SqlParameter();
        objFirstName.ParameterName = "@FirstName";
        objFirstName.SqlDbType = SqlDbType.VarChar;
        objFirstName.Size = 100;
        objFirstName.Value = txtFirstName.Text;
        objCommand.Parameters.Add(objFirstName);

        SqlParameter objLastName = new SqlParameter();
        objLastName.ParameterName = "@LastName";
        objLastName.SqlDbType = SqlDbType.VarChar;
        objLastName.Size = 100;
        objLastName.Value = txtLastName.Text;
        objCommand.Parameters.Add(objLastName);

        SqlParameter objUserName = new SqlParameter();
        objUserName.ParameterName = "@UserName";
        objUserName.SqlDbType = SqlDbType.VarChar;
        objUserName.Size = 100;
        objUserName.Value = txtUserName.Text;
        objCommand.Parameters.Add(objUserName);

        SqlParameter objPassword = new SqlParameter();
        objPassword.ParameterName = "@Password";
        objPassword.SqlDbType = SqlDbType.VarChar;
        objPassword.Size = 50;
        objPassword.Value = txtPassword.Text;
        objCommand.Parameters.Add(objPassword);

        SqlParameter objConfirmPassword = new SqlParameter();
        objConfirmPassword.ParameterName = "@ConfirmPassword";
        objConfirmPassword.SqlDbType = SqlDbType.VarChar;
        objConfirmPassword.Size = 50;
        objConfirmPassword.Value = txtConfirmPassword.Text;
        objCommand.Parameters.Add(objConfirmPassword);

        SqlParameter objCalender = new SqlParameter();
        objCalender.ParameterName = "@Birthdate";
        objCalender.SqlDbType = SqlDbType.VarChar;
        objCalender.Size = 50;
        objCalender.Value = txtCalender.Text;
        objCommand.Parameters.Add(objCalender);

        SqlParameter objGender = new SqlParameter();
        objGender.ParameterName = "@Gender";
        objGender.SqlDbType = SqlDbType.VarChar;
        objGender.Size = 50;
        objGender.Value = ddlGender.SelectedValue;
        objCommand.Parameters.Add(objGender);

        SqlParameter objMobile = new SqlParameter();
        objMobile.ParameterName = "@Mobile";
        objMobile.SqlDbType = SqlDbType.VarChar;
        objMobile.Size = 100;
        objMobile.Value = txtMobile.Text;
        objCommand.Parameters.Add(objMobile);

        SqlParameter objType = new SqlParameter();
        objType.ParameterName = "@Type";
        objType.SqlDbType = SqlDbType.VarChar;
        objType.Size = 50;
        objType.Value = "Insert";
        objCommand.Parameters.Add(objType);

        SqlParameter objReturnValue = new SqlParameter();
        objReturnValue.ParameterName = "@ReturnIdentityValue";
        objReturnValue.SqlDbType = SqlDbType.Int;
        objReturnValue.Direction = ParameterDirection.ReturnValue;
        objCommand.Parameters.Add(objReturnValue);

        SqlParameter objOutParam = new SqlParameter();
        objOutParam.ParameterName = "@OutParam";
        objOutParam.SqlDbType = SqlDbType.VarChar;
        objOutParam.Size = 50;
        objOutParam.Direction = ParameterDirection.Output;
        objCommand.Parameters.Add(objOutParam);
        int result = objCommand.ExecuteNonQuery();


        if(result==1)
        {
            BindGridRegister();
            lblResult.Text = string.Format("{0} {1}, your account created successfully", txtFirstName.Text, txtLastName.Text);
            
           
        }
        else
        {

            lblResult.Text = string.Format("Account not created, some entries are missing");
        }

        objConn.Close();
        objCommand.Dispose();
        Response.Redirect("Login.aspx");
    }

   
}