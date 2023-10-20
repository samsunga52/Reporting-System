<%@ Page Async="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Newcustomer.aspx.cs" Inherits="ZainNabi_EasySystems.Newcustomer" %>

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
            <a href="#">Customer</a> > <a href="#">New customer</a>
        </div>
        <div class="form-container">
            <div class="form-column">
                <label for="txtFirstName">First Name</label>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name is required"></asp:RequiredFieldValidator>

                <label for="txtLastName">Last Name</label>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator>

                <label for="ddlTitle">Title</label>
                <asp:DropDownList ID="ddlTitle" runat="server">
                    <asp:ListItem Text="Mr." Value="Mr."></asp:ListItem>
                    <asp:ListItem Text="Mrs." Value="Mrs."></asp:ListItem>
                    <asp:ListItem Text="Ms." Value="Ms."></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="ddlTitle" ErrorMessage="Title is required"></asp:RequiredFieldValidator>

                <label for="txtAddress">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required"></asp:RequiredFieldValidator>


            </div>
            <div class="form-column">
                <label for="txtEmail">Email</label>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>

                <label for="txtCellNumber">Cell Number</label>
                <asp:TextBox ID="txtCellNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCellNumber" runat="server" ControlToValidate="txtCellNumber" ErrorMessage="Cell Number is required"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCellNumber" runat="server" ControlToValidate="txtCellNumber" ErrorMessage="Invalid cell number format" ValidationExpression="^\d{10}$"></asp:RegularExpressionValidator>

                <label for="txtReferenceNumber">Reference Number</label>
                <asp:TextBox ID="txtReferenceNumber" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReferenceNumber" runat="server" ControlToValidate="txtReferenceNumber" ErrorMessage="Reference Number is required"></asp:RequiredFieldValidator>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnCaptureTrans" runat="server" Text="Capture Transaction" OnClick="btnCaptureTrans_Click" Visible="false" />
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="btnViewTrans" runat="server" Text="View Transaction" OnClick="btnViewTrans_Click" Visible="false" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnViewTrans" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <br />
            </div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="No transaction data" Visible="false"></asp:Label>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" Visible="false"></asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </body>
    </html>
</asp:Content>
