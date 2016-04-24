<%@ Page Title="Cart - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Assignment_2.Site.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 80%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <h3>Shopping Cart</h3>
            <asp:GridView ID = "cart" runat = "server" AutoGenerateColumns = "false" EmptyDataText = "No items in cart" ToolTip = "Items in your cart" Width = "80%">
                <Columns>
                    <asp:HyperLinkField DataTextField = "Name" HeaderText = "Product Name" DataNavigateUrlFields = "productID" DataNavigateUrlFormatString = "~/Site/ProductDetails.aspx?productID={0}"/>
                    <asp:HyperLinkField DataTextField = "CategoryName" HeaderText = "Category Name" DataNavigateUrlFields = "CategoryID" DataNavigateUrlFormatString = "~/Site/CategoryDetails.aspx?categoryID={0}"/>
                    <asp:BoundField DataField = "Price" HeaderText = "Price" />
                    <asp:BoundField DataField = "SalePrice" HeaderText = "Sale Price" />
                    <asp:TemplateField HeaderText = "Is Product On Sale" SortExpression = "OnSale">
                                    <ItemTemplate>
                                        <%# (Convert.ToBoolean (Eval ("OnSale"))) ? "Yes" : "No" %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                    <asp:TemplateField HeaderText = "Product Image" ItemStyle-HorizontalAlign = "Center">
                        <ItemTemplate>
                            <asp:Image ImageUrl = '<%#"/FetchImage.ashx?productName=" + Eval ("Name") + "&productID=" + Eval ("ProductID")%>' Width = "150" runat = "server" Height = "150"/>
                        </ItemTemplate>
                    </asp:TemplateField>                
                    <asp:BoundField DataField = "ShortDescription" HeaderText = "Description" />
                    <asp:BoundField DataField = "Added" HeaderText = "Product Added" />
                    <asp:TemplateField HeaderText = "Actions">
                        <ItemTemplate>
                            <asp:Button ID = "delete" runat = "server" Text = "Delete" OnClick = "delete_Click" CommandArgument = '<%# Container.DataItemIndex %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>       
                </Columns>
            </asp:GridView>

            <br /> <br />

            <asp:Button ID = "checkout" runat = "server" Text = "Checkout" OnClick = "checkout_Click"/>
        </div>
    </div>

</asp:Content>
