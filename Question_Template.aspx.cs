using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.WebControls;
/*
Hello Matt, I ended up using isPostBack
I know the way I did it is quit different than what you have explained, but it's working =)

Custom Classes That I am using:
DatabaseManager, SessionManager, UserAnswers

Application Flow:
-if isPostBack use default Question ID = 1
-userID is created
-if not get the NextQuestionId from session
-Run a query using the QuestionID
-Run a second query for Options using the CurrentQuestionID
-Inside getQuestion is condition to check if there is an ExtraQuestion stored in Session
-I am adding the current question type to a List<strint> than accessing it on getOptions.
-getOptions will check the type and make visible the correct UI Type
-User select an option and click on the next button.
-Next button will check what type of question and do the corresponding action
-if it's radio button or checkBox, it will cycle through all and store the answers.
-if Multiple Choice was selected, it will store the answers in a string[] userSelectionArray
-fillList() function will fill an UserObject, than add to List<userAnswers>, Than Add to Session.
-endButton will get all the data and save to the database after a clean-up in the list, removing all the garbage(null)
*/
namespace Data_Driven_6518_Survey_App
{
    public partial class _Default : System.Web.UI.Page
    {
        int currentQuestionID;
        DatabaseManager db;
        SqlCommand cmd;
        userAnswers userObj;
        string queryString;
        static Random rand;
        int userID;
        public SqlDataReader reader;
        string nextQuestionID;
        string userSelection;
        string[] userSelectionArray;
        List<string> questionHistory;
        List<string> multipleSelection;
        //When page load template is loaded dynamicaly from the first question
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rand = new Random();
                userID = rand.Next();
                HttpContext.Current.Session["userID"] = userID;
                HttpContext.Current.Session["currentType"] = new List<string>();
                nextQuestionID = "1";
                getQuestion(nextQuestionID);
            }
            else
            {
                nextQuestionID = (string)HttpContext.Current.Session["nextQuestionID"];
            };
        }
        //Get question based on the question ID from session
        public void getQuestion(string nextQuestionID)
        {
            if ((string)HttpContext.Current.Session["ExtraQuestion"] == "bank")
            {
                nextQuestionID = "8";
                HttpContext.Current.Session["ExtraQuestion"] = "";
            }
            else if ((string)HttpContext.Current.Session["ExtraQuestion"] == "Sport")
            {
                nextQuestionID = "9";
                HttpContext.Current.Session["ExtraQuestion"] = "";
            }
            else if ((string)HttpContext.Current.Session["ExtraQuestion"] == "Travel")
            {
                nextQuestionID = "10";
                HttpContext.Current.Session["ExtraQuestion"] = "";
            }

            db = new DatabaseManager();
            queryString = "select * from question where Q_ID = " + nextQuestionID;
            using (SqlConnection conn = db.openConnection())
            {
                cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string type = (string)reader["Q_Type"];
                    currentQuestionID = (int)reader["Q_ID"];
                    question_lbl.Text = (string)reader["Q_Text"];
                    id_lbl.Text = Convert.ToString(reader["Q_ID"]);
                    questionHistory = (List<string>)HttpContext.Current.Session["currentType"];
                    questionHistory.Add(type);
                    HttpContext.Current.Session["currentType"] = questionHistory;
                    HttpContext.Current.Session["nextQuestionID"] = Convert.ToString(reader["Next_Q_ID"]);
                    HttpContext.Current.Session["currentQuestionID"] = (int)reader["Q_ID"];
                    getOptions(currentQuestionID, type);
                }
                else
                {
                    error_lbl.Text = "fail";
                }
                reader.Close();
            }
        }

        public void getOptions(int question_ID, string type)
        {
            using (SqlConnection conn = db.openConnection())
            {
                queryString = "Select * from [Option] where Que_ID = " + question_ID;
                cmd = new SqlCommand(queryString, conn);
                reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    //As reader are only foward type of class, I am adding this step. so  it reades also the first value
                    //ListItem item = new ListItem((string)reader["Opt_Text"], reader["Opt_ID"].ToString());
                    string textBoxLabel = (string)reader["Opt_Text"];

                    if (type == "checkbox")
                    {
                        checkBoxList.Items.Clear();
                        checkBoxList.Items.Add(new ListItem((string)reader["Opt_Text"], reader["Opt_ID"].ToString()));
                        while (reader.Read())
                        {
                            checkBoxList.Items.Add(new ListItem((string)reader["Opt_Text"], reader["Opt_ID"].ToString()));
                        }
                        checkBoxList.Visible = true;
                    }
                    else if (type == "Text")
                    {
                        textBox_lbl.Visible = true;
                        answer_txtBox.Visible = true;
                        answer_txtBox.Text = "";
                        textBox_lbl.Text = textBoxLabel;

                    }
                    else if(type == "Bool")
                    {
                        radioButtonList.Items.Clear();
                        radioButtonList.Items.Add(new ListItem((string)reader["Opt_Text"], reader["Opt_ID"].ToString()));
                        radioButtonList.Visible = true;

                        while (reader.Read())
                        {
                            radioButtonList.Items.Add(new ListItem((string)reader["Opt_Text"], reader["Opt_ID"].ToString()));
                            //option_lbl.Controls.Add(radioButtonList);
                        }
                    }
                    else if (type == "end")
                    {
                        option_lbl.Text = (string)reader["Opt_Text"];
                        next_btn.Visible = false;
                        Check_Session.Visible = false;
                        endButton.Visible = true;
                    }
                }
                reader.Close();
            }
        }

        public void fillList(int question_id, string userSelection, string answerText = "null")
        {
            userSelectionArray = new string[10];
            userObj = new userAnswers();
            userObj.answerText = answerText;
            userObj.question_ID = question_id;
            userObj.userSelection = userSelection;
            if (multipleSelection != null)
            {
                for (int i = 0; i < multipleSelection.Count; i++)
                {
                    userSelectionArray.SetValue(multipleSelection[i], i);
                }
                userObj.checkBoxValues = userSelectionArray;
            }
            userID = (int)HttpContext.Current.Session["userID"];
            userObj.user_ID = userID;

            SessionManager.RecordUserToSession(userObj);
        }

        protected void next_btn_Click1(object sender, EventArgs e)
        {
            int questionId = (int)HttpContext.Current.Session["currentQuestionID"];
            List<string> tempList = (List<string>)HttpContext.Current.Session["currentType"];
            string currentQuestion = tempList[tempList.Count - 1];
            switch (currentQuestion)
            {
                case "checkbox":
                    userSelection = (string)HttpContext.Current.Session["userSelection"];
                    fillList(questionId, userSelection);
                    checkBoxList.Visible = false;
                    getQuestion(nextQuestionID);
                    break;
                case "Text":
                    HttpContext.Current.Session["userAnswer"] = answer_txtBox.Text;
                    string userAnswer = (string)HttpContext.Current.Session["userAnswer"];
                    fillList(questionId, userSelection, userAnswer);
                    textBox_lbl.Visible = false;
                    if (tempList[tempList.Count -1] == "Text")
                    {
                        answer_txtBox.Visible = false;
                    }
                    else
                    {
                        answer_txtBox.Visible = true;
                    }
                    getQuestion(nextQuestionID);

                    break;
                case "Bool":
                    for (int i = 0; i < radioButtonList.Items.Count; i++)
                    {
                        if (radioButtonList.Items[i].Selected)
                        {
                            userSelection = Convert.ToString(radioButtonList.Items[i]);
                        }
                    }
                    fillList(questionId, userSelection);
                    radioButtonList.Visible = false;
                    getQuestion(nextQuestionID);
                    break;
                default:
                    Response.Write("Invalid Question Type");
                    break;
            };
        }

        protected void BoxClicked(object sender, EventArgs e)
        {
            multipleSelection = new List<string>();
            for (int i = 0; i < checkBoxList.Items.Count; i++)
            {
                if (checkBoxList.Items[i].Selected)
                {
                    multipleSelection.Add(Convert.ToString(checkBoxList.Items[i]));
                    HttpContext.Current.Session["userSelection"] = Convert.ToString(checkBoxList.Items[i]);
                }
            }

            checkBoxList.Visible = false;
            if ((string)HttpContext.Current.Session["userSelection"] == "Sport")
            {
                HttpContext.Current.Session["ExtraQuestion"] = "Sport";
            }
            else if ((string)HttpContext.Current.Session["userSelection"] == "Travel")
            {
                HttpContext.Current.Session["ExtraQuestion"] = "Travel";
            }
            else if 
                (((string)HttpContext.Current.Session["userSelection"] == "Common-Wealth") ||
                ((string)HttpContext.Current.Session["userSelection"] == "Wespac") ||
                ((string)HttpContext.Current.Session["userSelection"] == "ANZ"))
            {
                HttpContext.Current.Session["ExtraQuestion"] = "bank";
            }
        }

        protected void Check_Session_Click(object sender, EventArgs e)
        {
            List<userAnswers> list = SessionManager.retrieveListFromSession();

            foreach (userAnswers item in list)
            {
                Response.Write("userID: " + item.user_ID + "<br>");
                Response.Write("QuestionID: " + item.question_ID + "<br>");
                Response.Write("userSelection " + item.userSelection + "<br>");
                if(item.checkBoxValues != null)
                {
                    foreach (string i in item.checkBoxValues)
                    {
                        if (i != null)
                        {
                            Response.Write("Values Selected " + i + "<br>");
                        }
                    }

                }
               
            }
        }
        protected void radioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < radioButtonList.Items.Count; i++)
            {
                if (radioButtonList.Items[i].Selected)
                {
                    HttpContext.Current.Session["userSelection"] = Convert.ToString(radioButtonList.Items[i]);
                }
            }
        }

        protected void endButton_Click(object sender, EventArgs e)
        {
            //if the question was radio button, use userSelection
            //if the queston was checkBox, use multipleSelection

            List<userAnswers> list = SessionManager.retrieveListFromSession();
            db = new DatabaseManager();
            using (SqlConnection conn = db.openConnection())
            {
                //Register user IP , Date and user_ID to User table
                //Refering to StackoverFlow, userSessionID approach instead o using Users IP is recommended
                DateTime thisDay = DateTime.Today;
                var userSessionID = HttpContext.Current.Session.SessionID;
                int currentID = (int)HttpContext.Current.Session["userID"];
                queryString = "Insert Into [User] (U_Time, U_IP, U_ID) " +
                    "VALUES ('" + thisDay + "', '" + userSessionID + "','" + currentID + "')";

                cmd = new SqlCommand(queryString, conn);
                cmd.ExecuteNonQuery();

                foreach (userAnswers item in list)
                {
                    if ((item.userSelection == null) && (item.answerText == "null"))
                    {
                        option_lbl.Text = " Some options are missing";
                    }

                    try
                    {
                        //Check if the number of Characters exceed the ones set on the database
                        queryString = "Insert Into Answer (U_ID, Que_ID, Ans_Text) " +
                        "VALUES (" + item.user_ID + ", " + item.question_ID + ", '" + item.answerText + "')";
                        cmd = new SqlCommand(queryString, conn);
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        for (int i = 0; i < ex.Errors.Count; i++)
                        {
                            error_lbl.Text = "Index #" + i + "\n" +
                                "Message: " + ex.Errors[i].Message + "\n" +
                                "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                                "Source: " + ex.Errors[i].Source + "\n" +
                                "Procedure: " + ex.Errors[i].Procedure + "\n";
                        }
                    }
                    
                    if (item.checkBoxValues != null)
                    {
                        foreach (var i in item.checkBoxValues)
                        {
                            if (i != null)
                            {
                                queryString = "Insert Into Answer (U_ID, Que_ID, Ans_Text) " +
                                "VALUES (" + item.user_ID + ", " + item.question_ID + ", '" + i + "')";
                                cmd = new SqlCommand(queryString, conn);
                                cmd.ExecuteNonQuery();
                            }

                        }
                    }
                    // Delete all rows fron answer table 
                    //DELETE FROM Answer WHERE Ans_ID > 0;
                }
            }
            option_lbl.Text = "Items saved to the database";
            register_btn.Visible = true;
            endButton.Visible = false;
            staff_search_btn.Visible = true;
        }

        protected void register_btn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("RegistrationForm.aspx");
        }

        protected void staff_search_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffSearch.aspx");
        }
    }

}