<%@ Page Title="Checkout - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Assignment_2.Site.Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 50%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <table>
            
                <tr>
                    <td>
                        Full Name:
                    </td>

                    <td>
                        <asp:TextBox ID = "name" runat = "server" TextMode = "SingleLine" ToolTip = "Enter your name" Width = "15%">
                        </asp:TextBox>
                    </td>

                    <td>
                        <asp:RequiredFieldValidator runat = "server" ControlToValidate = "name" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Credit Card Number (9 Digit):
                    </td>

                    <td>
                        <asp:TextBox ID = "number" runat = "server" TextMode = "SingleLine" ToolTip = "Enter your credit card number" Width = "15%">
                        </asp:TextBox>
                    </td>

                    <td>
                        <asp:RequiredFieldValidator runat = "server" ControlToValidate = "number" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>

                    <td>
                        <asp:RegularExpressionValidator runat = "server" ControlToValidate = "number" ValidationExpression = "^\d{9}$" ErrorMessage = "Invalid number (9 digits only)">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Credit Card Expiry (mm/yy):
                    </td>

                    <td>
                        <asp:TextBox ID = "expiry" runat = "server" TextMode = "SingleLine" ToolTip = "Enter your credit card expiry date (mm/yy)" Width = "15%">
                        </asp:TextBox>
                    </td>

                    <td>
                        <asp:RequiredFieldValidator runat = "server" ControlToValidate = "expiry" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>

                    <td>
                        <asp:RegularExpressionValidator runat = "server" ControlToValidate = "expiry" ValidationExpression = "(0[1-9]|1[0-2])\/[0-9]{2}" ErrorMessage = "Invalid format (mm/yy)">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID = "submit" runat = "server" Text = "Submit" CausesValidation = "true" OnClick = "submit_Click" />
                    </td>
                    <td>
                        <asp:Button ID = "cancel" runat = "server" Text = "Cancel Transaction" CausesValidation = "false" OnClick = "cancel_Click" />
                    </td>
                </tr>

            </table>

        </div>
    </div>

</asp:Content>
