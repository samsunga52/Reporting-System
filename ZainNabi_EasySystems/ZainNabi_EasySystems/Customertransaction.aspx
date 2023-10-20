<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customertransaction.aspx.cs" Inherits="ZainNabi_EasySystems.Customertransaction" %>

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
            <a href="#">Customer</a> > <a href="#">New customer transaction</a>
        </div>
        <div class="form-container">
            <div class="form-column">
                <label for="txtTransDate">Transaction Date - (yyyy/mm/dd)</label>
                <asp:TextBox ID="txtTransDate" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTransDate" runat="server" ControlToValidate="txtTransDate" ErrorMessage="Date is required" ValidationExpression="^\d{4}/\d{2}/\d{2}$"></asp:RequiredFieldValidator>

                <label for="txtTransDescr">Transaction Description</label>
                <asp:TextBox ID="txtTransDescr" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTransDescr" runat="server" ControlToValidate="txtTransDescr" ErrorMessage="Description is required"></asp:RequiredFieldValidator>

                <label for="txtAddress">Transaction Amount</label>
                <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAmount" ErrorMessage="Amount is required" ValidationExpression="^\d+\.\d{2}$"></asp:RequiredFieldValidator>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </body>
    </html>
</asp:Content>
