<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="NotSupported.aspx.cs" Inherits="SMSPaymentGateway.NotSupported" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <h2><%: Title %></h2>
            <div class="form-horizontal">                
                <h4>Your browser is not supported</h4>
                <hr />
                <div class="form-group">
                    <div class="col-md-10">                      
                        <asp:Label ID="lblMessage" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-10">                      
                        <asp:Label ID="lblMessage2" runat="server">We recommend that you use Mozilla Firefox or Google Chrome</asp:Label>
                    </div>
                </div>

            </div>

   
</asp:Content>
