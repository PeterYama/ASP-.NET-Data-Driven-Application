using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Data_Driven_6518_Survey_App
{
    public partial class StaffLogin : System.Web.UI.Page
    {
        string userName;
        string userPass;
        string queryString;
        string adminID;
        DatabaseManager db;
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader reader;
        string ok = "alert(\"Success !\");";
        string notOk = "alert(\"User Name or Password don't match !\");";

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DatabaseManager();
            conn = new SqlConnection();
        }

        protected void LoginConfirmBtn_Click(object sender, EventArgs e)
        {
            conn = db.openConnection();
            queryString = "select * from staff where staff_login = @_UserName AND staff_password = @_userPass";
            using (SqlCommand sqlCommand = new SqlCommand(queryString, conn))
            {
                userName = userNameText.Text;
                userPass = passwordText.Text;
                sqlCommand.Parameters.Add("@_UserName", SqlDbType.VarChar, 50).Value = userName;
                sqlCommand.Parameters.Add("@_userPass", SqlDbType.VarChar, 50).Value = userPass;
                sqlCommand.Prepare();

                reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    adminID = reader["staff_ID"].ToString();
                    ScriptManager.RegisterStartupScript(this, GetType(),
                      "ServerControlScript", ok, true);
                    //redirect admin to search page
                    Response.Redirect("StaffSearch.aspx",false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(),
                     "ServerControlScript", notOk, true);
                }

            }
        }
    }
}