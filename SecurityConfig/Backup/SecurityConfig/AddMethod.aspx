<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMethod.aspx.cs" Inherits="SecurityConfig.AddMethod" %>

<%@ Register src="ucMenu.ascx" tagname="ucMenu" tagprefix="uc1" %>

<%@ Register src="ucMethodArgumentComparator.ascx" tagname="ucMethodArgumentComparator" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:ucMenu ID="ucMenu1" runat="server" />
    <div>
    <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red"></asp:Label>
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td>
                    Method Name</td>
                <td>
                    <asp:TextBox ID="txtMethodName" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ErrorMessage="Enter Method Name" ForeColor="Red" ControlToValidate="txtMethodName" ValidationGroup="method"></asp:RequiredFieldValidator>
                      
                </td>
            </tr>
            <tr>
                <td>
                    Class Name</td>
                <td>
                     <asp:TextBox ID="txtClassName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <uc2:ucMethodArgumentComparator ID="ucMethodArgumentComparator1" 
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAddMethod" runat="server" Text="Add Method" 
                          onclick="btnAddMethod_Click" ValidationGroup="method" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" 
                          /></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                     &nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="grdMethods" runat="server" AutoGenerateColumns="False" 
                        AutoGenerateSelectButton="True" CellPadding="4" DataKeyNames="PK_ID" 
                         ForeColor="#333333" GridLines="None" 
                        AllowPaging="True" onselectedindexchanged="method_selected" 
                        onpageindexchanging="grdMethods_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="PK_ID" HeaderText="PK_ID" ReadOnly="True" 
                                SortExpression="PK_ID" Visible="false" />
                            <asp:TemplateField HeaderText="METHOD_NAME" SortExpression="METHOD_NAME">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("METHOD_NAME")  %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("METHOD_NAME").ToString() + (Eval("Comparator_Count").ToString() != "0"?" ("+ Eval("Comparator_Count").ToString()+")":"") %> '></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="ROW_STATUS" HeaderText="ROW_STATUS" 
                                SortExpression="ROW_STATUS" />
                            <asp:BoundField DataField="CLASS_NAME" HeaderText="CLASS_NAME" 
                                SortExpression="CLASS_NAME" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:EntityDataSource ID="entSrcMethodGrid" runat="server" 
                        ConnectionString="name=Medappz2_LiveEntities" 
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" 
                        EntitySetName="L_SECU_ALL_METHODS" EntityTypeFilter="L_SECU_ALL_METHODS" 
                        OrderBy="" Select="">
                    </asp:EntityDataSource>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
