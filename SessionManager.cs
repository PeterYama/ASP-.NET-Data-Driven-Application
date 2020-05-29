using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data_Driven_6518_Survey_App
{
    internal class SessionManager
    {

        public static void RecordUserToSession(userAnswers userObj)
        {

            if (HttpContext.Current.Session["userAnswers"] == null)
            {
                List<userAnswers> answersList = new List<userAnswers>();
                answersList.Add(userObj);
                HttpContext.Current.Session["userAnswers"] = answersList;
            }
            else
            {
                List<userAnswers> answersList = (List<userAnswers>)HttpContext.Current.Session["userAnswers"];
                answersList.Add(userObj);
                HttpContext.Current.Session["userAnswers"] = answersList;
            }
        }

        public static List<userAnswers> retrieveListFromSession()
        {
            return (List<userAnswers>)HttpContext.Current.Session["userAnswers"];
        }
    }
}