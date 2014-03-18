<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.aspx.cs" Inherits="TetsApp.FileUpload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="file" id="myFile" />
    </div>
    </form>
    <script type="text/jscript">
        if (new XMLHttpRequest().upload) {
            // welcome home!
        } else {
            alert("Browser Not supported");
        }

        var fileObj = document.getElementById("myFile");
        fileObj.onchange = callBack2;
        var xhr = new XMLHttpRequest();
        // xhr.upload.addEventListener("progress", onUploadProgress);

        function callbackFunction(event) {
            var FileList = event.target.files;
            var File = FileList[0];
            xhr.open('post', 'http://www.myface.com/FileUpload.aspx', true);
            xhr.setRequestHeader("Content-Type", "application/octet-stream");
            xhr.setRequestHeader("X-File-Name", File.name || File.fileName);
           // xhr.setRequestHeader("X-File-Size", File.size || File.fileSize);
            xhr.setRequestHeader("X-File-Type", File.type);
            var formdata = new FormData();
            formdata.append('file', File);
            //            if ('getAsBinary' in File)
            //                xhr.sendAsBinary(File.getAsBinary());
            //            else
            //                xhr.send(File);
            xhr.send(formdata);
        }
        function callBack2(event) {
            var blob = this.files[0];

            var BYTES_PER_CHUNK = 1024 * 1024; // 1MB chunk sizes.
            var SIZE = blob.size;

            var start = 0;
            var end = BYTES_PER_CHUNK;

            while (start < SIZE) {
                upload(blob.slice(start, end));

                start = end;
                end = start + BYTES_PER_CHUNK;
            }

        }
        function upload(blobOrFile) {
            var xhr = new XMLHttpRequest();
            xhr.open('POST', 'http://www.myface.com/FileUpload.aspx', true);
            xhr.setRequestHeader("X-File-Name", 'p');
            //  xhr.setRequestHeader("X-File-Size", File.size || File.fileSize);
            xhr.setRequestHeader("X-File-Type", '');
            //xhr.onload = function(e) { ... };
            xhr.send(blobOrFile);
        }

        function onUploadProgress(event) {
            if (event.lengthComuptable) {
                log(Math.round((event.loaded * 100) / event.total) + '%');
            }
        }
       
    </script>
</body>
</html>
