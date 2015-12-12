<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="SMSPaymentGateway.Account.MyAccount" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
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
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtFriendlyURLName" CssClass="col-md-3 control-label">Friendly URL Name:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtFriendlyURLName" CssClass="form-control" autocomplete="off" AutoPostBack="True" OnTextChanged="txtFriendlyURLName_TextChanged"/>    
                        <asp:Label runat="server" ID="lblFriendlyURLName" CssClass="text-danger"/>                                                
                        <p>
                        </p>
                    </div>
                </div>
                <div class="form-inline">                    
                    <asp:Label runat="server" ID="lblSuggested"  AssociatedControlID="lblSuggested" CssClass="col-md-3 control-label"></asp:Label>
                    <div class="col-md-9">
                        <p>
                            <asp:Label runat="server" ID="lblSuggestedNames" CssClass="text-info"/>
                        </p>                                       
                        
                    </div>
                </div>
                <div class="form-inline">                    
                    <asp:Label runat="server" AssociatedControlID="lblFriendlyURL" CssClass="col-md-3 control-label">Orders URL:</asp:Label>
                    <div class="col-md-9">
                        <p>
                            <asp:Label runat="server" ID="lblFriendlyURL" CssClass="text-info"/>
                        </p>                                       
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-3 control-label">First Name:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" AutoPostBack="True" />
                        <asp:Label runat="server" ID="lblFirstNameValidator" CssClass="text-danger"/>
                        <p>
                        </p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtMiddleName" CssClass="col-md-3 control-label">Middle Name:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" />
                        <p>
                        </p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-3 control-label">Last Name: </asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" AutoPostBack="True" />
                        <asp:Label runat="server" ID="lblLastNameValidator" CssClass="text-danger"/>
                        <p>
                        </p>
                    </div>
                </div>
                
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-3 control-label">Address:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control-multiline" TextMode="MultiLine" AutoPostBack="True"/>
                        <asp:Label runat="server" ID="lblAddressValidator" CssClass="text-danger"/>  
                        <p>
                        </p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtMobileNo" CssClass="col-md-3 control-label">Mobile No:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" TextMode="Phone" AutoPostBack="True" />
                        <asp:Label runat="server" ID="lblMobileNumberValidator" CssClass="text-danger" />  
                        <p>
                        </p>
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="ddlProvince" CssClass="col-md-3 control-label">Province:</asp:Label>
                    <div class="col-md-9">
                        <asp:DropDownList runat="server" ID="ddlProvince" CssClass="form-control-dropdown" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"/>
                        <p>
                        </p>                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="ddlTown" CssClass="col-md-3 control-label">Town:</asp:Label>
                    <div class="col-md-9">
                        <asp:DropDownList runat="server" ID="ddlTown" CssClass="form-control-dropdown" />
                        <p>
                        </p>
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
