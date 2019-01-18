<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyFollowed.aspx.cs" Inherits="MuhendisSozluk.User.MyFollowed" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Repeater ID="rpt_myFollowed" runat="server">
            <ItemTemplate>
                <div style="width:100%; height:100px; background-color:aquamarine; margin:5px;">
                    <asp:Label ID="lbl_followed_name" runat="server" Text='<% #Eval("Name") %>' Font-Bold="true" Font-Names="consolas"></asp:Label>
                    <asp:Label ID="lbl_followed_seniority" runat="server" Text='<% #Eval("Rating") %>' Font-Bold="false" Font-Names="consolas"></asp:Label><br />
                    <asp:Label ID="lbl_followed_rating" runat="server" Text='<% #Eval("Rating") %>' ForeColor="" Font-Names="consolas"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
