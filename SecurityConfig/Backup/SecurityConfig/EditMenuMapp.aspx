<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMenuMapp.aspx.cs" Inherits="SecurityConfig.EditMenuMapp" %>

<%@ Register src="ucMenuMapItem.ascx" tagname="ucMenuMapItem" tagprefix="uc1" %>

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
    <div>
    
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td>
                    <asp:RadioButtonList ID="rLstParentMenu" runat="server" AutoPostBack="True" DataSourceID="EntityDataSource4"
                        DataTextField="MENU_NAME" DataValueField="PK_MENU_ID" RepeatDirection="Horizontal"
                        ViewStateMode="Enabled" OnSelectedIndexChanged="rLstParentMenu_SelectedIndexChanged">
                    </asp:RadioButtonList>
        <asp:HiddenField ID="hdnLevel" runat="server" Value="-100" />
        <asp:HiddenField ID="hdnMenuID" runat="server" Value="-100" />
                    <asp:EntityDataSource ID="EntityDataSource4" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_V_UTILITY_MENU"
                        EntityTypeFilter="L_V_UTILITY_MENU" Select="it.[PK_MENU_ID], it.[MENU_NAME]"
                        Where="it.[FK_PARENT_ID]  is null && it.[MENU_NAME] != '' ">
                    </asp:EntityDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlMenu" runat="server" AutoPostBack="True" 
                        DataTextField="MENU_NAME" DataValueField="PK_MENU_ID" 
                        OnSelectedIndexChanged="Menu_selected">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMenu_1" runat="server" AutoPostBack="True" 
                        DataTextField="MENU_NAME" DataValueField="PK_MENU_ID" 
                        OnSelectedIndexChanged="Menu_selected">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMenu_2" runat="server" AutoPostBack="True" 
                        DataTextField="MENU_NAME" DataValueField="PK_MENU_ID" 
                        OnSelectedIndexChanged="Menu_selected">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMenu_3" runat="server" AutoPostBack="True" 
                        DataTextField="MENU_NAME" DataValueField="PK_MENU_ID" 
                        OnSelectedIndexChanged="Menu_selected">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:DataList ID="DataList1" runat="server">
                        <ItemTemplate>
                            <uc1:ucMenuMapItem ID="ucMenuMapItem1" runat="server" MethodID='<%# Eval("FK_METHOD_ID") %>'  />
                        </ItemTemplate>
                    </asp:DataList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
