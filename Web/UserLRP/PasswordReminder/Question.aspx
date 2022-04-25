<%@ Page Title="" Language="C#" MasterPageFile="~/UserLRP/LRP.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="Web.UserLRP.PasswordReminder.Question" %>

<%@ Register Src="~/UserControl/UserQuestionControl.ascx" TagPrefix="uc1" TagName="UserQuestionControl" %>


<asp:Content ID="Content2" ContentPlaceHolderID="myLRP" runat="server">
    <uc1:UserQuestionControl runat="server" ID="UserQuestionControl" />
</asp:Content>
