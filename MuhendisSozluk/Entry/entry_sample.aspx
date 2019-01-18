<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="entry_sample.aspx.cs" Inherits="MuhendisSozluk.Entry.entry_sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-color:#eeeeee">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_title_name" runat="server" Text="sözlük">

            </asp:Label>
        <asp:Repeater ID="entry_repeater" runat="server">
            <ItemTemplate>
        <div class="cover" style="width:75%; float:right;  margin-top:20px; background-color:#d9d9d9">
            <div class="entry" style="width:100%; height:auto; padding:5px">
                <asp:Label ID="lbl_rpt_entry_content" runat="server" Text='<% #Eval("Contents") %>'></asp:Label>
              
            </div>
            <div class="stats" style="width:100%; height:20px; margin-bottom:5px; margin-top:20px;">
                <asp:Button ID="entry_like" runat="server" Width="5%" Height="100%" ForeColor="Green" BackColor="Transparent" Text="+" Font-Size="Large" BorderStyle="None" Font-Bold="true"/>
                 <asp:Button ID="entry_dislike" runat="server" Width="5%" Height="100%" ForeColor="Red" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text="-" Font-Bold="true"/>
                 <asp:Button ID="entry_fav" runat="server" Width="5%" Height="100%" ForeColor="Blue" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text="#" Font-Bold="true"/>
                 <asp:Label ID="entry_rating" runat="server"  Width="24%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("Rating") %>'/>
                 <asp:Label ID="entry_date" runat="server" Width="15%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("Date") %>'/>
                 <asp:Label ID="entry_writer" runat="server" Width="24%" Height="100%" ForeColor="Gray" BackColor="Transparent" BorderStyle="None" Text='<% #Eval("WriterName") %>' />
                 <asp:Button ID="entry_complain" runat="server" Width="6%" Height="100%" ForeColor="Yellow" BackColor="Transparent" Font-Size="Large" BorderStyle="None" Text="!?" Font-Bold="true"/>
            </div>
        </div>
            </ItemTemplate>
        </asp:Repeater>
        <%--<asp:SqlDataSource ID="entry_data_source" runat="server" 
            ConnectionString="data source = DESKTOP-PIRF3HI\SQLEXPRESS; Database = SozlukDB; Integrated Security = True; "
            SelectCommand="SELECT * FROM ENTRY">

        </asp:SqlDataSource>--%>

        </div>
    </form>
</body>
</html>
