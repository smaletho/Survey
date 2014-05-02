using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.VisualBasic.FileIO;

namespace ThreeSixSafety
{
    public partial class Admin : System.Web.UI.Page
    {
        public class questionData
        {
            List<int> zeroQuestions = new List<int>();
            string firstAnswer;
            string secondAnswer;
            string thirdAnswer;

            public int getNumberedAnswer(int i)
            {
                return zeroQuestions[i];
            }

            public questionData parseQuestions(string q)
            {
                //this.zeroQuestions = new List<int>();
                string[] strArr = q.Split(';');
                questionData ls = new questionData();
                ls.firstAnswer = strArr[0];
                ls.secondAnswer = strArr[1];
                ls.thirdAnswer = strArr[2];

                for (int i = 3; i < (strArr.Length - 1); i++)
                {
                    ls.zeroQuestions.Add(Convert.ToInt32(strArr[i]));
                }

                return ls;
            }
            public int getQuestionCount()
            {
                return this.zeroQuestions.Count;
            }
            public string getJobTitle()
            {
                return this.firstAnswer;
            }
            public string getDept()
            {
                return this.secondAnswer;
            }
            public string getDuration()
            {
                return this.thirdAnswer;
            }
        }
        public struct userData
        {
            public string userName;
            public string dateTaken;
            public questionData questions;

            //Constructor
            public userData(string userName, string dateTaken, questionData questions)
            {
                this.userName = userName;
                this.dateTaken = dateTaken;
                this.questions = questions;
            }
        }

        public class numData
        {
            public int num0Answer = 0;
            public int num1Answer = 0;
            public int num2Answer = 0;
            public int num3Answer = 0;
            public int num4Answer = 0;
            public int num5Answer = 0;
            public int num6Answer = 0;
            public int num7Answer = 0;

            public List<int> answerList = new List<int>();

            public void addAnswer(int response)
            {
                answerList.Add(response);

                switch (response)
                {
                    case 0:
                        num0Answer++;
                        break;
                    case 1:
                        num1Answer++;
                        break;
                    case 2:
                        num2Answer++;
                        break;
                    case 3:
                        num3Answer++;
                        break;
                    case 4:
                        num4Answer++;
                        break;
                    case 5:
                        num5Answer++;
                        break;
                    case 6:
                        num6Answer++;
                        break;
                    case 7:
                        num7Answer++;
                        break;
                }
            }

            public int getResponse(int qNum)
            {
                return answerList[qNum];
            }

            public int getTotalResponse()
            {
                return (num1Answer + (num2Answer * 2) + (num3Answer * 3) + (num4Answer * 4) + (num5Answer * 5) + (num6Answer * 6));
            }
        }

        public class byTitleData
        {
            public numData executiveData = new numData();
            public numData lineSuperData = new numData();
            public numData lineTeamData = new numData();

            public numData adminData = new numData();
            public numData salesData = new numData();
            public numData manufacturingData = new numData();
            public numData warehouseData = new numData();
            public numData otherData = new numData();

            public numData zeroTo5 = new numData();
            public numData sixTo11 = new numData();
            public numData twelveTo17 = new numData();
            public numData eighteenTo23 = new numData();
            public numData over24 = new numData();

            public List<string> getTotalnum()
            {
                List<string> totalList = new List<string>();

                string total0 = (executiveData.num0Answer + lineSuperData.num0Answer + lineTeamData.num0Answer).ToString();
                string total1 = (executiveData.num1Answer + lineSuperData.num1Answer + lineTeamData.num1Answer).ToString();
                string total2 = (executiveData.num2Answer + lineSuperData.num2Answer + lineTeamData.num2Answer).ToString();
                string total3 = (executiveData.num3Answer + lineSuperData.num3Answer + lineTeamData.num3Answer).ToString();
                string total4 = (executiveData.num4Answer + lineSuperData.num4Answer + lineTeamData.num4Answer).ToString();
                string total5 = (executiveData.num5Answer + lineSuperData.num5Answer + lineTeamData.num5Answer).ToString();
                string total6 = (executiveData.num6Answer + lineSuperData.num6Answer + lineTeamData.num6Answer).ToString();
                string total7 = (executiveData.num7Answer + lineSuperData.num7Answer + lineTeamData.num7Answer).ToString();

                totalList.Add(total0);
                totalList.Add(total1);
                totalList.Add(total2);
                totalList.Add(total3);
                totalList.Add(total4);
                totalList.Add(total5);
                totalList.Add(total6);
                totalList.Add(total7);

                return totalList;
            }

        }

