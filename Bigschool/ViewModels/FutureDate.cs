using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Bigschool.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isVailid= DateTime.TryParseExact(Convert.ToString(value),"MM/dd/yyyy",CultureInfo.CurrentCulture,DateTimeStyles.None,out dateTime);
            return (isVailid && dateTime > DateTime.Now);
        }

    }
   
}