<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ProductsWebPageV4.aspx.cs" Inherits="Web.ProductsWebPageV4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Products" runat="server">
    <!-- ======= Menu Section ======= -->
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
              <li data-filter=".filter-starters">Starters</li>
              <li data-filter=".filter-salads">Salads</li>
              <li data-filter=".filter-specialty">Specialty</li>
            </ul>
          </div>
        </div>

        <div class="row menu-container" data-aos="fade-up" data-aos-delay="200">

          <div class="col-lg-6 menu-item filter-starters">

            <img src="assets/img/menu/lobster-bisque.jpg" class="menu-img" alt="">

            <div class="menu-content">
              <a href="#">Lobster Bisque</a><span>$5.95</span>
            </div>

            <div class="menu-ingredients">
              Lorem, deren, trataro, filede, nerada
            </div>

          </div>

        </div>

      </div>
    </section><!-- End Menu Section -->
</asp:Content>
