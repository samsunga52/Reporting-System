<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="ZainNabi_EasySystems.Customers" %>

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

            .float-right {
                float: right;
            }
        </style>
        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
    </head>
    <body>
        <div class="breadcrumb">
            <a href="#">Customer</a> > <a href="#">Current Customers</a>
        </div>
        <br />
         <asp:Button ID="btnCustomer" CssClass="float-left" runat="server" Text="New customer" OnClick="btnCustomer_Click" />
        <div class="form-container">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="CustomerID" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="ReferenceNo" HeaderText="ReferenceNo" SortExpression="ReferenceNo" />
                    <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
                    <asp:BoundField DataField="CustomerName" HeaderText="CustomerName" SortExpression="CustomerName" />
                    <asp:BoundField DataField="AddedDate" HeaderText="AddedDate" SortExpression="AddedDate" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="CellNo" HeaderText="CellNo" SortExpression="CellNo" />
                    <asp:BoundField DataField="Agent" HeaderText="Agent" SortExpression="Agent" />
                    <asp:TemplateField HeaderText="Remove">
                        <ItemTemplate>
                             <asp:CheckBox ID="chkRemoved" runat="server" AutoPostBack="true" OnCheckedChanged="chkRemoved_CheckedChanged" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandArgument='<%# Eval("CustomerID") %>' OnClick="btnEdit_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [ReferenceNo], [CustomerID], [CustomerName], [AddedDate], [Email], [CellNo], [Agent] FROM [Customers] WHERE DeletedOn IS NULL"></asp:SqlDataSource>
        </div>
    </body>
    </html>
</asp:Content>


