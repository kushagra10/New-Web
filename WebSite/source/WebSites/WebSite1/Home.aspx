<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="CustomerID" OnSelectedIndexChanged="Unnamed1_SelectedIndexChanged">
                <Columns>
                    
                    <asp:HyperLinkField DataTextField="First_Name" DataNavigateUrlFields="CustomerID" DataNavigateUrlFormatString="~/Link.aspx?ID={0}" HeaderText="First Name" ItemStyle-Width = "150" >
                    
<ItemStyle Width="150px"></ItemStyle>
                    </asp:HyperLinkField>
                    
                    <asp:BoundField DataField="Middle_Name" HeaderText="Middle_Name" SortExpression="Middle_Name" />
                    <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                    <asp:BoundField DataField="Total_Purchase_Amt" HeaderText="Total_Purchase_Amt" SortExpression="Total_Purchase_Amt" />
                </Columns>
                

                 
            </asp:GridView>
            
            
            
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:candidate-test-data-sourceConnectionString %>" SelectCommand="SELECT C.CustomerID, C.FirstName COLLATE SQL_Latin1_General_CP1_CI_AS AS First_Name, C.MiddleName COLLATE SQL_Latin1_General_CP1_CI_AS AS Middle_Name, C.LastName COLLATE SQL_Latin1_General_CP1_CI_AS AS Last_Name, S.SubTotal AS Total_Purchase_Amt FROM SalesLT.Customer AS C INNER JOIN SalesLT.SalesOrderHeader AS S ON C.CustomerID = S.CustomerID ORDER BY Total_Purchase_Amt DESC"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
