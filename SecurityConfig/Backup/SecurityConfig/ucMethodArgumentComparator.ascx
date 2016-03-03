<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMethodArgumentComparator.ascx.cs" Inherits="SecurityConfig.ucMethodArgumentComparator" %>
<table cellpadding="0" cellspacing="0" class="style1">
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
                    </table>