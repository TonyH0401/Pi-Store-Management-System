using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Midterm_NET
{
    public partial class frmPrint : Form
    {
        private List<Product> _products = new List<Product>();
        private String _bill_id, _order_id, _client_id, _employee_id, _date, _total_price;

        public frmPrint(List<Product> dataSource, String _bill_id, String _order_id, String _client_id, String _employee_id, String _date, String _total_price)
        {
            //if there is an error here, remember to public the Product class
            InitializeComponent();
            _products = dataSource;
            this._bill_id = _bill_id;
            this._order_id = _order_id;
            this._client_id = _client_id;
            this._employee_id = _employee_id;
            this._date = _date;
            this._total_price = _total_price;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            //name the dataset the same as the dataset model (class) and the rds should have the same string name
            ReportDataSource rds = new ReportDataSource("Product", _products);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Midterm_NET.Report1.rdlc";
            reportViewer1.Dock = DockStyle.Fill;
            this.Controls.Add(reportViewer1);
            reportViewer1.RefreshReport();

            Microsoft.Reporting.WinForms.ReportParameter[] para = new Microsoft.Reporting.WinForms.ReportParameter[]
            {
                new Microsoft.Reporting.WinForms.ReportParameter("pDate", _date),
                new Microsoft.Reporting.WinForms.ReportParameter("pTotal", _total_price),
                new Microsoft.Reporting.WinForms.ReportParameter("pEmployee", _employee_id),
                new Microsoft.Reporting.WinForms.ReportParameter("pClient", _client_id),
                new Microsoft.Reporting.WinForms.ReportParameter("pOrder", _order_id),
                new Microsoft.Reporting.WinForms.ReportParameter("pBill", _bill_id)
            }; 
            this.reportViewer1.LocalReport.SetParameters(para);
            this.reportViewer1.RefreshReport();
        }
    }
}
