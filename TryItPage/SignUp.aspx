<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="web_client.WebForm2" %>

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
  <div class="flex justify-between py-7 px-10 w-full bg-blue-500 lg:px-24">
    <div class="flex items-center text-xl font-semibold text-center">
      <span class="material-symbols-outlined"> query_stats </span>
      QuoteWatch
    </div>
    <ul class="flex flex-col gap-2 md:flex-row">
      <li class="underline"><a href="default.aspx">Home</a></li>
      <li class="text-lg font-bold">Sign Up</li>
      <li class="underline"><a href="">Login</a></li>
      <li class="underline"><a href="">Members</a></li>
      <li class="underline"><a href="">Staff</a></li>
    </ul>
  </div>
  <div class="flex justify-center h-full">
    <div class="p-12 py-12 my-20 bg-gray-200 rounded-md shadow-lg">
      <h1 class="mb-2 text-2xl font-bold text-center underline">Sign Up</h1>
      <p class="text-center max-w-[80ch]">
        Want to become a member? Sign up below.
      </p>
      <form class="flex flex-col gap-2 mt-1">
        <div class="flex justify-between">
          <label class="font-bold" for="username">Username: </label>
          <input
            class="pl-2 rounded-md"
            placeholder="e.g. TA"
            type="text"
            name="username"
            value=""
          />
        </div>
        <div class="flex justify-between">
          <label class="font-bold" for="password">Password: </label>
          <input
            class="pl-2 rounded-md"
            placeholder="e.g. Cse445!"
            type="password"
            name="password"
            value=""
          />
        </div>
        <div class="flex justify-center h-6">
          <div class="max-w-sm font-semibold text-center text-red-500">
            <!-- Your username is too new for this legacy system. -->
          </div>
        </div>
        <button
          class="py-2 font-bold text-white bg-blue-500 rounded-full duration-300 hover:scale-105"
          type="submit"
        >
          Create Account
        </button>
      </form>
    </div>
  </div>
</body>
</html>
