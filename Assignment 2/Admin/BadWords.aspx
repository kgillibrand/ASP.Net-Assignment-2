<%@ Page Title="Bad Words (Admin) - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Admin/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="BadWords.aspx.cs" Inherits="Assignment_2.Admin.BadWords" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 50%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <br /> <br />

            Bad Words <br />
            <asp:GridView ID = "badWords" runat = "server" AllowPaging = "true" PageSize = "20" AutoGenerateColumns = "false" EmptyDataText = "No Bad Words to Display" ToolTip = "Bad Words =(" Width = "100%">
                <Columns>
                    <asp:BoundField HeaderText = "Bad Word" DataField = "wordText"/>
                    <asp:BoundField HeaderText = "Date/Time Added" DataField = "wordAdded"/>
                    <asp:TemplateField HeaderText = "Actions">
                        <ItemTemplate>
                            <asp:Button ID = "deleteWord" runat = "server" CommandArgument = '<%# Eval ("wordID") %>'  Text = "Delete" OnClick = "deleteWord_Click" CausesValidation = "false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br /> <br />

            <asp:TextBox ID = "writeBadWord" runat = "server">
            </asp:TextBox>

            <br />

            <asp:RegularExpressionValidator runat = "server" ControlToValidate = "writeBadWord" ErrorMessage = "Enter one word, no spaces allowed" ValidationExpression = "[^\s]+" />
            <asp:RequiredFieldValidator runat = "server" ControlToValidate = "writeBadWord" ErrorMessage = "This field is required" />

            <br />

            <asp:Button ID = "submitBadWord" Text = "Add Bad Word" OnClick  = "submitBadWord_Click" runat = "server" CausesValidation = "true"/>
       </div>
    </div>

</asp:Content>
