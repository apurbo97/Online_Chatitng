<%@ Page Language="C#" AutoEventWireup="true" CodeFile="malicious_acc_report.aspx.cs" Inherits="malicious_acc_report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Malicious</title>
    <link rel="shortcut icon" href="image/logolight.png">
    <link rel="stylesheet" type="text/css" href="responsiveform.css" />
	<link rel="stylesheet" media="screen and (max-width: 1200px) and (min-width: 601px)" href="responsiveform1.css" />
	<link rel="stylesheet" media="screen and (max-width: 600px) and (min-width: 351px)" href="responsiveform2.css" />
	<link rel="stylesheet" media="screen and (max-width: 350px)" href="responsiveform3.css" />
</head>
<body>
    <div id="envelope">
<header>
    <table width="100%">
        <tr>
             <center><img src="image/logoDark.png" width="45%" /><p>New Experience of chating</p></center>
            </td>
            <td><a href="home_login.aspx">Logout</a></td>        
        </tr>
    </table>
    
</header>
<table width="100%" cellpadding="0" cellspacing="0">
        <tr style="height:50px">
            <th style="text-align:center; width:50%; background-color: #6699FF; font-weight:bold "><a href="user_list_admin.aspx">USER LIST</a></th>
            <th style="text-align:center; width:50%; background-color: #6699FF; font-weight:bold"><a href="malicious_acc_report.aspx">MALICIOUS REPORTS </a></th>
           
        </tr>
    </table>
    <form id="form1" runat="server">
   <div style="height:400px; overflow:scroll;">
        
        <center>
         </center>
        <asp:GridView ID="grd_data" runat="server" AutoGenerateColumns="False" 
                Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" 
                onrowcommand="grd_data_RowCommand" >
                
                <RowStyle BackColor="#EFF3FB" />
                
                <Columns>
                    <asp:ButtonField Text="Deactivate" CommandName="de" />
                    <asp:BoundField DataField="sl_no" HeaderText="SL NO" />
                    <asp:ButtonField DataTextField="request_id" HeaderText="REPORTED BY" CommandName="r_by"/>
                    <asp:ButtonField DataTextField="report_id" HeaderText="REPORTED TO" CommandName="r_to" />
                    <asp:BoundField DataField="description" HeaderText="DESCRIPTION" />
                </Columns>
                
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>
       
        </div>
    </form>

</div>

</body>
</html>
