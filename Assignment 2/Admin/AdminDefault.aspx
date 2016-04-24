<%@ Page Title="Admin Home - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Admin/MasterPageAdminMenu.Master" AutoEventWireup="true" CodeBehind="AdminDefault.aspx.cs" Inherits="Assignment_2.Admin.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 60%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <h3>All Products</h3>
            <asp:GridView ID = "products" runat = "server" AutoGenerateColumns = "false" EmptyDataText = "No items to display" ToolTip = "All products in the database"  Width = "100%">
                <Columns>
                    <asp:HyperLinkField DataTextField = "productName" HeaderText = "Product Name" DataNavigateUrlFields = "productID" DataNavigateUrlFormatString = "~/Site/ProductDetails.aspx?productID={0}"/>
                    <asp:HyperLinkField DataTextField = "categoryName" HeaderText = "Category Name" DataNavigateUrlFields = "categoryID" DataNavigateUrlFormatString = "~/Site/CategoryDetails.aspx?categoryID={0}"/>
                    <asp:BoundField DataField = "productPrice" HeaderText = "Price" />
                    <asp:BoundField DataField = "productSalePrice" HeaderText = "Sale Price" />
                    <asp:TemplateField HeaderText = "Is Product On Sale" SortExpression = "productOnSale">
                                    <ItemTemplate>
                                        <%# (Convert.ToBoolean (Eval ("productOnSale"))) ? "Yes" : "No" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                    <asp:TemplateField HeaderText = "Product Image" ItemStyle-HorizontalAlign = "Center">
                        <ItemTemplate>
                            <asp:Image ImageUrl = '<%#"/FetchImage.ashx?productName=" + Eval ("productName") + "&productID=" + Eval ("productID")%>' Width = "150" runat = "server" Height = "150"/>
                        </ItemTemplate>
                    </asp:TemplateField>                          
                    <asp:BoundField DataField = "productShortDescription" HeaderText = "Description" />
                    <asp:BoundField DataField = "productAdded" HeaderText = "Product Added" />
                    <asp:TemplateField HeaderText = "Actions">
                        <ItemTemplate>
                            <asp:Button ID = "editProduct" runat = "server" CommandArgument = '<%#Eval ("productID")%>'  Text = "Edit" OnClick = "editProduct_Click" CausesValidation = "false" ToolTip = "Edit product" />
                            <asp:Button ID = "deleteProduct" runat = "server" CommandArgument = '<%#Eval ("productID")%>'  Text = "Delete" OnClick = "deleteProduct_Click" CausesValidation = "false" ToolTip = "Delete product"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <br /> <br />

            <h3>All Categories</h3>
            <asp:GridView ID = "categories" runat = "server" EmptyDataText = "No categories to display" AutoGenerateColumns = "false" Width = "800px" ToolTip = "All categoires in the database">
                <Columns>
                    <asp:HyperLinkField DataTextField = "categoryName" HeaderText = "Categories" DataNavigateUrlFields = "categoryID" DataNavigateUrlFormatString = "~/Site/CategoryDetails.aspx?categoryID={0}"/>
                    <asp:BoundField DataField = "categoryAdded" HeaderText = "Category Added" />
                    <asp:TemplateField HeaderText = "Actions">
                            <ItemTemplate>
                                <asp:Button ID = "editCategory" runat = "server" CommandArgument = '<%#Eval ("categoryID")%>'  Text = "Edit" OnClick = "editCategory_Click" CausesValidation = "false" ToolTip = "Edit category" />
                                <asp:Button ID = "deleteCategory" runat = "server" CommandArgument = '<%#Eval ("categoryID")%>'  Text = "Delete" OnClick = "deleteCategory_Click" CausesValidation = "false" ToolTip = "Delete category" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
