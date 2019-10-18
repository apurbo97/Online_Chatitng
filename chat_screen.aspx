<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chat_screen.aspx.cs" Inherits="chat_screen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Chat</title>
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
            <th style="text-align:center; width:33%; background-color: #0066FF; font-weight:bold"><a href="chat_screen.aspx"> CHAT </a></th>
            <th style="text-align:center; width:33%; background-color: #6699FF; font-weight:bold"><a href="search_screen.aspx">SEARCH</a> </th>
        </tr>
    </table>
            
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
   <div style="height:400px; overflow:scroll;">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
            </asp:Timer>
        Chating with : <asp:Label ID="lbl_person_name" runat="server" Text="" style="text-transform:uppercase; color:Blue"></asp:Label>        
        <center>
            <asp:GridView ID="grd_data" runat="server" AutoGenerateColumns="false" GridLines="Horizontal" 
                Width="100%" EmptyDataText="No chat history" ShowHeader="False" 
                onrowcommand="grd_data_RowCommand">
                <Columns>
                    <%--<asp:ButtonField Text="X" ItemStyle-Width="30px" />--%>
                    <asp:TemplateField  ItemStyle-Width="70px">
                        <ItemTemplate>
                            <asp:Image ID="img_profile" runat="server" style="border-radus:25%" Width="60px" ImageUrl='<%# "image_view.aspx?id=" + Eval("sender") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="msg" />
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                        
                            <asp:Image ID="img_msg" runat="server" Visible="false" Width="100px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="date" ItemStyle-Width="100px" />
                </Columns>
                
            </asp:GridView>
            <asp:GridView ID="grd_hiden" runat="server" Visible="false" 
                ondatabound="grd_hiden_DataBound" onrowdatabound="grd_hiden_RowDataBound">
            </asp:GridView>
        </center>
        
        </ContentTemplate>
       
       </asp:UpdatePanel>
       
        
        
        
        </div>
<asp:TextBox ID="txt_msg_id" runat="server" Visible="false"></asp:TextBox>
        <table width="100%" >
            <tr>
                <td style="width:70%">
                    <asp:TextBox ID="txt_msg" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:FileUpload ID="FileUpload1" runat="server" visible="false"/>        
                </td>
                <td style="width:30%">
                    <asp:Button runat="server" ID="btn_send" Text="SEND" onclick="btn_send_Click"  /> 
                    <asp:Button runat="server" ID="btn_send_img" Text="SEND" Visible="false" 
                        onclick="btn_send_img_Click" />    
                    
                </td>
            </tr>
            <tr>
                <td>
                <asp:Button ID="btn_upload" runat="server" Text="Image/video" 
                        onclick="btn_upload_Click" />
                </td>
            </tr>
        </table>
        
        
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

                $("#btn_send").click(function () {
                 if (!validate("txt_msg")) {
                        return false;
                    }                
                });
            }

            )
            $(document).ready(

            function () {

                $("#btn_send_img").click(function () {
                 if (!validate("FileUpload1")) {
                        return false;
                    }                
                });
            }

            )

</script>
</html>
