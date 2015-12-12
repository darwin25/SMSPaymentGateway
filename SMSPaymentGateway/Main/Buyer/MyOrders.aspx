<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster2.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="SMSPaymentGateway.Main.Buyer.MyOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <meta name="viewport" content = "width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />
            <h2><%: Title %></h2>
            <p class="text-danger">
                <asp:Label ID="Message" runat="server"></asp:Label>
            </p>
            <asp:HiddenField runat="server" ID="txtEmailAddress" />
            <div class="form-horizontal">

                <div class="form-inline">
                    
                    <div class="col-md-12">
                        <asp:Label ID="lblOrderStatus"  runat="server" Font-Bold="True" Font-Size="Larger" Text="MY PURCHASES" ForeColor="#009933"></asp:Label>
                        <p></p>
                    </div>
                </div>        
                <div class="form-inline">  
                    
                    <div class="col-md-12">                                                                    
                         <asp:GridView ID="GridView1" runat="server" CssClass="footable"  AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="uniquetransactionid, orderstatus" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="uniquetransactionid" HeaderText="Unique Tranx Code" />                                      
                                    <asp:BoundField DataField="customerfriendlyurlname" HeaderText="Seller" />
                                    <asp:BoundField DataField="orderamount" HeaderText="Order Amount" DataFormatString="{0:n2}"/>
                                    <asp:BoundField DataField="orderdescription" HeaderText="Order Description" ItemStyle-Width="300px" >
                                    <ItemStyle Width="300px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="orderdatetimecreated" HeaderText="Date Ordered" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="orderstatus" HeaderText="Status" />
                                    <asp:ButtonField ButtonType="Button" CommandName="View" Text="View Details">
                                        <ControlStyle CssClass="btn btn-info btn-sm" />
                                        <ItemStyle Width="100px" />
                                    </asp:ButtonField>
                                    <asp:ButtonField ButtonType="Button" CommandName="Dispute" Text="Open a Dispute">
                                        <ControlStyle CssClass="btn btn-info btn-sm" />
                                        <ItemStyle Width="100px" />
                                    </asp:ButtonField>
                                    
                                    
                                </Columns>
                                <EmptyDataTemplate>                                    
                                    <div class="form-inline">
                    
                                        <div class="col-md-12" style="text-align: center">
                                            <asp:Label ID="lbEmpty"  runat="server" Text="No purchases found for this date range" ForeColor="#009933" Width="100%" ></asp:Label>                                        
                                        </div>
                                    </div> 
                                </EmptyDataTemplate>
                            </asp:GridView>    
       
                         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetBuyerOrders" TypeName="Web.Actions.GetOrderAction">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="txtEmailAddress" Name="buyereremailaddress" PropertyName="Value" Type="String" />
                                 <asp:QueryStringParameter Name="fromdate" QueryStringField="fromdate" Type="DateTime" />
                                 <asp:QueryStringParameter Name="todate" QueryStringField="todate" Type="DateTime" />
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
                        <asp:Button runat="server"  Text="Export to CSV" CssClass="btn btn-primary btn-lg" ID="btnExport" OnClick="btnExport_Click" />
                        
                    </div>
                </div>
                <div class="form-inline">
                    <ul class="pager">
                      <li><a href="../Main.aspx"><span class="glyphicon glyphicon-home"></span> Home</a></li>
                      
                    </ul>
                </div>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
