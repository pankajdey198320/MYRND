<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestJS.aspx.cs" Inherits="SecurityConfig.TestJS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        var originalClick = function (e) {
            e.preventDefault();
            console.log('original button click');
        };

        (function () {
            var extendedClick = originalClick;
            originalClick = function () {
               return false;
            };
        })(); 
        $(document).ready(function () {
          


            $("#Button1").click(function (e) {

                originalClick(e);
            });
        });
        function doSome() {
            alert("I am original");
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="button" id="mbtn1" value="one" onclick="doSome()" />
    <input type="button" id="Button1" value="two" /><asp:DataList ID="DataList1" 
            runat="server" DataSourceID="EntityDataSource1">
            <ItemTemplate>
                PARAM_KEY:
                <asp:Label ID="PARAM_KEYLabel" runat="server" Text='<%# Eval("PARAM_KEY") %>' />
                <br />
                PARAM_INDEX:
                <asp:Label ID="PARAM_INDEXLabel" runat="server" 
                    Text='<%# Eval("PARAM_INDEX") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
&nbsp;<asp:EntityDataSource ID="EntityDataSource1" runat="server" 
            ConnectionString="name=Medappz2_LiveEntities" 
            DefaultContainerName="Medappz2_LiveEntities" EnableFlattening="False" 
            EntitySetName="L_SECU_METHOD_ARG_COMPARATOR" 
            Select="it.[PARAM_KEY], it.[PARAM_INDEX]">
        </asp:EntityDataSource>
    </div>
    </form>
</body>
</html>
