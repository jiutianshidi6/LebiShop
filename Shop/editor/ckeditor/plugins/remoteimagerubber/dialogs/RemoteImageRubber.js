(function () {
    CKEDITOR.dialog.add("RemoteImageRubber",
    function (a) {
        return {
            title: "保存远程图片",
            minWidth: "290px",
            minHeight: "70px",
            contents: [{
                id: "RemoteImageRubber",
                label: "",
                title: "",
                expand: true,
                width: "290px",
                height: "70px",
                padding: 0,
                elements: [{
                    type: "html",
                    style: "width:290px;height:70px;overflow:hidden;",
                    html: '<iframe name="mutiimageupload" id="mutiimageupload" src="' + WebPath + '/editor/ckeditor/plugins/RemoteImageRubber/RemoteImageRubber.aspx?n=ckeditor&i=1" frameborder="0" width="290" height="70px" scrolling="no" allowtransparency="true"></iframe><input name="mutiimage" id="mutiimage" type="hidden" value="" />'

                }]
            }],

            onOk: function () {
                //点击确定按钮后的操作
                var htmlstr = $("#mutiimage").val();
                a.insertHtml(htmlstr);
                $("#mutiimage").val("");
            }
        }
    })
})();