<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="WithdrawMethods.aspx.cs" Inherits="SMSPaymentGateway.Main.Utils.WithdrawMethods" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <meta name="viewport" content = "width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />

            <asp:HiddenField runat="server" ID="txtEmailAddress" />
            <div class="form-horizontal">

                <div class="form-inline">
                    
                    <div class="col-md-12">
                        <asp:Label ID="Label1"  runat="server" Font-Bold="True" Font-Size="Larger" Text="WITHDRAWAL METHODS" ForeColor="#009933"></asp:Label>
                        <p></p>
                    </div>
                </div>        
                <div class="form-inline">  
                    
                    <div class="col-md-12">                                                                    
                         <asp:GridView ID="GridView1" runat="server" CssClass="footable"  AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="withdrawmethodid" OnRowDataBound="GridView1_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="withdrawmethodid" HeaderText="ID"/>                                      
                                    <asp:BoundField DataField="paymentoption" HeaderText="Payment Option" />
                                    <asp:BoundField DataField="bankname" HeaderText="Bank  / Pay Agent"/>
                                    <asp:BoundField DataField="accountnumber" HeaderText="Account Number" />

                                    
                                    <asp:CommandField ButtonType="Button" ShowCancelButton="False" ShowHeader="True" ShowSelectButton="True"  >
                                    <ControlStyle CssClass="btn btn-info btn-sm" />
                                    <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    
                                </Columns>
                                <EmptyDataTemplate>                                    
                                    <div class="form-inline">
                    
                                        <div class="col-md-12" style="text-align: center">
                                            <asp:Label ID="lbEmpty"  runat="server" Text="No Withdraw Methods Available" ForeColor="#009933" Width="100%" ></asp:Label>                                        
                                        </div>
                                    </div> 
                                </EmptyDataTemplate>
                            </asp:GridView>    
       
                         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetWithdrawMethods" TypeName="Web.Actions.GetWalletAction">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="txtEmailAddress" Name="emailaddress" PropertyName="Value" Type="String" />
                             </SelectParameters>
                         </asp:ObjectDataSource>
                        <link href="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/css/footable.min.css"
                            rel="stylesheet" type="text/css" />
                        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                        <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-footable/0.1.0/js/footable.min.js"></script>
                        <script type="text/javascript">

                            $(function () {
                                $('[id*=GridView1]').footable();
                            });
                    </script>
                    </div>
                    <p></p>
                </div>  
                <div class="form-inline">
                    <div class="col-md-12"> 
                        <asp:Button runat="server"  Text="Add Withdrawal Method" CssClass="btn btn-primary btn-lg" ID="btnSubmit" OnClick="btnSubmit_Click" />

                        
                    </div>
                </div>
                <div class="form-inline">
                    <ul class="pager">
                      <li><a href="../Main/Main.aspx"><span class="glyphicon glyphicon-home"></span> Home</a></li>
                      
                    </ul>
                </div>            
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
