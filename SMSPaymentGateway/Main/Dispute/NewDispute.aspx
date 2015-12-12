<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="NewDispute.aspx.cs" Inherits="SMSPaymentGateway.Main.Dispute.NewDispute" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                <asp:Label ID="Label1" runat="server">test</asp:Label>
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
