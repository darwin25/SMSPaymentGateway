<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster2.Master" AutoEventWireup="true" CodeBehind="Main2.aspx.cs" Inherits="SMSPaymentGateway.Main.Main2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <h2><%: Title %></h2>
            <p class="text-danger">
                <asp:Label ID="Message" runat="server"></asp:Label>
            </p>

             <meta name="viewport" content = "width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />

            <asp:HiddenField runat="server" ID="txtEmailAddress" />
            <div class="form-horizontal">
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="lblWalletBalance" CssClass="col-md-2 control-label">Wallet Balance:</asp:Label>
                    <div class="col-md-10">
                        <asp:Label ID="lblWalletBalance" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"  ></asp:Label>                                               
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtDateFrom" CssClass="col-md-2 control-label">Date (From):</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtDateFrom" CssClass="form-control" AutoPostBack="False" TextMode="Date" Width="200px" />                        
                        <p></p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtDateTo" CssClass="col-md-2 control-label">Date (To):</asp:Label>
                    <div class="col-md-10">
                        <asp:TextBox runat="server" ID="txtDateTo" CssClass="form-control" AutoPostBack="False" TextMode="Date" Width="200px" />                        
                        <p></p>
                    </div>
                </div>
               
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="lblMyOrders" CssClass="col-md-2 control-label"></asp:Label>
                    <div class="col-md-10">
                        <asp:Label ID="lblMyOrders" runat="server"></asp:Label>                                               
                    </div>
                </div>
    
            </div>
        
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
