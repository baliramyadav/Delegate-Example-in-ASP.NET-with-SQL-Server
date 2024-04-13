<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="AddStudent_UsingDelegate.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Form</title>
    <meta charset="UTF-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container">
            <h2>Student Form</h2>
            <div class="form-group">
                <asp:Label ID="lblName" runat="server" Text="Student Name:"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" required></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblAge" runat="server" Text="Student Age:"></asp:Label>
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" TextMode="Number" required></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
            </div>
                
        </div>
        </div>
    </form>
</body>
</html>
