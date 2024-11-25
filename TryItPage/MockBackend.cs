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
    }
}