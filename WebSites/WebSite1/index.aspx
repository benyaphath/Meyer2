<style type="text/css">
     .hidden
     {
         display:none;
     }
</style>
<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" />
        <asp:gridview ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="login" HeaderText ="Login"/>
                <asp:BoundField DataField="ru">
                    <ItemStyle CssClass="hidden"/>
                    <HeaderStyle CssClass="hidden"/>
                </asp:BoundField>
                <asp:ImageField DataImageUrlField="im" HeaderText="Image">
                    <ControlStyle Height="50px" Width="50px" />
                </asp:ImageField>
                <asp:CommandField ShowSelectButton="True"/>
            </Columns>
        </asp:gridview>
    </form>
</body>
</html>
