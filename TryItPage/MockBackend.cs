using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MockBackendNameSpace
{
    public class SimpleResponse
    {
        public bool Success;
        public string ErrorMsg;
    }
    public class ContentResponse<T>
    {
        public bool Success;
        public string ErrorMsg;
        public T Content;
    }
    public static class Backend
    {

        public static SimpleResponse ValidateLogin(string username, string password)
        {
            SimpleResponse res = new SimpleResponse();
            // hash password bump with db
            res.Success = true;
            // res.Success = false;
            // res.ErrorMsg="reason its invalid"
            return res;
        }

        public static SimpleResponse CreateUser(string username, string password)
        {
            SimpleResponse res = new SimpleResponse();
            res.Success = true;
            // res.Success = false;
            // res.ErrorMsg="duplicate user"
            return res;
        }

        // if this get too complicated for the backend maybe we can shrink the problem down to only getting and setting a single stock symbol for the list and make the watch list just a watch symbol
        public static ContentResponse<string[]> GetWatchList(string username)
        {
            // assume the username exists because watch list functions get called at the member page
            ContentResponse<string[]> res = new ContentResponse<string[]>();
            res.Success = true;
            res.Content =new string[]{ "lmt","ibm"};
            // res.Success = false;
            // res.ErrorMsg=""
            return res;
        }

        public static SimpleResponse AddSymbol(string username,string symbol)
        {
            // assume the username exists because watch list functions get called at the member page
            SimpleResponse res = new SimpleResponse();
            res.Success = true;
            // res.Success = false;
            // res.ErrorMsg="already in list"
            return res;
        }

        public static SimpleResponse RemoveSymbol(string username,string symbol)
        {
            // assume its in list, the plan is to call this with a button per list symbol not text box
            SimpleResponse res = new SimpleResponse();
            res.Success = true;
            // res.Success = false;
            // res.ErrorMsg=""
            return res;
        }

    }
}