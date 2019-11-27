using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rkna_Project.Reportes.Area
{
    public partial class AreaReport : System.Web.UI.Page
    { 
        DataTable Area, CompInfo;
        ReportBiningata ReporBin;

        protected void ReportViewer1_Init(object sender, EventArgs e)
        {

        }

        protected void ReportViewer1_Load(object sender, EventArgs e)
        {

        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            ReporBin = new ReportBiningata();
            CompInfo = ReporBin.GetCompanyInf();
            Area = ReporBin.GetArea();
            // ReportViewer1.LocalReport.DataSources.Clear();

            this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Area", Area));
            this.ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CompInfo", CompInfo));
            //  ReportViewer1.LocalReport.ReportPath = @"Reportes\Area\AreaReport.rdlc";
            this.ReportViewer1.LocalReport.DisplayName = "Report about Areas";
            this.ReportViewer1.LocalReport.Refresh();
            
        }

    }
}