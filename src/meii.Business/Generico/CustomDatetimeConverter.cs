using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace meii.Business.Generico
{
    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
