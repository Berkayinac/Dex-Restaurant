<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLoginControl.ascx.cs" Inherits="Web.UserControl.UserLoginControl" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div class="limiter">
					<div class="container-login100">
						<div class="wrap-login100">
							<div class="login100-form validate-form">
								<span class="login100-form-title p-b-43">
									Dex Login
								</span>
					
					
								<div class="wrap-input100 validate-input" data-validate = "Valid email is required: ex@abc.xyz">
									<asp:TextBox ID="tbx_Email" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Email</span>
								</div>
					
					
								<div class="wrap-input100 validate-input" data-validate="Password is required">
									<asp:TextBox ID="tbx_Password" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Password</span>
								</div>
			

								<div class="container-login100-form-btn">
									<asp:Button ID="Btn_Login" CssClass="login100-form-btn" runat="server" OnClick="Btn_Login_Click" Text="Login" />
									<br />
									<br />
									<br />
									<asp:Button ID="Btn_Register" CssClass="login100-form-btn" Width="50%" runat="server"  OnClick="Btn_Register_Click" Text="Register" />
									<asp:Button ID="Btn_PasswordReminder" CssClass="login100-form-btn" Width="50%" runat="server" OnClick="Btn_PasswordReminder_Click" Text="Password Reminder" />
								</div>
					
								<div class="text-center p-t-46 p-b-20">
									<span class="txt2">
										<asp:Label ID="lbl_Login" runat="server" Text=""></asp:Label>

									</span>
								</div>

							</div>

							<div class="login100-more" style="background-image: url('/models/img/event-custom.jpg');">
							</div>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>