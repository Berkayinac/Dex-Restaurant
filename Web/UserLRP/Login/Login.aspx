<%@ Page Title="" Language="C#" MasterPageFile="~/UserLRP/LRP.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.UserLRP.Login.Login" %>

<%@ Register Src="~/UserControl/UserLoginControl.ascx" TagPrefix="uc1" TagName="UserLoginControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="myLRP" runat="server">
    <uc1:UserLoginControl runat="server" ID="UserLoginControl" />
</asp:Content>
