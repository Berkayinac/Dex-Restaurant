<%@ Page Title="" Language="C#" MasterPageFile="~/UserLRP/LRP.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.UserLRP.Register.Register" %>

<%@ Register Src="~/UserControl/UserRegisterControl.ascx" TagPrefix="uc1" TagName="UserRegisterControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="myLRP" runat="server">
    <uc1:UserRegisterControl runat="server" ID="UserRegisterControl" />
</asp:Content>
