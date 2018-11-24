using System.Web.Mvc;
using System.Reflection;
using System.Globalization;
using System;

namespace saman
{
    public static class Utility
    {
        public static string ToPersian(this System.DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);
            int hour = pc.GetHour(dt);
            int min = pc.GetMinute(dt);

            DateTime PersianDateTime = new DateTime(year, month, day, hour, min, 0);

            return PersianDateTime.ToString("yyyy/MM/dd HH:mm");
        }

        public static DateTime ToPersianDate(this DateTime dt)
        {
            PersianCalendar pc = new PersianCalendar();
            int year = pc.GetYear(dt);
            int month = pc.GetMonth(dt);
            int day = pc.GetDayOfMonth(dt);
            int hour = pc.GetHour(dt);
            int min = pc.GetMinute(dt);

            return new DateTime(year, month, day, 0, 0, 0);
        }

       
    }

  
    
        public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
        {
            public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
            {
                return controllerContext.RequestContext.HttpContext.Request.IsAjaxRequest();
            }
        }
   
}