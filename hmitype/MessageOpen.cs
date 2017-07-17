using System;
using System.Drawing;
using System.Windows.Forms;

namespace hmitype
{
    public static class MessageOpen
    {
        public static DialogResult Show(string messagestr)
        {
            Form form = new MessageForm(messagestr);
            form.ShowDialog();
            return form.DialogResult;
        }

        public static DialogResult Show(string messagestr, Color color)
        {
            Form form = new MessageForm(messagestr, color);
            form.ShowDialog();
            return form.DialogResult;
        }

        public static DialogResult Show(string messagestr, string title, MessageBoxButtons mb)
        {
            Form form = new MessageForm(messagestr, title, mb);
            form.ShowDialog();
            return form.DialogResult;
        }
    }
}