        public class byCategoryData
        {
            public byTitleData riskData = new byTitleData();
            public byTitleData compData = new byTitleData();
            public byTitleData cultureData = new byTitleData();
            public byTitleData financeData = new byTitleData();

            public int num_executiveData = 0;
            public int num_lineSuperData = 0;
            public int num_lineTeamData = 0;

            public int num_adminData = 0;
            public int num_salesData = 0;
            public int num_manufacturingData = 0;
            public int num_warehouseData = 0;
            public int num_otherData = 0;

            public int num_zeroTo5 = 0;
            public int num_sixTo11 = 0;
            public int num_twelveTo17 = 0;
            public int num_eighteenTo23 = 0;
            public int num_over24 = 0;

            public int getTotalPeople()
            {
                return (num_executiveData + num_lineSuperData + num_lineTeamData);
            }

            public decimal getTotalRisk()
            {
                int totalPeople = (num_executiveData + num_lineSuperData + num_lineTeamData);

                int executiveRisk = riskData.executiveData.getTotalResponse();
                int superRisk = riskData.lineSuperData.getTotalResponse();
                int teamRisk = riskData.lineTeamData.getTotalResponse();

                int riskAv = (executiveRisk + superRisk + teamRisk) / totalPeople;

                decimal riskAvPer = ((decimal)riskAv / 36) * 7;

                return riskAvPer;
            }

            public decimal getTotalCulture()
            {
                int totalPeople = (num_executiveData + num_lineSuperData + num_lineTeamData);

                int executiveCul = cultureData.executiveData.getTotalResponse();
                int superCul = cultureData.lineSuperData.getTotalResponse();
                int teamCul = cultureData.lineTeamData.getTotalResponse();

                int culAv = (executiveCul + superCul + teamCul) / totalPeople;

                decimal culAvPer = ((decimal)culAv / 36) * 7;

                return culAvPer;
            }

            public decimal getTotalCompliance()
            {
                int totalPeople = (num_executiveData + num_lineSuperData + num_lineTeamData);

                int executiveComp = compData.executiveData.getTotalResponse();
                int superComp = compData.lineSuperData.getTotalResponse();
                int teamComp = compData.lineTeamData.getTotalResponse();

                int compAv = (executiveComp + superComp + teamComp) / totalPeople;

                decimal compAvPer = ((decimal)compAv / 36) * 7;

                return compAvPer;
            }

            public decimal getTotalFinance()
            {
                int totalPeople = (num_executiveData + num_lineSuperData + num_lineTeamData);

                int executiveFin = financeData.executiveData.getTotalResponse();
                int superFin = financeData.lineSuperData.getTotalResponse();
                int teamFin = financeData.lineTeamData.getTotalResponse();

                int finAv = (executiveFin + superFin + teamFin) / totalPeople;

                decimal finAvPer = ((decimal)finAv / 36) * 7;

                return finAvPer;
            }

