<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Web.Register.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <link rel="icon" type="image/png" href="assets/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="assets/vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/vendor/animsition/css/animsition.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/vendor/select2/select2.min.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="assets/vendor/daterangepicker/daterangepicker.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="assets/css/util.css"/>
	<link rel="stylesheet" type="text/css" href="assets/css/main.css"/>

</head>
<body style="background-color: #666666;">
    <form id="form1" runat="server">

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

								<div class="wrap-input100 validate-input">
									<asp:TextBox ID="tbx_Email" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Email</span>
								</div>
					
								<div class="wrap-input100 validate-input">
									<asp:TextBox ID="tbx_Password" CssClass="input100" runat="server"></asp:TextBox>
									<span class="focus-input100"></span>
									<span class="label-input100">Password</span>
								</div>
								
								<div class="wrap-input100 validate-input">
									<asp:DropDownList ID="drp_SecurityQuestions" CssClass="input100" Width="100%" Height="100%" runat="server">
                                    </asp:DropDownList>
									<span class="focus-input100"></span>
									<span class="label-input100">Select Your Security Question</span>
								</div>

								<div class="wrap-input100 validate-input" data-validate="Password is required">
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

    </form>


	<script src="/Login/assets/vendor/jquery/jquery-3.2.1.min.js"></script>
<!--===============================================================================================-->
	<script src="/Login/assets/vendor/animsition/js/animsition.min.js"></script>
<!--===============================================================================================-->
	<script src="/Login/assets/vendor/bootstrap/js/popper.js"></script>
	<script src="/Login/assets/vendor/bootstrap/js/bootstrap.min.js"></script>
<!--===============================================================================================-->
	<script src="/Login/assets/vendor/select2/select2.min.js"></script>
<!--===============================================================================================-->
	<script src="/Login/assets/vendor/daterangepicker/moment.min.js"></script>
	<script src="/Login/assets/vendor/daterangepicker/daterangepicker.js"></script>
<!--===============================================================================================-->
	<script src="/Login/assets/vendor/countdowntime/countdowntime.js"></script>
<!--===============================================================================================-->
	<script src="/Login/assets/js/main.js"></script>
</body>
</html>
