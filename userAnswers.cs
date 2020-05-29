
namespace Data_Driven_6518_Survey_App
{
    public class userAnswers
    {

		private string[] _checkBoxValues;

		public string[] checkBoxValues
		{
			get { return _checkBoxValues; }
			set { _checkBoxValues = value; }
		}

		private string _opt_id;

		public string opt_id
		{
			get { return _opt_id; }
			set { _opt_id = value; }
		}
		

		private int _user_ID;
		public int user_ID
		{
			get { return _user_ID; }
			set { _user_ID = value; }
		}

		private int _question_ID;

		public int question_ID
		{
			get { return _question_ID; }
			set { _question_ID = value; }
		}

		private string _userSelection;
		public string userSelection
		{
			get { return _userSelection; }
			set { _userSelection = value; }
		}

		private string _userSelectionText;

		public string userSelectionText
		{
			get { return _userSelectionText; }
			set { _userSelectionText = value; }
		}

		private string _ip;

		public string userIP
		{
			get { return _ip; }
			set { _ip = value; }
		}

		private char _date;

		public char date
		{
			get { return _date; }
			set { _date = value; }
		}

		private string _answerText;

		public string answerText
		{
			get { return _answerText; }
			set { _answerText = value; }
		}


		
	}
}