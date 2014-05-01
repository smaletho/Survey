<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="ThreeSixSafety.Admin" %>

<!DOCTYPE html>

<link href="CircumplexStyle.css" rel="stylesheet" />
<link href="AdminStyle.css" rel="stylesheet" />

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="text-align: center">
                <h1 style="font-family: Calibri">Circumplex Data</h1>
            </div>
            <div class="divCSS">
                <table>
                    <tr>
                        <td style="position: absolute; height: 145px; width: 350px; left: -370px;background-color:lightgray;opacity:0.7">
                            <h2 class="headText">I. Risk Mitigation</h2>
                            <h3 id="riskAvLab" class="overlayText" runat="server">Average = XX%</h3>
                            <br />
                        </td>
                        <td rowspan="2" style="width: 300px; height: 300px; position: absolute;">
                            <div id="topLeftDiv" class="hovDiv" runat="server">

                                <div id="topLeftOverlay" runat="server">
                                </div>
                            </div>
                            <div id="topRightDiv" class="hovDiv" runat="server">

                                <div id="topRightOverlay" runat="server">
                                </div>
                            </div>
                            <div id="botLeftDiv" class="hovDiv" runat="server">

                                <div id="botLeftOverlay" runat="server">
                                </div>
                            </div>
                            <div id="botRightDiv" class="hovDiv" runat="server">

                                <div id="botRightOverlay" runat="server">
                                </div>
                            </div>

                            <asp:Image ID="Image1" ImageUrl="Images/full-circle.png" CssClass="mainCSS" runat="server" />
                        </td>
                        <td style="position: absolute; height: 145px; width: 350px; left: -370px; top: 158px;background-color:lightgray;opacity:0.7">
                            <h2 class="headText">IV. Financial</h2>
                            <h3 id="financialAvLab" class="overlayText" runat="server">Average = XX%</h3>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="position: absolute; height: 145px; width: 350px; left: 320px;background-color:lightgray;opacity:0.7">
                            <h2 class="headText">II. Regulatory Compliance</h2>
                            <h3 id="compAvLab" class="overlayText" runat="server">Average = XX%</h3>
                            <br />
                        </td>
                        <td style="position: absolute; height: 145px; width: 350px; left: 320px; top: 158px;background-color:lightgray;opacity:0.7">
                            <h2 class="headText">III. Culture</h2>
                            <h3 id="cultureAvLab" class="overlayText" runat="server">Average = XX%</h3>
                            <br />
                        </td>
                    </tr>
                </table>

            </div>
            <br />
            <hr />
            <br />
            <div style="text-align: center; margin: 0 auto">
                <table style="width: 640px; margin-left: auto; margin-right: auto">
                    <tr>
                        <td style="width: 200px; font-family: Calibri">Executive Management
                        </td>
                        <td style="width: 20px"></td>
                        <td style="width: 200px; font-family: Calibri">Line Supervisor
                        </td>
                        <td style="width: 20px"></td>
                        <td style="width: 200px; font-family: Calibri">Line Team Supervisor
                        </td>
                    </tr>
                </table>
                <table style="width: 640px; height: 200px; margin-left: auto; margin-right: auto">
                    <tr>
                        <td>
                            <div style="position: relative; border-style: solid">
                                <div id="execPurpleImg" style="background-image: url('Images/1-purple.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; z-index: -1" runat="server"></div>
                                <div id="execRedImg" style="background-image: url('Images/2-red.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; left: 94px; z-index: -1" runat="server"></div>
                                <div id="execBlueImg" style="background-image: url('Images/3-blue.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; top: 94px; left: 94px; z-index: -1" runat="server"></div>
                                <div id="execYellowImg" style="background-image: url('Images/4-yellow.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; top: 94px; z-index: -1" runat="server"></div>
                                <asp:Image ID="Image2" ImageUrl="Images/full-circle.png" runat="server" Style="width: 100%; z-index: 5" />
                            </div>
                        </td>
                        <td style="width: 20px"></td>
                        <td>
                            <div style="position: relative; border-style: solid">
                                <div id="superPurpleImg" style="background-image: url('Images/1-purple.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; z-index: -1" runat="server"></div>
                                <div id="superRedImg" style="background-image: url('Images/2-red.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; left: 94px; z-index: -1" runat="server"></div>
                                <div id="superBlueImg" style="background-image: url('Images/3-blue.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; top: 94px; left: 94px; z-index: -1" runat="server"></div>
                                <div id="superYellowImg" style="background-image: url('Images/4-yellow.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; top: 94px; z-index: -1" runat="server"></div>

                                <asp:Image ID="Image3" ImageUrl="Images/full-circle.png" runat="server" Style="width: 100%; z-index: 5" />
                            </div>
                        </td>
                        <td style="width: 20px"></td>
                        <td>
                            <div style="position: relative; border-style: solid">
                                <div id="teamPurpleImg" style="background-image: url('Images/1-purple.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; z-index: -1" runat="server"></div>
                                <div id="teamRedImg" style="background-image: url('Images/2-red.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; left: 94px; z-index: -1" runat="server"></div>
                                <div id="teamBlueImg" style="background-image: url('Images/3-blue.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; top: 94px; left: 94px; z-index: -1" runat="server"></div>
                                <div id="teamYellowImg" style="background-image: url('Images/4-yellow.png'); background-size: 100%; position: absolute; height: 94px; width: 94px; top: 94px; z-index: -1" runat="server"></div>

                                <asp:Image ID="Image4" ImageUrl="Images/full-circle.png" runat="server" Style="width: 100%; z-index: 5" />
                            </div>
                        </td>
                    </tr>
                </table>
                <table style="width: 640px; height: 480px; margin-left: auto; margin-right: auto">
                    <tr>
                        <td style="border-style: solid; width: 200px; border-color: #7030a0">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Risk</label>
                            <br />
                            <asp:Label ID="execRiskLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #7030a0">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Risk</label>
                            <br />
                            <asp:Label ID="superRiskLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #7030a0">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Risk</label>
                            <br />
                            <asp:Label ID="teamRiskLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>

                    </tr>
                    <tr>
                        <td style="border-style: solid; width: 200px; border-color: #c10001">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Compliance</label>
                            <br />
                            <asp:Label ID="execCompLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #c10001">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Compliance</label>
                            <br />
                            <asp:Label ID="superCompLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #c10001">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Compliance</label>
                            <br />
                            <asp:Label ID="teamCompLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; width: 200px; border-color: #022161">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Culture</label>
                            <br />
                            <asp:Label ID="execCulLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #022161">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Culture</label>
                            <br />
                            <asp:Label ID="superCulLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #022161">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Culture</label>
                            <br />
                            <asp:Label ID="teamCulLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid; width: 200px; border-color: #e46c0d;">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Finance</label>
                            <br />
                            <asp:Label ID="execFinLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #e46c0d;">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Finance</label>
                            <br />
                            <asp:Label ID="superFinLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                        <td style="width: 20px"></td>
                        <td style="border-style: solid; width: 200px; border-color: #e46c0d;">
                            <br />
                            <label style="font-family: Calibri; font-weight: bold">Finance</label>
                            <br />
                            <asp:Label ID="teamFinLabel" runat="server" Style="font-family: Calibri"></asp:Label>
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <hr />
            <br />
            <div style="text-align: center">
                <asp:Button ID="editQuestions" runat="server" Text="Edit/Add Questions" CssClass="buttonStyle" />
                <asp:Button ID="exportCSV" runat="server" Text="Export Answers as CSV file" CssClass="buttonStyle" />
                <br />
                <asp:Button ID="printButton" runat="server" Text="Create Printout" />
            </div>
        </div>
    </form>
</body>
</html>
