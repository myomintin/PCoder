using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PCoder.Core;
using PCodes.Core;
using PCodes.Data;

namespace PCoder.Forms;

public partial class ImportForm : Form
{
    private readonly OpenFileDialog ofd;
    private List<string>? messages;
    private Dictionary<string, ImportSettings?>? settings;
    private DbContextOptions<ApplicationDbContext>? options;
    private string connection = string.Empty;

    public ImportForm()
    {
        InitializeComponent();
        ofd = new OpenFileDialog();
    }

    private void Form_Load(object sender, EventArgs e)
    {
        try
        {
            IConfigurationRoot config = ConfigurationHelper.Default();
            connection = config.GetConnectionString("DefaultConnection") ?? string.Empty;
            ofd.Filter = AppHelper.GetExcelFilter();
            ofd.RestoreDirectory = true;
            messages = [];
            settings = config.GetSection("ImportSettings").Get<Dictionary<string, ImportSettings?>?>();
            options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connection).Options;
            ConnectionInfoLabel.Text = AppHelper.GetConnectionInfo(connection);
            if (!AppHelper.IsDbOK(connection))
            {
                BrowseButton.Enabled = false;
                ImportButton.Enabled = false;
                UIHelper.ShowWarning("Connection is not OK.");
            }
        }
        catch (Exception ex)
        {
            UIHelper.ShowError(ex, "Load");
        }
    }

    private void Form_FormClosing(object sender, FormClosingEventArgs e)
    {
        try
        {
            ofd?.Dispose();
        }
        catch (Exception ex)
        {
            UIHelper.ShowError(ex, "Closing");
        }
    }

    private void CloseButton_Click(object sender, EventArgs e)
    {
        try
        {
            Close();
        }
        catch (Exception ex)
        {
            UIHelper.ShowError(ex, "Close");
        }
    }

    private void BrowseButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ImportFileLabel.Text = ofd.FileName;
            }
        }
        catch (Exception ex)
        {
            UIHelper.ShowError(ex, "PCodes Import File");
        }
    }

    private void ImportButton_Click(object sender, EventArgs e)
    {
        string title = "Import PCodes";
        if (string.IsNullOrEmpty(ImportFileLabel.Text))
        {
            UIHelper.ShowWarning("Please browse to import PCodes File.", title);
            return;
        }
        if (!File.Exists(ImportFileLabel.Text))
        {
            UIHelper.ShowWarning("File does not exist.", title);
            return;
        }

        try
        {
            this.WaitCursor();
            ResultTextBox.Text = string.Empty;
            messages?.Clear();
            AppHelper.Upgrade(ImportFileLabel.Text, settings, options, messages);
            if (messages != null)
            {
                ResultTextBox.Text = Environment.NewLine.Combine(messages);
            }
            this.DefaultCursor();
        }
        catch (Exception ex)
        {
            this.DefaultCursor();
            UIHelper.ShowError(ex, "Import");
        }
    }
}
