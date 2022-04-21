<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserPanelV1.aspx.cs" Inherits="Web.AdminPages.AdminUserPanelV1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MyPage" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-light " AutoGenerateColumns="false"  >
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id"  />
                        <asp:BoundField DataField="FirstName" HeaderText="FirstName"  />
                        <asp:BoundField DataField="LastName" HeaderText="LastName"  />
                        <asp:BoundField DataField="Email" HeaderText="Email"  />
                        <asp:BoundField DataField="Password" HeaderText="Password"  />
                        <asp:BoundField DataField="Status" HeaderText="Status"  />
                        <asp:BoundField DataField="SecurityQuestionId" HeaderText="SecurityQuestionId"  />
                        <asp:BoundField DataField="SecurityQuestionAnswer" HeaderText="SecurityQuestionAnswer"  />

                        <asp:TemplateField>
                            <ItemTemplate>

                                <asp:LinkButton id="LnkBtn_Delete" Text="Delete" CssClass="btn btn-danger"  CommandName="Delete"  CommandArgument='<%# Eval("Id")%>' OnCommand="LnkBtn_Delete_Command" runat="server"/>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
           </div>
        </ContentTemplate>
    </asp:UpdatePanel>


        
</asp:Content>
