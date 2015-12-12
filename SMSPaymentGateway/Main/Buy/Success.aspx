<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="SMSPaymentGateway.Main.Buy.Success" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <h2><%: Title %></h2>
            <div class="form-horizontal">                
                <h4>Your Unique Transaction Code</h4>
                <hr />
                <div class="form-group">
                    <div class="col-md-12">                      
                        <asp:Label ID="lblUniqueTransactionCode" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Label" ForeColor="#009933"></asp:Label>
                    </div>
                </div>
                <div>               
                    <p>An email has been sent to you with instructions on how to pay using Smart Money or GCash. </p> 
                    <p>Keep your Smart Money and GCash reference number confidential. </p>
                </div>
            </div>

</asp:Content>
