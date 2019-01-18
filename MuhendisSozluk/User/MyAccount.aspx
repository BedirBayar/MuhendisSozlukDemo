<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="MuhendisSozluk.User.MyAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="MyAccount.css" rel="stylesheet" />
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
           
               <asp:Button ID="btn_default_profile" runat="server" BorderStyle="None" BackColor="#ffffe6" Width="49%" Height="100%" Font-Size="Large" Text="Kayıt Ol" OnClick="btn_default_profile_Click" />
                        <asp:Button ID="btn_default_loginout" runat="server"  BorderStyle="None" BackColor="#ffffe6" Width="49%" Height="100%" Font-Size="Large" Text="Giriş Yap" OnClick="btn_default_loginout_Click" /> 
                

                </div>
                <div class="department_info"></div>
                <div class="rating_info"></div>
            </div>
       

          </div>
                <div class="categories">

        
              </div>
        <div class="solkanat">
           <%-- <asp:Button ID="updateSolKanat" runat="server" OnClick="updateLastTitles" Height="20px" Width="305px" BackColor="#777755" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" />--%>
             <asp:Repeater ID="title_repeater" runat="server" >
                <ItemTemplate>
                    <div style="width:100%; height:30px; border-bottom:1px dashed gray; float:left; background-color:#777777">
                        <asp:LinkButton ID="btn_left_title" Font-Underline="false" OnClick="btn_left_title_Click" CssClass="btn_left_title" runat="server" Width="100%"  ForeColor="White" Text='<% #Eval("Name") %>'></asp:LinkButton>
                            <%--<asp:Label ID="lbl_title_entry_today" runat="server" Width="19%" ForeColor="#d9d9d9" Text='<% #Eval("Today") %>'></asp:Label> --%>
                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>  

           <%-- <asp:ListBox ID="ListSolKanat" CssClass="ListSolKanat" runat="server" Height="599px" Width="100%" BackColor="#ffd9b3" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" SelectionMode="Single" ></asp:ListBox>--%>

        </div>
        <div class="myaccount">
           <div class="fixedinfo">
               <asp:Label ID="lbl_myaccount_username" runat="server" Text="kullanıcı adı" Width="250px"></asp:Label><asp:Label ID="lbl_myaccount_username_data" runat="server" Width="250px" ForeColor="#009933" Font-Size="Large" Text="kullanıcı adı"  ></asp:Label>

           </div>
            <div class="fixedinfo">
               <asp:Label ID="lbl_myaccount_department" runat="server" Width="250px" Text="bölüm"></asp:Label><asp:Label ID="lbl_myaccount_department_data" runat="server" Width="250px" Font-Overline="false" ForeColor="#009933" Text="bölüm"></asp:Label>
               </div>
           
            <div class="fixedinfo">
                <asp:Label ID="lbl_myaccount_mail" runat="server" Text="e-mail  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_myaccount_mail" runat="server" Width="250px"  ForeColor="#009933" BackColor="#ffffe6" ></asp:TextBox>
            </div>
            <div class="fixedinfo">
                <asp:Label ID="lbl_myaccount_password" runat="server" Text="parola  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_myaccount_password" runat="server" Width="250px"  BackColor=" #ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="fixedinfo">
                <asp:Label ID="lbl_myaccount_newpassword" runat="server" Text="yeni parola (isteğe bağlı) :  " Width="250px" Height="75px" Font-Size="Large"></asp:Label> 

                <asp:TextBox ID="txt_myaccount_newpassword" runat="server" Width="250px"  BackColor="#ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="fixedinfo">
                <asp:Label ID="lbl_myaccount_confirmpassword" runat="server" Text="yeni parola tekrar  :  " Width="250px" Font-Size="Large"></asp:Label> 
                <asp:TextBox ID="txt_myaccount_confirmpassword" runat="server" Width="250px"  BackColor="#ffffe6" TextMode="Password"></asp:TextBox>
            </div>
            <div class="fixedinfo">
                <asp:Label ID="lbl_myaccount_gender_lady" runat="server" Text="kadın  :  " Width="250px" Font-Size="Large" Height="75px"></asp:Label> <asp:CheckBox ID="check_myaccount_lady" runat="server" Width="50px" Height="50px"/>
                <asp:Label ID="lbl_myaccount_gender_gentleman" runat="server" Text="erkek  :  " Width="250px" Font-Size="Large"></asp:Label> <asp:CheckBox ID="check_myaccount_gentleman" runat="server" Width="50px" Height="50px"/>
            </div>
            <div class="fixedinfo">
                <asp:Button Class="btn_myaccount_enter" ID="btn_myaccount_enter" runat="server" Width="100px" Height="90%" Font-Size="Large" Text="güncelle" BorderStyle="None" OnClick="btn_myaccount_enter_Click" />
            </div>
            <div class="fixedinfo">
                <asp:Label ID="lbl_myaccount_savestate" runat="server" ForeColor="White"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
