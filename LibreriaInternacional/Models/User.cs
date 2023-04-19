using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibreriaInternacional.Models
{
    public class User
    {
        public int idUser { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public int CC { get; set; }
        public string ExpireDate { get; set; }
        public int CVC { get; set;}


    }
    public class LoginResponsePayload
    {
        public string idToken { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string refreshToken { get; set; }
        public string expiresIn { get; set; }
        public string localId { get; set; }
        public bool registered { get; set; }
    }
}