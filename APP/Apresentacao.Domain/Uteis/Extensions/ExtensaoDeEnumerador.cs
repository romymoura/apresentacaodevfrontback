using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Apresentacao.Domain.Uteis.Extensions
{
    public static class ExtensaoDeEnumerador
    {
        public static string GetEnumDescription<T>(string value)
        {
            Type type = typeof(T);
            var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

            if (name == null)
            {
                return string.Empty;
            }

            var field = type.GetField(name);
            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
        }

        public static IEnumerable<SelectListItem> EnumToSelectList<T>(string tipoCase = null)
        {
            return (Enum.GetValues(typeof(T)).Cast<T>().Select(
                e => new SelectListItem()
                {
                    Text = (tipoCase == null ? GetEnumDescription<T>(e.ToString()) : (tipoCase.ToUpper() == "U" ? GetEnumDescription<T>(e.ToString()).ToUpper() : GetEnumDescription<T>(e.ToString()).ToLower())),
                    Value = e.ToString()
                })).ToList();
        }
    }
}
