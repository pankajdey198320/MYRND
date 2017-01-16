System.register(["./helper"], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    var helper_1, SVGDraw;
    return {
        setters: [
            function (helper_1_1) {
                helper_1 = helper_1_1;
            }
        ],
        execute: function () {
            SVGDraw = (function () {
                function SVGDraw() {
                }
                SVGDraw.prototype.draw = function (svg, shape) {
                    if (svg == undefined || svg == null)
                        svg = new helper_1.SvgComponent('svg');
                    svg.addAttr('width', 320);
                    svg.addAttr('height', 320);
                    var rect = new helper_1.SvgComponent('rect')
                        .addAttr('x', shape.position.x)
                        .addAttr('y', shape.position.y)
                        .addAttr('width', shape.width)
                        .addAttr('height', shape.height)
                        .addAttr('fill', '#95B3D7');
                    svg.appendChild(rect);
                    document.body.appendChild(svg.elem);
                    return svg;
                };
                return SVGDraw;
            }());
            exports_1("SVGDraw", SVGDraw);
        }
    };
});
//# sourceMappingURL=draw.js.map