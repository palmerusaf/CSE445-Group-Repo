﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Staff.aspx.cs" Inherits="web_client._default" MaintainScrollPositionOnPostBack="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="default.css" />
   <title>QuoteWatch - Staff</title>
   <link
     rel="stylesheet"
     href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0&icon_names=query_stats"
   />
</head>
<body>
    <form runat="server">
    <div class="flex justify-between py-7 px-10 w-full bg-blue-500 lg:px-24">
      <div class="flex items-center text-xl font-semibold text-center">
        <span class="material-symbols-outlined"> query_stats </span>
        QuoteWatch
      </div>
      <ul class="flex flex-col gap-2 md:flex-row">
        <li class="underline"><a href="default.aspx">Home</a></li>
        <li class="underline"><a href="SignUp.aspx">Sign Up</a></li>
        <li class="underline"><a href="Login.aspx">Login</a></li>
        <li class="underline"><a href="Members.aspx">Members</a></li>
        <li class="text-lg font-bold">Staff</li>
      </ul>
    </div>
        <h1>Public Try It Page</h1>
        <p>This application offers serveral financial services to assist members in making trades.</p>
        <p>Please click the link below to try out our demo.</p>
        <a href="Members.aspx">Go to Members Page</a>
        <p>Furthermore, you can test individual services on this page.</p>
        <h2>Stock Quote</h2>
        <p>This service will fetch opening stock quotes.</p>
        <label>ServiceURL:</label>
        <a href="http://webstrar26.fulton.asu.edu/page4/StockQuote.svc?wsdl">http://webstrar26.fulton.asu.edu/page4/StockQuote.svc?wsdl</a>
        <label>Method Signature:</label>
        <code>string Stockquote(string symbol)</code>
        <label>
            Enter a stock symbol: 
        <asp:TextBox runat="server" ID="StockQuoteInput" />
        </label>
        <asp:Button runat="server" Text="Get Opening Price" OnClick="StockQuoteSubmit"></asp:Button>
        <asp:TextBox Enabled="false" runat="server" ID="StockQuoteOutput" />

        <h2>News Focus</h2>
        <p>This service will fetch news urls based on specified topics.</p>
        <label>ServiceURL:</label>
        <a href="http://webstrar26.fulton.asu.edu/page2/NewsFocus.svc/NewsFocusService?topics=tech">http://webstrar26.fulton.asu.edu/page2/NewsFocus.svc/NewsFocusService?topics=tech</a>
        <label>Method Signature:</label>
        <code>string[] NewsFocus(string topics)</code>
        <label>
            Enter topics sperated by commas: 
        <asp:TextBox runat="server" ID="NewsFocusInput" />
        </label>
        <asp:Button runat="server" Text="Find News Links" OnClick="NewsFocusSubmit"></asp:Button>
        <asp:Repeater runat="server" ID="NewsFocusOutput" >
            <ItemTemplate>
                <a href='<%# Container.DataItem %>' target="_blank"><%# Container.DataItem %></a>
            </ItemTemplate>
        </asp:Repeater>


        <h2>Charts</h2>
        <p>This service will take in data and return an html string to render a chart.</p>
        <label>ServiceURL:</label>
        <a href="http://webstrar26.fulton.asu.edu/page0/Charts.svc?wsdl">http://webstrar26.fulton.asu.edu/page0/Charts.svc?wsdl</a>
        <label>Method Signature:</label>
        <code>string Chart(string chartLabel, string[] dataLabels, string[] dataValues)</code>
        <label>
            Enter a label for your chart:
        <asp:TextBox runat="server" ID="ChartLabelInput" />
        </label>
        <label>
            Enter labels for your data seperated by commas
        <asp:TextBox runat="server" ID="ChartDataLabelsInput" />
        </label>
        <label>
            Enter values for your data seperated by commas
        <asp:TextBox runat="server" ID="ChartDataValuesInput" />
        </label>
        <asp:Button runat="server" Text="Build Chart" OnClick="ChartSubmit"></asp:Button>
        <asp:Literal ID="ChartOutput" Mode="PassThrough" runat="server"  />

        <h2>Annual Stock Report</h2>
        <p>This service will take a stock symbol and generates an annual stock report by returning an object that contains the annual return and a 12 month list of closing prices and month labels.</p>
        <label>ServiceURL:</label>
        <a href="http://webstrar26.fulton.asu.edu/page4/StockQuote.svc?wsdl">http://webstrar26.fulton.asu.edu/page4/StockQuote.svc?wsdl</a>
        <label>Method Signature:</label>
        <code>AnnualStockData AnnualStockReport(string symbol)</code>
        <label>
            Enter a stock symbol: 
        <asp:TextBox runat="server" ID="AnnualStockInput" />
        </label>
        <asp:Button runat="server" Text="Generate Report" OnClick="AnnualStockSubmit"></asp:Button>
        <asp:Repeater runat="server" ID="AnnualStockListOutput" >
            <ItemTemplate>
                <p> <%# Container.DataItem %> </p>
            </ItemTemplate>
        </asp:Repeater>


        <h2>Password Hasher Test</h2>
    
        <!-- Input fields for password and salt -->
        <asp:Label runat="server" Text="Enter Password: " />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" EnableViewState="true"/><br /><br />
    
        <asp:Label runat="server" Text="Generated Salt: " />
        <asp:TextBox ID="txtSalt" runat="server" ReadOnly="true" /><br /><br />
    
        <!-- Buttons for generating salt, hashing, and verifying -->
        <asp:Button ID="btnGenerateSalt" runat="server" Text="Generate Salt" OnClick="btnGenerateSalt_Click" /><br /><br />
    
        <asp:Label runat="server" Text="Hashed Password: " />
        <asp:TextBox ID="txtHashedPassword" runat="server" ReadOnly="true" /><br /><br />
    
        <asp:Button ID="btnHashPassword" runat="server" Text="Hash Password" OnClick="btnHashPassword_Click" /><br /><br />
    
        <!-- Verification fields and result -->
        <asp:Label runat="server" Text="Verify Password: " />
        <asp:TextBox ID="txtVerifyPassword" runat="server" TextMode="Password" EnableViewState="true"/><br /><br />
    
        <asp:Button ID="btnVerifyPassword" runat="server" Text="Verify" OnClick="btnVerifyPassword_Click" /><br /><br />
    
        <asp:Label ID="lblVerificationResult" runat="server" Text="" />

        <!-- Cookies Test -->
        <h2>Cookies Test</h2>
    
        <asp:Label runat="server" Text="Enter Username: " />
        <asp:TextBox ID="CookiesUserNameInput" runat="server" EnableViewState="true"/><br /><br />
    
        <asp:Label runat="server" Text="Enter Username: " />
        <asp:TextBox ID="CookiesPasswordInput" runat="server" EnableViewState="true"/><br /><br />
        <asp:Button ID="CookiesStoreButton" runat="server" Text="Store Cookies" OnClick="CookiesStoreButtonClick" /><br /><br />
        <asp:Button ID="CookiesGetButton" runat="server" Text="Get Cookies" OnClick="CookiesGetButtonClick" /><br /><br />
    
        <asp:Label runat="server" ID="CookiesOutput" Text="" />

        <!-- Global Events Test -->
        <h2>Global Events Test</h2>
    
        <asp:Label runat="server" Text="Total number of visitors: " />
        <asp:Label runat="server" Text="" ID="VisitorCountOutput" />
    </form>
</body>
</html>
