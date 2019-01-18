<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rooms.aspx.cs" Inherits="MuhendisSozluk.Admin.Rooms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="MenuItems.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
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
                        <asp:ListBox ID="all_rooms_listbox" runat="server" Width="100%" Height="1000px" OnSelectedIndexChanged="all_rooms_listbox_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
                    </div>
                           
                    <div class="operation">
                        
                        <div class="operation_field">
                            
                        <asp:Label ID="lbl_room_name" runat="server" Text="oda adı     "></asp:Label>    <asp:TextBox ID="txt_op_roomname" runat="server" ></asp:TextBox> <br />
                       </div>
                        <div class="operation_field">
                         <asp:Label ID="Label2" runat="server" Text="nüfusu    : "></asp:Label>   <asp:Label ID="lbl_op_population" runat="server"></asp:Label> <br />
                            </div>
                            <div class="operation_field">
                         <asp:Label ID="Label3" runat="server" Text="başkanı     :"></asp:Label>    <asp:TextBox ID="txt_op_leader" runat="server"></asp:TextBox><br />
                               </div>
                        <div class="operation_field">
                            <asp:Label ID="Label9" runat="server" Text="başlık sayısı      :">     </asp:Label> 
                            <asp:Label ID="lbl_op_no_of_headers" runat="server"></asp:Label> 
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label5" runat="server" Text="entry sayısı    "></asp:Label>    <asp:Label ID="lbl_op_no_of_entries" runat="server"></asp:Label><br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label6" runat="server" Text="takipçi sayısı     "></asp:Label>  <asp:Label ID="lbl_op_followers" runat="server"></asp:Label>  <br />
                        </div>
                       <div class="operation_field">
                               <asp:Button ID="btn_room_save" Width="100%" Height="50px" runat="server" BackColor="#ccffcc" Text="böyle kaydet" /><br />
                           
                        </div>
                        <div class="operation_field">
                            <asp:Label ID="lbl_writer_save_status" runat="server" Height="40px"></asp:Label>
                        </div>
                          </div>
                           <div class="operation">
                                <div class="operation_field">
                               <asp:Label ID="Label1" runat="server" Text="oda adı     "></asp:Label>    <asp:TextBox ID="txt_op_newroom_name" runat="server" ></asp:TextBox> <br />
                       </div>
                            <div class="operation_field">
                         <asp:Label ID="Label8" runat="server" Text="başkanı     :"></asp:Label>    <asp:DropDownList ID="ddl_op_newroom_head" runat="server" Height="16px" Width="131px"></asp:DropDownList><br />
                               </div>
                       
                       <div class="operation_field">
                               <asp:Button ID="btn_newroom_save" Width="100%" Height="50px" runat="server" BackColor="#ccccff" Text="oda oluştur" OnClick="btn_newroom_save_Click"  /><br />
                           <asp:Label ID="lbl_newroom_save_status" runat="server" Height="40px"></asp:Label>
                        </div>
                   </div>
                </div>
    </form>
</body>
</html>
