

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="suan icin pes.aspx.cs" Inherits="Web.suan_icin_pes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                    <table class="table table-hover">
                     <thead class="thead">
                        <tr>
                          <th scope="col">ProductId</th>
                          <th scope="col">CategoryId</th>
                          <th scope="col">ProductName</th>
                          <th scope="col">UnitPrice</th>
                          <th scope="col">UnitsInStock</th>
                        </tr>
                      </thead>       
                  
                       <tbody>
                            <tr>
                            <% foreach (var product in GetAll()) { %>
                            <td><%= product.ProductId %></td>
                            <td><%= product.CategoryId %></td>
                            <td><%= product.ProductName %></td>
                            <td><%= product.UnitPrice %></td>
                            <td><%= product.UnitsInStock %></td>
                            <td><asp:Button ID="Button1" runat="server" Text="Update" CssClass = "btn btn-primary" OnClick="btn_Update_Click"/></td>
                            <td><asp:Button ID="Button2" runat="server" CommandName="ThisBtnClick" OnClick="btn_Remove_Click" Text="Remove" CssClass = "btn btn-danger"/></td>
                            </tr>
                           <% } %>
                      </tbody>
             </table>
        </div>
    </form>
</body>
</html>
