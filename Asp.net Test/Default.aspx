<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Assets._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="https://kendo.cdn.telerik.com/themes/6.4.0/default/default-main.css" rel="stylesheet" />
    <script src="https://kendo.cdn.telerik.com/2023.2.606/js/jquery.min.js"></script>
    <script src="https://kendo.cdn.telerik.com/2023.2.606/js/kendo.all.min.js"></script>

    <div class="jumbotron">
        <h1>Assets Test</h1>
        <p class="lead">Here you can get data from a spread sheet and populate the KendoGrid (Telerik).</p>
     
        <asp:Button ID="GetDataBtn" runat="server" Text="Get Data" class="btn btn-primary btn-lg center" OnClick="GetData_Click" />

    </div>

    
    <div id="grid"></div>
    <script>
        $(document).ready(function () {
            // Prepare the data source
            var dataSource = new kendo.data.DataSource({
                data:GetAssetsData()
        });

            // Initialize the Kendo Grid
            $("#grid").kendoGrid({
                dataSource: dataSource,
                columnMenu: {
                    filterable: false
                },
                height: 680,
                sortable: true,
                navigatable: true,
                resizable: true,
                reorderable: true,
                groupable: true,
                filterable: true,
                toolbar: ["excel", "pdf", "search"],
                columns: [
                    { field: "AssetId", title: "Asset ID" },
                    { field: "AssetName", title: "Asset Name" },
                    { field: "Model", title: "Model" },
                    { field: "VendorName", title: "Vendor Name" },
                    { field: "Description", title: "Description" }
                ]
            });
     });

    function GetAssetsData() {
        return <%= GetAssetsJson() %>;
        }
    </script>
</asp:Content>
