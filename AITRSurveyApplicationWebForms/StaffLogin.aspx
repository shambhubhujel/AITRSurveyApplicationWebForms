<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"CodeBehind="StaffLogin.aspx.cs" Inherits="AITRSurveyApplicationWebForms.StaffLogin" %>

<asp:Content ID="SatffLogin" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container">
			<h2 class="form-heading">Log in to AITR Survey Admin</h2>
            <span>(Admin log in is required for Dashboard.!!!)</span>
        <hr />
            <br /><br />
            
            <div class="form-fields">
                <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Username" autofocus="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ValidationGroup='valGroup1' ControlToValidate="txtUserName" ErrorMessage="Please enter Username.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control" ValidationGroup='valGroup1' placeholder="Password" ></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter password.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
            </div>
			 <asp:Button ID="btnLogIn" runat="server" ValidationGroup='valGroup1' class="btn btn-lg btn-primary btn-block" Text="Log In" OnClick="BtnLogIn_Click"></asp:Button>
            <asp:Label ID="Msg" style="vertical-align:central" ForeColor="Red" runat="server"></asp:Label>
            
		
	</div> 
    </asp:Content>