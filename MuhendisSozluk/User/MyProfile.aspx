<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="MuhendisSozluk.User.MyProfile" %>

<!DOCTYPE HTML Frameset DTD>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="MyProfile.css" rel="stylesheet" />
    <script type="text/javascript">
        var currentbutton;
        function getVisibility(y) {
             if (y == 1) {
                 document.getElementById("entry_frame").style.visibility = "visible";
            document.getElementById("favs_frame").style.visibility = "hidden";
            document.getElementById("fol_frame").style.visibility = "hidden";
                 document.getElementById("suspend_frame").style.visibility = "hidden";

                    document.getElementById("entry_frame").style.height = "100%";
            document.getElementById("favs_frame").style.height = "0%";
            document.getElementById("fol_frame").style.height = "0%";
                 document.getElementById("suspend_frame").style.height = "0%";
                 return false;
            }
            else if(y == 2) {
                 document.getElementById("entry_frame").style.visibility ="hidden";
            document.getElementById("favs_frame").style.visibility = "visible";
            document.getElementById("fol_frame").style.visibility = "hidden";
                 document.getElementById("suspend_frame").style.visibility = "hidden";

                     document.getElementById("entry_frame").style.height = "0%";
            document.getElementById("favs_frame").style.height = "100%";
            document.getElementById("fol_frame").style.height = "0%";
                 document.getElementById("suspend_frame").style.height = "0%";
                 return false;
            }
             else if(y == 3) {
            document.getElementById("entry_frame").style.visibility = "hidden";
            document.getElementById("favs_frame").style.visibility = "hidden";
            document.getElementById("fol_frame").style.visibility = "visible";
                 document.getElementById("suspend_frame").style.visibility = "hidden";

                     document.getElementById("entry_frame").style.height = "0%";
            document.getElementById("favs_frame").style.height = "0%";
            document.getElementById("fol_frame").style.height = "100%";
                 document.getElementById("suspend_frame").style.height = "0%";

                 return false;
             }
                 else if(y== 4) {
            document.getElementById("entry_frame").style.visibility = "hidden";
            document.getElementById("favs_frame").style.visibility = "hidden";
            document.getElementById("fol_frame").style.visibility = "hidden";
                 document.getElementById("suspend_frame").style.visibility = "visible";

                     document.getElementById("entry_frame").style.height = "0%";
            document.getElementById("favs_frame").style.height = "0%";
            document.getElementById("fol_frame").style.height = "0%";
                 document.getElementById("suspend_frame").style.height = "10%";
                 return false;
            }
             else{
                    
                 getVisibility(1)
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" method="get">
        <div class="top">
            <div class="logo">
                 </div>
            
            <div class="search">

            </div>
            <div class="profile">
                <div class="buttons">
           
               <asp:Button ID="btn_default_profile" runat="server" BorderStyle="None" BackColor="#ffffe6" Width="49%" Height="100%" Font-Size="Large" Text="kayıt ol" OnClick="btn_default_profile_Click" />
                        <asp:Button ID="btn_default_loginout" runat="server"  BorderStyle="None" BackColor="#ffffe6" Width="49%" Height="100%" Font-Size="Large" Text="giriş yap" OnClick="btn_default_loginout_Click" /> 
                

                </div>
                <div class="department_info"></div>
                <div class="rating_info"></div>
            </div>
       

          </div>
                <div class="categories">

        
              </div>
        <div class="solkanat">
           <%-- <asp:Button ID="updateSolKanat" runat="server" OnClick="updateLastTitles" Height="20px" Width="305px" BackColor="#777755" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" />--%>
             <asp:Repeater ID="title_repeater" runat="server" >
                <ItemTemplate>
                    <div style="width:100%; height:30px; border-bottom:1px dashed gray; float:left; background-color:#777777">
                        <asp:LinkButton ID="btn_left_title" Font-Underline="false" OnClick="btn_left_title_Click" CssClass="btn_left_title" runat="server" Width="100%"  ForeColor="White" Text='<% #Eval("Name") %>'></asp:LinkButton>
                            <%--<asp:Label ID="lbl_title_entry_today" runat="server" Width="19%" ForeColor="#d9d9d9" Text='<% #Eval("Today") %>'></asp:Label> --%>
                        
                    </div>
                </ItemTemplate>
            </asp:Repeater>  
          <%--  <asp:ListBox ID="ListSolKanat" CssClass="ListSolKanat" runat="server" Height="599px" Width="100%" BackColor="#ffd9b3" ForeColor="#333333" Font-Size="Large" Font-Names="Consolas" SelectionMode="Single" ></asp:ListBox>--%>

        </div>
        <div class="myprofile">
            <div class="myprofile_buttons">
                
               <div class="b1"> <input type="button" style="background-color:#dcefed; border-style:none; width:100%; height:50px; font-size:large" runat="server" value="entrylerim" onclick="getVisibility(1)"/></div>
                <div class="b1"> <input type="button" style="background-color:#ffa987; border-style:none; width:100%; height:50px; font-size:large" runat="server" value="favorilerim" onclick="getVisibility(2)"/></div>
                <div class="b1"> <input type="button" style="background-color:#ffeb87; border-style:none; width:100%; height:50px; font-size:large" runat="server" value="takip ettiklerim" onclick="getVisibility(3)"/></div>
                <div class="b1"> <input type="button" style="background-color:#ff5050; border-style:none; width:100%; height:50px; font-size:large" runat="server" value="engellediklerim" onclick="getVisibility(4)"/></div>
                <%--<div class="b2"><asp:Button ID="myfavs" runat="server" BackColor="#ffa987" BorderStyle="None" Text="favorilerim" Width="100%" Height="50px" Font-Size="Large" OnClientClick="getVisibility(2)"/></div>
                <div class="b3"><asp:Button ID="myfollowed" runat="server" BackColor="#ffeb87" BorderStyle="None" Text="takip ettiklerim" Width="100%" Height="50px" Font-Size="Large" OnClientClick="getVisibility(3)"/></div>
                <div class="b4"><asp:Button ID="mysuspended" runat="server" BackColor="#ff5050" BorderStyle="None" Text="engellediklerim" Width="100%" Height="50px" Font-Size="Large"  OnClientClick="getVisibility(4)"/></div>--%>
                <div class="b5"><asp:Button ID="myaccount" runat="server" BackColor="#bfaac1" BorderStyle="None" Text="hesabım" Width="100%" Height="50px" Font-Size="Large" OnClick="myaccount_Click"/></div>
            
            </div>
            <div class="content">
               <iframe id="entry_frame" style="width:100%; height:100%;" src="/User/MyEntries.aspx">

               </iframe>
                <iframe id="favs_frame"  style="width:100%; height:100%;" src="/User/MyFavs.aspx">

               </iframe>
                <iframe id="fol_frame"  style="width:100%; height:100%;" src="/User/MyFollowed.aspx">

               </iframe>
                <iframe id="suspend_frame" style="width:100%; height:100%;" src="/User/MySuspend.aspx">

               </iframe>
                

               <%-- <div class="myentries_edit">
                <asp:TextBox ID="myentries_editbox" runat="server" Width="100%" TextMode="MultiLine" Visible="true"></asp:TextBox>
                    <asp:Label ID="lbl_myentries_updatestate" runat="server" Color="green" BackColor="#eeffe6"></asp:Label>
                    <asp:Button ID="btn_myentries_edit" runat="server" Text="güncelle" Font-Size="Large" Width="150px" Height="50px" BackColor="#eeffe6" BorderStyle="None" OnClick="btn_myentries_edit_Click"/>
                    <asp:Button ID="btn_myentries_delete" runat="server" Text="sil" Font-Size="Large" Width="150px" Height="50px"  BackColor="#ffeee6" BorderStyle="None" OnClick="btn_myentries_delete_Click"/>
                </div> 
                <asp:ListBox ID="myaccount_bulletedlist" Class="myentries_list" runat="server" SelectionMode="Single" AutoPostBack="true"  Width="100%" BackColor="#ffffe6" Visible="true" OnSelectedIndexChanged="myaccount_bulletedlist_SelectedIndexChanged"></asp:ListBox>
               
                 
                <div class="myentries_edit">
                <asp:ListBox ID="myfavorites_list" Class="myentries_list" runat="server" Width="100%" BackColor="#ffffe6" Visible="false"></asp:ListBox>
                <asp:Button ID="btn_myentries_unfav" runat="server" Text="favorilerden çıkar" Font-Size="Large" Width="150px" Height="50px" Visible="false" BackColor="#eeffe6" BorderStyle="None"/>                  
                    </div>
                <div class="myentries_edit">
                <asp:ListBox ID="myfollowed_list" Class="myentries_list" runat="server" Width="100%" BackColor="#ffffe6" Visible="false"></asp:ListBox>
                <asp:Button ID="btn_myentries_unfollow" runat="server" Text="takipten çıkar" Font-Size="Large" Width="150px" Height="50px" Visible="false" BackColor="#eeffe6" BorderStyle="None"/>      
                    </div>
                <div class="myentries_edit">
                <asp:ListBox ID="mysuspended_list" Class="myentries_list" runat="server" Width="100%" BackColor="#ffffe6" Visible="false"></asp:ListBox>
                <asp:Button ID="btn_myprofile_unsuspend" runat="server" Text="engeli kaldır" Font-Size="Large" Width="150px" Height="50px" Visible="false" BackColor="#eeffe6" BorderStyle="None"/>
                </div>--%>

            </div>
      </div> 
    </form>
</body>
</html>
