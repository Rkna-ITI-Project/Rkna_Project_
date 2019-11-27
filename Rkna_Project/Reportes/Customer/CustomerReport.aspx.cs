using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;


namespace Rkna_Project.Reportes.Customer
{
   
    public partial class CustomerReport : System.Web.UI.Page
    {
        DataTable CompInfo,Customer,Car,Cu_Sluts;
        ReportBiningata ReporBin;

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///ReportViewer2.Reset();
            ReporBin = new ReportBiningata();
            ReportViewer2.LocalReport.DataSources.Clear();
            CompInfo = ReporBin.GetCompanyInf();
            Car = ReporBin.GetCars(DropDownList1.SelectedValue.ToString());
            Cu_Sluts = ReporBin.GetCu_Slot(DropDownList1.SelectedValue.ToString());
            Customer = ReporBin.Get_Cust(DropDownList1.SelectedValue.ToString());

            this.ReportViewer2.LocalReport.DataSources.Add(new ReportDataSource("Customer", Customer));
            this.ReportViewer2.LocalReport.DataSources.Add(new ReportDataSource("Car", Car));
            this.ReportViewer2.LocalReport.DataSources.Add(new ReportDataSource("Cu_Sluts", Cu_Sluts));
            this.ReportViewer2.LocalReport.DataSources.Add(new ReportDataSource("CompInfo", CompInfo));
            this.ReportViewer2.LocalReport.DisplayName = "Report About Customer  "+DropDownList1.SelectedItem.Text;
            this.ReportViewer2.LocalReport.Refresh();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
    }
}