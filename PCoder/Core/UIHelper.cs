using PCodes.Core;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace PCoder.Core;

[DebuggerStepThrough]
public static class UIHelper
{
    public static void WaitCursor(this Control control)
    {
        Cursor.Current = Cursors.WaitCursor;
    }

    public static void DefaultCursor(this Control control)
    {
        Cursor.Current = Cursors.Default;
    }

    public static DialogResult Show(string text)
    {
        return MessageBox.Show(text);
    }

    public static DialogResult Show(string text, string caption)
    {
        return MessageBox.Show(text, caption);
    }

    public static DialogResult ShowConfirm(string text, string caption = "Confirm")
    {
        return MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
    }

    public static DialogResult ShowInformation(string text, string caption = "Information")
    {
        return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    public static DialogResult ShowWarning(string text, string caption = "Warning")
    {
        return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }

    public static DialogResult ShowError(string text, string caption = "Error")
    {
        return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    public static DialogResult ShowError(Exception ex, string caption = "Error")
    {
        List<Exception> list = ex.GetAllExceptions();
        string? text = null;

        if (list.Count > 1)
            text = string.Format("{0}----{0}", Environment.NewLine).Combine(list.Select(m => m.Message));
        else if (list.Count == 1)
            text = list.First().Message;
        else
            text = ex.Message;

        return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    public static DialogResult ShowErrorWithLog(string text, string caption = "Error",
        [CallerFilePath] string? path = null, [CallerMemberName] string? member = null, [CallerLineNumber] int line = 0)
    {
        return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }

    public static DialogResult ShowErrorWithLog(Exception ex, string caption = "Error",
        [CallerFilePath] string? path = null, [CallerMemberName] string? member = null, [CallerLineNumber] int line = 0)
    {
        List<Exception> list = ex.GetAllExceptions();
        string? text = null;

        if (list.Count > 1)
            text = string.Format("{0}----{0}", Environment.NewLine).Combine(list.Select(m => m.Message));
        else if (list.Count == 1)
            text = list.First().Message;
        else
            text = ex.Message;

        return MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
}
