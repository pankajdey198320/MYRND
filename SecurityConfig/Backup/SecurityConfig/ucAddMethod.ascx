<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAddMethod.ascx.cs" Inherits="SecurityConfig.ucAddMethod" %>
<asp:TextBox ID="txtMethodName" runat="server" Height="22px"></asp:TextBox>
                       <asp:Button ID="btnAddMethod" runat="server" Text="Add Method" 
                          onclick="btnAddMethod_Click" ValidationGroup="method" />
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                          ErrorMessage="Enter Method Name" ForeColor="Red" ControlToValidate="txtMethodName" ValidationGroup="method"></asp:RequiredFieldValidator>
                      