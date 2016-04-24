<%@ Page Title="Product Details - Kieran's Student Technological Store" Language="C#" MasterPageFile="~/Site/MasterPage.Master" AutoEventWireup="True" CodeBehind="ProductDetails.aspx.cs" Inherits="Assignment_2.Site.ProductDetails" EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div style = "text-align: center;">
        <div style = "width: 80%; margin-left: auto; margin-right: auto;" class="w3-container w3-border w3-hover-border-blue">

            <asp:ScriptManager runat="Server" />

            <ajaxToolkit:TabContainer runat="server" Width = "100%">

                <ajaxToolkit:TabPanel runat = "server" HeaderText = "Product" Width = "100%">
                    <ContentTemplate>
                        <h3>Product Details</h3>
                        <asp:GridView ID = "productView" runat = "server" AutoGenerateColumns = "false" EmptyDataText = "No product to display" ToolTip = "All products belonging to this category" Width = "800px">
                            <Columns>
                                <asp:BoundField DataField = "productName" HeaderText = "Product Name" />
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
                                <asp:TemplateField HeaderText = "Average Rating">
                                    <ItemTemplate>
                                        <asp:Literal ID = "averageLiteral" runat = "server" >
                                        </asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:BoundField DataField = "productAdded" HeaderText = "Product Added" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel runat = "server" HeaderText = "Long Description" Width = "100%">
                    <ContentTemplate>
                        <h3>Long Product Description</h3>
                        <asp:TextBox ID = "longDescription" runat = "server" TextMode = "MultiLine" ReadOnly = "true" Rows = "20" Width = "800px">
                        </asp:TextBox>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

                <ajaxToolkit:TabPanel runat = "server" HeaderText = "Comments" Width = "100%">
                    <ContentTemplate>
                        <h3>Product Ratings and Comments</h3>
                        <asp:GridView ID = "commentsView" runat = "server" AutoGenerateColumns = "false" EmptyDataText = "No comments to display" ToolTip = "All comments and ratings belonging to this product" Width = "800px">
                            <Columns>
                                <asp:BoundField DataField = "commentText" HeaderText = "Comment Text" />
                                <asp:BoundField DataField = "commentRating" HeaderText = "Product Rating (?/5)" />
                                <asp:BoundField DataField = "commentName" HeaderText = "Posted By" />
                                <asp:BoundField DataField = "commentPosted" HeaderText = "Posted On" />
                                <asp:TemplateField HeaderText = "Actions">
                                    <ItemTemplate>
                                         <asp:Button ID = "deleteComment" runat = "server" CommandArgument = '<%#Eval ("commentID")%>'  Text = "Delete" OnClick = "deleteComment_Click" CausesValidation = "false" ToolTip = "Delete comment"/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                        <br /> <br />

                        <h3>Write Comment</h3>
                        <asp:TextBox ID = "comment" runat = "server" TextMode = "MultiLine" Rows = "5" Width = "60%">
                        </asp:TextBox> <br />
                        <asp:RequiredFieldValidator runat = "server" ControlToValidate = "comment" ErrorMessage = "This field is required">
                        </asp:RequiredFieldValidator>

                        <br />

                        <h3>Product Rating</h3> <br />
                            <asp:TextBox ID = "rating" runat = "server" ToolTip = "Product rating" Width = "10px">
                            </asp:TextBox>
                            <asp:TextBox ID = "ratingSlider" runat = "server" Width = "10px">
                            </asp:TextBox>
                            <ajaxToolkit:SliderExtender TargetControlID = "rating" Minimum = "0" Maximum = "5" Steps = "6" runat = "server" EnableKeyboard = "true" ViewStateMode = "Enabled" BoundControlID = "ratingSlider"/>
                        <br />

                        <asp:Button ID = "submitComment" runat = "server" text = "Submit" CausesValidation = "true" OnClick = "submitComment_Click" />
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>

            </ajaxToolkit:TabContainer>

            <asp:Button ID = "add" runat = "server" Text = "Add to Cart" Visble = "true" OnClick ="add_Click"/>
        </div>
    </div>

</asp:Content>
