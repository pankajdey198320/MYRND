<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperationActionMap.aspx.cs" Inherits="SecurityConfig.OperationActionMap" %>

<%@ Register src="ucMenu.ascx" tagname="ucMenu" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    
    <div>
    
        <uc1:ucMenu ID="ucMenu1" runat="server" />
    
        <table class="style1">
            <tr>
                <td>
                    Module</td>
                <td>
                    <asp:DropDownList ID="ddlModule" runat="server" 
                        DataSourceID="EntityDataSource1" DataTextField="NAME" 
                        DataValueField="PK_ID" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:EntityDataSource ID="EntityDataSource1" runat="server" CommandText="" 
                        ConnectionString="name=Medappz2_LiveEntities" 
                        DefaultContainerName="Medappz2_LiveEntities" EntitySetName="L_SECU_CONFIG" 
                        EntityTypeFilter="L_SECU_CONFIG" Select="it.[NAME], it.[PK_ID]" 
                        Where="it.[FK_SCE_CONFIG_TYPE] ==2" EnableFlattening="False">
                    </asp:EntityDataSource>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Screen</td>
                <td>
                     <asp:DropDownList ID="ddlScreen" runat="server" AutoPostBack="True" 
                         DataSourceID="EntityDataSource2" DataTextField="NAME" DataValueField="PK_ID" 
                         ondatabound="ddlScreen_DataBound" 
                         onselectedindexchanged="ddlScreen_SelectedIndexChanged">
                    </asp:DropDownList>
                     <asp:EntityDataSource ID="EntityDataSource2" runat="server" 
                         ConnectionString="name=Medappz2_LiveEntities" 
                         DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" 
                         EntitySetName="L_SECU_CONFIG" EntityTypeFilter="L_SECU_CONFIG" 
                         Where="it.[FK_PK_PARENT_ID] == @parentid">
                         <WhereParameters>
                             <asp:ControlParameter ControlID="ddlModule" DbType="Int64" DefaultValue="-1" 
                                 Name="parentid" PropertyName="SelectedValue" />
                         </WhereParameters>
                     </asp:EntityDataSource>
                </td>
                <td>
                     <b>Method Name</b></td>
            </tr>
            <tr>
                <td>
                    Section</td>
                <td>
                      <asp:DropDownList ID="ddlSection" runat="server" 
                          
                          onselectedindexchanged="ddlSection_SelectedIndexChanged" 
                          AutoPostBack="True" ondatabound="ddlSection_DataBound">
                    </asp:DropDownList>
                      <asp:EntityDataSource ID="EntityDataSource3" runat="server" 
                          ConnectionString="name=Medappz2_LiveEntities" 
                          DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" 
                          EntitySetName="L_SECU_CONFIG" EntityTypeFilter="L_SECU_CONFIG" 
                          Where="it.[FK_PK_PARENT_ID] == @ParId">
                          <WhereParameters>
                              <asp:ControlParameter ControlID="ddlScreen" DbType="Int64" Name="ParId" 
                                  PropertyName="SelectedValue" />
                          </WhereParameters>
                      </asp:EntityDataSource>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  SetFocusOnError="true"
                          ErrorMessage="Section Not Selected" ForeColor="Red" ControlToValidate="ddlSection" ValidationGroup="method" ></asp:RequiredFieldValidator>
                </td>
                <td>
                      <asp:DropDownList ID="ddlMethods" runat="server" 
                          >
                      </asp:DropDownList>
                     
                      <asp:EntityDataSource ID="EntityDataSource5" runat="server" 
                          ConnectionString="name=Medappz2_LiveEntities" 
                          DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" 
                          EntitySetName="L_SECU_ALL_METHODS" EntityTypeFilter="" Select="" 
                          Where="it.[FK_CONFIG_ID] == @ParId">
                          <WhereParameters>
                              <asp:ControlParameter ControlID="ddlSection" DbType="Int64" Name="ParId" 
                                  PropertyName="SelectedValue" />
                          </WhereParameters>
                      </asp:EntityDataSource>
                      <%-- <asp:TextBox ID="txtMethodName" runat="server" Height="22px"></asp:TextBox>
                       <asp:Button ID="btnAddMethod" runat="server" Text="Add Method" 
                          onclick="btnAddMethod_Click" ValidationGroup="method" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ErrorMessage="Enter Method Name" ForeColor="Red" ControlToValidate="txtMethodName" ValidationGroup="method"></asp:RequiredFieldValidator>--%>
                      
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    Action</td>
                <td>
                    <asp:EntityDataSource ID="EntityDataSource4" runat="server" 
                        ConnectionString="name=Medappz2_LiveEntities" 
                        DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" 
                        EntitySetName="l_SECU_OPERATION_ACTION">
                    </asp:EntityDataSource>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                        DataSourceID="EntityDataSource4" DataTextField="ACTION_NAME" 
                        DataValueField="PK_ID" RepeatDirection="Horizontal">
                    </asp:RadioButtonList>
                </td>
                <td>
                    <%--<table cellpadding="0" cellspacing="0" class="style1">
                        <tr>
                            <td>
                                Key<asp:TextBox ID="txtXompKey" runat="server" Width="60%"></asp:TextBox>
                            </td>
                            <td>
                                Index
                                <asp:TextBox ID="txtCompIndex" runat="server" Width="60%"></asp:TextBox>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlParamType" runat="server" Width="50px">
                                    <asp:ListItem Value="1">Query String</asp:ListItem>
                                    <asp:ListItem Value="2">Method Signature</asp:ListItem>
                                    <asp:ListItem Value="3">Session</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnCompAdd" runat="server" Height="19px" 
                                    onclick="btnCompAdd_Click" Text="Add" Width="44px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:DataList ID="dtListCopm" runat="server" CellPadding="4" 
                                    ForeColor="#333333" RepeatDirection="Horizontal" Width="384px">
                                    <AlternatingItemStyle BackColor="White" />
                                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                    <ItemStyle BackColor="#E3EAEB" />
                                    <ItemTemplate>
                                        <div style="height: 62px; width: 65px">
                                            <div style="height: 22px;">
                                                <asp:Label ID="lblKey" runat="server" Text='<%# Eval("ParamKey") %>'></asp:Label>
                                            </div>
                                            <div style="height: 22px;">
                                                <asp:Label ID="lblIndex" runat="server" Text='<%# Eval("ParamIndex") %>'></asp:Label>
                                            </div>
                                            <div style="height: 22px;">
                                                <asp:Label ID="lblValue" runat="server" Text='<%# Eval("ParamValue") %>'></asp:Label>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                    <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                </asp:DataList>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" onclick="OpMapSave"  Text="Save"/>
                    <asp:Button ID="btnCancel" runat="server"   Text="Cancel" 
                        onclick="btnCancel_Click"/>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="grdOpAcMap" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateDeleteButton="True" 
                        AutoGenerateSelectButton="True" CellPadding="4" DataKeyNames="PK_ID" 
                        DataMember="PK_ID" ForeColor="#333333" GridLines="None" 
                        onpageindexchanging="GridView1_PageIndexChanging" 
                        onrowdeleted="GrdOpMap_RowDeleting" onrowdeleting="GrdOpMap_RowDeleting" 
                        onselectedindexchanged="OpActionMapSelected">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
