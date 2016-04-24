<%@ Page Title = "Home - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assignment_2.Menu.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style = "text-align: center;">
        <div style = "width: 60%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <h3>Most recently added products</h3>
            <asp:GridView ID = "products" runat = "server" AllowPaging = "true" PageSize = "5" AutoGenerateColumns = "false" EmptyDataText = "No items to display" ToolTip = "Top 5 items by date added" OnPageIndexChanging = "items_PageIndexChanging" Width = "100%">
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
                </Columns>
            </asp:GridView>

        </div>
    </div>

</asp:Content>
