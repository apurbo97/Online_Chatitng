<%@ Page Language="C#" AutoEventWireup="true" CodeFile="new_user.aspx.cs" Inherits="new_user" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ditails Entry Form</title>
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
               <center><img src="image/logoDark.png" width="45%" /><p>New Experience of chating</p></center>
            </td>
        </tr>
    </table>
    
</header>
<hr />
<form id="form1" runat="server">
    <asp:TextBox ID="txt_user_id" runat="server" Visible="false" placeholder="Your here"></asp:TextBox>
    <label>Name </label>
    <asp:TextBox ID="txt_name" runat="server"  placeholder="Your name here"></asp:TextBox>
	<label>Address </label>
    <asp:TextBox ID="txt_address" runat="server"   placeholder="your address here"></asp:TextBox>
    <label> City</label>
    <asp:TextBox ID="txt_city" runat="server"  placeholder="Delhi/aagra..."></asp:TextBox>
	<label> State</label>
    <asp:TextBox ID="txt_state" runat="server"  placeholder="Bihar/jharkhand..."></asp:TextBox>
	<label> Phone</label>
    <asp:TextBox ID="txt_phone" runat="server"  placeholder="only numbers"></asp:TextBox>
	<label> E-Mail</label>
    <asp:TextBox ID="txt_email" runat="server"  placeholder="name@gmail.com"></asp:TextBox>
	<label>Gender </label><br />
<asp:DropDownList ID="drp_gender" runat="server">
    <asp:ListItem>--Select--</asp:ListItem>
    <asp:ListItem>Male</asp:ListItem>
    <asp:ListItem>Female</asp:ListItem>
    <asp:ListItem>Other</asp:ListItem>
</asp:DropDownList>
<br />
	<label> Date of Birth</label>
    <asp:TextBox ID="txt_dob" runat="server"  placeholder="mm/dd/yyyy"></asp:TextBox>
	<label> Select Your photo</label>
    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
	<label>Password </label>
    <asp:TextBox ID="txt_password" runat="server"  TextMode="Password" placeholder="password"></asp:TextBox>
    <label>Confirm Password </label>
    <asp:TextBox ID="txt_conf_password" runat="server"  TextMode="Password" placeholder="password"></asp:TextBox>
    
<asp:Button ID="btn_save" runat="server" Text="Save" onclick="btn_save_Click" />
<asp:Button ID="btn_back" runat="server" Text="Back To Profile" onclick="btn_back_Click" />
</form>
</div>

</body>
<script src="jquery.js" type="text/javascript"></script>
<script type="text/javascript">
 function validate(id) {
            if ($("#" + id).val() == null || $("#" + id).val() == ""||$("#" + id).val() == "--Select--") {
     
               $("#" + id).css('border-color', 'red');
                return false;
            }
            else
                $("#" + id).css('border-color', '');
            return true;
           
        }
        $(document).ready(

            function () {

                $("#btn_save").click(function () {
                    if (!validate("txt_name")) {
                        return false;
                    }
                    if (!validate("txt_address")) {
                        return false;
                    }
                    if (!validate("txt_city")) {
                        return false;
                    }
                    if (!validate("txt_state")) {
                        return false;
                    }
                    if (!validate("txt_phone")) {
                        return false;
                    }
                    if (!validate("txt_email")) {
                        return false;
                    }
                    if (!validate("drp_gender")) {
                        return false;
                    }
                    if (!validate("txt_dob")) {
                        return false;
                    }
                    
                    if (!validate("txt_password")) {
                        return false;
                    }
                    if (!validate("txt_conf_password")) {
                        return false;
                    }
                });
            }

            )

</script>
</html>
