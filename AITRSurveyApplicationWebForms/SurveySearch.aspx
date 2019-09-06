<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SurveySearch.aspx.cs" Inherits="AITRSurveyApplicationWebForms.SurveySearch" %>
<asp:Content ID="SurveySearch" ContentPlaceHolderID="MainContent" runat="server">
    <section id="main" class="wrapper ">
				<div class="container 8u$ center">
					<header class="major ">
						<h2>Survey Report Dashboard</h2>
                        <hr />
					</header>
                    
                      <div class="form-row d-flex justify-content-center">
                          <div class="form-group col-md-3">
                            <asp:TextBox ID="username" runat="server" CssClass="form-control form-control-sm" placeholder="Search"></asp:TextBox>
                        </div>
                          <div class="form-group col-md-2">
                            <!--<asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="criteria"></asp:TextBox>-->
                              <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                  <asp:ListItem>Gender</asp:ListItem>
                                  <asp:ListItem Value="1">Male</asp:ListItem>
                                  <asp:ListItem Value="2">Female</asp:ListItem>
                                  <asp:ListItem Value="3">Other</asp:ListItem>
                              </asp:DropDownList>
                        </div>
                          <div class="form-group col-md-2">
                              <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
                                  <asp:ListItem>State</asp:ListItem>
                                  <asp:ListItem Value="5">NSW</asp:ListItem>
                                  <asp:ListItem Value="6">QLD</asp:ListItem>
                                  <asp:ListItem Value="7">SA</asp:ListItem>
                                  <asp:ListItem Value="8">TAS</asp:ListItem>
                                  <asp:ListItem Value="9">VIC</asp:ListItem>
                                  <asp:ListItem Value="10">WA</asp:ListItem>
                                  <asp:ListItem Value="11">ACT</asp:ListItem>
                                  <asp:ListItem Value="12">NT</asp:ListItem>
                              </asp:DropDownList>
                            <!--<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="criteria"></asp:TextBox>-->
                        </div>
                          <div class="form-group col-md-2">
                            <!--<asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="criteria"></asp:TextBox>-->
                              <asp:DropDownList ID="ddlBankUsed" runat="server" CssClass="form-control">
                                  <asp:ListItem>Bank Used</asp:ListItem>
                                  <asp:ListItem>CommonWealth</asp:ListItem>
                                  <asp:ListItem>Westpac</asp:ListItem>
                                  <asp:ListItem>ANZ</asp:ListItem>
                                  <asp:ListItem>Bendigo</asp:ListItem>
                              </asp:DropDownList>
                        </div>
                          <div class="form-group col-md-2">
                            <!--<asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="criteria"></asp:TextBox>-->
                              <asp:DropDownList ID="ddlBankService" runat="server" CssClass="form-control">
                                  <asp:ListItem>Service</asp:ListItem>
                                  <asp:ListItem>Internet Banking</asp:ListItem>
                                  <asp:ListItem>Home Loan</asp:ListItem>
                                  <asp:ListItem>Credit Card</asp:ListItem>
                                  <asp:ListItem>Share Investment</asp:ListItem>
                              </asp:DropDownList>
                        </div>
                          <div class="form-group col-md-1">
                            <asp:Button ID="btnSearchSurvey" runat="server" Text="Search" CssClass="btn btn-primary btn-sm"/>
                        </div>

                    </div>
                  <table class="table table-bordered">
                      <thead>
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">First</th>
                          <th scope="col">Last</th>
                          <th scope="col">Handle</th>
                        </tr>
                      </thead>
                      <tbody>
                        <tr>
                          <th scope="row">1</th>
                          <td>Mark</td>
                          <td>Otto</td>
                          <td>@mdo</td>
                        </tr>
                        <tr>
                          <th scope="row">2</th>
                          <td>Jacob</td>
                          <td>Thornton</td>
                          <td>@fat</td>
                        </tr>
                        <tr>
                          <th scope="row">3</th>
                          <td colspan="2">Larry the Bird</td>
                          <td>@twitter</td>
                        </tr>
                        <tr>
                          <th scope="row">2</th>
                          <td>Jacob</td>
                          <td>Thornton</td>
                          <td>@fat</td>
                        </tr>
                        <tr>
                          <th scope="row">3</th>
                          <td colspan="2">Larry the Bird</td>
                          <td>@twitter</td>
                        </tr>
                      </tbody>
                    </table>
<nav aria-label="Page navigation example">
  <ul class="pagination pull-right">
    <li class="page-item"><a class="page-link" href="#">Previous</a></li>
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item"><a class="page-link" href="#">2</a></li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
    <li class="page-item"><a class="page-link" href="#">Next</a></li>
  </ul>
</nav>

				</div>
</section>
</asp:Content>
