<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_profile.aspx.cs" Inherits="user_profile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Profile</title>
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
            <td style="width:30%">
                  <center><img src="image/logoDark.png" width="45%" /><p>New Experience of chating</p></center><a href="home_login.aspx">Logout</a>
            </td>
        </tr>
        
    </table>
    
</header>
<hr />
<form id="form1" runat="server">
   <div>
        <center>
        <h1>Welcome</h1>
       <asp:Image ID="img_profPic" runat="server" style="border-radius:50%;border-width:5px;border-style:groove;border-color:#eeeeee" Width="200px" Height="200px" />
       <h1>
           <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label></h1>
        <h2>
            <asp:Label ID="lbl_time" runat="server" Text=""></asp:Label></h2>
            <asp:Button ID="btn_msg" runat="server" Text="GO To MESSAGES" 
                    onclick="btn_msg_Click" />
            <asp:Button ID="btn_basic" runat="server" Text="EDIT BASIC DETAILS" 
                    onclick="btn_basic_Click" />
            
        </center>
    </div>
    </form>
    </div>
</body>
</html>
