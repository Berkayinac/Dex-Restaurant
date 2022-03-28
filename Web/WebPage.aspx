<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="WebPage.aspx.cs" Inherits="Web.WebPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Products" runat="server">
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
              <a href="#"><%=product.Name%></a> <span>$<%=product.UnitPrice %> <br> <a href="WebPage.aspx?id=<%= product.Id %>" class="book-a-table-btn scrollto d-none d-lg-flex hulo"> Add To Cart</a>  </span>
            </div>
             
            <div class="menu-ingredients">
              <%=product.QuantityPerUnit %>
            </div>
          </div>
          <%  }%>
        </div>
          
      </div>
    </section><!-- End Menu Section -->
</asp:Content>
