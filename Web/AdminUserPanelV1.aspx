﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminUserPanelV1.aspx.cs" Inherits="Web.AdminUserPanelV1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Product" runat="server">
        <div>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-light " AutoGenerateColumns="false"  >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id"  />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName"  />
            <asp:BoundField DataField="LastName" HeaderText="LastName"  />
            <asp:BoundField DataField="Email" HeaderText="Email"  />
            <asp:BoundField DataField="PasswordHash" HeaderText="PasswordHash"  />
            <asp:BoundField DataField="PasswordSalt" HeaderText="PasswordSalt"  />
            <asp:BoundField DataField="Status" HeaderText="Status"  />

            <asp:TemplateField>
                <ItemTemplate>

                    <asp:LinkButton id="LnkBtn_Delete" Text="Delete" CssClass="btn btn-danger"  CommandName="Delete"  CommandArgument='<%# Eval("Id")%>' OnCommand="LnkBtn_Delete_Command" runat="server"/>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
