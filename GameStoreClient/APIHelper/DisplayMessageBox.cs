using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameStoreClient.APIHelper
{
    public class DisplayMessageBox
    {
        public static MessageBoxResult Show(string? message, List<string>? messages, string caption, MessageBoxButton button, MessageBoxImage icon)
        {
            var content = message;
            if (messages != null)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string item in messages)
                {
                    builder.AppendLine(item);
                }
                content = builder.ToString();
            }

          return  MessageBox.Show(content, caption, button, icon);
        }
    }
}
