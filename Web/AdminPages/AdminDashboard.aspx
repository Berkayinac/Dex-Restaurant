<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="Web.AdminPages.AdminDashboard" %>
<asp:Content ID="Content3" ContentPlaceHolderID="DashBoard" runat="server">
     <!-- /. ROW  -->

                <div class="row">
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-green green">
                            <div class="panel-left pull-left green">
                                <i class="fa fa-bar-chart-o fa-5x"></i>
                                
                            </div>
                            <div class="panel-right pull-right">
								<h3>
                                    <asp:Label ID="lbl_Products" runat="server" Text=""></asp:Label>
								</h3>
                               <strong> Products</strong>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-blue blue">
                              <div class="panel-left pull-left blue">
                                <i class="fa fa-shopping-cart fa-5x"></i>
								</div>
                                
                            <div class="panel-right pull-right">
							<h3>
                                <asp:Label ID="lbl_Orders" runat="server" Text=""></asp:Label></h3>
                               <strong> Orders</strong>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-red red">
                            <div class="panel-left pull-left red">
                                <i class="fa fa fa-comments fa-5x"></i>
                               
                            </div>
                            <div class="panel-right pull-right">
							 <h3>
                                 <asp:Label ID="lbl_Customers" runat="server" Text=""></asp:Label></h3>
                               <strong> Customers </strong>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-brown brown">
                            <div class="panel-left pull-left brown">
                                <i class="fa fa-users fa-5x"></i>
                                
                            </div>
                            <div class="panel-right pull-right">
							<h3>
                                <asp:Label ID="lbl_Categories" runat="server" Text=""></asp:Label> </h3>
                             <strong>Categories</strong>

                            </div>
                        </div>
                    </div>
                </div>
				
		
		<div class="row">
			<div class="col-xs-6 col-md-3">
				<div class="panel panel-default">
					<div class="panel-body easypiechart-panel">
						<h4>Products</h4>
						<div class="easypiechart" id="easypiechart-blue" data-percent="<%=ProductsPersent()%>" ><span class="percent"><%=ProductsPersent()%>%</span>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-6 col-md-3">
				<div class="panel panel-default">
					<div class="panel-body easypiechart-panel">
						<h4>Orders</h4>
						<div class="easypiechart" id="easypiechart-orange" data-percent="<%=OrdersPersent()%>" ><span class="percent"><%=OrdersPersent()%>%</span>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-6 col-md-3">
				<div class="panel panel-default">
					<div class="panel-body easypiechart-panel">
						<h4>Customers</h4>
						<div class="easypiechart" id="easypiechart-teal" data-percent="<%=CustomersPersent()%>" ><span class="percent"><%=CustomersPersent()%>%</span>
						</div>
					</div>
				</div>
			</div>
			<div class="col-xs-6 col-md-3">
				<div class="panel panel-default">
					<div class="panel-body easypiechart-panel">
						<h4>Categories</h4>
						<div class="easypiechart" id="easypiechart-red" data-percent="<%= CategoriesPersent() %>" ><span class="percent"><%= CategoriesPersent() %>%</span>
						</div>
					</div>
				</div>
			</div>
		</div><!--/.row-->
    
                <div class="row">
                   
                    <div class="col-md-8 col-sm-12 col-xs-12">

                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Responsive Table Example
                            </div> 
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered table-hover">
                                        <thead>
                                            <tr>
                                                <th>CategoryId</th>
                                                <th>CategoryName</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <%foreach (var category in CategoriesGetAll()){ %>
                                            <tr>
                                                <td><%= category.Id %></td>
                                                <td><%= category.Name %></td>
                                            </tr>
                                            <% } %>
                                        </tbody>
                                     </table>
                                </div>
                            </div>
                        </div>
        </div>
     </div>
</asp:Content>
