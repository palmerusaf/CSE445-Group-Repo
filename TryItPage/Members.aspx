<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="web_client.Members" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Exchange Rate Service Test</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Currency Exchange Rate Checker</h2>
            
            <asp:Label ID="Label1" runat="server" Text="Currency 1:"></asp:Label>
            <asp:TextBox ID="Currency1TextBox" runat="server" Width="100px"></asp:TextBox>
            
            <asp:Label ID="Label2" runat="server" Text="Currency 2:"></asp:Label>
            <asp:TextBox ID="Currency2TextBox" runat="server" Width="100px"></asp:TextBox>
            
            <asp:Button ID="GetExchangeRateButton" runat="server" Text="Get Exchange Rate" OnClick="GetExchangeRateButton_Click" />
            
            <asp:Label ID="ResultLabel" runat="server" Text="" EnableViewState="false"></asp:Label>
        </div>
    </form>
</body>
</html>
