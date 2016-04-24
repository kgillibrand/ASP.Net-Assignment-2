<%@ Page Title="Add Product (Admin) - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Admin/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Assignment_2.Admin.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager runat = "server">
    </asp:ScriptManager>

    <div style = "text-align: center;">
        <div style = "width: 1000px; margin-left: auto; margin-right: auto;">

            <table>

                <tr>
                    <td>
                        Product Category:
                    </td>
                    <td>
                        <asp:DropDownList ID = "categories" runat = "server" ToolTip = "Select a Category" Width = "300px">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        Product Name:
                    </td>
                    <td>
                        <asp:TextBox ID = "name" runat = "server" TextMode = "SingleLine" Width = "300px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate = "name" runat = "server" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Short Description:
                    </td>
                    <td>
                        <asp:TextBox ID = "shortDescription" runat ="server" TextMode = "MultiLine" Width = "600px" Height = "150px">
                        </asp:TextBox>
                        <ajaxToolkit:HtmlEditorExtender TargetControlID = "shortDescription" runat = "server" EnableSanitization = "false" ID = "shortDescriptionExtender">
                            <Toolbar> 
                                <ajaxToolkit:Undo />
                                <ajaxToolkit:Redo />
                                <ajaxToolkit:Bold />
                                <ajaxToolkit:Italic />
                                <ajaxToolkit:Underline />
                                <ajaxToolkit:StrikeThrough />
                                <ajaxToolkit:Subscript />
                                <ajaxToolkit:Superscript />
                                <ajaxToolkit:JustifyLeft />
                                <ajaxToolkit:JustifyCenter />
                                <ajaxToolkit:JustifyRight />
                                <ajaxToolkit:JustifyFull />
                                <ajaxToolkit:InsertOrderedList />
                                <ajaxToolkit:InsertUnorderedList />
                                <ajaxToolkit:CreateLink />
                                <ajaxToolkit:UnLink />
                                <ajaxToolkit:RemoveFormat />
                                <ajaxToolkit:SelectAll />
                                <ajaxToolkit:UnSelect />
                                <ajaxToolkit:Delete />
                                <ajaxToolkit:Cut />
                                <ajaxToolkit:Copy />
                                <ajaxToolkit:Paste />
                                <ajaxToolkit:BackgroundColorSelector />
                                <ajaxToolkit:ForeColorSelector />
                                <ajaxToolkit:FontNameSelector />
                                <ajaxToolkit:FontSizeSelector />
                                <ajaxToolkit:Indent />
                                <ajaxToolkit:Outdent />
                                <ajaxToolkit:InsertHorizontalRule />
                            </Toolbar>
                        </ajaxToolkit:HtmlEditorExtender>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate = "shortDescription" runat = "server" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Long Description:
                    </td>
                    <td>
                        <asp:TextBox ID = "longDescription" runat = "server" TextMode = "MultiLine" Width = "600px" Height = "300px">
                        </asp:TextBox>
                        <ajaxToolkit:HtmlEditorExtender TargetControlID = "longDescription" runat = "server" EnableSanitization = "false" ID = "longDescriptionExtender">
                            <Toolbar> 
                                <ajaxToolkit:Undo />
                                <ajaxToolkit:Redo />
                                <ajaxToolkit:Bold />
                                <ajaxToolkit:Italic />
                                <ajaxToolkit:Underline />
                                <ajaxToolkit:StrikeThrough />
                                <ajaxToolkit:Subscript />
                                <ajaxToolkit:Superscript />
                                <ajaxToolkit:JustifyLeft />
                                <ajaxToolkit:JustifyCenter />
                                <ajaxToolkit:JustifyRight />
                                <ajaxToolkit:JustifyFull />
                                <ajaxToolkit:InsertOrderedList />
                                <ajaxToolkit:InsertUnorderedList />
                                <ajaxToolkit:CreateLink />
                                <ajaxToolkit:UnLink />
                                <ajaxToolkit:RemoveFormat />
                                <ajaxToolkit:SelectAll />
                                <ajaxToolkit:UnSelect />
                                <ajaxToolkit:Delete />
                                <ajaxToolkit:Cut />
                                <ajaxToolkit:Copy />
                                <ajaxToolkit:Paste />
                                <ajaxToolkit:BackgroundColorSelector />
                                <ajaxToolkit:ForeColorSelector />
                                <ajaxToolkit:FontNameSelector />
                                <ajaxToolkit:FontSizeSelector />
                                <ajaxToolkit:Indent />
                                <ajaxToolkit:Outdent />
                                <ajaxToolkit:InsertHorizontalRule />
                            </Toolbar>
                        </ajaxToolkit:HtmlEditorExtender>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate = "longDescription" runat = "server" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Product Price:
                    </td>
                    <td>
                        <asp:TextBox ID = "price" runat = "server" TextMode = "SingleLine" Width = "200px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate = "price" runat = "server" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate = "price" runat = "server" ErrorMessage = "A numerical value is required" ValidationExpression = "^[0-9]\d*(\.\d+)?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        Product Sale Price:
                    </td>
                    <td>
                        <asp:TextBox ID = "salePrice" runat = "server" TextMode = "SingleLine" Width = "200px">
                        </asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ControlToValidate = "salePrice" runat = "server" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ControlToValidate = "salePrice" runat = "server" ErrorMessage = "A numerical value is required" ValidationExpression = "^[0-9]\d*(\.\d+)?$">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:CheckBox ID = "onSale" runat = "server" Text = "Item on sale?" />
                    </td>
                </tr>

                <tr>
                    <td>
                        Product Image:
                    </td>
                    <td>
                        <asp:Image runat = "server" ID = "currentImage" ToolTip = "Current product image" AlternateText = "This product has no image" Width = "200px" Height = "200px"/>
                    </td>
                </tr>
                        
                <tr>
                    <td>
                        New Product Image:
                    </td>
                    <td>
                        <asp:FileUpload ID = "newImage" runat = "server" ToolTip = "Upload new image"/>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button id = "submit" runat = "server" Text = "Submit" CausesValidation = "true" OnClick = "submit_Click"/>
                    </td>
                </tr>

            </table>

        </div>
    </div>
</asp:Content>
