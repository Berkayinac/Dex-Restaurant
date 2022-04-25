<%@ Page Title="" Language="C#" MasterPageFile="~/UserLRP/LRP.Master" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="Web.UserLRP.PasswordReminder.PasswordChange" %>

<%@ Register Src="~/UserControl/UserPasswordChangeControl.ascx" TagPrefix="uc1" TagName="UserPasswordChangeControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="myLRP" runat="server">
    <uc1:UserPasswordChangeControl runat="server" ID="UserPasswordChangeControl" />
</asp:Content>
