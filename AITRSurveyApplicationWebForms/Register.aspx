<%@ Page Title="Respondent Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"CodeBehind="Register.aspx.cs" Inherits="AITRSurveyApplicationWebForms.Register" %>
<asp:Content ID="RegisterPage" ContentPlaceHolderID="MainContent" runat="server">

 

    <div class="container">
            <h2 class="form-heading">Respondent Register</h2>
            <span>[This Register is only for respondent and is optional. !!!]</span>
        <hr />
            <br />
            <br />

            <div class="form-fields">
                <asp:TextBox ID="txtFirstName" runat="server" class="form-control" placeholder="Given Name" autofocus="true"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter FirstName.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                <asp:TextBox ID="txtLastName" runat="server"  class="form-control" ValidationGroup='valGroup1' placeholder="LastName"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter Lastname .Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                
                <asp:TextBox ID="txtDoB" runat="server"  TextMode="Date" class="form-control" placeholder="Date of Birth"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/assests/calendarIcon .png" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtDoB" ErrorMessage="Please select DOB.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                <asp:TextBox ID="txtContactNumber" runat="server" TextMode="Number" class="form-control" ValidationGroup='valGroup1' placeholder="Your Contact Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Please enter contact number.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>

            </div>

            <asp:Button ID="SignUpButton" runat="server" ValidationGroup='valGroup1' Style="margin-top: 10px;" class="btn btn-lg btn-primary btn-block" Text="Sign Up" OnClick="SignUp_Click"></asp:Button>
        <asp:Button ID="btnSkip" runat="server"  Style="margin-top: 10px;" class="btn btn-lg btn-primary btn-block" Text="Skip" OnClick="Skip_Click"></asp:Button>
            <asp:Label ID="Msg" Style="vertical-align: central" runat="server"></asp:Label>

        
    </div> 
</asp:Content>
