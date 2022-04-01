<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPages/Admin.Master" AutoEventWireup="true" CodeBehind="AdminOrderPanelV1.aspx.cs" Inherits="Web.AdminPages.AdminOrderPanelV1" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MyPage" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
        <asp:GridView ID="GridView1" runat="server" CssClass="table table-light " AutoGenerateColumns="false"  >
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id"  />
            <asp:BoundField DataField="ProductId" HeaderText="ProductId"  />
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID"  />

            <asp:TemplateField>
                <ItemTemplate>

                    <asp:LinkButton id="LnkBtn_Update" Text="Update" CssClass="btn btn-warning" CommandName="Update"  CommandArgument='<%# Eval("Id")%>' OnCommand="LnkBtn_Update_Command" runat="server"/>
                    <asp:LinkButton id="LnkBtn_Delete" Text="Delete" CssClass="btn btn-danger"  CommandName="Delete"  CommandArgument='<%# Eval("Id")%>' OnCommand="LnkBtn_Delete_Command" runat="server"/>

                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
    </div>
      <div class="form-group row">
          <div class="col-lg-5">


            <label for="exampleFormControlInput1">ProductId</label>
            <asp:TextBox ID="tbx_AddProductId" CssClass="form-control" runat="server"></asp:TextBox>

             <label for="exampleFormControlInput1">CustomerID</label>
            <asp:TextBox ID="tbx_AddCustomerID" CssClass="form-control" runat="server"></asp:TextBox>


            <asp:Button ID="btn_Add" runat="server" CssClass="btn btn-success" Text="Add" OnClick="btn_Add_Click" />
          </div>

          <div class="col-lg-5">

             <label for="exampleFormControlInput1">Id</label>
            <asp:TextBox ID="tbx_UpdateId" CssClass="form-control" runat="server"></asp:TextBox>

            <label for="exampleFormControlInput1">ProductId</label>
            <asp:TextBox ID="tbx_UpdateProductId" CssClass="form-control" runat="server"></asp:TextBox>

             <label for="exampleFormControlInput1">CustomerID</label>
            <asp:TextBox ID="tbx_UpdateCustomerID" CssClass="form-control" runat="server"></asp:TextBox>


            <asp:Button ID="btn_Update" runat="server" CssClass="btn btn-warning" Text="Update" OnClick="btn_Update_Click" />
          </div>
      </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    
</asp:Content>
