<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuMapItem.ascx.cs" Inherits="SecurityConfig.ucMenuMapItem" %>
<div style="width: 100px;height:auto;">
    <asp:Label ID="lblMethodNama" runat="server" Text=""></asp:Label>
<%--<asp:ListView ID="lstComparatorValue" runat="server" >
    <AlternatingItemTemplate>
        <tr style="background-color:#FFF8DC;">
            <td>
                <asp:Label ID="FK_METHOD_IDLabel" runat="server" 
                    Text='<%# Eval("FK_METHOD_ID") %>' />
            </td>
            <td>
                <asp:Label ID="PK_IDLabel" runat="server" Text='<%# Eval("PK_ID") %>' />
            </td>
            <td>
                <asp:Label ID="PARAM_KEYLabel" runat="server" Text='<%# Eval("PARAM_KEY") %>' />
            </td>
            <td>
                <asp:Label ID="PARAM_INDEXLabel" runat="server" 
                    Text='<%# Eval("PARAM_INDEX") %>' />
            </td>
        </tr>
    </AlternatingItemTemplate>
    <EditItemTemplate>
        <tr style="background-color:#008A8C;color: #FFFFFF;">
            <td>
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                    Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                    Text="Cancel" />
            </td>
            <td>
                <asp:TextBox ID="FK_METHOD_IDTextBox" runat="server" 
                    Text='<%# Bind("FK_METHOD_ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="PK_IDTextBox" runat="server" Text='<%# Bind("PK_ID") %>' />
            </td>
            <td>
                <asp:TextBox ID="PARAM_KEYTextBox" runat="server" 
                    Text='<%# Bind("PARAM_KEY") %>' />
            </td>
            <td>
                <asp:TextBox ID="PARAM_INDEXTextBox" runat="server" 
                    Text='<%# Bind("PARAM_INDEX") %>' />
            </td>
        </tr>
    </EditItemTemplate>
    
    
    <ItemTemplate>
        <tr style="background-color:#DCDCDC;color: #000000;">
            <td>
                <asp:Label ID="FK_METHOD_IDLabel" runat="server" 
                    Text='<%# Eval("FK_METHOD_ID") %>' />
            </td>
            <td>
                <asp:Label ID="PK_IDLabel" runat="server" Text='<%# Eval("PK_ID") %>' />
            </td>
            <td>
                <asp:Label ID="PARAM_KEYLabel" runat="server" Text='<%# Eval("PARAM_KEY") %>' />
            </td>
            <td>
                <asp:Label ID="PARAM_INDEXLabel" runat="server" 
                    Text='<%# Eval("PARAM_INDEX") %>' />
            </td>
        </tr>
    </ItemTemplate>
    <LayoutTemplate>
        <table runat="server">
            <tr runat="server">
                <td runat="server">
                    <table ID="itemPlaceholderContainer" runat="server" border="1" 
                        style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                        
                        <tr ID="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </td>
            </tr>
            <tr runat="server">
                <td runat="server" 
                    style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                </td>
            </tr>
        </table>
    </LayoutTemplate>
    <SelectedItemTemplate>
        <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
            <td>
                <asp:Label ID="FK_METHOD_IDLabel" runat="server" 
                    Text='<%# Eval("FK_METHOD_ID") %>' />
            </td>
            <td>
                <asp:Label ID="PK_IDLabel" runat="server" Text='<%# Eval("PK_ID") %>' />
            </td>
            <td>
                <asp:Label ID="PARAM_KEYLabel" runat="server" Text='<%# Eval("PARAM_KEY") %>' />
            </td>
            <td>
                <asp:Label ID="PARAM_INDEXLabel" runat="server" 
                    Text='<%# Eval("PARAM_INDEX") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>--%>
</div>


