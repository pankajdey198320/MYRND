<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigINS.aspx.cs" Inherits="SecurityConfig.ConfigINS" %>

<%@ Register src="Config.ascx" tagname="Config" tagprefix="uc1" %>

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
    
    <uc2:ucMenu ID="ucMenu1" runat="server" />
    
    <uc1:Config ID="Config1" runat="server" />
    
    </form>
</body>
</html>
