<%@ Page Title="" Language="C#" MasterPageFile="~/Main/mainMaster.Master" AutoEventWireup="true" CodeBehind="Escrow.aspx.cs" Inherits="SMSPaymentGateway.Main.Business.Escrow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <meta name="viewport" content = "width = device-width, initial-scale = 1.0, minimum-scale = 1.0, maximum-scale = 1.0, user-scalable = no" />

            <asp:HiddenField runat="server" ID="txtEmailAddress" />
            <div class="form-horizontal">

                <div class="form-inline">
                    
                    <div class="col-md-12">
                        <asp:Label ID="lblOrderStatus"  runat="server" Font-Bold="True" Font-Size="Larger" Text="ON ESCROW" ForeColor="#009933"></asp:Label>
                        <p></p>
                    </div>
                </div>        
                <div class="form-inline">  
                    
                    <div class="col-md-12">                                                                    
                         <asp:GridView ID="GridView1" runat="server" CssClass="footable"  AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" ShowHeaderWhenEmpty="True" OnRowCommand="GridView1_RowCommand" DataKeyNames="uniquetransactionid">
                                <Columns>
                                    <asp:BoundField DataField="uniquetransactionid" HeaderText="Unique Tranx Code" />                                      
                                    <asp:BoundField DataField="buyercustomername" HeaderText="Customer Name" />
                                    <asp:BoundField DataField="orderamount" HeaderText="Order Amount" DataFormatString="{0:n2}"/>
                                    <asp:BoundField DataField="datetimecreated" HeaderText="Date Created" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="datetimereceived" HeaderText="Date Paid" DataFormatString="{0:MM/dd/yyyy}" />
                                    <asp:BoundField DataField="orderdescription" HeaderText="Order Description" ItemStyle-Width="300px" />
                                    <asp:CommandField ButtonType="Button" SelectText="View Details" ShowCancelButton="False" ShowHeader="True" ShowSelectButton="True" >
                                    
                                    <ControlStyle CssClass="btn btn-info btn-sm" />
                                    <ItemStyle Width="100px" />
                                    </asp:CommandField>
                                    
                                </Columns>
                                <EmptyDataTemplate>                                    
                                    <div class="form-inline">
                    
                                        <div class="col-md-12" style="text-align: center">
                                            <asp:Label ID="lbEmpty"  runat="server" Text="No Orders On Escrow" ForeColor="#009933" Width="100%" ></asp:Label>                                        
                                        </div>
                                    </div> 
                                </EmptyDataTemplate>
                            </asp:GridView>    
       
                         <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetOrders" TypeName="Web.Actions.GetOrderAction">
                             <SelectParameters>
                                 <asp:ControlParameter ControlID="txtEmailAddress" Name="selleremailaddress" PropertyName="Value" Type="String" />
                                 <asp:Parameter DefaultValue="Escrow" Name="orderstatus" Type="String" />                                 
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
