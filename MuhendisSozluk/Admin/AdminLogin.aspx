<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="MuhendisSozluk.Admin.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Mühendis Sözlük Moderatör Girişi</h2>
        <div class="layer1" style="width:100%; height:250px; float:left; text-align:center; margin-top:200px;">
             <div class="login_mail" style="height:50px;">
                <asp:Label ID="lbl_admlogin_mail" runat="server" Text="e-mail  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_admlogin_mail" runat="server" Width="250px"  BackColor="#ffffe6"></asp:TextBox>
               
            </div>
            <div class="login_password" style="height:50px;">
                <asp:Label ID="lbl_admlogin_password" runat="server" Text="parola  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_admlogin_password" runat="server" Width="250px"  BackColor="#ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="login_enter" style="height:50px;">
                <asp:Button ID="btn_admlogin_enter" runat="server" Text="giriş" Width="250px" BackColor="#ffd9b3" Height="60px" Font-Size="Larger" OnClick="btn_admlogin_enter_Click" />
            </div>
            <div class="login_issue" style="height:50px;">
                <asp:Button Class="btn_admlogin_issue" ID="btn_login_issue" BorderStyle="None" BackColor="#fff0e6" runat="server" Text="şifremi unuttum" Width="250px" Height="30px"  />
            </div>,
           <div class="login_error" style="height:50px;">
               <asp:Label ID="lbl_admlogin_error" BackColor="#ffd9b3" runat="server" Text=""></asp:Label>
           </div>
        </div>
    </form>
</body>
</html>
