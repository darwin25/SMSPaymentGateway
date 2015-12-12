<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddWithdrawMethod.aspx.cs" Inherits="SMSPaymentGateway.Main.Utils.AddWithdrawMethod" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2><%: Title %></h2>
                <p class="text-danger">
                    <asp:Label ID="Message" runat="server"></asp:Label>
                </p>

                <div class="form-horizontal">
                    <h2></h2>
                    <h4>Add Withdraw Method </h4>
                    <hr />
                    <div class="form-inline">
                        <asp:Label runat="server" AssociatedControlID="txtRecepient" CssClass="col-md-3 control-label">Recipient:</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="txtRecepient" CssClass="form-control" AutoCompleteType="Disabled" />
                            <asp:Label runat="server" ID="lblRecepientValidator" CssClass="text-danger"/>                          
                            <p></p>
                        </div>
                    </div>
                    <div class="form-inline">
                        <asp:Label runat="server" AssociatedControlID="ddlPaymentOption" CssClass="col-md-3 control-label">Payment Option:</asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList runat="server" ID="ddlPaymentOption" CssClass="form-control-dropdown" AutoPostBack="true" OnTextChanged="ddlPaymentOption_TextChanged"/>
                            <p></p>
                        </div>
                    </div>                    
                    <div class="form-inline">
                        <asp:Label runat="server" AssociatedControlID="ddlBank" CssClass="col-md-3 control-label">Bank / Pay Agent:</asp:Label>
                        <div class="col-md-9">
                            <asp:DropDownList runat="server" ID="ddlBank" CssClass="form-control-dropdown"/>
                            <p></p>
                        </div>
                    </div>     
                    <div class="form-inline">
                        <asp:Label runat="server" AssociatedControlID="txtBankAccountNumber" CssClass="col-md-3 control-label">Bank Account Number:</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="txtBankAccountNumber" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="true" OnTextChanged="txtBankAccountNumber_TextChanged"/>
                            <asp:Label runat="server" ID="lblBankAccountNumberValidator" CssClass="text-danger"/>                          
                            <p></p>
                        </div>
                    </div>
                    <div class="form-inline">
                        <div class="col-md-offset-3 col-md-9"  >
                            <p></p>
                            <asp:Button runat="server"  Text="Submit" CssClass="btn btn-primary btn-lg" ID="btnSubmit" OnClick="btnSubmit_Click" />
                        
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
            <ProgressTemplate>
                <div class="modal1">
                    <div class="center1">
                        <img alt="" src="../Images/Processing.gif" />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
</asp:Content>
