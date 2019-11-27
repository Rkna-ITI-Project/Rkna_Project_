﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AreaReport.aspx.cs" Inherits="Rkna_Project.Reportes.Area.AreaReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 906px">
    <form id="form1" runat="server">
        <div>
           
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%"  BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" AsyncRendering="False" KeepSessionAlive="False" Height="838px">
         <ServerReport ReportServerUrl="" />
         <LocalReport ReportPath="Reportes\Area\AreaReport.rdlc">
         </LocalReport>
      
      </rsweb:ReportViewer>

        </div>
    </form>
    </body>
</html>
