<%@ Page Title="" Language="C#" MasterPageFile="~/UserLRP/LRP.Master" AutoEventWireup="true" CodeBehind="PasswordReminder.aspx.cs" Inherits="Web.UserLRP.PasswordReminder.PasswordReminder" %>

<%@ Register Src="~/UserControl/UserPasswordReminderControl.ascx" TagPrefix="uc1" TagName="UserPasswordReminderControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="myLRP" runat="server">
    <uc1:UserPasswordReminderControl runat="server" ID="UserPasswordReminderControl" />
</asp:Content>
