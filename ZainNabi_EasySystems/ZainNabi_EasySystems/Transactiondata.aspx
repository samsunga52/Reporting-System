<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Transactiondata.aspx.cs" Inherits="ZainNabi_EasySystems.Transactiondata" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title></title>
        <style>
            .form-container {
                display: flex;
                justify-content: space-between;
            }

                .form-container .form-column {
                    width: 45%;
                }

                .form-container label {
                    display: block;
                    margin-bottom: 5px;
                }

                .form-container input[type="text"],
                .form-container textarea {
                    width: 100%;
                    padding: 5px;
                    margin-bottom: 10px;
                    border: 1px solid #ccc;
                    border-radius: 4px;
                    box-sizing: border-box;
                }

                .form-container select {
                    width: 100%;
                    padding: 5px;
                    margin-bottom: 10px;
                    border: 1px solid #ccc;
                    border-radius: 4px;
                    box-sizing: border-box;
                }

                .form-container .error-message {
                    color: red;
                    margin-bottom: 10px;
                }

                .form-container .breadcrumb {
                    margin-bottom: 20px;
                }
        </style>
        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    </head>
    <body>
        <div class="breadcrumb">
            <a href="#">Customer</a> > <a href="#">Transaction Data</a>
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="No transaction data" Visible="false"></asp:Label>
        <br />
        <br />
        <form>
            <label for="txtFromDate">From Date - (yyyy/mm/dd)</label>
            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
            <label for="txtToDate">To Date - (yyyy/mm/dd)</label>
            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>

            <asp:Button ID="btnLoadReport" runat="server" Text="Load Report" OnClick="btnLoadReport_Click" />
            <div>
                <asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView>
            </div>
            <br />
            <asp:Button ID="btnExportXML" runat="server" Text="Export XML" OnClick="btnExportXML_Click" />
            <asp:Button ID="btnExportExcel" runat="server" Text="Export Excel" OnClick="btnExportExcel_Click" />
        </form>
    </body>
    </html>
</asp:Content>
