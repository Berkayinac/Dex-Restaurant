<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebPage.aspx.cs" Inherits="Web.WebPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="myCart" runat="server">
   <li class="dropdown"><a href="#"><span>Cart</span> <i class="bi bi-chevron-down"></i></a>
            <ul>
                 <% if (GetCarts() != null){ %>
                    <%foreach (var cart in GetCarts()){ %>
                      <li><a href="#"><%=cart.ProductName%> <span><%=cart.Quantity%></span></a></li>
                    <% } %>
                    <asp:LinkButton ID="Lnk_Cart" CssClass="book-a-table-btn scrollto d-none d-lg-flex" OnClick="Lnk_Cart_Click" runat="server">Cart</asp:LinkButton>
                <% } %>
            </ul>
         </li>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="Products" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="Grd_ProductDtos" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"  Width="200%" PageSize="4">
                <Columns>

                    <asp:BoundField DataField="Id"  ItemStyle-CssClass="hiddencol" />
                    <asp:BoundField DataField="CategoryName" ItemStyle-CssClass="hiddencol"  />
                    <asp:BoundField DataField="Name"  ItemStyle-CssClass="hiddencol" />
                    <asp:BoundField DataField="UnitPrice" ItemStyle-CssClass="hiddencol"  />
                    <asp:BoundField DataField="UnitsInStock" ItemStyle-CssClass="hiddencol"  />
              
                    <asp:TemplateField>
                        <ItemTemplate>

                            <div class="row menu-container" data-aos="fade-up" data-aos-delay="200">
                                <div class="col-lg-6 menu-item <%#Eval("CategoryName")%>">

                                    <img src="models/img/menu/lobster-bisque.jpg" class="menu-img" alt="">
                                    <div class="menu-content" width="100%">
                        
                                        <a href="#"><%#Eval("Name")%></a> <span>$<%#Eval("UnitPrice")%>
                                        <asp:LinkButton ID="Lnk_AddToCart" CssClass="book-a-table-btn scrollto d-none d-lg-flex" CommandArgument='<%#Eval("Id")%>' CommandName='<%#Eval("Name")%>' OnCommand="Lnk_AddToCart_Command" runat="server">Add To Cart</asp:LinkButton>
                                        </span>
                                    </div>
                            
                                    <div class="menu-ingredients">
                                         <%#Eval("UnitsInStock")%>
                                   </div>

                               </div>
                            </div>

                        </ItemTemplate> 
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>