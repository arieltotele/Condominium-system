using FastReport;
using FastReport.Preview;
using System;
using System.Windows.Forms;

namespace Condominium_System.Presentation.Views
{
    public partial class ReportViewerForm : Form
    {
        private readonly Report _report;

        public ReportViewerForm(Report report)
        {
            InitializeComponent();
            _report = report ?? throw new ArgumentNullException(nameof(report));
            Load += ReportViewerForm_Load;
        }

        private void ReportViewerForm_Load(object sender, EventArgs e)
        {
            var preview = new PreviewControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(preview);

            _report.Preview = preview;
            _report.Prepare();
            _report.ShowPrepared();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            _report?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
