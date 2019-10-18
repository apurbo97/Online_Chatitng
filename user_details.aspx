<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_details.aspx.cs" Inherits="user_details" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Details</title>
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
            <td style="width:40%" >
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
            <th style="text-align:center; width:33%; background-color: #0066FF; font-weight:bold "><a href="friend_list.aspx">FRIEND LIST</a></th>
            <th style="text-align:center; width:33%; background-color: #6699FF; font-weight:bold"><a href="chat_screen.aspx"> CHAT </a>
        
            </th>
            <th style="text-align:center; width:33%; background-color: #6699FF; font-weight:bold"><a href="search_screen.aspx">SEARCH</a> </th>
        </tr>
    </table>
    <form id="form1" runat="server">
   <div style="height:400px; overflow:scroll;">
        
    <center>
    <h1>Person Details</h1>
       <asp:Image ID="img_person" runat="server" style="border-radius:50%;border-width:5px;border-style:groove;border-color:#eeeeee" Width="200px" Height="200px" />
       <h1>Name : <asp:Label ID="lbl_person_name" runat="server" Text="" style="color:Blue;"></asp:Label></h1>
        <h3>Address : <asp:Label ID="lbl_address" runat="server" Text="" style="color:Blue;"></asp:Label></h3>
        <h3>Date of Birth : <asp:Label ID="lbl_date" runat="server" Text="" style="color:Blue;"></asp:Label></h3>
        <h3>Email : <asp:Label ID="lbl_email" runat="server" Text="" style="color:Blue;"></asp:Label></h3>
        <h3>Phone : <asp:Label ID="lbl_phone" runat="server" Text="" style="color:Blue;"></asp:Label></h3>
            <asp:Button ID="btn_friend" runat="server" Text="" onclick="btn_friend_Click" />
            <asp:Button ID="btn_block" runat="server" Text="BLOCK IT" 
                    onclick="btn_block_Click" />
            <asp:Button ID="btn_report" runat="server" Text="REPORT IT" 
                    onclick="btn_report_Click" />
        </center>
    
        </div>
    </form>
    
    </div>
</body>
</html>
