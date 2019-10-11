<%@ Page Title="EndofSurvey" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EndofSurvey.aspx.cs" Inherits="AITRSurveyApplicationWebForms.EndofSurvey" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
        <div style="text-align: center">

            <h2>End of Survey</h2>
            <hr />
            <asp:Table  class="table table-bordered" runat="server" ID="questionAnswerDisplayTable" BorderWidth="1px">
                <asp:TableRow runat="server">
                    <asp:TableCell runat="server">QuestionId</asp:TableCell>
                    <asp:TableCell runat="server">Answer Text</asp:TableCell>
                    <asp:TableCell runat="server">OptionId</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-sm ml-2" OnClick="btnSubmit_Click" />
            <br /><br /><span>Please click submit to save your survey response.Thank you!!</span>

        </div>
</asp:Content>
