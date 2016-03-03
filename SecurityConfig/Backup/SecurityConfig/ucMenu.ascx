<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenu.ascx.cs" Inherits="SecurityConfig.ucMenu" %>
  <div>
        <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" 
            DynamicHorizontalOffset="2" Font-Names="Verdana" Font-Size="0.8em" 
            ForeColor="#666666" Orientation="Horizontal" StaticSubMenuIndent="10px">
            <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#E3EAEB" />
            <DynamicSelectedStyle BackColor="#1C5E55" />
            <Items>
                <asp:MenuItem Text="MasterConfig" Value="MasterConfig">
                    <asp:MenuItem NavigateUrl="~/ConfigINS.aspx" Text="App" Value="App">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Module.aspx" Text="Module" Value="Module">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/Screen.aspx" Text="Screen" Value="Screen">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/section.aspx" Text="Section" Value="Section">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="~/AddMethod.aspx" Text="Methods" Value="Methods">
                    </asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Mapping" Value="Mapping">
                    <asp:MenuItem NavigateUrl="~/OperationActionMap.aspx" Text="Action Section Map" 
                        Value="Action Section Map"></asp:MenuItem>
                    <asp:MenuItem Text="Templet With Menu" Value="Templet With Menu" 
                        NavigateUrl="~/TempletMenuMap.aspx"></asp:MenuItem>
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#666666" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <StaticSelectedStyle BackColor="#1C5E55" />
        </asp:Menu>
    </div>