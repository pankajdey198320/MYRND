System.register(["./exportd.def"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function main() {
        var y = new exportd_def_1.Rect();
        y.height = 100;
        y.width = 200;
        var ct = new exportd_def_1.ScreenCoordinate();
        ct.x = 23;
        ct.y = 45;
        y.position = ct;
        var dx = new exportd_def_1.SVGDraw();
        var gx = new exportd_def_1.graphicsBase(y, dx);
        gx.paint();
    }
    var exportd_def_1;
    return {
        setters: [
            function (exportd_def_1_1) {
                exportd_def_1 = exportd_def_1_1;
            }
        ],
        execute: function () {
        }
    };
});
//# sourceMappingURL=index.js.map