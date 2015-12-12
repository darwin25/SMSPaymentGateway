<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SMSPaymentGateway._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/main.css" rel="stylesheet" />
    <div class="jumbotron">
        <h1>Shop Online. No credit card needed</h1>        
        <p class="lead">Pay with Smart Money or GCash.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Individuals</h2>
            <div class="thumbnail">
                <img class="img-responsive" src="Images/40652308.jpg" />
            </div>
            <p>
                <a class="btn btn-primary btn-lg" href="http://go.microsoft.com/fwlink/?LinkId=301948">See how it works</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Merchants</h2>
            <div class="thumbnail">
                <img class="img-responsive" src="Images/50869566.jpg"  />
            </div>            
            <p>
                <a class="btn btn-primary btn-lg" href="http://go.microsoft.com/fwlink/?LinkId=301949">Get paid</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Trust and Safety</h2>
            <div class="thumbnail">
                <img class="img-responsive" src="Images/Escrow%20(1).jpg" />
            </div>            <p>
                <a class="btn btn-primary btn-lg" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more</a>
            </p>
        </div>
    </div>
</asp:Content>
