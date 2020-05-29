<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffSearch.aspx.cs" Inherits="Data_Driven_6518_Survey_App.StaffSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Registration</title>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link rel="stylesheet" runat="server" type="text/css" href="../Content/staffsearch.css"/>
</head>
<body>
    <div class="container">
        <div class="col-lg-12 marginTop">
            <strong class="col-lg-2">User Name</strong>
            <div class="col-lg-4">
            <input class="form-control" type="text" /></div>
        </div>
        <div class=""></div>
        <div class="col-lg-12 marginTop">
            <strong class="col-lg-2">Category</strong>
             <div class="col-lg-4">
            <select class="form-control">
                <option>bank</option>
                <option>news paper</option>
                <option>sports</option>
                <option>bank service</option>
            </select>
            </div>
            <br />
             <div class="marginTop col-lg-4">
            <input class="form-control" type="text" />
            </div>
        </div>        
        <div class="marginTop col-lg-12">
        <strong class="col-lg-2">Description</strong>
        <div class=" col-lg-8">
            <textarea class="form-control"></textarea>                
            </div>
        </div>
         <br />
        <div class="marginTop col-lg-12 ">
        <input type="submit" value="submit" class="btn btn-primary"/>
        </div>
</div>
</body>
</html>
