<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="MyFunding.aspx.cs" Inherits="SMSPaymentGateway.Main.Utils.MyFunding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2><%: Title %></h2>
            <p class="text-danger">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </p>

            <div class="form-horizontal">
                <h2></h2>
                <hr />
                <asp:HiddenField runat="server" ID="txtEmailAddress" />                     
                <asp:HiddenField runat="server" ID="txtCustomerID" />                     
                <div class="form-inline">
                    
                    <div class="col-md-12">
                        <asp:DetailsView runat="server" ID="DetailsView1"  />
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtFundingStatus" CssClass="col-md-3 control-label">Funding Status:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtFundingStatus" ForeColor="Blue" Height="28px" Font-Size="Large" />                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtUniqueTransactionCode" CssClass="col-md-3 control-label">Unique Transaction Code:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtUniqueTransactionCode" ForeColor="Blue" Height="28px" Font-Size="Medium" />
                    </div>
                    <p></p>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtFundingAmount" CssClass="col-md-3 control-label">Funding Amount:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtFundingAmount" Height="28px" />
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtDateTimeCreated" CssClass="col-md-3 control-label">Date / Time Created:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtDateTimeCreated" Height="28px" />
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" ID=lblDateTimePOC AssociatedControlID="txtDateTimePOC" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtDateTimePOC" Height="28px" />
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtDateTimeExpired" CssClass="col-md-3 control-label">This order will expire on:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtDateTimeExpired" Height="28px" />
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtPaymentReferenceNumber" CssClass="col-md-3 control-label">Payment Reference Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtPaymentReferenceNumber" CssClass="form-control"/>                     
                    </div>
                    <div class="col-md-offset-3 col-md-9"  >
                        <%--<asp:Button runat="server"  Text="..More" CssClass="btn btn-default" ID="btnOptions" data-toggle="modal" data-target="#myModal" />                                               
                          <!-- Modal -->
                          <div class="modal fade" id="myModal" role="dialog">
                            <div class="modal-dialog modal-lg">
    
                              <!-- Modal content-->
                              <div class="modal-content">
                                <div class="modal-header">
                                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                                  <h4 class="modal-title">Options</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="container">
                                        <form role="form">
                                            <p>I will create a new funding that matches the amount in the payment reference number</p>
                                            <p></p>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio">                                                                                        
                                            <asp:ListItem> Do not cancel the funding.</asp:ListItem>
                                            <asp:ListItem> Cancel the funding.</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                        </form>
                                        <p></p>
                                    </div>
                                  
                                </div>
                                <div class="modal-footer">
                                  <asp:Button runat="server" ID="btnSubmit1" class="btn btn-default" Text="Submit"/>
                                  <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                              </div>
      
                            </div>
                          </div>--%>
  


                    </div>
                </div>
                <div class="form-inline">                    
                    <div class="col-md-offset-3 col-md-9"  >
                        <p></p>
                        <asp:Button runat="server"  Text="Pay Order" CssClass="btn btn-primary btn-lg" ID="btnPayOrder" OnClick="btnPayOrder_Click" />
                        
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="modal1">
                <div class="center1">
                    <img alt="" src="../../Images/Processing.gif"/>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
