<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MuhendisSozluk._default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title id="title" runat="server"></title>
    <link href="default.css" rel="stylesheet" />
   
</head>
<body>
    <form id="form1" runat="server" class="form1">
      
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
            <div class="search_title"> 
            <asp:TextBox ID="txt_default_title_search" runat="server" BorderStyle="None" Width="80%" BackColor="Gray" Height="20px"></asp:TextBox> 
            <asp:Button ID="btn_default_title_search" runat="server" Width="18%" Height="20px" Text="ara" BackColor="#333333" BorderStyle="None" ForeColor="White"/>
           <%-- <asp:Button ID="updateSolKanat" runat="server" OnClick="updateLastTitles" Height="20px" Width="305px" BackColor="#777755" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" />--%>
        </div> 
            <asp:Repeater ID="title_repeater" runat="server" >
                <ItemTemplate>
                    <div style="width:100%; height:30px; border-bottom:1px dashed gray; float:left; background-color:#777777">
                        <asp:LinkButton ID="btn_left_title" Font-Underline="false" OnClick="btn_left_title_Click" CssClass="btn_left_title" runat="server" Width="100%"  ForeColor="White" Text='<% #Eval("Name") %>'></asp:LinkButton>
                            <%--<asp:Label ID="lbl_title_entry_today" runat="server" Width="19%" ForeColor="#d9d9d9" Text='<% #Eval("Today") %>'></asp:Label> --%>
                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>   
<%--<asp:ListBox ID = "listSolKanat" runat="server" AutoPostBack="True" OnSelectedIndexChanged="listSolKanat_SelectedIndexChanged" Height="599px" Width="100%" BackColor="#ffd9b3" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" SelectionMode="Single">
</asp:ListBox>--%>

           <%-- <asp:ListBox ID="ListSolKanat" CssClass="ListSolKanat" runat="server" Height="599px" Width="100%" BackColor="#ffd9b3" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" SelectionMode="Single"  OnSelectedIndexChanged="ListSolKanat_OnSelectedItemChanged"  ></asp:ListBox>--%>

        </div>
            <div class=" entries">
                <div class="title_name" style="width:100%; height:30px; float:left; text-align:center; line-height:30px;">
                    <asp:Label ID="lbl_default_title_name" runat="server" Font-Bold="true" Text="başlık"></asp:Label>
                </div>

                 <asp:Repeater ID="entry_repeater" runat="server">
            <ItemTemplate>
        <div class="cover" style="width:100%; float:right;  margin-top:20px; background-color:#d9d9d9">
            <div class="entry" style="width:100%; height:auto; padding:5px">
                <p id="lbl_rpt_entry_content" runat="server"><%#Eval("Contents")%> </p>
              
            </div>
            <div class="stats" style="width:100%; height:20px; margin-bottom:5px; margin-top:20px;">
                <asp:Button ID="entry_like" runat="server" Width="5%" Height="100%" ForeColor="Green" BackColor="Transparent" Text="+" Font-Size="Large" BorderStyle="None" Font-Bold="true"/>
                 <asp:Button ID="entry_dislike" runat="server" Width="5%" Height="100%" ForeColor="Red" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text="-" Font-Bold="true"/>
                 <asp:Button ID="entry_fav" runat="server" Width="5%" Height="100%" ForeColor="Blue" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text="#" Font-Bold="true"/>
                 <asp:Label ID="entry_rating" runat="server"  Width="15%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("Rating") %>'/>
                 <asp:Label ID="entry_date" runat="server" Width="24%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("Date") %>'/>
                 <asp:Label ID="entry_writer" runat="server" Width="34%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("WriterName") %>' />
                 <asp:Button ID="entry_complain" runat="server" Width="6%" Height="100%" ForeColor="Orange" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text="!?" Font-Bold="true"/>
            </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>
                
                <asp:TextBox Class="txt_write_entry" ID="txt_write_entry" runat="server" MaxLength="100" TextMode="MultiLine" placeholder="entry girebilmek için giriş yapınız." Width="99%" ></asp:TextBox>
                <div class="entry_send_button">
                    <asp:Button ID="btn_entry_send" runat="server" BorderStyle="None" Text="gönder" Width="100px" Height="100%" BackColor="#ffffe6" OnClick="btn_entry_send_Click"/>
                    <asp:Label ID="lbl_entrysend_status" runat="server"></asp:Label>
                </div>
        </div>
    </form>
</body>
</html>

