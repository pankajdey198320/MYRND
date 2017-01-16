System.register([], function (exports_1, context_1) {
    "use strict";
    var __moduleName = context_1 && context_1.id;
    function HtmlDomElement(tag, namespace) {
        this.elem = namespace.length > 1
            ? document.createElementNS("http://www.w3.org/2000/svg", tag)
            : document.createElement(tag);
        this.addAttr = function (key, value) {
            var _atr = document.createAttribute(key);
            _atr.value = value;
            this.elem.setAttributeNode(_atr);
        };
        this.appendChild = function (e) {
            this.elem.appendChild(e.elem);
        };
    }
    var SVG_NAMESPACE, SvgComponent;
    return {
        setters: [],
        execute: function () {
            SVG_NAMESPACE = "http://www.w3.org/2000/svg";
            SvgComponent = (function () {
                function SvgComponent(tagName) {
                    this.elem = document.createElementNS(SVG_NAMESPACE, tagName);
                }
                SvgComponent.prototype.addAttr = function (key, value) {
                    var _atr = document.createAttribute(key);
                    _atr.value = value;
                    this.elem.setAttributeNode(_atr);
                    return this;
                };
                SvgComponent.prototype.appendChild = function (e) {
                    this.elem.appendChild(e.elem);
                    return this;
                };
                return SvgComponent;
            }());
            exports_1("SvgComponent", SvgComponent);
        }
    };
});
//# sourceMappingURL=helper.js.map