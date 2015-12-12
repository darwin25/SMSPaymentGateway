<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="SMSPaymentGateway.Account.SignUp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Label ID="Message" runat="server"></asp:Label>
    </p>

    <div class="form-horizontal">
        <h4>Create a new account</h4>
        <hr />
        <div class="form-inline">
          <div class="col-md-6">
              <asp:Panel runat="server" ID="Panel1" CssClass="panel panel-default" Height="500px">
                  <div class="panel-body">
                        <h4>Buy with Bayan Pay</h4>
                        For people who primarily want to buy 
                      <div class="form-inline">
                        <div>     
                            <br />                   
                                <p>
                                    <asp:Button runat="server" ID="Button1" Text="Get Started" CssClass="btn btn-primary btn-lg" />
                                </p>

                            <br />

                        </div>
                      <div>

                            <div>
                                For purchases within the Philippines
                                <ul>                                
                                    <li>Pay using Smart Money, GCash or Over the Counter</li>
                                    <li>Your eligible purchases are covered by our Buyer Protection program.</li>                                        
                                </ul>
                            </div>
                            <br />
                            <div>
                                For OFWs
                                <ul>                                
                                    <li>Shop online for your loved ones in the Philippines</li>
                                    <li>Pay Over-the-Counter from any of partner remittance companies</li>
                                    <li>Your eligible purchases are covered by our Buyer Protection program.</li>                                        
                                </ul>
                            </div>
                        </div>
                    </div>                        
                   </div>
              </asp:Panel>
          </div>
        </div>
        <div class="form-inline">
          <div class="col-md-6">
              <asp:Panel runat="server" ID="Panel2" CssClass="panel panel-default" Height="500px">                  
                    <div class="panel-body">
                        <h4>Receive payments with Bayan Pay</h4>
                        For people and businesses who primarily want to receive payments
                        <div class="form-inline">
                            <div>     
                                <br />                   
                                    <p>
                                        <asp:Button runat="server" ID="Button2" Text="Get Started" CssClass="btn btn-primary btn-lg" />
                                    </p>

                                <br />

                            </div>
                          <div>
                            <div>

                                <div>
                                    For purchases within the Philippines
                                    <ul>                                
                                        <li>No set up or monthly fees. Pay a transaction fee when you make a sale.</li>
                                        <asp:AppearanceEditorPart />
                                        <li>Accept payments from buyers who don't use credit or debit cards.</li>
                                        <li>Enjoy peace of mind with our 24/7 transaction monitoring and Seller Protection for your eligible transactions.</li>                                                                          
                                    </ul>
                                </div>
                            
                            </div>
                        </div>
                    </div>
                </div>
              </asp:Panel>
          </div>
        </div>
        <div class="form-inline">
                    <div class="col-md-12"  >                        
                        <p></p>
                        <br />
                    </div>
        </div>
    </div>
</asp:Content>
