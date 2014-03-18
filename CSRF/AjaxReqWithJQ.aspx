<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AjaxReqWithJQ.aspx.cs"
    Inherits="TetsApp.AjaxReqWithJQ" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.7.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

//            $.getJSON("http://www.myface.com/CORS/JSONP.asmx/HelloWorld?callback=?", null, function (customers) {
//                    alert('Received ' + customers.length + ' Customers');

//                   
//                });
            $.ajax({
                type: "GET",
                url: "http://www.myface.com/CORS/JSONP.asmx/HelloWorld?callback=?",               
                contentType: "application/json;",
                dataType: "json",
                success: function (msg) {
                    alert(msg.Prop1); 
                 }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    </form>
</body>
</html>
