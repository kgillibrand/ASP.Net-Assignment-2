<%@ Page Title="Add Category (Admin) - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Admin/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Assignment_2.Admin.AddCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 40%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <table>

                <tr>
                    <td>
                        Category Name:
                    </td>
                    <td>
                        <asp:TextBox ID = "name" runat = "server" TextMode = "SingleLine" Width = "300px" ToolTip = "Category Name">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate = "name" runat = "server" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID = "submit" runat = "server" Text = "Submit" OnClick = "submit_Click" CausesValidation = "true"/>
                    </td>
                </tr>

            </table>

        </div>
    </div>

</asp:Content>
