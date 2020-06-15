using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data_Driven_6518_Survey_App
{
    public partial class StaffSearch : System.Web.UI.Page
    {
        //Allow minimum of 4 criteria to be searched (include bank used and bank service)
        string sortCondition;
        string baseQuery;
        string finalQuery;
        string sortBySex;
        string banskUsed;
        string banksServices;
        string sortBysUserChoice;
        DatabaseManager db;
        SqlConnection conn;
        SqlDataAdapter dataAdapter;
        DataSet dataset;

        protected void Page_Load(object sender, EventArgs e)
        {
            db = new DatabaseManager();
            dataAdapter = new SqlDataAdapter();
            baseQuery = "Select Answer.U_ID, [" +
                "User].U_FirstName, [User].U_Time, " +
                "Question.Q_Text, Answer.Ans_text " +
                "from Question " +
                "Inner Join Answer " +
                "ON Answer.Que_ID = Question.Q_ID " +
                "INNER JOIN [User] " +
                "on [User].U_ID = Answer.U_ID ";
        }

        protected void searchBtn_Click1(object sender, EventArgs e)
        {
            dataset = new DataSet();
            banksServices = bankServiceDropDown.SelectedValue;
            banskUsed = bankUsedDropdown.SelectedValue;
            sortBySex = sexDropDown.SelectedValue;
            sortBysUserChoice = adminSelectionDropdown.SelectedValue;
            conn = db.openConnection();
            if (sortBysUserChoice != "")
            {
                switch (sortBysUserChoice)
                {
                    case "Any": //Order by Name
                        sortCondition = "";
                        break;
                    case "User Name": //Order by Name
                        sortCondition = "Order By [User].U_FirstName DESC ";
                        break;
                    case "Newest entries": // Oder by Date
                        sortCondition = "Order By [User].U_Time DESC ";
                        break;
                }
            }

            finalQuery = baseQuery + "Where Answer.Ans_text IN (@_banksServices,@_banskUsed,@_sortBySex) " + sortCondition;
            using (SqlCommand populateGridViewComand = new SqlCommand(finalQuery, conn))
                {
                if (sortBySex == "")
                {
                    sortBySex = "''";
                }else if(banskUsed == "")
                {
                    banskUsed = "''";
                }else if(banksServices == "")
                {
                    banksServices = "''";
                }

                populateGridViewComand.Parameters.Add("@_banksServices", SqlDbType.VarChar, 15).Value = banksServices;
                populateGridViewComand.Parameters.Add("@_banskUsed", SqlDbType.VarChar, 15).Value = banskUsed;
                populateGridViewComand.Parameters.Add("@_sortBySex", SqlDbType.VarChar, 15).Value = sortBySex;
                dataAdapter = new SqlDataAdapter(populateGridViewComand);
                dataAdapter.Fill(dataset, "Answer");
                resultGridView.DataSource = dataset.Tables["Answer"];
                resultGridView.DataBind();
                conn.Close();

                }
            }
        }
    }
