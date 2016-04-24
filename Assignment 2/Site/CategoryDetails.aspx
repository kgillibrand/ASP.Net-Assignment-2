<%@ Page Title="Category Details - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryDetails.aspx.cs" Inherits="Assignment_2.Menu.CategoryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 80%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <asp:Label ID = "category" runat = "server">
            </asp:Label>

            <br /> <br />

            <asp:GridView ID = "products" runat = "server" AutoGenerateColumns = "false" EmptyDataText = "No products to display" ToolTip = "All products belonging to this category" Width = "80%">
                <Columns>
                    <asp:HyperLinkField DataTextField = "productName" HeaderText = "Product Name" DataNavigateUrlFields = "productID" DataNavigateUrlFormatString = "~/Site/ProductDetails.aspx?productID={0}"/>
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
                </Columns>
            </asp:GridView>

        </div>
    </div>

</asp:Content>
