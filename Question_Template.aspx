<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Question_Template.aspx.cs" Inherits="Data_Driven_6518_Survey_App._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container title-container" style="text-align: left">
        <asp:Label ID="Label1" 
            runat="server"
            Font-Bold="true"                            
            Text="Question: "></asp:Label>
        <asp:Label ID="id_lbl" 
            Font-Bold="true"                            
            runat="server"></asp:Label>
                   <br />
                   <br />
                <asp:Label ID="question_lbl"
                    Font-Bold="true"                    
                    runat="server"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container card-container">
        <div class="card">
            <div class="card-body">
                <asp:Label ID="option_lbl" runat="server" Text=""></asp:Label>
                <p class="card-text">
                <asp:Button ID="endButton" 
                    class="btn btn-secondary" 
                    runat="server" 
                    Visible="false"
                    Text="Exit" 
                    OnClick="endButton_Click" />
                </p>
                <p class="card-text">
                    <asp:Label ID="textBox_lbl" runat="server" Text="" Visible="False"></asp:Label>
                </p>
                <asp:TextBox ID="answer_txtBox" 
                    runat="server" 
                    Visible="false">
                </asp:TextBox>
                <br />
                <asp:RadioButtonList ID="radioButtonList"
                    CssClass="spaced"
                    Visible="false"
                    runat="server" 
                    OnSelectedIndexChanged="radioButtonList_SelectedIndexChanged">
                </asp:RadioButtonList>
                <br />
                <asp:CheckBoxList ID="checkBoxList" 
                    CellPadding="5"
                    CellSpacing="5"
                    CssClass="checkBoxSpace"
                    Visible="false"
                    RepeatColumns="1"
                    RepeatDirection="Vertical"
                    RepeatLayout="Flow"
                    TextAlign="Right"
                    runat="server" 
                    OnSelectedIndexChanged="BoxClicked">
                </asp:CheckBoxList>
                <br />
                <div class="container button-container mx-5">
                    <asp:Button ID="next_btn" 
                    class="btn btn-primary btn-lg btn-block" 
                    runat="server" 
                    Text="Next" 
                    OnClick="next_btn_Click1" />
                </div>
                <asp:Button ID="Check_Session" 
                    class="btn btn-secondary" 
                    Visible="true"
                    runat="server" 
                    OnClick="Check_Session_Click" 
                    Text="Check " />
                <asp:Button ID="register_btn" 
                    class="btn btn-info" 
                    Visible="false"
                    runat="server" 
                    Text="Register" 
                    OnClick="register_btn_Click1" />

                <asp:Button ID="staff_search_btn" 
                    Visible="false"
                    class="btn btn-success" 
                    runat="server" 
                    Text="Staff Search" 
                    OnClick="staff_search_btn_Click" />
                <asp:Label ID="error_lbl" 
                    runat="server" 
                    Text="">
                </asp:Label>
            </div>
            
        </div>
    </div>

    </asp:Content>
