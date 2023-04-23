﻿using LibreriaInternacional.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using a = LibreriaInternacional.Models;

namespace LibreriaInternacional.Controller
{
    public class LogIn
    {
        public LoginResponsePayload SignInWithPassword(LoginResponsePayload user)
        {
            var url = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBCto-6ILYLzKll-aVE1niBPceZK64fPPc";
            var postData = "{'email':'" + user.email + "','password':'" + user.password + "','returnSecureToken':true}";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetBytes(postData).Length);
            }

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    LoginResponsePayload payload = JsonConvert.DeserializeObject<LoginResponsePayload>(reader.ReadToEnd());

                    return payload;
                }
            }
            catch
            {
                return null;
            }
        }
    }

    public class SingUp
    {
        public LoginResponsePayload SignUpWithPassword(LoginResponsePayload user)
        {
            var url = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=AIzaSyBCto-6ILYLzKll-aVE1niBPceZK64fPPc";
            var postData = "{'email':'" + user.email + "','password':'" + user.password + "','returnSecureToken':true}";

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(Encoding.UTF8.GetBytes(postData), 0, Encoding.UTF8.GetBytes(postData).Length);

            }

            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    LoginResponsePayload payload = JsonConvert.DeserializeObject<LoginResponsePayload>(reader.ReadToEnd());

                    return payload;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}