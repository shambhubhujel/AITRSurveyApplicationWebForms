<%@ Page Title="Respondent Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="AITRSurveyApplicationWebForms.Register" %>

<asp:Content ID="RegisterPage" ContentPlaceHolderID="MainContent" runat="server">



    <section id="main" class="wrapper ">
        <div class="container 8u$ center">
            <header class="major ">
                <h2 class="form-heading">Respondent Register</h2>
                <span>[This Register is only for respondent and is optional. !!!]</span>
                <asp:Label ID="test" runat="server" Text=""></asp:Label>
                <hr />


            </header>
            <br />
            <br />
            <div class="form-row d-flex justify-content-center">
                <div class="form-group col-md-10">
                    <label for="inputEmail4" class="text-dark h6 font-weight-bold">Username:</label>
                    <asp:TextBox ID="username" runat="server" CssClass="form-control" placeholder="Username" autofocus="true"></asp:TextBox>
                    <asp:Label ID="userNameTaken" runat="server" ForeColor="#FF3300"></asp:Label>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup='valGroup1' ControlToValidate="username" runat="server" ErrorMessage="Username is required" ForeColor="Red"></asp:RequiredFieldValidator>

                </div>

                <div class="form-group col-md-10">
                    <label for="inputEmail4" class="text-dark h6 font-weight-bold">Password:</label>
                    <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Your Password" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup='valGroup1' ControlToValidate="password" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group col-md-10">
                    <label for="inputEmail4" class="text-dark h6 font-weight-bold">First Name:</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" placeholder="Given Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvUsername" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtFirstName" ErrorMessage="Please enter FirstName.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>

                </div>
                <div class="form-group col-md-10">
                    <label for="inputEmail4" class="text-dark h6 font-weight-bold">Last Name:</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" ValidationGroup='valGroup1' placeholder="LastName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtLastName" ErrorMessage="Please enter Lastname .Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group col-md-9">
                    <label for="inputEmail4" class="text-dark h6 font-weight-bold">DoB:</label>
                    <asp:TextBox ID="txtDoB" CssClass="form-control" runat="server" placeholder="Date of Birth"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtDoB" ErrorMessage="Please select DOB.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>

                <div class="form-group col-md-1 align-self-left pb-2">
                    <asp:ImageButton ID="clndr_btn" runat="server" ImageUrl="~/assests/calendarIcon .png" CausesValidation="False" OnClick="clndr_btn_Click" />
                </div>
                <div class="form-group col-md-6">

                    <asp:Calendar ID="dobCalendar" Height="15px" OnSelectionChanged="dobCalendar_SelectionChanged" runat="server"></asp:Calendar>


                </div>

                <div class="form-group col-md-10">
                    <label for="inputEmail4" class="text-dark h6 font-weight-bold">Contact Number:</label>
                    <asp:TextBox ID="txtContactNumber" runat="server" TextMode="Number" class="form-control" ValidationGroup='valGroup1' placeholder="Your Contact Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup='valGroup1' runat="server" ControlToValidate="txtContactNumber" ErrorMessage="Please enter contact number.Required!!!!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                </div>


            </div>
            <div class="form-group col-md-10 ">
                <asp:Button ID="SignUpButton" runat="server" ValidationGroup='valGroup1' Style="margin-top: 10px;" class="btn btn-lg btn-primary btn-block" Text="Sign Up" OnClick="SignUp_Click"></asp:Button>

            </div>
            <div class="form-group col-md-10 ">
                <asp:Button ID="btnSkip" runat="server" Style="margin-top: 10px;" class="btn btn-lg btn-primary btn-block" Text="Skip" OnClick="Skip_Click"></asp:Button>
                <asp:Label ID="Msg" Style="vertical-align: central" runat="server"></asp:Label>
            </div>



        </div>
    </section>
</asp:Content>
