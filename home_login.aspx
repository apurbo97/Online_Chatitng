<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home_login.aspx.cs" Inherits="home_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
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
        </tr>
    </table>
    
</header>
<hr>
<form id="form1" runat="server">
    <center>
	<label>E-mail id </label><br />
    <asp:TextBox ID="txt_email" runat="server" style="width:60%" placeholder="yourname@gmail.com"></asp:TextBox>
	<br /><label>Password </label><br />
    <asp:TextBox ID="txt_password" runat="server" style="width:60%" TextMode="Password" placeholder="password"></asp:TextBox>
	<asp:Button ID="btn_login" runat="server" Text="LOGIN" style="width:60%" 
            onclick="btn_login_Click" />
	<asp:Button ID="btn_new" runat="server" Text="CREATE NEW ID" style="width:60%" 
            onclick="btn_new_Click" />
	</center>
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

                $("#btn_login").click(function () {
                 if (!validate("txt_email")) {
                        return false;
                    }
                    if (!validate("txt_password")) {
                        return false;
                    }
                    
                });
            }

            )

</script>
</html>
