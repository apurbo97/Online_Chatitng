<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report_page.aspx.cs" Inherits="report_page" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Report</title>
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
    <h1>Report Details</h1>
       
            
    <asp:TextBox ID="txt_report" runat="server" TextMode="MultiLine" Height="200px"   placeholder="Report content"></asp:TextBox>
            <asp:Button ID="btn_report" runat="server" Text="REPORT IT" onclick="btn_report_Click" />
        </center>
    
        </div>
    </form>
    
    </div>

</body>
<script src="jquery.js" type="text/javascript"></script>
<script type="text/javascript">
 function validate(id) {
            if ($("#" + id).val() == null || $("#" + id).val() == "") {
              
               $("#" + id).css('border-color', 'red');
                return false;
            }
            else
                $("#" + id).css('border-color', '');
            return true;
           
        }
        $(document).ready(

            function () {

                $("#btn_report").click(function () {
                 if (!validate("txt_report")) {
                        return false;
                    }                   
                });
            }

            )

</script>
</html>
