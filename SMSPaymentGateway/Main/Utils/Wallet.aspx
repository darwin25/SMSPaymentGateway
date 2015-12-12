<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="Wallet.aspx.cs" Inherits="SMSPaymentGateway.Main.Utils.Wallet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2><%: Title %></h2>
                <p class="text-danger">
                    <asp:Label ID="Message" runat="server"></asp:Label>
                </p>

                <div class="form-horizontal">
                    <h2></h2>
                    <hr />
                    <asp:HiddenField runat="server" ID="txtCustomerID" />
                    <div class="form-inline">
                        <asp:Label runat="server" AssociatedControlID="txtPaymentAmount" CssClass="col-md-3 control-label">Payment Amount:</asp:Label>
                        <div class="col-md-9">
                            <asp:TextBox runat="server" ID="txtPaymentAmount" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="True" OnTextChanged="txtPaymentAmount_TextChanged" />
                            <asp:Label runat="server" ID="lblPaymentAmountValidator" CssClass="text-danger"/>                          
                        </div>
                    </div>
                    <div class="form-inline">
                        <div class="col-md-offset-3 col-md-9"  >
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
