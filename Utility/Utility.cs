using CallCenterCoreAPI.Models.ViewModel;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace CallCenterCoreAPI
{
    public static class Utility
    {

        internal static string key = "b14ca5898a4e4133bbce2ea2315a1916";
        internal static DataTable ListToDatatable<T>(List<T> items)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dt.Columns.Add(prop.Name);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
        internal static string GenerateFileName(string context)
        {
            return context + "_" + DateTime.Now.ToString("ddMMyyyyHHmmssfff") + ".pdf";
        }

        internal static string EncryptText(string text)
        {
            
            var EncryptedString = AesOperation.EncryptString(key, text);
            return EncryptedString;
        }
        internal static string DecryptText(string text)
        {
            var DecryptedString = AesOperation.DecryptString(key, text);
            return DecryptedString;

     
        }


        public static string GetFinancialYear(DateTime curDate)
        {
            int CurrentYear = curDate.Year;
            int PreviousYear = (curDate.Year - 1);
            int NextYear = (curDate.Year + 1);
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = string.Empty;
            if (curDate.Month > 3)
            {
                FinYear = "04/01/"  + CurYear;
            }
            else
            {
                FinYear = PreYear;
            }
            return FinYear;
        }

        public static string GetTodayDate(DateTime curDate)
        {
            int CurrentYear = curDate.Year;
            int PreviousYear = (curDate.Year - 1);
            int NextYear = (curDate.Year + 1);
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = string.Empty;
            if (curDate.Month > 3)
            {
                FinYear = "04/01/" + CurYear;
            }
            else
            {
                FinYear = PreYear;
            }
            return FinYear;
        }

        

    }

}