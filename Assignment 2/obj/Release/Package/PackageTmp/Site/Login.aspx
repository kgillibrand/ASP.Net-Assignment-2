<%@ Page Title="Login - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Assignment_2.Site.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 50%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <asp:Login ID = "login" runat = "server" Width = "50%" UserNameLabelText = "Algonquin College Username: " PasswordLabelText = "Algonquin College Password: " LoginButtonText = "Login" FailureText = "Incorrect username or password" DisplayRememberMe = "false" OnAuthenticate = "login_Authenticate" ToolTip = "Enter your Algonquin College username and password">
            </asp:Login>

        </div>
    </div>

</asp:Content>
