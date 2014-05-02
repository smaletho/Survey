<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ThreeSixSafety.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Survey Home</title>
</head>
<body>

    <script lang="jv">

        function showDiv() {
            document.getElementById('loginDiv').style.visibility = 'visible';
        }

    </script>

    <form id="homeForm" runat="server">
    <div data-role="page">
        <div data-role="content" style="text-align:center">
            <asp:Label ID="Label1" runat="server" Text="Welcome to the Survey"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="nameBox" runat="server" placeholder="Enter your name" Width="200px"></asp:TextBox>
            <br />
   
            <br />
            <asp:Button ID="submitButton" runat="server" Text="Take Survey" OnClick="submitButton_Click"/>
            
            <br />
            <br />
            <a href="#" id="logLink" onclick="showDiv()">Login to Admin portal</a>
            <br />
            <div id="loginDiv" style="visibility:hidden">
                <br />
                <asp:TextBox ID="loginBox" runat="server" placeholder="Enter username"></asp:TextBox>
                <br />
                <asp:TextBox ID="passwordBox" runat="server" placeholder="Enter password" TextMode="Password"></asp:TextBox>
                <br />
                <asp:Button ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
                
            </div>
            
        </div>

    </div>
    </form>
</body>
</html>
