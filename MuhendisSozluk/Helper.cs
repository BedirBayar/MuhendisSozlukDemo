using System;
using System.Security.Cryptography;
using System.Web.Routing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace MuhendisSozluk
{
    public static class Helper
    {
        public static string GetQueryStringValue(string url, string key)
        {
            string retval = string.Empty;

            if (!string.IsNullOrEmpty(url) && url.IndexOf("?") > -1)
            {
                url = url.Split('?')[1];
                foreach (string query in url.Split('&'))
                {
                    if (!string.IsNullOrEmpty(query) && query.Split('=').Length > 1 && query.Split('=')[0] == key)
                    {
                        retval = query.Split('=')[1];
                        break;
                    }
                }
            }
            return retval;
        }

        public static string ShowMoney(object val)
        {

            string retval = "";

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencyDecimalDigits = 2;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencyGroupSizes = new int[] { 3 };
            nfi.NumberDecimalDigits = 2;
            nfi.NumberDecimalSeparator = ",";
            nfi.NumberGroupSeparator = ".";
            nfi.NumberGroupSizes = new int[] { 3 };
            nfi.PercentDecimalDigits = 2;
            nfi.PercentDecimalSeparator = ",";
            nfi.PercentGroupSeparator = ".";
            nfi.PercentGroupSizes = new int[] { 3 };

            if (val != null && val != DBNull.Value)
            {
                if (val is decimal)
                {
                    retval = Convert.ToDecimal(val).ToString("N", nfi);
                }
                else if (val is string)
                {

                    retval = Convert.ToDecimal(val, nfi).ToString("N", nfi);
                }
            }
            return retval;
        }
        public static string ShowDecimal(object val)
        {
            return ShowDecimal(val, 2);
        }
        public static string ShowDecimal(object val, int decimalPlaces)
        {

            string retval = "0.000";

            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.CurrencyDecimalDigits = decimalPlaces >= 0 ? decimalPlaces : 2;
            nfi.CurrencyDecimalSeparator = ",";
            nfi.CurrencyGroupSeparator = ".";
            nfi.CurrencyGroupSizes = new int[] { 3 };
            nfi.NumberDecimalDigits = decimalPlaces >= 0 ? decimalPlaces : 2;
            nfi.NumberDecimalSeparator = ",";
            nfi.NumberGroupSeparator = ".";
            nfi.NumberGroupSizes = new int[] { 3 };
            nfi.PercentDecimalDigits = decimalPlaces >= 0 ? decimalPlaces : 2;
            nfi.PercentDecimalSeparator = ",";
            nfi.PercentGroupSeparator = ".";
            nfi.PercentGroupSizes = new int[] { 3 };

            if (val != null && val != DBNull.Value)
            {
                if (val is decimal)
                {
                    if (decimalPlaces >= 0)
                    {
                        retval = Math.Round(Convert.ToDecimal(val), decimalPlaces, MidpointRounding.AwayFromZero).ToString("N", nfi);
                    }
                    else if (decimalPlaces == 0)
                    {
                        retval = Convert.ToDecimal(val).ToString("#0.##########").Replace(".", ",");
                    }
                    if (decimalPlaces < 0)
                    {
                        retval = Convert.ToDecimal(val).ToString("#0.##########", nfi).Replace(".", ",");
                    }
                }
                else if (val is string)
                {
                    if (decimalPlaces >= 0)
                    {
                        retval = Math.Round(Convert.ToDecimal(val, nfi), decimalPlaces, MidpointRounding.AwayFromZero).ToString("N", nfi);
                    }
                    else
                    {
                        retval = Convert.ToDecimal(val, nfi).ToString("#0.##########").Replace(".", ",");
                    }
                }
            }

            return retval;
        }
       
        public static string ShowDate(object date)
        {
            return ShowDate(date, false);
        }
        public static string ShowDate(object date, bool showTime)
        {
            return Convert.ToDateTime(date).ToString("dd.MM.yyyy" + (showTime ? " HH:mm" : ""));
        }
        public static void FillDrp(DropDownList drp, object data, string id, string value, bool addSelect)
        {
            drp.Items.Clear();
            drp.DataSource = data;
            drp.DataTextField = value;
            drp.DataValueField = id;
            drp.DataBind();
            if (addSelect)
            {
                drp.Items.Insert(0, new ListItem("Seçiniz...", "0"));
            }
        }
        public static void FillLbx(ListBox drp, object data, string id, string value, bool addSelect)
        {
            drp.Items.Clear();
            drp.DataSource = data;
            drp.DataTextField = value;
            drp.DataValueField = id;
            drp.DataBind();
            if (addSelect)
            {
                drp.Items.Insert(0, new ListItem("Hepsi", "0"));
            }
        }
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, "^(?(\"\")(\"\".+?\"\"@)|(([0-9a-zA-Z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-zA-Z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,6}))$");
        }
        public static string SEOUrl(string text)
        {
            text = text.ToLower();
            text = text.TrimEnd();
            text = text.TrimStart();
            text = Regex.Replace(text, "[\\s]+", " ");
            text = Regex.Replace(text, "[-]+", " ");
            text = Regex.Replace(text, "[.]+", ".");
            text = text.Replace(" ", "-");
            text = text.Replace(".", "-");
            text = text.Replace("/", "-");
            text = text.Replace("\\", "-");
            text = text.Replace("ç", "c");
            text = text.Replace("ı", "i");
            text = text.Replace("ğ", "g");
            text = text.Replace("ş", "s");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            if (text.Length > 0 && text[text.Length - 1] == '"')
            {
                text = text.TrimEnd('"') + "inch";
            }
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".™®½¾½”".ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                text = text.Replace(chars[i].ToString(), string.Empty);
            }
            text = Regex.Replace(text, "[-]+", "-");
            text = text.TrimEnd('-');
            return text;
        }
        public enum TypeUrl
        {
            Category = 1,
            Product = 2,
            Mark = 3,
            CMS = 4
        }
        //public static bool IsSeoUrlUsed(string url, int categoryID, int productID, short cmsID, int markID, TypeUrl typeURL)
        //{
        //    bool retval = false;
        //    // once reservedlara bakalim
        //    if (url == "yeni-urunler" || url == "cok-satanlar" || url.StartsWith("arama") || url == "iletisim" || url == "siparis" || url == "siparis-sorgulama" || url == "siparis-tamamlandi")
        //    {
        //        retval = true;
        //    }
        //    else if (DALCategory.IsUrlUsed(url, categoryID) || DALProduct.IsUrlUsed(url, productID) || DALMark.IsUrlUsed(url, markID) || DALCMS.IsUrlUsed(url, cmsID))
        //    {
        //        retval = true;
        //    }

        //    return retval;
        //}
        public static void ResetCategoryMenu()
        {
            foreach (string key in HttpContext.Current.Application.AllKeys)
            {
                if (key.StartsWith("#CATEGORYMENU"))
                {
                    HttpContext.Current.Application[key] = null;
                }
            }
        }
        public static decimal CDecimal(object val)
        {
            decimal retval = 0;

            if (val is decimal)
            {
                retval = Convert.ToDecimal(val);
            }
            else if (val is string)
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.CurrencyDecimalSeparator = ",";
                nfi.CurrencyGroupSeparator = ".";
                nfi.CurrencyGroupSizes = new int[] { 3 };
                nfi.NumberDecimalSeparator = ",";
                nfi.NumberGroupSeparator = ".";
                nfi.NumberGroupSizes = new int[] { 3 };
                nfi.PercentDecimalSeparator = ",";
                nfi.PercentGroupSeparator = ".";
                nfi.PercentGroupSizes = new int[] { 3 };
                retval = Convert.ToDecimal(val, nfi);
            }
            return retval;
        }
        public static DateTime CDate(object val)
        {
            DateTime retval = DateTime.MinValue;
            if (val is string)
            {
                DateTimeFormatInfo dfi = new DateTimeFormatInfo();
                dfi.DateSeparator = ".";
                dfi.FullDateTimePattern = "dd.MM.yyyy HH:mm";
                dfi.LongDatePattern = "dd.MM.yyyy HH:mm";
                dfi.LongTimePattern = "HH:mm";
                dfi.ShortDatePattern = "dd.MM.yyyy";
                dfi.ShortTimePattern = "HH:mm";
                dfi.TimeSeparator = ":";
                retval = Convert.ToDateTime(val, dfi);
            }
            else
            {
                retval = Convert.ToDateTime(val);
            }
            return retval;
        }
        public static Uri SITEURL
        {
            get { return Functions.SITEURL; }
        }
        //public static void LoginMember(User user, MEMBER member)
        //{
        //    user.ID = member.ID;
        //    user.NAME = member.NAME + " " + member.SURNAME.ToUpper(new CultureInfo("tr-TR"));
        //    user.FIRMID = member.FIRMID;
        //    user.PHONEACTIVATED = member.MOBILEACTIVETED;
        //    user.CANORDER = member.CANORDER;
        //    user.ISADMIN = member.ISADMIN;
        //    FIRM firm = DALFirm.Get(member.FIRMID);
        //    user.CANPAY = firm.CANPAY;
        //}

    }


}