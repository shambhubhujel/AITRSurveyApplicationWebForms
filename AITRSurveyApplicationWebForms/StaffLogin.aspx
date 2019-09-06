<%@ Page Title="Staff Login to AITR System" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"CodeBehind="StaffLogin.aspx.cs" Inherits="AITRSurveyApplicationWebForms.StaffLogin" %>

<asp:Content ID="SatffLogin" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
			<h2 class="form-heading">Log in to AITR Survey Admin</h2>
            <span>(This log in is only for AITR staff.!!!)</span>
            <br /><br />
            
            <div class="form-fields">
                <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Email" autofocus></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ValidationGroup='valGroup1' ControlToValidate="txtUserName" ErrorMessage="Please enter Username.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" ValidationGroup='valGroup1' placeholder="Password" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </div>
			 <asp:Button ID="btnLogIn" runat="server" ValidationGroup='valGroup1' class="btn btn-lg btn-primary btn-block" Text="Log In" OnClick="BtnLogIn_Click"></asp:Button>
            <asp:Label ID="Msg" style="vertical-align:central"  runat="server"></asp:Label>
            
		
	</div> 
    </asp:Content>