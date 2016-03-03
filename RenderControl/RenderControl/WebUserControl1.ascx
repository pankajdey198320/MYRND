<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControl1.ascx.cs" Inherits="RenderControl.WebUserControl1" %>
<div>
    Helo there!
    <% RenderControl.MailModel x = Session["try"] as RenderControl.MailModel;
        if (x == null)
            x = new RenderControl.MailModel();
    %>

    <%=   x.FirstName+" "+ x.LastName %>
    <asp:Label ID="msg" runat="server" Text="Invalid"></asp:Label>
</div>
