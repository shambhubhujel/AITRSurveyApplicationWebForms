<%@ Page Title="Survey Search" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveySearch.aspx.cs" Inherits="AITRSurveyApplicationWebForms.SurveySearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #header.alt nav a {
            color: black;
        }

        #header h1 strong a {
            color: black !important;
        }

        .center {
            margin: 10px auto;
        }

        header.major {
            margin: 40px auto 0px auto;
        }
    </style>
</asp:Content>
<asp:Content ID="SurveySearch" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main" class="wrapper ">
        <div class="container 8u$ center">
            <header class="major ">
                <h2>Survey Report Dashboard</h2>
                <hr />
            </header>

            <div class="form-row d-flex justify-content-center">
                
                <div class="form-group col-md-3">
                    <asp:TextBox ID="username" runat="server" CssClass="form-control form-control-sm" placeholder="Search Text"></asp:TextBox>
                </div>
                <div class="form-group col-md-2">
                    <!--<asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="criteria"></asp:TextBox>-->
                    <asp:DropDownList ID="ddlGender" runat="server" AppendDataBoundItems="true" CssClass="form-control" DataSourceID="SqlDataSource2" DataTextField="QuesOption" DataValueField="QuesOption">
                        <%-- Empty value on dropdown list --%>
                        <asp:ListItem Text="Select Gender" Value="" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DB_9AB8B7_D19DDA6422ConnectionString %>" SelectCommand="SELECT QuesOption FROM questionoptions WHERE (QuestionId = @que_id)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="1" Name="que_id" QueryStringField="1" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="true" CssClass="form-control" DataSourceID="SqlDataSource3" DataTextField="QuesOption" DataValueField="QuesOption">
                        <asp:ListItem Text="State" Value="" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:DB_9AB8B7_D19DDA6422ConnectionString %>" SelectCommand="SELECT QuesOption FROM questionoptions WHERE (QuestionId = @que_id)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="3" Name="que_id" QueryStringField="3" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="form-group col-md-2">
                    <asp:DropDownList ID="ddlBank" runat="server" AppendDataBoundItems="true" CssClass="form-control" DataSourceID="SqlDataSource1" DataTextField="QuesOption" DataValueField="QuesOption">
                        <asp:ListItem Text="Bank Used" Value="" />
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_9AB8B7_D19DDA6422ConnectionString %>" SelectCommand="SELECT QuesOption FROM questionoptions WHERE (QuestionId = @que_id)">
                        <SelectParameters>
                            <asp:QueryStringParameter DefaultValue="6" Name="que_id" QueryStringField="6" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div class="form-group col-md-2">
                              <asp:DropDownList ID="ddlBankService" runat="server" AppendDataBoundItems="true" CssClass="form-control" DataSourceID="SqlDataSource4" DataTextField="QuesOption" DataValueField="QuesOption">
                                <asp:ListItem Text="Bank Services" Value="" />
                              </asp:DropDownList>
                              <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:DB_9AB8B7_D19DDA6422ConnectionString %>" SelectCommand="SELECT QuesOption FROM questionoptions WHERE (QuestionId = @que_id)">
                                  <SelectParameters>
                                      <asp:QueryStringParameter DefaultValue="7" Name="que_id" QueryStringField="7" Type="Int32" />
                                  </SelectParameters>
                              </asp:SqlDataSource>
                        </div>
                <div class="form-group col-md-1">
                    <asp:Button ID="btnSearchSurvey" runat="server" Text="Search" CssClass="btn btn-primary btn-sm" OnClick="btnSearchSurvey_Click" />
                </div>
                <div class="form-group col-md-1">
                    <asp:Button ID="btn_ShowAll" runat="server" Text="Show All" CssClass="btn btn-primary btn-sm" OnClick="btn_ShowAll_Click" />
                </div>
                

            </div>
            <hr />
            
            <%-- Displays search result on a table --%>
            <asp:Panel ID="Panel1" runat="server">
                 
               <h3>Search Results</h3>
               
                    <div class="form-group">
                        <asp:GridView CssClass="table table-bordered"
                            ID="gvSearchResults" runat="server">
                        </asp:GridView>
                    </div>
            </asp:Panel>



        </div>
    </section>
</asp:Content>
