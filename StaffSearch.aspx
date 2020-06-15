<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffSearch.aspx.cs" Inherits="Data_Driven_6518_Survey_App.StaffSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Sort By"></asp:Label>
            <br />
            <asp:DropDownList ID="adminSelectionDropdown" 
                runat="server" 
                Height="30px" 
                Width="361px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>User Name</asp:ListItem>
                <asp:ListItem>Newest entries</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Banks used"></asp:Label>
            <br />
            <asp:DropDownList ID="bankUsedDropdown" runat="server" Width="363px" Height="16px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Wespac</asp:ListItem>
                <asp:ListItem>NAB</asp:ListItem>
                <asp:ListItem>ANZ</asp:ListItem>
                <asp:ListItem>Internet Banking</asp:ListItem>
                <asp:ListItem>Bendigo Bank</asp:ListItem>
                <asp:ListItem>Common-Wealth</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Banks Services"></asp:Label>
            <br />
            <asp:DropDownList ID="bankServiceDropDown" runat="server" Height="19px" Width="363px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Home Loan</asp:ListItem>
                <asp:ListItem>Credit Card</asp:ListItem>
                <asp:ListItem>Share Investment</asp:ListItem>
                <asp:ListItem>Property</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Label ID="Label4" runat="server" Text="Sex"></asp:Label>
            <br />
            <asp:DropDownList ID="sexDropDown" runat="server" Height="16px" Width="361px">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
                <asp:ListItem>Preffer not to say</asp:ListItem>
            </asp:DropDownList>
            <br />
        </div>
        <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click1" style="height: 26px" Width="61px" />
        <br />
        <br />
        <br />
        <asp:GridView ID="resultGridView" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
