<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="Data_Driven_6518_Survey_App.StaffLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:TextBox ID="userNameText" runat="server"></asp:TextBox>
        <asp:TextBox ID="passwordText" runat="server"></asp:TextBox>
        <asp:Button ID="LoginConfirmBtn" runat="server" OnClick="LoginConfirmBtn_Click" Text="Confirm" />
    </form>
</body>
</html>
