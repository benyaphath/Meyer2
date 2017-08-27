<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Detail.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="Button1" runat="server" Text="Back" />
        <asp:gridview ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="full_name" HeaderText ="Full Name"/>
                <asp:BoundField DataField="description" HeaderText ="Description"/>
                <asp:BoundField DataField="stargazers_count" HeaderText ="Star"/>
                <asp:BoundField DataField="forks_count" HeaderText ="Forks"/>
            </Columns>
        </asp:gridview>
    </form>
</body>
</html>
