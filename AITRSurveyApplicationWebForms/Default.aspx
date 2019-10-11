<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AITRSurveyApplicationWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>AITR Survey Program</h1>
        <p class="lead">Please spend some time to complete our short survey.<br />Thank you.</p>
        <p> <asp:Button ID="btnStartSurvey"  class="btn btn-primary btn-lg" runat="server" Text="Start Survey>>" OnClick="btnStartSurvey_Click" /></p>
    </div>

    <div class="row">
        <div class="col-md-6">
            
        </div>
        <div class="col-md-6">
            
        </div>
    </div>

</asp:Content>
