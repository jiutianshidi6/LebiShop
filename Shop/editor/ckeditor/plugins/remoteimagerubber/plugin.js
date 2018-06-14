(function() {
    CKEDITOR.plugins.add("RemoteImageRubber", {
        requires: ["dialog"],
        init: function(a) {
            a.addCommand("RemoteImageRubber", new CKEDITOR.dialogCommand("RemoteImageRubber"));
            a.ui.addButton("RemoteImageRubber", {
                label: "保存远程图片",
                command: "RemoteImageRubber",
                icon: this.path + "RemoteImageRubber.png"
            });
            CKEDITOR.dialog.add("RemoteImageRubber", this.path + "dialogs/RemoteImageRubber.js") 
        }
 
    })
 
})();