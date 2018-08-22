using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNavi.Core.DataObjects.DataModels
{
    class ContentAttribute
    {
        public ContentAttribute() { ; }

        public ContentAttribute(string title, string value)
        {
            Title = title;
            Value = value;
        }

        public string Title { get; }
        public string Value { get; }
        public bool HasValue => !string.IsNullOrEmpty(Value);
    }
}
