<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="web_client.SignUp" %>

<!DOCTYPE html>
<html lang="en">
  <head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=, initial-scale=1.0" />
    <title>QuoteWatch - Sign Up</title>
    <link
      rel="stylesheet"
      href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0&icon_names=query_stats"
    />
    <script src="https://cdn.tailwindcss.com"></script>
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
        <li class="text-lg font-bold">Sign Up</li>
        <li class="underline"><a href="Login.aspx">Login</a></li>
        <li class="underline"><a href="Members.aspx">Members</a></li>
        <li class="underline"><a href="Staff.aspx">Staff</a></li>
      </ul>
    </div>
    <div class="flex justify-center h-full">
      <div class="p-12 py-12 my-20 bg-gray-200 rounded-md shadow-lg">
        <h1 class="mb-2 text-2xl font-bold text-center underline">Sign Up</h1>
        <p class="text-center max-w-[80ch]">Want to become a member? Sign up below.</p>
        <div class="flex flex-col gap-2 mt-1">
            <asp:Login ID="MembersLogin" runat="server" 
    DestinationPageUrl="Members.aspx" 
    OnAuthenticate="Members_Authenticate" >
          <LayoutTemplate>
            <div class="flex justify-between">
              <asp:Label
                class="font-bold"
                ID="UserNameLabel"
                runat="server"
                AssociatedControlID="UserName"
                >Username:</asp:Label
              >
              <asp:TextBox
                class="pl-2 rounded-md"
                ID="UserName"
                runat="server"
              ></asp:TextBox>
            </div>
            <div class="flex justify-between">
              <asp:Label
                class="font-bold mt-2"
                ID="PasswordLabel"
                runat="server"
                AssociatedControlID="Password"
                >Password:</asp:Label
              >
              <asp:TextBox
                class="pl-2 mt-2 rounded-md"
                ID="Password"
                runat="server"
                TextMode="Password"
              ></asp:TextBox>
              <asp:RequiredFieldValidator
                ID="PasswordRequired"
                runat="server"
                ControlToValidate="Password"
                ErrorMessage="Password is required."
                ToolTip="Password is required."
                ValidationGroup="login"
                >*</asp:RequiredFieldValidator
              >
            </div>
            <div class="flex justify-center h-6">
              <asp:Literal
                ID="FailureText"
                runat="server"
                EnableViewState="False"
              ></asp:Literal>
            </div>
            <asp:Button
              class="py-2 w-full font-bold text-white bg-blue-500 rounded-full duration-300 hover:scale-105"
              ID="LoginButton"
              runat="server"
              CommandName="Login"
              Text="Creat Account"
              ValidationGroup="login"
            />
          </LayoutTemplate>
            </asp:Login>
        </div>
      </div>
    </div>
      </form>
  </body>
</html>

