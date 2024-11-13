<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="web_client.Login" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Login to access the Members Page</h2>
            <asp:Login ID="MembersLogin" runat="server" 
    DestinationPageUrl="Members.aspx" 
    OnAuthenticate="Members_Authenticate" />

        </div>
    </form>
</body>
</html>

