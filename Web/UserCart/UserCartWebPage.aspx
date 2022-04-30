<%@ Page Title="" Language="C#" MasterPageFile="~/UserCart/UserCart.Master" AutoEventWireup="true" CodeBehind="UserCartWebPage.aspx.cs" Inherits="Web.UserCart.UserCartWebPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="CartTemplate" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" Width="100%" PageSize="4">
                <Columns>
                    <asp:BoundField DataField="ProductId" ItemStyle-CssClass="hiddencol"  />
                    <asp:BoundField DataField="UserName" ItemStyle-CssClass="hiddencol" />
                    <asp:BoundField DataField="ProductName" ItemStyle-CssClass="hiddencol"  />
                    <asp:BoundField DataField="ProductUnitPrice"  ItemStyle-CssClass="hiddencol" />
                    <asp:BoundField DataField="Quantity" ItemStyle-CssClass="hiddencol"  />
                        
                    <asp:TemplateField>
                        <ItemTemplate>
                             <div class="row menu-container" data-aos="fade-up" data-aos-delay="200">
                                <div class="col-lg menu-item  <%#Eval("UserName")%>">

                                    <img src="models/img/menu/lobster-bisque.jpg" class="menu-img" alt="">
                                    <div class="menu-content">

                                        <a href="#"><%#Eval("ProductName")%></a>  <span>$<%#Eval("ProductUnitPrice")%>
                                            <asp:LinkButton ID="Lnk_DeleteToCart" CssClass="book-a-table-btn scrollto d-none d-lg-flex" CommandArgument='<%#Eval("ProductId")%>' CommandName='<%#Eval("UserName")%>'  runat="server" OnCommand="Lnk_DeleteToCart_Command" >Delete To Cart</asp:LinkButton>
                                        </span>
                                    </div>
                            
                                    <div class="menu-ingredients">
                                         <%#Eval("Quantity")%>
                                   </div>

                               </div>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
            <asp:Label ID="lbl_TotalPrice" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="Lnk_Order" Width="13%" CssClass="book-a-table-btn scrollto d-none d-lg-flex" OnClick="Lnk_Order_Click" runat="server">Order Now</asp:LinkButton>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
