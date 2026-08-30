using System.Runtime.InteropServices;

namespace Control
{
    public class NoCaretRichTextBox : RichTextBox
    {
        private const int EM_HIDESELECTION = 0x043F;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            SendMessage(Handle, EM_HIDESELECTION, new IntPtr(1), IntPtr.Zero);
        }
    }
}