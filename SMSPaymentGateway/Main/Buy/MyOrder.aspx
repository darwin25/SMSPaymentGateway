<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyOrder.aspx.cs" Inherits="SMSPaymentGateway.Main.Buy.MyOrder" %>

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
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtOrderStatus" CssClass="col-md-3 control-label">Order Status:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtOrderStatus" ForeColor="Blue" Height="28px" Font-Size="Large" />
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtCustomerDetails" CssClass="col-md-3 control-label">Customer Details:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtCustomerDetails" Height="85px"/>
                        <asp:HiddenField runat="server" ID="txtCustomerID" />                     
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtSellerDetails" CssClass="col-md-3 control-label">Seller Details:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtSellerDetails" Height="85px" />
                        
                        <asp:HiddenField runat="server" ID="txtSellerID" />
                        <p></p>
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
                    <asp:Label runat="server" AssociatedControlID="txtOrderDescription" CssClass="col-md-3 control-label">Order Description:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtOrderDescription" Height="28px" Width="280px" />
                        <p></p>    
                    </div>
                </div>
     
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtOrderAmount" CssClass="col-md-3 control-label">Order Amount:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtOrderAmount" Height="28px" />
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
                        <p></p>
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
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="radio">                                            
                                            <asp:ListItem> Pay and credit the balance to my wallet.</asp:ListItem>                                            
                                            <asp:ListItem> Credit the whole amount to my Bayan Pay Wallet. Do not cancel the tansaction.</asp:ListItem>
                                            <asp:ListItem> Cancel the order and credit the whole amount to my Bayan Pay Wallet.</asp:ListItem>                                            
                                        </asp:RadioButtonList>
                                        </form>
                                        <p></p>
                                    </div>
                                  
                                </div>
                                <div class="modal-footer">
                                  <asp:Button runat="server" ID="btnSubmit1" class="btn btn-default" Text="Submit" OnClick="btnSubmit1_Click" />
                                  <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                              </div>
      
                            </div>
                          </div>--%>
  


                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server"  CssClass="col-md-3 control-label"></asp:Label>            
                    <div class="col-md-9">
                        <asp:CheckBox runat="server" ID="CheckBox1" Text="I have reviewed the details of my order and authorize Bayan Pay to pay the seller stated above."/>
                        
                    </div>
                </div>
                <div class="form-inline">
                    <div class="col-md-offset-3 col-md-9"  >                        
                        <asp:Button runat="server"  Text="Pay Order" CssClass="btn btn-primary btn-lg" ID="btnPayOrder" OnClick="btnPayOrder_Click" UseSubmitBehavior="false"/>
                        
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

