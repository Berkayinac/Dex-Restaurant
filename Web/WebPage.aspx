<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebPage.aspx.cs" Inherits="Web.WebPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <script src="Scripts/jquery-3.0.0.js"></script>

    <script>
        function myfunction(myId) {
            alert("asd"+myId)
        }
    </script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Products" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section id="menu" class="menu section-bg">
              <div class="container" data-aos="fade-up">

                <div class="section-title">
                  <h2>Menu</h2>
                  <p>Check Our Tasty Menu</p>
                </div>


                <div class="row" data-aos="fade-up" data-aos-delay="100">
                  <div class="col-lg-12 d-flex justify-content-center">
                    <ul id="menu-flters">
                     <li data-filter="*" class="filter-active">All</li>
                     <% foreach (var category in GetAllCategories()){ %>
                      <li data-filter=".<%=category.Name %>"><%=category.Name%></li>
            
                    <% }%>
                    </ul>
                  </div>
                </div>

                <div class="row menu-container" data-aos="fade-up" data-aos-delay="200">
                     <% foreach (var product in GetAllProductDtos()){ %>

                  <div class="col-lg-6 menu-item <%=product.CategoryName %>">
                    <img src="models/img/menu/lobster-bisque.jpg" class="menu-img" alt="">
                    <div class="menu-content">
                        
                      <a href="#"><%=product.Name%></a> <span>$<%=product.UnitPrice %> <br>  <input id="Btn_Add_to_CartV1" onclick="myfunction(<%=product.Id %>)" class="book-a-table-btn scrollto d-none d-lg-flex hulo" type="button" value="Add To Cart Js" /></span>
                    </div>
             
                    <div class="menu-ingredients">
                      <%=product.QuantityPerUnit %>
                    </div>
                  </div>
                  <%  }  %>
                </div>
          
              </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>

    

    
</asp:Content>


