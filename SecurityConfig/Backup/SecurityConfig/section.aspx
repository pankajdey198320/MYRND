﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="section.aspx.cs" Inherits="SecurityConfig.section" %>

<%@ Register Src="Config.ascx" TagName="Config" TagPrefix="uc1" %>
<%@ Register src="ucMenu.ascx" tagname="ucMenu" tagprefix="uc2" %>
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
        <uc2:ucMenu ID="ucMenu1" runat="server" />
        <table class="style1">
            <tr>
                <td>
                    ApplicationName
                </td>
                <td>
                    <asp:DropDownList ID="ddlApp" runat="server" DataSourceID="EfConfigsrc" DataTextField="NAME"
                        DataValueField="PK_ID" AutoPostBack="True" OnDataBound="ddlApp_DataBound" OnSelectedIndexChanged="ddlApp_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EfConfigsrc" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_SECU_CONFIG"
                        Select="it.[PK_ID], it.[NAME]" Where="it.[FK_PK_PARENT_ID] == -1">
                    </asp:EntityDataSource>
                </td>
            </tr>
            <tr>
                <td>
                    Module</td>
                <td>
                    <asp:DropDownList ID="ddlModule" runat="server" DataSourceID="EntityDataSource1"
                        DataTextField="NAME" DataValueField="PK_ID" AutoPostBack="True" OnDataBound="ddlModule_DataBound"
                        OnSelectedIndexChanged="ddlModule_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_SECU_CONFIG"
                        Select="it.[PK_ID], it.[NAME]" Where="it.[FK_PK_PARENT_ID] == @app">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="ddlApp" DbType="Int64" Name="app" PropertyName="SelectedValue" />
                        </WhereParameters>
                    </asp:EntityDataSource>
                </td>
            </tr>

              <tr>
                <td>
                    Screen</td>
                <td>
                    <asp:DropDownList ID="ddlScreen" runat="server" DataSourceID="EntityDataSource2"
                        DataTextField="NAME" DataValueField="PK_ID" AutoPostBack="True" 
                        ondatabound="ddlScreen_DataBound" 
                        onselectedindexchanged="ddlScreen_SelectedIndexChanged" >
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource2" runat="server" ConnectionString="name=Medappz2_LiveEntities"
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" EntitySetName="L_SECU_CONFIG"
                        Select="it.[PK_ID], it.[NAME]" Where="it.[FK_PK_PARENT_ID] == @app">
                        <WhereParameters>
                            <asp:ControlParameter ControlID="ddlModule" DbType="Int64" Name="app" PropertyName="SelectedValue" />
                        </WhereParameters>
                    </asp:EntityDataSource>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <uc1:Config ID="Config1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
