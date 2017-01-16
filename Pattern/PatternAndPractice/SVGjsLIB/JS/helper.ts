function HtmlDomElement(tag, namespace) {
    this.elem = namespace.length > 1
        ? document.createElementNS("http://www.w3.org/2000/svg", tag)
        : document.createElement(tag);
    this.addAttr = function (key, value) {
        var _atr = document.createAttribute(key);
        _atr.value = value;
        this.elem.setAttributeNode(_atr);
    }
    this.appendChild = function (e) {

        this.elem.appendChild(e.elem);
    }

}
const SVG_NAMESPACE = "http://www.w3.org/2000/svg";
class SvgComponent {
    elem: SVGElement;
    constructor(tagName: string) {
        this.elem = document.createElementNS(SVG_NAMESPACE, tagName);
    }

    addAttr(key: string, value: any): SvgComponent {
        var _atr = document.createAttribute(key);
        _atr.value = value;
        this.elem.setAttributeNode(_atr);
        return this;
    }
    appendChild(e: SvgComponent): SvgComponent {
        this.elem.appendChild(e.elem);
        return this;
    }
}
export { SvgComponent };
