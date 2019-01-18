<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Titles.aspx.cs" Inherits="MuhendisSozluk.Admin.Titles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="MenuItems.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="top" style="background-color:#ff8e8e">
                <div class="top_logo">
                    <h2>logo</h2>
            </div>
                <div class="top_search">
                    
                </div>
                <div class="top_profile">
                    <h2>profile</h2>
                    </div>
                </div>
                       <div class="list">
                           <div class="all">
                        <asp:ListBox ID="all_titles_listbox" runat="server" Width="100%" Height="1000px" AutoPostBack="true" OnSelectedIndexChanged="all_titles_listbox_SelectedIndexChanged"></asp:ListBox>
                    </div>
                           
                    <div class="operation">
                        <div class="operation_field">
                            
                        <asp:Label ID="lbl_title_name" runat="server" Text="başlık adı     "></asp:Label>    <asp:TextBox ID="txt_titles_name" BorderStyle="None" BackColor="#bbbbbb" runat="server" ForeColor="White" Width="200px" ></asp:TextBox> <br />
                       </div>
                         <div class="operation_field">
                         <asp:Label ID="Label5" runat="server" Text="bağlı olduğu oda    : "></asp:Label>   <asp:TextBox ID="txt_titles_room" BorderStyle="None" BackColor="#bbbbbb" runat="server" ForeColor="White" Width="200px"></asp:TextBox> <br />
                            </div>
                        <div class="operation_field">
                         <asp:Label ID="Label2" runat="server" Text="entry sayısı    : "></asp:Label>   <asp:Label ID="lbl_titles_entrycount" runat="server" ForeColor="White"></asp:Label> <br />
                            </div>
                 
                        <div class="operation_field">
                         <asp:Label ID="Label6" runat="server" Text="takipçi sayısı     "></asp:Label>  <asp:Label ID="lbl_titles_followers" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label1" runat="server" Text="son güncelleme     "></asp:Label>  <asp:Label ID="lbl_titles_lastupdate" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label3" runat="server" Text="açılma tarihi     "></asp:Label>  <asp:Label ID="lbl_titles_started" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label4" runat="server" Text="faydalı     "></asp:Label>  <asp:Label ID="lbl_titles_useful" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label7" runat="server" Text="faydasız     "></asp:Label>  <asp:Label ID="lbl_titles_useless" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                         <div class="operation_field">
                         <asp:Label ID="Label8" runat="server" Text="görünür     "></asp:Label>  <asp:Label ID="lbl_titles_visible" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label10" runat="server" Text="aktif     "></asp:Label>  <asp:Label ID="lbl_titles_isactive" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>

                       <div class="operation_field">
                           <asp:Button ID="btn_stop_title" Width="49%" Height="50px" runat="server" BackColor="#ffcccc" Text="inaktif / aktif" OnClick="btn_stop_title_Click"  />
                               <asp:Button ID="btn_hide_title" runat="server" Width="50%" Height="50px" BackColor="#ffaaaa" Text="görünmez / görünür" OnClick="btn_hide_title_Click" />
                               <asp:Button ID="btn_room_save" Width="100%" Height="50px" runat="server" BackColor="#ccffcc" Text="böyle kaydet" OnClick="btn_room_save_Click" /><br />
                           <asp:Label ID="lbl_titles_save_status" runat="server" Height="40px"></asp:Label>
                    </div>
                          
                          </div>
                           </div>
        </div>
    </form>
</body>
</html>
