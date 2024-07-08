using PCoder.Core;

namespace PCoder.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
    }

    private void ExitMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (Form control in MainPanel.Controls)
            {
                control.Close();
            }
            Application.Exit();
        }
        catch (Exception ex)
        {
            UIHelper.ShowError(ex, "App Exit");
        }
    }

    private void ImportMenuItem_Click(object sender, EventArgs e)
    {
        SetForm<ImportForm>();
    }

    //private void StatesMenuItem_Click(object sender, EventArgs e)
    //{
    //    SetForm<StatesForm>();
    //}

    private void SetForm<T>()
        where T : Form
    {
        try
        {
            Type type = typeof(T);
            if (MainPanel.Controls.Count > 0 && MainPanel.Controls[0] is Form cf)
            {
                if (cf.Name == type.Name)
                {
                    return;
                }
                cf.Close();
            }
            var f = Activator.CreateInstance<T>();

            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            f.FormBorderStyle = FormBorderStyle.None;
            MainPanel.Controls.Add(f);
            f.Show();
        }
        catch (Exception ex)
        {
            UIHelper.ShowError(ex);
        }
    }
}
