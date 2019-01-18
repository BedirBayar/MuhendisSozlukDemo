<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MuhendisSozluk.Admin.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Home.css" rel="stylesheet" />
    <style>
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainbody">
            <div class="top">
                <div class="top_logo">
                    <h2>logo</h2>
            </div>
                <div class="top_search">
                    <asp:TextBox ID="txt_admin_search" runat="server" placeholder="başlık, #entry ya da @yazar" Style="width:250px; height:28px; border:0px; margin-right:5px; padding-left:3px; padding-right:3px;" OnTextChanged="txt_admin_search_TextChanged"></asp:TextBox>
                    <asp:Button ID="btn_admin_search" runat="server" Text="ara" Font-Size="Large" ForeColor="White" BackColor="#886666" BorderStyle="None" Width="50px" Height="30px" Style="border: 1px solid white" OnClick="btn_admin_search_Click"></asp:Button>

                </div>
                <div class="top_profile">
                    <asp:Button ID="btn_profile_name" runat="server" Width="100%" Height="100%" Font-Overline="false" BorderStyle="None" BackColor="Gray" ForeColor="White" OnClick="btn_profile_name_Click"></asp:Button>
                </div>
                </div>
            <div class="menu">
                <div class="inner_menu">
                    <asp:Button CssClass="menu_button" ID="btn_adm_menu_users" runat="server" class="btn_adm_menu" BackColor="#f45050" Font-Size="Large" Text="Kullanıcılar" OnClick="btn_adm_menu_users_Click" />
                    <asp:Button CssClass="menu_button" ID="btn_adm_menu_dep" runat="server" class="btn_adm_menu" BackColor="#93baf9" Font-Size="Large" Text="Odalar" OnClick="btn_adm_menu_dep_Click" />
                    <asp:Button CssClass="menu_button" ID="btn_adm_menu_titles" runat="server" class="btn_adm_menu" BackColor="#ff9c23" Font-Size="Large" Text="Başlıklar" OnClick="btn_adm_menu_titles_Click" />
                    <asp:Button CssClass="menu_button" ID="btn_adm_menu_entries" runat="server" class="btn_adm_menu" BackColor="#22ff89" Font-Size="Large" Text="Entryler" OnClick="btn_adm_menu_entries_Click" />
                    <asp:Button CssClass="menu_button" ID="btn_adm_menu_reported" runat="server" class="btn_adm_menu" BackColor="#c54efc" Font-Size="Large" Text="Şikayetler" />
                </div>
                <div class="search_result"> 
                    <asp:Label ID="Label1" runat="server" text="yazarı :"></asp:Label><asp:Label ID="lbl_search_entry_writer" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label2" runat="server" text="numarası :"></asp:Label><asp:Label ID="lbl_search_entry_number" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label11" runat="server" text="like :"></asp:Label><asp:Label ID="lbl_search_entry_like" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label13" runat="server" text="dislike :"></asp:Label><asp:Label ID="lbl_search_entry_dislike" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label15" runat="server" text="fav :"></asp:Label><asp:Label ID="lbl_search_entry_fav" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label12" runat="server" text="başarı :"></asp:Label><asp:Label ID="lbl_search_entry_rating" runat="server" ForeColor="White"></asp:Label> <br />
                     <asp:Label ID="Label14" runat="server" text="başlık :"></asp:Label><asp:Label ID="lbl_search_entry_title" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:TextBox ID="txt_search_entry_contents" Width="95%" runat="server" TextMode="MultiLine"></asp:TextBox>
                     <asp:Label ID="Label17" runat="server" text="tarih :"></asp:Label><asp:Label ID="lbl_search_entry_date" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Button ID="btn_home_entry_save" runat="server" Width="120px" Height="40px" Text="kaydet" BorderStyle="None" CssClass="home_save_buttons" OnClick="btn_home_entry_save_Click" />
                    <asp:Button ID="btn_home_entry_delete" runat="server" Width="120px" Height="40px" Text="imha et" BackColor="#888888" BorderStyle="None" CssClass="home_save_buttons" OnClick="btn_home_entry_delete_Click" /><br />
                     <asp:Button ID="btn_home_entry_hide" runat="server" Width="240px" Height="40px" Text="gizle" BorderStyle="None" BackColor="#aa8888" OnClick="btn_home_entry_hide_Click"/>
                    <asp:Label ID="lbl_search_entry_save_status" runat="server" Height="40px" ForeColor="White"></asp:Label>

                </div>
                <div class="search_result">  
                    <asp:Label ID="Label5" runat="server" text="başlık adı :"></asp:Label><asp:TextBox ID="txt_search_title_name" runat="server" BorderStyle="None" BackColor="#999999" ForeColor="White"></asp:TextBox> <br />
                   <asp:Label ID="Label3" runat="server" text="başlığı açan :"></asp:Label><asp:Label ID="lbl_search_title_writer" runat="server" ForeColor="White"></asp:Label> <br />
                   
                    <asp:Label ID="Label22" runat="server" text="oda :"></asp:Label><asp:DropDownList ID="ddl_search_title_department" runat="server" BorderStyle="None" BackColor="#999999" Width="180px" ForeColor="White"></asp:DropDownList> <br />
                    <asp:Label ID="Label16" runat="server" text="faydalı :"></asp:Label><asp:Label ID="lbl_search_title_useful" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label19" runat="server" text="faydasız :"></asp:Label><asp:Label ID="lbl_search_title_useless" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label21" runat="server" text="görünür :"></asp:Label><asp:Label ID="lbl_search_title_visible" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Label ID="Label4" runat="server" text="aktif :"></asp:Label><asp:Label ID="lbl_search_title_active" runat="server" ForeColor="White"></asp:Label> <br />
          
                    <asp:Label ID="Label18" runat="server" text="tarih :"></asp:Label><asp:Label ID="lbl_search_title_date" runat="server" ForeColor="White"></asp:Label> <br />
                    <asp:Button ID="btn_home_title_save" runat="server" Width="120px" Height="40px" Text="kaydet" BorderStyle="None" CssClass="home_save_buttons" OnClick="btn_home_title_save_Click" />
                    <asp:Button ID="btn_home_title_stop" runat="server" Width="120px" Height="40px" Text="durdur" BackColor="#888888" BorderStyle="None" CssClass="home_save_buttons" OnClick="btn_home_title_stop_Click" /><br />
                     <asp:Button ID="btn_home_title_hide" runat="server" Width="240px" Height="40px" Text="gizle" BorderStyle="None" BackColor="#aa8888" OnClick="btn_home_title_hide_Click" />
                    <asp:Label ID="lbl_search_title_save_status" runat="server" Height="40px" ForeColor="White"></asp:Label>

                </div>
                <div class="search_result"> 
                        <asp:Label ID="Label6" runat="server" Text="kullanıcı adı     "></asp:Label>    <asp:TextBox ID="txt_search_writer_name" runat="server"  BorderStyle="None" BackColor="#999999" ForeColor="White"></asp:TextBox> <br />
                    <asp:Label ID="Label10" runat="server" Text="bağlı olduğu oda     "></asp:Label>    <asp:Label ID="lbl_search_writer_department" runat="server" ForeColor="White"></asp:Label><br />
                        <asp:Label ID="Label7" runat="server" Text="kıdemi     "></asp:Label>   <asp:DropDownList ID="ddl_search_writer_seniority" runat="server" Width="150px" BorderStyle="None" BackColor="#999999" ForeColor="White"></asp:DropDownList> <br />
                    <asp:Label ID="Label24" runat="server" Text="rating      "></asp:Label>    <asp:Label ID="lbl_search_writer_rating" runat="server" ForeColor="White"></asp:Label><br />
                        <asp:Label ID="Label8" runat="server" Text="parolası     "></asp:Label>    <asp:TextBox ID="txt_search_writer_password" runat="server"  BorderStyle="None" BackColor="#999999" ForeColor="White"></asp:TextBox><br />
                           <asp:Label ID="Label9" runat="server" Text="uzaklaştırma  :"> </asp:Label> <asp:Label ID="lbl_search_writer_suspend" runat="server" ForeColor="White"></asp:Label> <br />
                        
                     <asp:Label ID="Label20" runat="server" Text="takipçi sayısı     "></asp:Label>  <asp:Label ID="lbl_search_writer_followers" runat="server" ForeColor="White"></asp:Label>  <br />
                        <asp:Label ID="Label23" runat="server" Text="entry sayısı     "></asp:Label>    <asp:Label ID="lbl_search_writer_entrycount" runat="server" ForeColor="White"></asp:Label><br />
                        
                       
                               <asp:Button ID="btn_search_writer_block_3" Width="120px" Height="50px" BorderStyle="None" runat="server" BackColor="#ffcccc" Text="3 gün uzaklaştır" OnClick="btn_search_writer_block_3_Click" />
                               <asp:Button ID="btn_search_writer_block_10" runat="server" Width="120px" BorderStyle="None" Height="50px" BackColor="#ffaaaa" Text="10 gün uzaklaştır" OnClick="btn_search_writer_block_10_Click"  />
                               <asp:Button ID="btn_search_writer_block_101" runat="server" Width="120px" BorderStyle="None" Height="50px" BackColor="#ff8888" Text="101 gün uzaklaştır" OnClick="btn_search_writer_block_101_Click"/>
                               <asp:Button ID="btn_search_writer_destroy" runat="server" Width="120px" BorderStyle="None" Height="50px" BackColor="#ff6666" Text="imha et" OnClick="btn_search_writer_destroy_Click"  />
                               <asp:Button ID="btn_search_writer_save" Width="240px" Height="50px" BorderStyle="None" runat="server" BackColor="#ccffcc" Text="böyle kaydet" OnClick="btn_search_writer_save_Click" /><br />
                           <asp:Label ID="lbl_search_writer_save_status" runat="server" Height="40px" ForeColor="White"></asp:Label>
                </div>
                
            </div>
            
</div>
                   
            


          
    </form>
</body>
</html>
