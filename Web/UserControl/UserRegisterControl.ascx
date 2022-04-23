<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserRegisterControl.ascx.cs" Inherits="Web.UserControl.UserRegisterControl" %>

<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
				<div class="limiter">
					<div class="container-login100">
						<div class="wrap-login100">
							<div class="login100-form validate-form">
								<span class="login100-form-title p-b-43">
									Dex Register
								</span>
					
								<div class="wrap-input100 validate-input">
									<asp:TextBox ID="tbx_FirstName" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">First Name</span>
								</div>

								<div class="wrap-input100 validate-input">
									<asp:TextBox ID="tbx_LastName" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Last Name</span>
								</div>

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
								
								<div class="wrap-input100 validate-input">
									<asp:DropDownList ID="drp_SecurityQuestions" CssClass="input100" Width="100%" Height="100%" runat="server"></asp:DropDownList>
									<span class="focus-input100"></span>
									<span class="label-input100">Select Your Security Question</span>
								</div>

								<div class="wrap-input100 validate-input">
									<asp:TextBox ID="tbx_SecurityQuestionAnswer" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Write your Security Question Answer</span>
								</div>

								<div class="container-login100-form-btn">
									<asp:Button ID="Btn_Register" CssClass="login100-form-btn" runat="server" OnClick="Btn_Register_Click" Text="Register" />
								</div>
					
								<div class="text-center p-t-46 p-b-20">
									<span class="txt2">
										<asp:Label ID="lbl_Register" runat="server" Text=""></asp:Label>
									</span>
								</div>

							</div>

							<div class="login100-more" style="background-image: url('/models/img/hero-bg.jpg');">
							</div>
						</div>
					</div>
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>