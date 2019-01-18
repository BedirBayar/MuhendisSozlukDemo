<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entries.aspx.cs" Inherits="MuhendisSozluk.Admin.Entries" %>

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
                        <asp:ListBox ID="all_entries_listbox" runat="server" Width="100%" Height="1000px" AutoPostBack="true" OnSelectedIndexChanged="all_entries_listbox_SelectedIndexChanged" ></asp:ListBox>
                    </div>
                           
                    <div class="operation">
                        <div class="operation_field">
                            
                        <asp:Label ID="lbl_title_name" runat="server" Text="entry no     "></asp:Label>    <asp:Label ID="lbl_entry_number" BorderStyle="None" runat="server" ForeColor="White" Width="200px" ></asp:Label> <br />
                       </div>
                         <div class="operation_field">
                         <asp:Label ID="Label5" runat="server" Text="içerik   : "></asp:Label>   <asp:TextBox ID="txt_entry_contents" BorderStyle="None" BackColor="#bbbbbb" runat="server" ForeColor="White" Width="200px"></asp:TextBox> <br />
                            </div>
                        <div class="operation_field">
                         <asp:Label ID="Label3" runat="server" Text="tarih     "></asp:Label>  <asp:Label ID="lbl_entry_date" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label2" runat="server" Text="like    : "></asp:Label>   <asp:Label ID="lbl_entry_like" runat="server" ForeColor="White"></asp:Label> <br />
                            </div>
                 
                        <div class="operation_field">
                         <asp:Label ID="Label6" runat="server" Text="dislike     "></asp:Label>  <asp:Label ID="lbl_entry_dislike" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label1" runat="server" Text="favori     "></asp:Label>  <asp:Label ID="lbl_entry_fav" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label4" runat="server" Text="rating     "></asp:Label>  <asp:Label ID="lbl_entry_rating" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                         <div class="operation_field">
                         <asp:Label ID="Label8" runat="server" Text="görünür     "></asp:Label>  <asp:Label ID="lbl_entry_visible" runat="server" ForeColor="White"></asp:Label>  <br />
                        </div>
                       <div class="operation_field">
                           <asp:Button ID="btn_entry_delete" Width="49%" Height="50px" runat="server" BackColor="#ffcccc" Text="imha et" OnClick="btn_entry_delete_Click"  />
                               <asp:Button ID="btn_entry_hide" runat="server" Width="50%" Height="50px" BackColor="#ffaaaa" Text="görünmez / görünür" OnClick="btn_entry_hide_Click"  />
                               <asp:Button ID="btn_entry_save" Width="100%" Height="50px" runat="server" BackColor="#ccffcc" Text="böyle kaydet" OnClick="btn_entry_save_Click"  /><br />
                           <asp:Label ID="lbl_entry_save_status" runat="server" Height="40px"></asp:Label>
                    </div>
                          
                          </div>
                           </div>
        </div>
    </form>
</body>
</html>
