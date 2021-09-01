using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//custom namespaces
using Utility;

namespace MyTestApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //MainForm mainForm = new MainForm();
            Application.Run(FormManager.Current);

        }

    }
    class FormManager : ApplicationContext
    {
        private List<Form> forms = new List<Form>();

        private void onFormClosed(object sender, EventArgs e)
        {
            forms.Remove((Form)sender);
            if (!forms.Any())
            {
                ExitThread();
            }
        }

        public void RegisterForm(Form frm)
        {
            frm.FormClosed += onFormClosed;
            forms.Add(frm);
        }

        public T CreateForm<T>() where T : Form, new()
        {
            var ret = new T();
            RegisterForm(ret);
            return ret;
        }

        private static Lazy<FormManager> _current = new Lazy<FormManager>();
        public static FormManager Current => _current.Value;

        public FormManager()
        {
            var form1 = CreateForm<Form1>();
            form1.Show();
        }
    }
}

namespace SF12
{
    class User
    {
        public User(string name = "Nome", string surname ="cognome", string birthday = "25/12/0003", bool firstVisit = false, string notes = "")
        {
            Name = StringMan.FormatString(name);
            Surname = StringMan.FormatString(surname);
            Birthday = DateTime.Parse(birthday);
            FirstVisit = firstVisit;
            Notes = notes;
        }


        //User private data
        private string name = "";
        private string surname = "";
        private DateTime birthday = DateTime.Today;
        private bool firstVisit = false;
        private string notes = "";

        //Getter and Setters
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public DateTime Birthday { get => birthday; set => birthday = value; }
        public bool FirstVisit { get => firstVisit; set => firstVisit = value; }
        public string Notes { get => notes; set => notes = value; }
    }

    class Question
    {
        public Question(int id = 0, string questionText = "", List<answer> possibleAnswersList = null)
        {
            QuestionId = id;
            QuestionText = questionText;
            PossibleAnswersList = possibleAnswersList;
        }

        private int questionId = 0;
        private string questionText = "";
        private List<answer> possibleAnswersList = null;
        public struct answer
        {
            string answerText;
            double answerPoints;
        }

        public int QuestionId { get => questionId; set => questionId = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public List<answer> PossibleAnswersList { get => possibleAnswersList; set => possibleAnswersList = value; }
    }

    class Questionnaire : Question
    {
        public Questionnaire(List<Question> questionList = null)
        {
            QuestionList = questionList;
        }

        private List<Question> questionList = null;

        public List<Question> QuestionList { get => questionList; set => questionList = value; }
    }
}

namespace Utility
{
    public static class StringMan
    {
        public static string FormatString(string word)
        {

            return word;
        }
    }
}