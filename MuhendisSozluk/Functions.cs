using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Net.Mail;
using System.Net;

namespace MuhendisSozluk
{
    public class Functions
    {
        #region Encryptor
        private static byte[] Key = { 91, 93, 19, 39, 110, 195, 123, 98, 101, 213, 5, 50, 52, 92, 193, 133, 193, 111, 221, 164, 58, 128, 89, 48, 97, 154, 83, 187, 111, 164, 171, 74 };
        private static byte[] IV = { 10, 61, 235, 120, 122, 121, 82, 248, 15, 121, 196, 212, 176, 46, 54, 85 };

        private static byte[] Encrypt(byte[] clearData)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }
        private static byte[] Decrypt(byte[] cipherData)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        public static string EncryptString(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            byte[] encryptedData = Encrypt(clearBytes);
            return Convert.ToBase64String(encryptedData);
        }
        public static string DecryptString(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedData = Decrypt(cipherBytes);
            return Encoding.Unicode.GetString(decryptedData);
        }
        public static string MD5(string text)
        {
            byte[] result = new byte[text.Length];
            MD5 md = new MD5CryptoServiceProvider();
            UTF8Encoding encode = new UTF8Encoding();
            result = md.ComputeHash(encode.GetBytes(text));

            return BitConverter.ToString(result).Replace("-", "");

        }
        #endregion
        public enum SqlType
        {
            MSSql = 1,
            MySql = 2
        }

        public static void Clear(Control parent)
        {
            foreach (Control cntrl in parent.Controls)
            {
                if ((cntrl.GetType() == typeof(TextBox)))
                {
                    ((TextBox)(cntrl)).Text = string.Empty;
                }
                if ((cntrl.GetType() == typeof(DropDownList)))
                {
                    ((DropDownList)(cntrl)).SelectedValue = "0";
                }
                if (cntrl.HasControls())
                {
                    Clear(cntrl);
                }
            }
        }
        public static Uri SITEURL
        {
            get { return new Uri(DecryptString(ConfigurationSettings.AppSettings["SystemCode"]).Split('~')[0]); }
        }
        public static string THEME
        {
            get
            {
                if (HttpContext.Current.Application["THEME"] == null)
                {
                    HttpContext.Current.Application["THEME"] = ConfigurationSettings.AppSettings["THEME"];
                }
                return HttpContext.Current.Application["THEME"].ToString();
            }
        }
        public static string TABLEPREFIX
        {
            get { return ConfigurationSettings.AppSettings["TablePrefix"]; }
        }
    }
}