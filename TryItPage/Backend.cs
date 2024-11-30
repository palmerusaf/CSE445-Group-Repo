﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Xml.Linq;
using web_client.PasswordHasher;

namespace BackendNameSpace
{

    public static class XmlHelper
    {
        private static readonly string XmlFilePath = HttpContext.Current.Server.MapPath("~\\TryItPage\\Users.xml");

        public static XElement LoadXml()
        {
            return XElement.Load(XmlFilePath);
        }
        public static void SaveXml(XElement xml)
        {
            xml.Save(XmlFilePath);
        }
        public static XElement FindUser(string username)
        {
            XElement xml = LoadXml();
            return xml.Elements("User").FirstOrDefault(u => u.Element("Username").Value == username);
        }
    }





    public class SimpleResponse
    {
        public bool Success;
        public string ErrorMsg;
    }
    public class ContentResponse
    {
        public bool Success;
        public string ErrorMsg;
        public List<string> Content;
    }
    public class Backend
    {
        private IPasswordHasher client;
        public SimpleResponse ValidateLogin(string username, string password)
        {
            SimpleResponse res = new SimpleResponse();
            XElement user = XmlHelper.FindUser(username);

            if (user == null)
            {
                res.Success = false;
                res.ErrorMsg = "User does not exist.";
                return res;
            }

            string storedHash = user.Element("PasswordHash").Value;
            string salt = user.Element("Salt").Value;
            if (client == null)
            {
                var factory = new ChannelFactory<IPasswordHasher>("BasicHttpBinding_IPasswordHasher");
                client = factory.CreateChannel();
            }
            // hash password bump with db
            bool isValid = client.VerifyPassword(password, storedHash, salt);
            if (isValid)
            {

                res.Success = true;
                return res;
            }
            else
            {
                res.Success = false;
                res.ErrorMsg = "Invalid password.";
                return res;

            }
            //res.Success = true;
            // res.Success = false;
            // res.ErrorMsg="reason its invalid"
            //return res;
        }

        public SimpleResponse CreateUser(string username, string password)
        {
            // lets require usernames be unique so we can also use them as username ids
            // this means we'll have to bump the db to make sure this is true
            SimpleResponse res = new SimpleResponse();
            XElement xml = XmlHelper.LoadXml();

            if (XmlHelper.FindUser(username) != null)
            {
                res.Success = false;
                res.ErrorMsg = "Username already exists.";
                return res;
            }

            if (client == null)
            {
                var factory = new ChannelFactory<IPasswordHasher>("BasicHttpBinding_IPasswordHasher");
                client = factory.CreateChannel();
                string salt = client.GenerateSalt();
                string NewHash = client.HashPassword(password, salt);


                XElement newUser = new XElement("User",
                new XElement("Username", username),
                new XElement("PasswordHash", NewHash),
                new XElement("Salt", salt)
                );

                xml.Add(newUser);
                XmlHelper.SaveXml(xml);

                res.Success = true;
                return res;


            }


            res.Success = true;
            // res.Success = false;
            // res.ErrorMsg="duplicate user"
            return res;
        }

        // if this get too complicated for the backend maybe we can shrink the problem down to only getting and setting a single stock symbol for the list and make the watch list just a watch symbol
        public static ContentResponse GetWatchList(string username)
        {
            // assume the username exists because watch list functions get called at the member page
            ContentResponse res = new ContentResponse();
            res.Success = true;
            res.Content =new List<string>{ "lmt","ibm"};
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
