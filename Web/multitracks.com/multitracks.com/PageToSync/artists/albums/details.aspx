<%@ Page Language="C#" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="AlbumsDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Album Details</title>
    <link media="all" rel="stylesheet" href="~/PageToSync/css/index.css">
</head>
<body>
<form id="form1" runat="server">
    <h1>Albums</h1>

    <!-- Albums Repeater Section -->
    <%--<asp:Repeater ID="Albums" runat="server">
        <ItemTemplate>
            <div>
                <img src='<%# Eval("AlbumImageURL") %>' alt='<%# Eval("albumTitle") %>' />
                <h3><%# Eval("albumTitle") %></h3>
            </div>
        </ItemTemplate>
    </asp:Repeater>--%>
    <div class="discovery--grid-holder">

        <div class="ly-grid ly-grid-cranberries">
												
            <asp:Repeater runat="server" ID="Albums">
                <ItemTemplate>
                    <div class="media-item">
                        <a class="media-item--img--link" href="#" tabindex="0">
                            <img class="media-item--img" alt='<%#Eval("albumTitle") %>' src='<%#Eval("albumImageURL") %>' srcset='<%# Eval("albumImageURL") %>, <%# Eval("albumImageURL") %> 2x'>
                            <span class="image-tag">Master</span>
                        </a>
                        <a class="media-item--title" href="#" tabindex="0"><%#Eval("albumTitle") %></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div><!-- /.grid -->
    </div><!-- /.discovery-grid-holder -->


    <!-- Error Label -->
    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" />

</form>
</body>
</html>
