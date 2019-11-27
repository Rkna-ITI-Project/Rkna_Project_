<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerReport.aspx.cs" Inherits="Rkna_Project.Reportes.Customer.CustomerReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"> 
<head runat="server">
    <title></title>
</head>
<body style="height: 906px">
    <form id="form1" runat="server">
        <div>
           
     <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
            <asp:Label ID="Label1" runat="server" Font-Names="Forte" Font-Size="Medium" Text="Customer Name   :   "></asp:Label>
            <div style="height: 33px">
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="UserName" DataValueField="Id" Font-Names="Forte" Font-Size="Large" Height="30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="413px">
                </asp:DropDownList>
            </div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Id], [UserName] FROM [AspNetUsers]"></asp:SqlDataSource>
     <rsweb:ReportViewer ID="ReportViewer2" runat="server" Width="100%"  BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" AsyncRendering="False" KeepSessionAlive="False" Height="838px">
         <ServerReport ReportServerUrl="" />
         <LocalReport ReportPath="Reportes\Customer\CustomerReport.rdlc">
         </LocalReport>
      
      </rsweb:ReportViewer>

        </div>
    </form>
    </body>
</html>
