<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Writers.aspx.cs" Inherits="MuhendisSozluk.Admin.Writers" %>

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
                        <asp:ListBox ID="all_users_listbox" runat="server" Width="100%" Height="1000px" OnSelectedIndexChanged="all_users_listbox_SelectedIndexChanged" AutoPostBack="true" ></asp:ListBox>
                    </div>
                           
                    <div class="operation">
                        <div class="operation_field">
                            
                        <asp:Label ID="Label1" runat="server" Text="kullanıcı adı     "></asp:Label>    <asp:TextBox ID="txt_op_username" runat="server" ></asp:TextBox> <br />
                       </div>
                        <div class="operation_field">
                         <asp:Label ID="Label2" runat="server" Text="kıdemi     "></asp:Label>   <asp:DropDownList ID="ddl_op_seniority" runat="server"></asp:DropDownList> <br />
                            </div>
                            <div class="operation_field">
                         <asp:Label ID="Label3" runat="server" Text="parolası     "></asp:Label>    <asp:TextBox ID="txt_op_password" runat="server"></asp:TextBox><br />
                               </div>
                        <div class="operation_field">
                            <asp:Label ID="Label9" runat="server" Text="uzaklaştırma      :"> </asp:Label> 
                            <asp:Label ID="lbl_op_suspend" runat="server">    :</asp:Label> 
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label5" runat="server" Text="bağlı olduğu oda     "></asp:Label>    <asp:TextBox ID="txt_op_department" runat="server"></asp:TextBox><br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label6" runat="server" Text="takipçi sayısı     "></asp:Label>  <asp:Label ID="lbl_op_followers" runat="server"></asp:Label>  <br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label7" runat="server" Text="entry sayısı     "></asp:Label>    <asp:Label ID="lbl_op_entrycount" runat="server"></asp:Label><br />
                        </div>
                        <div class="operation_field">
                         <asp:Label ID="Label8" runat="server" Text="rating      "></asp:Label>    <asp:TextBox ID="txt_op_rating" runat="server"></asp:TextBox><br />
                        </div>
                         <div class="operation_field"> 
                               <asp:Button ID="btn_block_3" Width="24%" Height="50px" runat="server" BackColor="#ffcccc" Text="3 gün uzaklaştır" OnClick="btn_block_3_Click" />
                               <asp:Button ID="btn_block_10" runat="server" Width="25%" Height="50px" BackColor="#ffaaaa" Text="10 gün uzaklaştır" OnClick="btn_block_10_Click" />
                               <asp:Button ID="btn_block_101" runat="server" Width="25%" Height="50px" BackColor="#ff8888" Text="101 gün uzaklaştır" OnClick="btn_block_101_Click" />
                               <asp:Button ID="btn_destroy" runat="server" Width="24%" Height="50px" BackColor="#ff6666" Text="imha et" OnClick="btn_destroy_Click" />
                               <asp:Button ID="btn_writer_save" Width="100%" Height="50px" runat="server" BackColor="#ccffcc" Text="böyle kaydet" OnClick="btn_writer_save_Click" /><br />
                           <asp:Label ID="lbl_writer_save_status" runat="server" Height="40px"></asp:Label>
                    </div>
                          
                           </div> 
                           </div>

                           
              
                
        
    </form>
</body>
</html>
