using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace NgoTanLoc.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "dd/MM/yyyy HH:mm", 
                CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);

            return (isValid && dateTime >=DateTime.Now);
        }
    }
}