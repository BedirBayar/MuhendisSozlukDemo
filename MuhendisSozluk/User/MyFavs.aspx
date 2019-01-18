<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFavs.aspx.cs" Inherits="MuhendisSozluk.User.MyFavs" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Repeater ID="favs_entry_repeater" runat="server">
            <ItemTemplate>
        <div class="cover" style="width:80%; float:left;  margin-top:20px; background-color:#d9d9d9">
            <div class="entry" style="width:100%; height:auto; padding:5px">
                <asp:Label ID="lbl_rpt_entry_title_name" runat="server" Font-Bold="true" Text='<% #Eval("TitleName") %>'></asp:Label><br />
                <asp:Label ID="lbl_rpt_entry_number" runat="server" Text='<% #Eval("ID") %>'></asp:Label><pre>  </pre>
                <asp:Label ID="txt_rpt_entry_content" runat="server" TextMode="MultiLine" Width="700px" BorderStyle="None"  Text='<% #Eval("Contents") %>'></asp:Label>
              
            </div>
            <div class="stats" style="width:100%; height:20px; margin-bottom:5px; margin-top:20px;">
                <asp:Label ID="entry_like" runat="server" Width="5%" Height="100%" ForeColor="Green" BackColor="Transparent" Text='<% #Eval("LikeCount") %>' Font-Size="Large" BorderStyle="None" Font-Bold="true"/>
                 <asp:Label ID="entry_dislike" runat="server" Width="5%" Height="100%" ForeColor="Red" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text='<% #Eval("DislCount") %>' Font-Bold="true"/>
                 <asp:Label ID="entry_fav" runat="server" Width="5%" Height="100%" ForeColor="Blue" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text='<% #Eval("FavCount") %>' Font-Bold="true"/>
                 <asp:Label ID="entry_rating" runat="server"  Width="15%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("Rating") %>'/>
                 <asp:Label ID="entry_date" runat="server" Width="24%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("Date") %>'/>
                 <asp:Label ID="entry_writer" runat="server" Width="34%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("WriterName") %>' />
                
            </div>
            <div class="buttons" style="margin-top:10px; margin-left:50px;">
                <asp:Button ID="rpt_myentries_save" runat="server" Text="favorilerden çıkar" Width="150px" Height="50px" Font-Size="Large" OnClick="rpt_myentries_save_Click" />
            </div>

        </div>
            </ItemTemplate>
        </asp:Repeater>

        </div>
    </form>
</body>
</html>
