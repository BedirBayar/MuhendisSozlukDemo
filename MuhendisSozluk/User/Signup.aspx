<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="MuhendisSozluk.User.Signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Singnup.css" rel="stylesheet" />
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
        <div class="signup">
            <div class="signup_username">
                 <asp:Label ID="lbl_signup_name" runat="server" Text="kullanıcı adı  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_signup_name" runat="server" Width="250px"  BackColor="#ffffe6"></asp:TextBox>
            </div>
            <div class="signup_email">
                <asp:Label ID="lbl_signup_mail" runat="server" Text="e-mail  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_signup_mail" runat="server" Width="250px"  BackColor="#ffffe6"></asp:TextBox>
            </div>
            <div class="signup_password">
                <asp:Label ID="lbl_signup_password" runat="server" Text="parola  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_signup_password" runat="server" Width="250px"  BackColor="#ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="signup_confirmpassword">
                <asp:Label ID="lbl_signup_confirmpassword" runat="server" Text="parola tekrar  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_signup_confirmpassword" runat="server" Width="250px"  BackColor="#ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="signup_gender">
                <asp:Label ID="lbl_signup_gender_lady" runat="server" Text="kadın  :  " Width="250px" Font-Size="Large"></asp:Label> <asp:CheckBox ID="check_signup_gender_lady" runat="server" />
                <asp:Label ID="lbl_signup_gender_gentleman" runat="server" Text="erkek  :  " Width="250px" Font-Size="Large"></asp:Label> <asp:CheckBox ID="check_signup_gender_gentleman" runat="server" />
            </div>
            <div class="signup_department">
                <asp:Label ID="lbl_signup_department" runat="server" Text="bölüm  :  " Width="250px" Font-Size="Large"></asp:Label> 
               <%-- <asp:TextBox ID="txt_signup_department" runat="server" Width="250px"  BackColor="#aaaaaa"></asp:TextBox>--%>
                <asp:DropDownList ID="ddl_signup_department" runat="server" Width="250px"></asp:DropDownList>
            </div>
            <div class="signup_enter">
                <asp:Button Class="btn_signup_enter" ID="btn_signup_enter" runat="server" Font-Size="Large" Text="kaydol" OnClick="btn_signup_enter_Click" />
            </div>
            <div class="signup_state">
                <asp:Label ID="lbl_signup_warning" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
