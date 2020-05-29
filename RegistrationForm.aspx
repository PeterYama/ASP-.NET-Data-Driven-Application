<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="Data_Driven_6518_Survey_App.RegistrationForm" %>

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
    <link rel="stylesheet" runat="server" type="text/css" href="../Content/register.css"/>
</head>
<body>
    <div class="container register-form">
            <div class="form">
                <div class="note">
                    <p>User Registration</p>
                </div>

                <div class="form-content">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Your Name *" value=""/>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Phone Number *" value=""/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Your Password *" value=""/>
                            </div>
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Confirm Password *" value=""/>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Date of Birth" value=""/>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <input type="text" class="form-control" placeholder="Email" value=""/>
                            </div>
                           
                        </div>
                    </div>
                    <button type="button" class="btnSubmit">Submit</button>
                </div>
            </div>
        </div>
</body>
</html>