            public decimal subRisk(string title, string stat)
            {
                //stat == risk/compliance/finance/culture
                int totalPpl = 0;
                int responses = 0;
                int average = 0;
                decimal averagePer = 0;

                switch (title)
                {
                    case "Executive":
                        totalPpl = num_executiveData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.executiveData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.executiveData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.executiveData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.executiveData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Supervisor":
                        totalPpl = num_lineSuperData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.lineSuperData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.lineSuperData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.lineSuperData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.lineSuperData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Team":
                        totalPpl = num_lineTeamData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.lineTeamData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.lineTeamData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.lineTeamData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.lineTeamData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Admin":
                        totalPpl = num_adminData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.adminData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.adminData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.adminData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.adminData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Sales":
                        totalPpl = num_salesData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.salesData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.salesData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.salesData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.salesData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Manufacturing":
                        totalPpl = num_manufacturingData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.manufacturingData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.manufacturingData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.manufacturingData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.manufacturingData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Warehouse":
                        totalPpl = num_warehouseData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.warehouseData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.warehouseData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.warehouseData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.warehouseData.getTotalResponse();
                                break;
                        }
                        break;
                    case "Other":
                        totalPpl = num_otherData;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.otherData.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.otherData.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.otherData.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.otherData.getTotalResponse();
                                break;
                        }
                        break;
                    case "zero":
                        totalPpl = num_zeroTo5;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.zeroTo5.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.zeroTo5.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.zeroTo5.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.zeroTo5.getTotalResponse();
                                break;
                        }
                        break;
                    case "six":
                        totalPpl = num_sixTo11;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.sixTo11.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.sixTo11.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.sixTo11.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.sixTo11.getTotalResponse();
                                break;
                        }
                        break;
                    case "twelve":
                        totalPpl = num_twelveTo17;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.twelveTo17.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.twelveTo17.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.twelveTo17.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.twelveTo17.getTotalResponse();
                                break;
                        }
                        break;
                    case "eighteen":
                        totalPpl = num_eighteenTo23;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.eighteenTo23.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.eighteenTo23.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.eighteenTo23.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.eighteenTo23.getTotalResponse();
                                break;
                        }
                        break;
                    case "over24":
                        totalPpl = num_over24;

                        switch (stat)
                        {
                            case "Risk":
                                responses = riskData.over24.getTotalResponse();
                                break;
                            case "Compliance":
                                responses = compData.over24.getTotalResponse();
                                break;
                            case "Finance":
                                responses = financeData.over24.getTotalResponse();
                                break;
                            case "Culture":
                                responses = cultureData.over24.getTotalResponse();
                                break;
                        }
                        break;
                }
                average = responses / totalPpl;
                averagePer = ((decimal)average / 36) * 7;

                return averagePer;
            }
        }

        public List<userData> allUsers = new List<userData>();
        public byCategoryData userAnswers = new byCategoryData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (((string)Session["loggedIn"]) != "yes")
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //read from CSV into userData
                readAnswers();

                //read from userData into categoryData
                parseData();

                //scale pie slices
                scaleSlices();

                //fill in labels/overlays
                fillLabels();

                //query string stuff
                string riskGoalstr = Request.QueryString["risk"];
                string complianceGoalstr = Request.QueryString["comp"];
                string cultureGoalstr = Request.QueryString["cul"];
                string financeGoalstr = Request.QueryString["fin"];

                if (riskGoalstr != null)
                {
                    decimal riskGoal = Convert.ToDecimal(riskGoalstr);
                    scaleDiv(riskGoalImg, riskGoal, 150, "tl");
                    riskDrop.Items.FindByText(riskGoalstr).Selected = true;
                }
                if (complianceGoalstr != null)
                {
                    decimal compGoal = Convert.ToDecimal(complianceGoalstr);
                    scaleDiv(compGoalImg, compGoal, 150, "tr");
                    compDrop.Items.FindByText(complianceGoalstr).Selected = true;
                }
                if (cultureGoalstr != null)
                {
                    decimal culGoal = Convert.ToDecimal(cultureGoalstr);
                    scaleDiv(culGoalImg, culGoal, 150, "br");
                    culDrop.Items.FindByText(cultureGoalstr).Selected = true;
                }
                if (financeGoalstr != null)
                {
                    decimal finGoal = Convert.ToDecimal(financeGoalstr);
                    scaleDiv(finGoalImg, finGoal, 150, "bl");
                    finDrop.Items.FindByText(financeGoalstr).Selected = true;
                }
            }
        }

        protected void readAnswers()
        {
            string path = @"C:\inetpub\wwwroot\ThreeSixSafety\Answers.csv";
            try
            {
                if (File.Exists(path))
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (sr.Peek() >= 0)
                        {
                            string tempAns = sr.ReadLine();
                            string[] arr = tempAns.Split(',');

                            userData tmpUser = new userData();
                            tmpUser.userName = arr[0];
                            tmpUser.dateTaken = arr[1];

                            questionData tmpQ = new questionData();
                            tmpQ = tmpQ.parseQuestions(arr[2]);

                            tmpUser.questions = tmpQ;

                            allUsers.Add(tmpUser);
                        }
                    }
                }
            }
            catch (Exception x)
            {
                Console.WriteLine("The process failed: {0}", x.ToString());
            }
        }

        protected void parseData()
        {
            //loop through each of the people
            foreach (userData u in allUsers)
            {
                string tempJobTitle = u.questions.getJobTitle();
                string tempDept = u.questions.getDept();
                string tempDuration = u.questions.getDuration();

                switch (tempJobTitle)
                {
                    case "Executive Management":
                        userAnswers.num_executiveData++;
                        break;
                    case "Line Supervisor":
                        userAnswers.num_lineSuperData++;
                        break;
                    case "Line Team Supervisor":
                        userAnswers.num_lineTeamData++;
                        break;
                }

                switch (tempDept)
                {
                    case "Administration / Accounting / HR":
                        userAnswers.num_adminData++;
                        break;
                    case "Sales":
                        userAnswers.num_salesData++;
                        break;
                    case "Manufacturing":
                        userAnswers.num_manufacturingData++;
                        break;
                    case "Warehouse / Distribution":
                        userAnswers.num_warehouseData++;
                        break;
                    case "Something Else":
                        userAnswers.num_otherData++;
                        break;
                }

                switch (tempDuration)
                {
                    case "0 to 5 years":
                        userAnswers.num_zeroTo5++;
                        break;
                    case "6 to 11 years":
                        userAnswers.num_sixTo11++;
                        break;
                    case "12 to 17 years":
                        userAnswers.num_twelveTo17++;
                        break;
                    case "18 to 23 years":
                        userAnswers.num_eighteenTo23++;
                        break;
                    case "24+ years":
                        userAnswers.num_over24++;
                        break;
                }

                //loop through each question
                for (int i = 0; i < u.questions.getQuestionCount(); i++)
                {
                    //temp is the user's answer
                    int temp = u.questions.getNumberedAnswer(i);

                    //i is the question number
                    string ty = getQuestionType(i);

                    switch (tempJobTitle)
                    {
                        case "Executive Management":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.executiveData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.executiveData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.executiveData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.executiveData.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "Line Supervisor":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.lineSuperData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.lineSuperData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.lineSuperData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.lineSuperData.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "Line Team Supervisor":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.lineTeamData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.lineTeamData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.lineTeamData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.lineTeamData.addAnswer(temp);
                                    break;
                            }
                            break;
                    }

                    switch (tempDept)
                    {
                        case "Administration / Accounting / HR":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.adminData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.adminData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.adminData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.adminData.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "Sales":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.salesData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.salesData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.salesData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.salesData.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "Manufacturing":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.manufacturingData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.manufacturingData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.manufacturingData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.manufacturingData.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "Warehouse / Distribution":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.warehouseData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.warehouseData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.warehouseData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.warehouseData.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "Something Else":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.otherData.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.otherData.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.otherData.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.otherData.addAnswer(temp);
                                    break;
                            }
                            break;
                    }

                    switch (tempDuration)
                    {
                        case "0 to 5 years":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.zeroTo5.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.zeroTo5.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.zeroTo5.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.zeroTo5.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "6 to 11 years":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.sixTo11.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.sixTo11.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.sixTo11.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.sixTo11.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "12 to 17 years":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.twelveTo17.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.twelveTo17.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.twelveTo17.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.twelveTo17.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "18 to 23 years":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.eighteenTo23.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.eighteenTo23.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.eighteenTo23.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.eighteenTo23.addAnswer(temp);
                                    break;
                            }
                            break;
                        case "24+ years":
                            switch (ty)
                            {
                                case "Risk":
                                    userAnswers.riskData.over24.addAnswer(temp);
                                    break;
                                case "Compliance":
                                    userAnswers.compData.over24.addAnswer(temp);
                                    break;
                                case "Culture":
                                    userAnswers.cultureData.over24.addAnswer(temp);
                                    break;
                                case "Financial":
                                    userAnswers.financeData.over24.addAnswer(temp);
                                    break;
                            }
                            break;
                    }
                }
            }
        }

        protected string getQuestionType(int num)
        {
            string ty = "";

            TextFieldParser parser = new TextFieldParser(@"C:\inetpub\wwwroot\ThreeSixSafety\Questions.csv", System.Text.Encoding.GetEncoding("ISO-8859-1"));
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            int count = 0;

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();

                if (count == (num + 3))
                {
                    string[] t = fields[1].Split(';');
                    ty = t[1];
                    break;
                }
                count++;
            }

            return ty;
        }

        protected void scaleSlices()
        {

            //company circumplex
            scaleDiv(topLeftDiv, userAnswers.getTotalRisk(), 150, "tl");
            scaleDiv(topRightDiv, userAnswers.getTotalCompliance(), 150, "tr");
            scaleDiv(botLeftDiv, userAnswers.getTotalFinance(), 150, "bl");
            scaleDiv(botRightDiv, userAnswers.getTotalCulture(), 150, "br");

            //sub slices, risk
            scaleDiv(execPurpleImg, userAnswers.subRisk("Executive", "Risk"), 94, "tl");
            scaleDiv(superPurpleImg, userAnswers.subRisk("Supervisor", "Risk"), 94, "tl");
            scaleDiv(teamPurpleImg, userAnswers.subRisk("Team", "Risk"), 94, "tl");

            //sub slices, compliance
            scaleDiv(execRedImg, userAnswers.subRisk("Executive", "Compliance"), 94, "tr");
            scaleDiv(superRedImg, userAnswers.subRisk("Supervisor", "Compliance"), 94, "tr");
            scaleDiv(teamRedImg, userAnswers.subRisk("Team", "Compliance"), 94, "tr");

            //sub slices, finance
            scaleDiv(execYellowImg, userAnswers.subRisk("Executive", "Finance"), 94, "bl");
            scaleDiv(superYellowImg, userAnswers.subRisk("Supervisor", "Finance"), 94, "bl");
            scaleDiv(teamYellowImg, userAnswers.subRisk("Team", "Finance"), 94, "bl");

            //sub slices, culture
            scaleDiv(execBlueImg, userAnswers.subRisk("Executive", "Culture"), 94, "br");
            scaleDiv(superBlueImg, userAnswers.subRisk("Supervisor", "Culture"), 94, "br");
            scaleDiv(teamBlueImg, userAnswers.subRisk("Team", "Culture"), 94, "br");
        }

        protected void scaleDiv(HtmlGenericControl div, decimal scale, int pos, string loc)
        {
            decimal s = (scale / 7);
            //decimal d = (decimal)s / 36;
            decimal wid = pos * s;

            string size = ((int)wid).ToString() + "px";
            div.Style.Add("width", size);
            div.Style.Add("height", size);

            int moveInt = (int)(pos - wid);
            string moT = moveInt.ToString() + "px";

            switch (loc)
            {
                case "tl":
                    div.Style.Add("top", moT);
                    div.Style.Add("left", moT);
                    break;
                case "tr":
                    div.Style.Add("top", moT);
                    break;
                case "bl":
                    div.Style.Add("left", moT);
                    break;
                case "br":
                    break;
            }
        }

        protected void fillLabels()
        {
            fillTeamLabels();
            fillExecutiveLabels();
            fillSuperLabels();

            fillMainRiskLabel();
            fillMainComplianceLabel();
            fillMainCultureLabel();
            fillMainFinanceLabel();
        }

        protected void fillTeamLabels()
        {
            string riskAvStr = "Average: " + userAnswers.subRisk("Team", "Risk").ToString("#.##");
            string culAvStr = "Average: " + userAnswers.subRisk("Team", "Culture").ToString("#.##");
            string compAvStr = "Average: " + userAnswers.subRisk("Team", "Compliance").ToString("#.##");
            string finAvStr = "Average: " + userAnswers.subRisk("Team", "Finance").ToString("#.##");

            string numRisk = "0: " + userAnswers.riskData.lineTeamData.num0Answer.ToString()
                + " || 1: " + userAnswers.riskData.lineTeamData.num1Answer.ToString()
                + " || 2: " + userAnswers.riskData.lineTeamData.num2Answer.ToString()
                + "<br />3: " + userAnswers.riskData.lineTeamData.num3Answer.ToString()
                + " || 4: " + userAnswers.riskData.lineTeamData.num4Answer.ToString()
                + " || 5: " + userAnswers.riskData.lineTeamData.num5Answer.ToString()
                + " || 6: " + userAnswers.riskData.lineTeamData.num6Answer.ToString();

            string numComp = "0: " + userAnswers.compData.lineTeamData.num0Answer.ToString()
                + " || 1: " + userAnswers.compData.lineTeamData.num1Answer.ToString()
                + " || 2: " + userAnswers.compData.lineTeamData.num2Answer.ToString()
                + "<br />3: " + userAnswers.compData.lineTeamData.num3Answer.ToString()
                + " || 4: " + userAnswers.compData.lineTeamData.num4Answer.ToString()
                + " || 5: " + userAnswers.compData.lineTeamData.num5Answer.ToString()
                + " || 6: " + userAnswers.compData.lineTeamData.num6Answer.ToString();

            string numCul = "0: " + userAnswers.cultureData.lineTeamData.num0Answer.ToString()
                + " || 1: " + userAnswers.cultureData.lineTeamData.num1Answer.ToString()
                + " || 2: " + userAnswers.cultureData.lineTeamData.num2Answer.ToString()
                + "<br />3: " + userAnswers.cultureData.lineTeamData.num3Answer.ToString()
                + " || 4: " + userAnswers.cultureData.lineTeamData.num4Answer.ToString()
                + " || 5: " + userAnswers.cultureData.lineTeamData.num5Answer.ToString()
                + " || 6: " + userAnswers.cultureData.lineTeamData.num6Answer.ToString();

            string numFin = "0: " + userAnswers.financeData.lineTeamData.num0Answer.ToString()
                + " || 1: " + userAnswers.financeData.lineTeamData.num1Answer.ToString()
                + " || 2: " + userAnswers.financeData.lineTeamData.num2Answer.ToString()
                + "<br />3: " + userAnswers.financeData.lineTeamData.num3Answer.ToString()
                + " || 4: " + userAnswers.financeData.lineTeamData.num4Answer.ToString()
                + " || 5: " + userAnswers.financeData.lineTeamData.num5Answer.ToString()
                + " || 6: " + userAnswers.financeData.lineTeamData.num6Answer.ToString();

            teamRiskLabel.Text = riskAvStr + "<br />Number of Don't Knows: "
                + userAnswers.riskData.lineTeamData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineTeamData.ToString()
                + "<br />" + numRisk;

            teamCompLabel.Text = compAvStr + "<br />Number of Don't Knows: "
                + userAnswers.compData.lineTeamData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineTeamData.ToString()
                + "<br />" + numComp;

            teamCulLabel.Text = culAvStr + "<br />Number of Don't Knows: "
                + userAnswers.cultureData.lineTeamData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineTeamData.ToString()
                + "<br />" + numCul;

            teamFinLabel.Text = finAvStr + "<br />Number of Don't Knows: "
                + userAnswers.financeData.lineTeamData.num7Answer.ToString().ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineTeamData.ToString()
                + "<br />" + numFin;
        }

        protected void fillExecutiveLabels()
        {
            string riskAvStr = "Average: " + userAnswers.subRisk("Executive", "Risk").ToString("#.##");
            string culAvStr = "Average: " + userAnswers.subRisk("Executive", "Culture").ToString("#.##");
            string compAvStr = "Average: " + userAnswers.subRisk("Executive", "Compliance").ToString("#.##");
            string finAvStr = "Average: " + userAnswers.subRisk("Executive", "Finance").ToString("#.##");

            string numRisk = "0: " + userAnswers.riskData.executiveData.num0Answer.ToString()
                + " || 1: " + userAnswers.riskData.executiveData.num1Answer.ToString()
                + " || 2: " + userAnswers.riskData.executiveData.num2Answer.ToString()
                + "<br />3: " + userAnswers.riskData.executiveData.num3Answer.ToString()
                + " || 4: " + userAnswers.riskData.executiveData.num4Answer.ToString()
                + " || 5: " + userAnswers.riskData.executiveData.num5Answer.ToString()
                + " || 6: " + userAnswers.riskData.executiveData.num6Answer.ToString();

            string numComp = "0: " + userAnswers.compData.executiveData.num0Answer.ToString()
                + " || 1: " + userAnswers.compData.executiveData.num1Answer.ToString()
                + " || 2: " + userAnswers.compData.executiveData.num2Answer.ToString()
                + "<br />3: " + userAnswers.compData.executiveData.num3Answer.ToString()
                + " || 4: " + userAnswers.compData.executiveData.num4Answer.ToString()
                + " || 5: " + userAnswers.compData.executiveData.num5Answer.ToString()
                + " || 6: " + userAnswers.compData.executiveData.num6Answer.ToString();

            string numCul = "0: " + userAnswers.cultureData.executiveData.num0Answer.ToString()
                + " || 1: " + userAnswers.cultureData.executiveData.num1Answer.ToString()
                + " || 2: " + userAnswers.cultureData.executiveData.num2Answer.ToString()
                + "<br />3: " + userAnswers.cultureData.executiveData.num3Answer.ToString()
                + " || 4: " + userAnswers.cultureData.executiveData.num4Answer.ToString()
                + " || 5: " + userAnswers.cultureData.executiveData.num5Answer.ToString()
                + " || 6: " + userAnswers.cultureData.executiveData.num6Answer.ToString();

            string numFin = "0: " + userAnswers.financeData.executiveData.num0Answer.ToString()
                + " || 1: " + userAnswers.financeData.executiveData.num1Answer.ToString()
                + " || 2: " + userAnswers.financeData.executiveData.num2Answer.ToString()
                + "<br />3: " + userAnswers.financeData.executiveData.num3Answer.ToString()
                + " || 4: " + userAnswers.financeData.executiveData.num4Answer.ToString()
                + " || 5: " + userAnswers.financeData.executiveData.num5Answer.ToString()
                + " || 6: " + userAnswers.financeData.executiveData.num6Answer.ToString();

            execRiskLabel.Text = riskAvStr + "<br />Number of Don't Knows: "
                + userAnswers.riskData.executiveData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_executiveData.ToString()
                + "<br />" + numRisk;

            execCompLabel.Text = compAvStr + "<br />Number of Don't Knows: "
                + userAnswers.compData.executiveData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_executiveData.ToString()
                + "<br />" + numComp;

            execCulLabel.Text = culAvStr + "<br />Number of Don't Knows: "
                + userAnswers.cultureData.executiveData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_executiveData.ToString()
                + "<br />" + numCul;

            execFinLabel.Text = finAvStr + "<br />Number of Don't Knows: "
                + userAnswers.financeData.executiveData.num7Answer.ToString().ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_executiveData.ToString()
                + "<br />" + numFin;
        }

        protected void fillSuperLabels()
        {
            string riskAvStr = "Average: " + userAnswers.subRisk("Supervisor", "Risk").ToString("#.##");
            string culAvStr = "Average: " + userAnswers.subRisk("Supervisor", "Culture").ToString("#.##");
            string compAvStr = "Average: " + userAnswers.subRisk("Supervisor", "Compliance").ToString("#.##");
            string finAvStr = "Average: " + userAnswers.subRisk("Supervisor", "Finance").ToString("#.##");

            string numRisk = "0: " + userAnswers.riskData.lineSuperData.num0Answer.ToString()
                + " || 1: " + userAnswers.riskData.lineSuperData.num1Answer.ToString()
                + " || 2: " + userAnswers.riskData.lineSuperData.num2Answer.ToString()
                + "<br />3: " + userAnswers.riskData.lineSuperData.num3Answer.ToString()
                + " || 4: " + userAnswers.riskData.lineSuperData.num4Answer.ToString()
                + " || 5: " + userAnswers.riskData.lineSuperData.num5Answer.ToString()
                + " || 6: " + userAnswers.riskData.lineSuperData.num6Answer.ToString();

            string numComp = "0: " + userAnswers.compData.lineSuperData.num0Answer.ToString()
                + " || 1: " + userAnswers.compData.lineSuperData.num1Answer.ToString()
                + " || 2: " + userAnswers.compData.lineSuperData.num2Answer.ToString()
                + "<br />3: " + userAnswers.compData.lineSuperData.num3Answer.ToString()
                + " || 4: " + userAnswers.compData.lineSuperData.num4Answer.ToString()
                + " || 5: " + userAnswers.compData.lineSuperData.num5Answer.ToString()
                + " || 6: " + userAnswers.compData.lineSuperData.num6Answer.ToString();

            string numCul = "0: " + userAnswers.cultureData.lineSuperData.num0Answer.ToString()
                + " || 1: " + userAnswers.cultureData.lineSuperData.num1Answer.ToString()
                + " || 2: " + userAnswers.cultureData.lineSuperData.num2Answer.ToString()
                + "<br />3: " + userAnswers.cultureData.lineSuperData.num3Answer.ToString()
                + " || 4: " + userAnswers.cultureData.lineSuperData.num4Answer.ToString()
                + " || 5: " + userAnswers.cultureData.lineSuperData.num5Answer.ToString()
                + " || 6: " + userAnswers.cultureData.lineSuperData.num6Answer.ToString();

            string numFin = "0: " + userAnswers.financeData.lineSuperData.num0Answer.ToString()
                + " || 1: " + userAnswers.financeData.lineSuperData.num1Answer.ToString()
                + " || 2: " + userAnswers.financeData.lineSuperData.num2Answer.ToString()
                + "<br />3: " + userAnswers.financeData.lineSuperData.num3Answer.ToString()
                + " || 4: " + userAnswers.financeData.lineSuperData.num4Answer.ToString()
                + " || 5: " + userAnswers.financeData.lineSuperData.num5Answer.ToString()
                + " || 6: " + userAnswers.financeData.lineSuperData.num6Answer.ToString();

            superRiskLabel.Text = riskAvStr + "<br />Number of Don't Knows: "
                + userAnswers.riskData.lineSuperData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineSuperData.ToString()
                + "<br />" + numRisk;

            superCompLabel.Text = compAvStr + "<br />Number of Don't Knows: "
                + userAnswers.compData.lineSuperData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineSuperData.ToString()
                + "<br />" + numComp;

            superCulLabel.Text = culAvStr + "<br />Number of Don't Knows: "
                + userAnswers.cultureData.lineSuperData.num7Answer.ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineSuperData.ToString()
                + "<br />" + numCul;

            superFinLabel.Text = finAvStr + "<br />Number of Don't Knows: "
                + userAnswers.financeData.lineSuperData.num7Answer.ToString().ToString()
                + "<br />Number of Employees: "
                + userAnswers.num_lineSuperData.ToString()
                + "<br />" + numFin;
        }

        protected void fillMainRiskLabel()
        {
            string riskAvStr = "Average: " + userAnswers.getTotalRisk().ToString("#.##");

            List<string> ls = userAnswers.riskData.getTotalnum();

            string numRisk = "0: " + ls[0]
                + " || 1: " + ls[1]
                + " || 2: " + ls[2]
                + "<br />3: " + ls[3]
                + " || 4: " + ls[4]
                + " || 5: " + ls[5]
                + " || 6: " + ls[6];

            riskAvLab.InnerHtml = riskAvStr + "<br />Number of Don't Knows: "
                + ls[7]
                + "<br />Number of Employees: "
                + userAnswers.getTotalPeople().ToString()
                + "<br />" + numRisk;
        }
        protected void fillMainCultureLabel()
        {
            string culAvStr = "Average: " + userAnswers.getTotalCulture().ToString("#.##");

            List<string> ls = userAnswers.cultureData.getTotalnum();

            string numCul = "0: " + ls[0]
                + " || 1: " + ls[1]
                + " || 2: " + ls[2]
                + "<br />3: " + ls[3]
                + " || 4: " + ls[4]
                + " || 5: " + ls[5]
                + " || 6: " + ls[6];

            cultureAvLab.InnerHtml = culAvStr + "<br />Number of Don't Knows: "
                + ls[7].ToString()
                + "<br />Number of Employees: "
                + userAnswers.getTotalPeople().ToString()
                + "<br />" + numCul;
        }
        protected void fillMainComplianceLabel()
        {
            string compAvStr = "Average: " + userAnswers.getTotalCompliance().ToString("#.##");

            List<string> ls = userAnswers.compData.getTotalnum();

            string numComp = "0: " + ls[0]
                + " || 1: " + ls[1]
                + " || 2: " + ls[2]
                + "<br />3: " + ls[3]
                + " || 4: " + ls[4]
                + " || 5: " + ls[5]
                + " || 6: " + ls[6];

            compAvLab.InnerHtml = compAvStr + "<br />Number of Don't Knows: "
                + ls[7].ToString()
                + "<br />Number of Employees: "
                + userAnswers.getTotalPeople().ToString()
                + "<br />" + numComp;
        }
        protected void fillMainFinanceLabel()
        {
            string finAvStr = "Average: " + userAnswers.getTotalFinance().ToString("#.##");

            List<string> ls = userAnswers.financeData.getTotalnum();

            string numFin = "0: " + ls[0]
                + " || 1: " + ls[1]
                + " || 2: " + ls[2]
                + "<br />3: " + ls[3]
                + " || 4: " + ls[4]
                + " || 5: " + ls[5]
                + " || 6: " + ls[6];

            financialAvLab.InnerHtml = finAvStr + "<br />Number of Don't Knows: "
                + ls[7]
                + "<br />Number of Employees: "
                + userAnswers.getTotalPeople().ToString()
                + "<br />" + numFin;
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            string r = riskDrop.SelectedItem.ToString();
            string cu = culDrop.SelectedItem.ToString();
            string co = compDrop.SelectedItem.ToString();
            string f = finDrop.SelectedItem.ToString();

            string newUrl = "~/Admin.aspx?risk=" + r + "&cul=" + cu + "&comp=" + co + "&fin=" + f;
            Response.Redirect(newUrl);
        }
    }
}