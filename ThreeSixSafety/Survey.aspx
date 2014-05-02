<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Survey.aspx.cs" Inherits="ThreeSixSafety.Survey" %>

<!DOCTYPE html>

<style>
    .questionLabelCSS {
        font-weight:bold;
        font-style:italic;
    }
    .yesNoBoxCSS {
        width:20%;
        
    }
    .radioButtonSpaceCSS input[type="radio"] {
        margin-left:50px;
        margin-right:50px;
    }
</style>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div data-role="page">
        <div data-role="content">
            <div style="text-align:center">
                <asp:Label ID="personNameLabel" runat="server" Font-Bold="True" Font-Size="XX-Large">Welcome, person&#39;s name</asp:Label>

                <br />
            </div>
            <div>
                <asp:Panel ID="questionPanel" runat="server"></asp:Panel>
            </div>
            <asp:Button ID="submitButton" runat="server" Text="Submit" OnClick="submitButton_Click" />
        </div>
    </div>
    </form>
</body>
</html>

