System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var graphicsBase;
    return {
        setters: [],
        execute: function () {
            graphicsBase = (function () {
                function graphicsBase(Shape, Drawing) {
                    this.Shape = Shape;
                    this.Drawing = Drawing;
                }
                graphicsBase.prototype.paint = function () {
                    this.Drawing.draw(null, this.Shape);
                };
                return graphicsBase;
            }());
            exports_1("graphicsBase", graphicsBase);
        }
    };
});
//# sourceMappingURL=graphics.js.map