<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserPasswordChangeControl.ascx.cs" Inherits="Web.UserControl.UserPasswordChangeControl" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div class="limiter">
					<div class="container-login100">
						<div class="wrap-login100">
							<div class="login100-form validate-form">
								<span class="login100-form-title p-b-43">
									Password Reminder
								</span>
					
								<div class="wrap-input100 validate-input" data-validate="Password is required">
									<asp:TextBox ID="tbx_NewPassword" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">New Password</span>
								</div>

								<div class="wrap-input100 validate-input" data-validate="Password is required">
									<asp:TextBox ID="tbx_PasswordVerify" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Password Verify</span>
								</div>


								<div class="text-center p-t-46 p-b-20">
									<span class="txt2">
										<asp:Label ID="lbl_PasswordReminder" runat="server" Text=""></asp:Label>
									</span>
								</div>

								<div class="container-login100-form-btn">
									<asp:Button ID="Btn_PasswordChange" CssClass="login100-form-btn" runat="server" OnClick="Btn_PasswordChange_Click" Text="Password Reminder" />
								</div>

							</div>

							<div class="login100-more" style="background-image: url('/models/img/event-custom.jpg');">
							</div>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
