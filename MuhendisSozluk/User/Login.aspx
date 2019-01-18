<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MuhendisSozluk.User.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Login.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
          <div class="top">
            <div class="logo">
                 </div>
            
            <div class="search">

            </div>
            <div class="profile">
                <div class="buttons">
           
               <asp:Button ID="btn_default_profile" runat="server" BorderStyle="None" BackColor="#ffffe6" Width="49%" Height="100%" Font-Size="Large" Text="kayıt ol" OnClick="btn_default_profile_Click" />
                        <asp:Button ID="btn_default_loginout" runat="server"  BorderStyle="None" BackColor="#ffffe6" Width="49%" Height="100%" Font-Size="Large" Text="giriş yap" OnClick="btn_default_loginout_Click" /> 
                

                </div>
                <div class="department_info"></div>
                <div class="rating_info"></div>
            </div>
       

          </div>
                <div class="categories">

        
              </div>
        <div class="solkanat">
           <%-- <asp:Button ID="updateSolKanat" runat="server" OnClick="updateLastTitles" Height="20px" Width="305px" BackColor="#777755" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" />--%>

            <asp:ListBox ID="ListSolKanat" CssClass="ListSolKanat" runat="server" Height="599px" Width="100%" BackColor="#ffd9b3" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" SelectionMode="Single" ></asp:ListBox>

        </div>
        
       <div class="login">
            <div class="login_mail">
                <asp:Label ID="lbl_login_mail" runat="server" Text="e-mail  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_login_mail" runat="server" Width="250px"  BackColor="#ffffe6"></asp:TextBox>
               
            </div>
            <div class="login_password">
                <asp:Label ID="lbl_login_password" runat="server" Text="parola  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_login_password" runat="server" Width="250px"  BackColor="#ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="login_enter">
                <asp:Button ID="btn_login_enter" runat="server" Text="giriş" Width="250px" BackColor="#ffd9b3" Height="60px" Font-Size="Larger" OnClick="btn_login_enter_Click" />
            </div>
            <div class="login_issue">
                <asp:Button Class="btn_login_issue" ID="btn_login_issue" BorderStyle="None" BackColor="#fff0e6" runat="server" Text="şifremi unuttum" Width="250px" Height="30px"  />
            </div>,
           <div class="login_error">
               <asp:Label ID="lbl_login_error" BackColor="#ffd9b3" runat="server" Text=""></asp:Label>
           </div>
        </div>
        
    </form>
</body>
</html>
