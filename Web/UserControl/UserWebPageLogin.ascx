<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserWebPageLogin.ascx.cs" Inherits="Web.UserControl.UserWebPageLogin" %>


<asp:Literal ID="Literal1" runat="server"></asp:Literal>


<%if (Literal1.Text.Contains("Welcome")){ %>

<asp:Button ID="btn_Logout" CssClass="book-a-table-btn scrollto d-none d-lg-flex" OnClick="btn_Logout_Click" runat="server" Text="Logout" />

<% }  %>