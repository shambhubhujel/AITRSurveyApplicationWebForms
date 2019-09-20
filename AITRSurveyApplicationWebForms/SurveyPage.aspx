<%@ Page Title="SurveyForm" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveyPage.aspx.cs" Inherits="AITRSurveyApplicationWebForms.SurveyPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <section id="main" class="wrapper ">
				<div class="container 8u$ center">
					<header class="major ">
						<h2>Survey Questions</h2>
                        <hr />
					</header>
                    
                      <div class="form-row d-flex justify-content-center">
                          <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                           <br /><br />
                          <asp:Button ID="btnSkip" runat="server" Text="Skip" CssClass="btn btn-info btn-sm ml-2" OnClick="btnSkip_Click" />
                           <asp:Button ID="btnNextQue" runat="server" Text="Next" CssClass="btn btn-primary btn-sm ml-2" OnClick="btnNextQue_Click" />
                          <br /><asp:Label ID="Label1" runat="server" ></asp:Label>

                      </div>
                          
				</div>
</section>
</asp:Content>
