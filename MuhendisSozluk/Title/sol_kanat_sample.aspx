<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sol_kanat_sample.aspx.cs" Inherits="MuhendisSozluk.Title.sol_kanat_sample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="color:#d9d9d9">
    <form id="form1" runat="server">
        <div style="width:24%; height:auto; float: left;">
            <asp:Repeater ID="title_repeater" runat="server">
                <ItemTemplate>
                    <div style="width:100%; height:30px; border-bottom:1px dashed gray; float:left; background-color:#777777">
                        <asp:Label ID="lbl_rpt_title_name" runat="server"  Width="100%"  ForeColor="White" Text='<% #Eval("Name") %>'></asp:Label>
                            <%--<asp:Label ID="lbl_title_entry_today" runat="server" Width="19%" ForeColor="#d9d9d9" Text='<% #Eval("Today") %>'></asp:Label> --%>
                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
