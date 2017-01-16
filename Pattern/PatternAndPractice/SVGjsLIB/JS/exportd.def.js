System.register(["./draw", "./graphics", "./shape"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (draw_1_1) {
                exports_1({
                    "SVGDraw": draw_1_1["SVGDraw"]
                });
            },
            function (graphics_1_1) {
                exports_1({
                    "graphicsBase": graphics_1_1["graphicsBase"]
                });
            },
            function (shape_1_1) {
                exports_1({
                    "Shape": shape_1_1["Shape"],
                    "Square": shape_1_1["Square"],
                    "Rect": shape_1_1["Rect"],
                    "ScreenCoordinate": shape_1_1["ScreenCoordinate"]
                });
            }
        ],
        execute: function () {
        }
    };
});
//# sourceMappingURL=exportd.def.js.map