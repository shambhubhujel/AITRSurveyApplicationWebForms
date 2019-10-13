<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RespondentAnswers.aspx.cs" Inherits="AITRSurveyApplicationWebForms.RespondentAnswers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main" class="wrapper ">
        <div class="container 8u$ center">
            <header class="major ">
                <h2>Survey Information</h2>
                <span>Here is your review of you survey response!!</span>
                <hr />
            </header>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="146px" Width="774px">
                <Columns>
                    <asp:BoundField DataField="Respondent" HeaderText="Respondent" ReadOnly="True" SortExpression="Respondent" />
                    <asp:BoundField DataField="Question" HeaderText="Question" SortExpression="Question" />
                    <asp:BoundField DataField="Answer" HeaderText="Answer" SortExpression="Answer" />
                </Columns>
            </asp:GridView>

            <%-- Query respondent's answers based on registeredID --%>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_9AB8B7_D19DDA6422ConnectionString %>" SelectCommand="SELECT (CASE WHEN respondent.reg_respondentID IS NULL THEN 'Anonymous' ELSE registered_respondents.First_Name END) AS 'Respondent', q1.Contents AS 'Question', answer 'Answer' FROM answers LEFT  JOIN questions q1  ON(answers.QuestionID = q1.QuestionID ) left join respondent ON(answers.RespondentID = respondent.id) left join registered_respondents ON(respondent.reg_respondentID = registered_respondents .RespondentID ) WHERE respondent.reg_respondentID = @RegisteredID">
                <SelectParameters>
                    <asp:SessionParameter Name="RegisteredID" Type="String" SessionField="RegisteredID" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>


    </section>
    <br />
    <br />
    <div class="form-group justify-content-center">
        <asp:Button ID="btn_FinishSurvey" runat="server" Text="Close" CssClass="btn btn-primary btn-sm ml-2" OnClick="btn_FinishSurvey_Click" />
    </div>
</asp:Content>
