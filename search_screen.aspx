<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search_screen.aspx.cs" Inherits="search_screen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Search</title>
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
           <td style="width:40%">
                  <center><img src="image/logoDark.png" width="95%" /><p>New Experience of chating</p></center>
            </td>
            
            <td style="width:30%; text-align:center; ">
            <asp:Image ID="img_profPic" runat="server" style="border-radius:50%;border-width:5px;border-style:groove;border-color:#eeeeee" Width="100px" Height="100px" />
            <h1>
           <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></h1>
           <a href="home_login.aspx">Logout</a>
            </td>
        </tr>
    </table>
    
</header>

<table width="100%" cellpadding="0" cellspacing="0">
        <tr style="height:50px">
            <th style="text-align:center; width:33%; background-color: #6699FF; font-weight:bold "><a href="friend_list.aspx">FRIEND LIST</a></th>
            <th style="text-align:center; width:33%; background-color: #6699FF; font-weight:bold"><a href="chat_screen.aspx"> CHAT </a></th>
            <th style="text-align:center; width:33%; background-color: #0066FF; font-weight:bold"><a href="search_screen.aspx">SEARCH</a> </th>
        </tr>
    </table>
    <form id="form1" runat="server">
   <div style="height:400px; overflow:scroll;">
        
        <center>
        <asp:TextBox ID="txt_search" runat="server"  placeholder="name/phone number"></asp:TextBox>
        <asp:Button ID="btn_search" runat="server" Text="Search" 
                onclick="btn_search_Click"/>
        </center>
        <asp:GridView ID="grd_data" runat="server" AutoGenerateColumns="False" 
                Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" 
                onrowcommand="grd_data_RowCommand" >
                
                <RowStyle BackColor="#EFF3FB" />
                
                <Columns>
                    <asp:ButtonField Text="send request" CommandName="req"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="img_profile" ImageUrl='<%# "image_view.aspx?id=" + Eval("account_id") %>'  runat="server" style="border-radius:50%;border-width:5px;border-style:solid;border-color:#eeeeee" Width="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="name" />
                    <asp:ButtonField Text="details" CommandName="details" />
                </Columns>
                
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                
            </asp:GridView>
       <asp:GridView ID="grd_hide" runat="server" Visible="false">
       
       </asp:GridView>
        </div>
    </form>
    </div>
</body></html>
