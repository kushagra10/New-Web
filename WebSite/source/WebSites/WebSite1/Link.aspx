<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Link.aspx.cs" Inherits="Link" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <asp:GridView ID="GridView1" runat="server">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Image ID="Image1" Height="122px" ImageUrl='<%# Eval("ThumbNailPhoto","~/ThumbNailPhoto/{0}") %>' runat="server" Text="ThumbNailPhoto" DataTextField ="ThumbNailPhoto" Width="122px" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Export" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="TOP 5 Product Recommendations"></asp:Label>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            <br />
            <br />
            
            
        </div>
    </form>
</body>
</html>
