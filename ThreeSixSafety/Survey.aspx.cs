using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

namespace ThreeSixSafety
{
    public partial class Survey : System.Web.UI.Page
    {
        public struct fullQuestion
        {
            public string questionText;
            public string questionType;
            public string[] questionChoices;

            //Constructor
            public fullQuestion(string questionText, string questionType, string[] questionChoices)
            {
                this.questionText = questionText;
                this.questionType = questionType;
                this.questionChoices = questionChoices;
            }
        }

        List<fullQuestion> listOfQuestions = new List<fullQuestion>();
        List<int> vals = new List<int>();
        int numInitialQ = 0;
        int numTableQ = 0;
        List<RadioButtonList> normalQuestions = new List<RadioButtonList>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = (string)Session["Name"];
            if (userName == null)
            {
                Response.Redirect("~/Default.aspx", false);
            }
            personNameLabel.Text = "Welcome to the survey, " + userName;

            parseQuestions();
            addQuestions();
        }

        protected void parseQuestions()
        {

            TextFieldParser parser = new TextFieldParser(@"C:\inetpub\wwwroot\ThreeSixSafety\Questions.csv", System.Text.Encoding.GetEncoding("ISO-8859-1"));
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                //Processing row
                string[] fields = parser.ReadFields();
                fullQuestion tempQ = new fullQuestion();
                tempQ.questionText = fields[0];
                tempQ.questionType = fields[1];

                //parse fields[2]
                if (fields[2] != "")
                {
                    string[] opt = fields[2].Split(';');
                    tempQ.questionChoices = opt;
                }
                listOfQuestions.Add(tempQ);
            }
            parser.Close();
        }
        protected void addQuestions()
        {
            int count = 1;
            foreach (fullQuestion q in listOfQuestions)
            {
                Label lab = new Label();
                Label num = new Label();

                lab.CssClass = "questionLabelCSS";
                num.CssClass = "questionLabelCSS";

                num.Text = count.ToString() + ". ";
                questionPanel.Controls.Add(num);
                lab.Text = q.questionText;
                questionPanel.Controls.Add(lab);

                questionPanel.Controls.Add(new LiteralControl("<br />"));
                questionPanel.Controls.Add(new LiteralControl("<br />"));
                chooseQuestion(q.questionType, q.questionChoices, count);

                count++;
            }
            //questionPanel.Controls.Add()
        }

        protected void chooseQuestion(string type, string[] qList, int qNum)
        {
            if (qList != null)
            {
                int c = qList.Count();
            }
            if (type == "Choice")
            {
                RadioButtonList rbList = new RadioButtonList();
                foreach (string s in qList)
                {
                    ListItem l = new ListItem();
                    l.Text = s;
                    rbList.Items.Add(l);
                }
                questionPanel.Controls.Add(rbList);
                questionPanel.Controls.Add(new LiteralControl("<br />"));
                numInitialQ++;
            }
            else
            {
                string[] arr = type.Split(';');
                if (arr.Length > 1)
                {
                    addChoices(arr[1]);
                }
                numTableQ++;
            }
        }
        protected void addChoices(string ty)
        {
            TableRow row = new TableRow();
            TableRow row2 = new TableRow();
            Table t = new Table();
            t.Rows.Add(row);
            t.Rows.Add(row2);

            RadioButtonList rbList = new RadioButtonList();
            rbList.RepeatDirection = RepeatDirection.Horizontal;
            rbList.RepeatColumns = 8;
            rbList.RepeatLayout = RepeatLayout.Table;

            for (int i = 0; i < 8; i++)
            {
                TableCell cell = new TableCell();
                row.Cells.Add(cell);
                cell.Width = Unit.Pixel(100);
                cell.HorizontalAlign = HorizontalAlign.Center;
                cell.VerticalAlign = VerticalAlign.Middle;
                switch (i)
                {
                    case 0:
                        cell.Text = "Never or 0% of the time";
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        cell.Text = "Neutral or 50% of the time";
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        cell.Text = "Always or 100% of the time";
                        break;
                    case 7:
                        cell.Text = "I don't know, but it is important";
                        break;
                }
            }

            for (int i = 0; i < 8; i++)
            {
                ListItem l = new ListItem();
                l.Value = i.ToString();
                l.Text = "";
                rbList.Items.Add(l);
            }
            TableCell cell2 = new TableCell();
            row2.Cells.Add(cell2);
            cell2.ColumnSpan = 8;
            cell2.Controls.Add(rbList);
            rbList.CssClass = "radioButtonSpaceCSS";

            questionPanel.Controls.Add(t);
            //questionPanel.Controls.Add(rbList);
            questionPanel.Controls.Add(new LiteralControl("<br />"));
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            foreach (Control c in questionPanel.Controls)
            {
                if (c is RadioButtonList)
                {
                    vals.Add(((RadioButtonList)c).SelectedIndex);
                    normalQuestions.Add((RadioButtonList)c);
                }
                else if (c is Table)
                {
                    foreach (Control c1 in c.Controls)
                    {
                        if (c1 is TableRow)
                        {
                            foreach (Control c2 in c1.Controls)
                            {
                                if (c2 is TableCell)
                                {
                                    foreach (Control c3 in c2.Controls)
                                    {
                                        if (c3 is RadioButtonList)
                                        {
                                            vals.Add(((RadioButtonList)c3).SelectedIndex);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string miss = "";
            int cnt = 1;
            bool flag = false;
            foreach (int i in vals)
            {
                if (i == -1)
                {
                    miss += cnt.ToString() + ", ";
                    flag = true;
                }
                cnt++;
            }
            if (flag)
            {
                missedQuestion(miss);
            }
            else
            {
                submitVals();
            }
        }
        protected void missedQuestion(string qNum)
        {
            qNum = qNum.TrimEnd(' ');
            qNum = qNum.TrimEnd(',');
            string al = "<script>alert('Please answer all questions. You missed questions: " + qNum + "');</script>";
            ClientScript.RegisterClientScriptBlock(this.GetType(), "response", al);
            return;
        }
        protected void submitVals()
        {
            string fullWrite = "";
            string user = (string)Session["Name"];
            string date = DateTime.Now.ToString("M/d/yyyy");

            string answers = "";

            for (int i = 0; i < vals.Count; i++)
            {
                if (i < normalQuestions.Count)
                {
                    answers += normalQuestions[i].SelectedValue + ";";
                }
                else
                {
                    answers += vals[i].ToString() + ";";
                }
            }

            /*foreach (int i in vals)
            {
                if (i < normalQuestions.Count)
                {

                    answers += normalQuestions[i].SelectedValue + ";";
                }
                else
                {
                    answers += i.ToString() + ";";
                }
            }*/

            fullWrite = user + "," + date + "," + answers;

            string path = @"C:\inetpub\wwwroot\ThreeSixSafety\Answers.csv";
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(fullWrite);
                }
            }
            Response.Redirect("~/Results.aspx");
        }
    }
}