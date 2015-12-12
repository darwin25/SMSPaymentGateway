<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="ManageOrder.aspx.cs" Inherits="SMSPaymentGateway.Main.Business.ManageOrder" %>
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
                        <asp:HiddenField runat="server" ID="txtCustomerEmailAddress" />   
                        <asp:HiddenField runat="server" ID="txtsellerFriendlyURLName" />  
                        <asp:HiddenField runat="server" ID="txtSellerMobleNumber" />                     
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
                    <asp:Label runat="server" ID=lblDateTimePOC AssociatedControlID="txtDateTimePOC" CssClass="col-md-3 control-label">Date / Time Payment Received</asp:Label>
                    <div class="col-md-9">  
                        <asp:Label runat="server" ID="txtDateTimePOC" Height="28px" />
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtPaymentReferenceNumber" CssClass="col-md-3 control-label">Payment Reference Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtPaymentReferenceNumber" Height="28px" />                        
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="ddlSentThru" CssClass="col-md-3 control-label">Sent Thru :</asp:Label>
                    <div class="col-md-9">                        
                        <asp:DropDownList ID="ddlSentThru" runat="server" CssClass="form-control-dropdown" AutoPostBack="true" OnTextChanged="ddlSentThru_TextChanged" />
                        <asp:Label runat="server" ID="lblSentThruValidator" CssClass="text-danger"/> 
                        <p></p>
                    </div>
                </div>                
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtTrackingNumber" CssClass="col-md-3 control-label">Tracking Number:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtTrackingNumber" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtTrackingNumber_TextChanged"/>
                        <asp:Label runat="server" ID="lblTrackingNumberValidator" CssClass="text-danger"/>  
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtDateSentForDelivery" CssClass="col-md-3 control-label">Date Sent for Delivery:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtDateSentForDelivery" CssClass="form-control" AutoPostBack="true" TextMode="Date" Width="200px" OnTextChanged="txtDateSentForDelivery_TextChanged" />                        
                        <asp:Label runat="server" ID="lblDateSentValidator" CssClass="text-danger"/> 
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtEstimatedDateOfDelivery" CssClass="col-md-3 control-label">Estimated Date of Delivery:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtEstimatedDateOfDelivery" CssClass="form-control" AutoPostBack="true" TextMode="Date" Width="200px" OnTextChanged="txtEstimatedDateOfDelivery_TextChanged"/>                        
                        <asp:Label runat="server" ID="lblEstimatedDateOfDeliveryValidator" CssClass="text-danger"/> 
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <div class="col-md-offset-3 col-md-9"  >                        
                        <asp:Button runat="server"  Text="Update Order" CssClass="btn btn-primary btn-lg" ID="btnPayOrder"  UseSubmitBehavior="false" OnClick="btnPayOrder_Click"/>
                        
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
