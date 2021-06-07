using System;
using System.Collections.Generic;
using System.Text;

namespace LogApp.Application.Enums
{
    public static class GetEnums
    {
        public static List<EnumValueViewModel> GetValues<T>()
        {
            var values = new List<EnumValueViewModel>();

            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                values.Add(new EnumValueViewModel()
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Value = (int)itemType
                });
            }
            return values;
        }
    }
}
