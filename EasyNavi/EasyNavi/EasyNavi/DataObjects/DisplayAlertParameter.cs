using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EasyNavi.Core.DataObjects
{
    class DisplayAlertParameter
    {
        public string Title { get; }
        public string Message { get; }
        public string Accept { get; }
        public string Cancel { get; }
        public Func<bool, Task> Action { get; }

        public DisplayAlertParameter(string title, string message, string accept, string cancel, Func<bool, Task> action)
        {
            Title = title;
            Message = message;
            Accept = accept;
            Cancel = cancel;
            Action = action;
        }

        public static class Messages
        {
            public static string DisplayAlert { get; } = nameof(DisplayAlert);
        }
    }
}
