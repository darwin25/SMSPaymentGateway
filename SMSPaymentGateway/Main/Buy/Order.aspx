<%@ Page Language="C#" Culture="en-PH" AutoEventWireup="true" CodeBehind="Order.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SMSPaymentGateway.Main.Buy.Order" %>

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
                    <asp:Label runat="server" AssociatedControlID="txtPayee" CssClass="col-md-3 control-label">Payee:</asp:Label>
                    <div class="col-md-9">
                        <asp:Label runat="server" ID="txtPayee" Height="85px"/>
                        <asp:HiddenField runat="server" ID="txtSellerCustomerID" />
                        <asp:HiddenField runat="server" ID="txtSellerEmailAddress" />
                    </div>                    
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtEmailAddress" CssClass="col-md-3 control-label">Email Address:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtEmailAddress" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtEmailAddress_TextChanged" />                                
                        <asp:Label runat="server" ID="lblEmailAddressValidator" CssClass="text-danger"/>
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtFirstName" CssClass="col-md-3 control-label">First Name:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtFirstName_TextChanged" />
                        <asp:Label runat="server" ID="lblFirstNameValidator" CssClass="text-danger"/>
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtMiddleName" CssClass="col-md-3 control-label">Middle Name:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtMiddleName" CssClass="form-control" />
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtLastName" CssClass="col-md-3 control-label">Last Name: </asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtLastName_TextChanged" />
                        <asp:Label runat="server" ID="lblLastNameValidator" CssClass="text-danger"/>
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtAddress" CssClass="col-md-3 control-label">Address:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control-multiline" TextMode="MultiLine" AutoPostBack="True" OnTextChanged="txtAddress_TextChanged"/>
                        <asp:Label runat="server" ID="lblAddressValidator" CssClass="text-danger"/>  
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtMobileNo" CssClass="col-md-3 control-label">Mobile No:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtMobileNo" CssClass="form-control" TextMode="Phone" AutoPostBack="True" OnTextChanged="txtMobileNo_TextChanged" />
                        <asp:Label runat="server" ID="lblMobileNumberValidator" CssClass="text-danger"/>  
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="ddlProvince" CssClass="col-md-3 control-label">Province:</asp:Label>
                    <div class="col-md-9">  
                        <asp:DropDownList runat="server" ID="ddlProvince" CssClass="form-control-dropdown" AutoPostBack="True" OnTextChanged ="ddlProvince_TextChanged"  />
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="ddlTown" CssClass="col-md-3 control-label">Town:</asp:Label>
                    <div class="col-md-9">
                        <asp:DropDownList runat="server" ID="ddlTown" CssClass="form-control-dropdown"  />
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtPaymentAmount" CssClass="col-md-3 control-label">Payment Amount:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtPaymentAmount" CssClass="form-control" AutoCompleteType="Disabled" AutoPostBack="True" OnTextChanged="txtPaymentAmount_TextChanged" />
                        <asp:Label runat="server" ID="lblPaymentAmountValidator" CssClass="text-danger"/>  
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server" AssociatedControlID="txtDescription" CssClass="col-md-3 control-label">Description:</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control-multiline" TextMode="MultiLine" AutoCompleteType="Disabled" OnTextChanged="txtDescription_TextChanged"/>
                        <asp:Label runat="server" ID="lblDescriptionValidator" CssClass="text-danger"/>  
                        
                    </div>
                </div>
                <div class="form-inline">
                    <asp:Label runat="server"  CssClass="col-md-3 control-label"></asp:Label>            
                    <div class="col-md-9">
                        <asp:CheckBox runat="server" ID="CheckBox1" Text='I have read and accept the <a href="http://www.asp.net" title="Terms and Conditions">Terms and Conditions</a>' />
                        <asp:Label runat="server" ID="lblMessage" CssClass="text-danger"/>  
                        
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
                    <img alt="" src="../../Images/Processing.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
