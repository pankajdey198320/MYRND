<%@ Page Language="C#" EnableEventValidation="true" AutoEventWireup="true" CodeBehind="TempletMenuMap.aspx.cs"
    Inherits="SecurityConfig.TempletMenuMap" %>

<%@ Register src="ucMenu.ascx" tagname="ucMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 314px;
        }
        .style3
        {
            width: 89px;
        }
        .style4
        {
            width: 89px;
            height: 54px;
        }
        .style5
        {
            width: 314px;
            height: 54px;
        }
        .style6
        {
            height: 54px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <asp:HiddenField ID="hdnLevel" runat="server" Value="-100" />
        <uc1:ucMenu ID="ucMenu1" runat="server" />
        <asp:HiddenField ID="hdnMenuID" runat="server" Value="-100" />
        <table class="style1">
            <tr>
                <td class="style4">
                    Module
                </td>
                <td class="style5">
                    <asp:DropDownList ID="ddlModule" runat="server" DataSourceID="EntityDataSource1"
                        DataTextField="NAME" DataValueField="PK_ID" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" CommandText="" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EntitySetName="L_SECU_CONFIG" EntityTypeFilter="L_SECU_CONFIG"
                        Select="it.[NAME], it.[PK_ID]" Where="it.[FK_SCE_CONFIG_TYPE] ==2" EnableFlattening="False">
                    </asp:EntityDataSource>
                </td>
                <td class="style6">
                    <asp:RadioButtonList ID="rLstParentMenu" runat="server" AutoPostBack="True" DataSourceID="EntityDataSource4"
                        DataTextField="MENU_NAME" DataValueField="PK_MENU_ID" RepeatDirection="Horizontal"
                        ViewStateMode="Enabled" OnSelectedIndexChanged="rLstParentMenu_SelectedIndexChanged">
                    </asp:RadioButtonList>
                    <asp:EntityDataSource ID="EntityDataSource4" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_V_UTILITY_MENU"
                        EntityTypeFilter="L_V_UTILITY_MENU" Select="it.[PK_MENU_ID], it.[MENU_NAME]"
                        Where="it.[FK_PARENT_ID]  is null && it.[MENU_NAME] != '' ">
                    </asp:EntityDataSource>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Screen
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlScreen" runat="server" AutoPostBack="True" DataSourceID="EntityDataSource2"
                        DataTextField="NAME" DataValueField="PK_ID" OnDataBound="ddlScreen_DataBound"
                        OnSelectedIndexChanged="ddlScreen_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_SECU_CONFIG"
                        EntityTypeFilter="L_SECU_CONFIG" Where="it.[FK_PK_PARENT_ID] == @parentid">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="ddlModule" DbType="Int64" DefaultValue="-1" Name="parentid"
                                PropertyName="SelectedValue" />
                        </WhereParameters>
                    </asp:EntityDataSource>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMenu" runat="server" DataTextField="MENU_NAME" DataValueField="PK_MENU_ID"
                        OnSelectedIndexChanged="Menu_selected" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMenu_1" runat="server" DataTextField="MENU_NAME" DataValueField="PK_MENU_ID"
                        OnSelectedIndexChanged="Menu_selected" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMenu_2" runat="server" DataTextField="MENU_NAME" DataValueField="PK_MENU_ID"
                        OnSelectedIndexChanged="Menu_selected" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlMenu_3" runat="server" DataTextField="MENU_NAME" DataValueField="PK_MENU_ID"
                        OnSelectedIndexChanged="Menu_selected" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:RadioButtonList ID="RadioButtonList2" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Value="1">Enabled</asp:ListItem>
                        <asp:ListItem Value="2">ReadOnly</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td>


                </td>
            </tr>
            <tr>
                <td class="style3">
                    Section
                </td>
                <td class="style2">
                    <asp:DropDownList ID="ddlSection" runat="server" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged"
                        AutoPostBack="True" OnDataBound="ddlSection_DataBound">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource3" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_SECU_CONFIG"
                        EntityTypeFilter="L_SECU_CONFIG" Where="it.[FK_PK_PARENT_ID] == @ParId">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="ddlScreen" DbType="Int64" Name="ParId" PropertyName="SelectedValue" />
                        </WhereParameters>
                    </asp:EntityDataSource>
                </td>
                <td>
                    <asp:GridView ID="grvTemplet" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="453px" DataKeyNames="PK_ID" 
                        onselectedindexchanged="grvTemplet_SelectedIndexChanged">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="MenuName" HeaderText="Menu Name" />
                            <asp:BoundField DataField="AssignedAction" HeaderText="Sections(action)">
                                <ItemStyle Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OperationMode" HeaderText="Action Mode" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" Font-Names="Arial" 
                            Font-Size="X-Small" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" 
                        onclick="btnReset_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Action
                </td>
                <td class="style2">
                    <asp:RadioButtonList ID="rdbAction" runat="server" 
                        AutoPostBack="True" 
                        onselectedindexchanged="rdbAction_SelectedIndexChanged" Font-Names="Arial" 
                        Font-Size="Smaller">
                    </asp:RadioButtonList>
                    <asp:DataList ID="dtListCopm" runat="server" Width="64%" CellPadding="4" 
                        ForeColor="#333333">
                        <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="#FFFF99" 
                            Font-Size="Smaller" HorizontalAlign="Center" />
                        <HeaderTemplate>
                            This Mehod is being reused many places Please fill the parameter value that 
                            distinguish
                        </HeaderTemplate>
                        <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <ItemTemplate>
                            <div style="width:98%">
                                <asp:HiddenField ID="hdnComparatorID" runat="server" Value='<%# Eval("PK_ID") %>' />
                                <asp:Label ID="lblCmprator" runat="server" Text='<%# Eval("PARAM_KEY")  %>'></asp:Label>
                                <asp:TextBox ID="txtComparatorValue" runat="server" Text=""></asp:TextBox><asp:RequiredFieldValidator
                                 ControlToValidate="txtComparatorValue" ForeColor="Red" ValidationGroup="COMP_VALUE"    ID="RequiredFieldValidator1" runat="server" ErrorMessage="Please insert Param value"></asp:RequiredFieldValidator>                                
                            </div>
                        </ItemTemplate>
                        <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    </asp:DataList>

                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style2">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CausesValidation="true" ValidationGroup="COMP_VALUE">ADD</asp:LinkButton>
                </td>
                <td>
                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Save</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;
                </td>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
