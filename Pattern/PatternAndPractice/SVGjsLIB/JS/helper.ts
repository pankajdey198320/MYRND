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

class ScreenCoordinate {

    private _x: number;
    public get x(): number {
        return this._x;
    }
    public set x(v: number) {
        this._x = v;
    }

    private _y: number;
    public get y(): number {
        return this._y;
    }
    public set y(v: number) {
        this._y = v;
    }
    constructor(a: number = 0, b: number = 0) {
        this._x = a;
        this._y = b;
    }

}
export { SvgComponent,ScreenCoordinate };
