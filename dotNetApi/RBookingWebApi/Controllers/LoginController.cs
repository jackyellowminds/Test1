using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreWebApi.DataContext;
using OnlineBookStoreWebApi.Models;
using RBookingWebApi.DataContext;
using RBookingWebApi.DBL;
using RBookingWebApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace OnlineBookStoreWebApi.Controllers
{
    // User login
    [ApiController]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        
        private readonly IDatabaseService database;
        private readonly RBookingWeApiDataContext dbcontext;
        public LoginController(IDatabaseService database, RBookingWeApiDataContext dbcontext)
        {
                
            this.database = database;
            this.dbcontext = dbcontext;
        }

        // User Login 
        [HttpPost]
        [Route("LoginNow")]
        public async Task<IActionResult> LoginNow([FromBody] LoginMD data)
        {

            IActionResult response = Unauthorized();
            var user = await AuthenticateUser(data);
            if (user.Email != null)
            {                        
                user.UserNo = user.UserNo;
            }
            else
            {
                return Ok(user);
            }
            return Ok(user);
        }
        
        // TODO: Register User Details
        [HttpPost]
        [Route("RegisterUser")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterMD value)
        {
            String Response = "";
            String EncriptedPassword = Encrypt(value.Password);
            return Json(null);
        }

        //Encript User information
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        
        // Check user details from backend..
        private async Task<UserMD> AuthenticateUser(LoginMD login)
        {
            UserMD response =database.AuthenticateUser(login);
            return response;
        }
        
      
       

    }
}
