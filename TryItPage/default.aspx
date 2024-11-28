<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="web_client.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="UTF-8" />
   <meta name="viewport" content="width=, initial-scale=1.0" />
   <title>QuoteWatch - Home</title>
   <link
     rel="stylesheet"
     href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0&icon_names=query_stats"
   />
   <script src="https://cdn.tailwindcss.com"></script>
 </head>
 <body>
   <div class="flex justify-between py-7 px-10 w-full bg-blue-500 lg:px-24">
     <div class="flex items-center text-xl font-semibold text-center">
       <span class="material-symbols-outlined"> query_stats </span>
       QuoteWatch
     </div>
     <ul class="flex flex-col gap-2 md:flex-row">
       <li class="text-lg font-bold">Home</li>
       <li class="underline"><a href="SignUp.aspx">Sign Up</a></li>
       <li class="underline"><a href="Login.aspx">Login</a></li>
       <li class="underline"><a href="Members.aspx">Members</a></li>
       <li class="underline"><a href="Staff.aspx">Staff</a></li>
     </ul>
   </div>
   <div class="flex justify-center h-full">
     <div class="p-12 my-20 bg-gray-200 rounded-md shadow-lg">
       <h1 class="mb-2 text-2xl font-bold text-center underline">Welcome</h1>
       <p class="max-w-prose text-center">
         Welcome to QuoteWatch. This service allows you to run reports on your
         favorite stocks. Additionally, you can save stocks you want to keep an
         eye on with your personal watch list. <br />Click on the links above
         to sign up. <br />Already a member? You can find your member and login
         page above.<br />
         Are you a TA that wants to grade this project? You can also find links
         for you above.
       </p>
     </div>
   </div>
 </body>
</html>
