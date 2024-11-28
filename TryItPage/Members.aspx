<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Members.aspx.cs" Inherits="web_client.Members"  Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
        <li class="underline"><a href="SignUp.aspx">Sign Up</a></li>
        <li class="underline"><a href="Login.aspx">Login</a></li>
        <li class="text-lg font-bold">Members</li>
        <li class="underline"><a href="Staff.aspx">Staff</a></li>
      </ul>
    </div>
    <div class="grid grid-cols-5 grid-rows-6 gap-3 p-12 h-full">
      <div
        class="flex col-span-4 justify-center bg-gray-200 rounded-md shadow-lg item-center"
      >
        <div class="my-auto text-3xl font-bold">Members Page</div>
      </div>
      <div class="col-start-5 row-span-6 bg-gray-200 rounded-md shadow-lg">
        <div class="pt-6 w-full text-xl font-bold text-center">Watch List</div>
        <p class="pb-4 text-center">(click to insert)</p>
        <div
          class="flex overflow-hidden flex-col gap-4 px-4 text-nowrap text-ellipsis"
        >
            <asp:Repeater ID="WatchList" runat="server">
                <ItemTemplate>
                  <asp:Button runat="server"
                      OnClick="WatchListItemClick"
                    class="p-2 font-bold text-center text-white bg-gray-500 rounded-xl duration-200 hover:scale-110"
                    Text='<%# Container.DataItem %>' />
                </ItemTemplate>
            </asp:Repeater>
        </div>
      </div>
      <div
        class="row-span-5 row-start-2 bg-gray-200 rounded-md shadow-lg text-ellipsis"
      >
        <div class="py-4 w-full text-xl font-bold text-center">News Links</div>
        <div class="overflow-hidden flex-col px-4 text-nowrap text-ellipsis">
            <asp:Repeater runat="server" ID="NewsLinks">
                <ItemTemplate>
                  <a class="underline" target="_blank" href='<%# Container.DataItem %>'
                    ><%# Container.DataItem %><br /></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
      </div>
      <div
        class="col-span-3 col-start-2 row-span-4 row-start-3 bg-gray-200 rounded-md shadow-lg"
      >
        <div class="py-4 w-full text-xl font-bold text-center">Chart</div> <div class="px-4 pt-2 w-full"> 
            <asp:Literal ID="Chart" Mode="PassThrough" runat="server"  />
        </div>
      </div>
      <div
        class="flex col-span-3 col-start-2 row-start-2 items-center bg-gray-200 rounded-md shadow-lg"
      >
        <div class="grid grid-cols-5 grid-rows-2 gap-4 p-4 w-full">
          <div class="col-span-5 text-lg font-bold text-center">
            Current Price:
            <asp:Label runat="server" class="inline" ID="CurrentPrice" Text=""/>
          </div>
          <div
            class="col-start-1 row-start-2 p-2 text-lg font-bold text-center rounded-xl"
          >
            Symbol:
          </div>
          <asp:TextBox
              runat="server"
              ID="InputBox"
            class="col-start-2 row-start-2 p-2 font-bold text-center rounded-xl duration-300 hover:scale-105"
          />
          <asp:Button runat="server" OnClick="ReportClick"
            class="col-start-3 row-start-2 p-2 font-bold text-center text-white bg-blue-500 rounded-xl duration-300 hover:scale-105"
          Text="Run Report"   
          />
          <asp:Button runat="server" OnClick="AddClick"
            class="col-start-4 row-start-2 p-2 font-bold text-center text-white bg-green-500 rounded-xl duration-300 hover:scale-105"
              Text="Add"
          />
          <asp:Button runat="server" OnClick="RemoveClick" 
            class="col-start-5 row-start-2 p-2 font-bold text-center text-white bg-red-500 rounded-xl duration-300 hover:scale-105" Text="Remove"/> 
        </div>
      </div>
    </div>
      </form>
  </body>
</html>
