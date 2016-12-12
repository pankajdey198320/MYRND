
class DrawBase {
    //constructor(shape) {
    //    if (typeof (shape) != 'object') {
    //        console.log('Doh! it \'s not objecy');
    //        throw new DOMException();
    //    }
    //    else if (shape.isShapeObject == undefined || shape.isShapeObject != true) {
    //        console.log('this is not valid shape')
    //        throw new DOMException();
    //    }
    //    else {
    //        this.Shape = shape;
    //    }
    //}
    get isDrawObject() {
        return true;
    }
    draw(svg, shape) { }
}

/////Factory to create draw provider base on shape provided
class DrawProviderFactory {
    createDrawProvider(shape)// Should be shape type
    {
        if (shape.isShapeObject == undefined || shape.isShapeObject == false) {
            throw DOMException();
        }
        switch (shape.name) {
            case 'shape': {
                return new DrawBase();
            }
            case 'line': {
                return new drawLine();
            }
            case 'rect':
            case 'square':
                {
                    return new drawRect();
                } case 'circle': {
                    return new drawCircle();
                }
            default: {
                return new DrawBase();
            }
        }
    }
}

class SVGDraw extends DrawBase {
    //constructor(shape) {
    //    super(shape);

    //}

    draw(svg, shape) {
        if (svg == undefined || svg == null)
            svg = new HtmlDomElement('svg', "http://www.w3.org/2000/svg");
        svg.addAttr('width', 320);
        svg.addAttr('height', 320);

        var rect = new HtmlDomElement('rect', "http://www.w3.org/2000/svg");
        rect.addAttr('x', shape.position.x);
        rect.addAttr('y', shape.position.y);
        rect.addAttr('width', shape.width);
        rect.addAttr('height', shape.height);

        rect.addAttr('fill', '#95B3D7');

        svg.appendChild(rect);
        //document.body.appendChild(svg.elem);
        return svg;
    }

}

class drawLine extends DrawBase {
    //<line x1="0" y1="0" x2="200" y2="200" style="stroke:rgb(255,0,0);stroke-width:2" />
    draw(svg, shape) {
        if (shape.name != 'Line') {
            throw new DOMException();
        }
        // svg = new HtmlDomElement('svg', "http://www.w3.org/2000/svg");
        l1.addAttr('x1', shape.position.x);
        l1.addAttr('y1', shape.position.y);
        l1.addAttr('x2', shape.positionTo.x);
        l1.addAttr('y2', shape.positionTo.y);
        l1.addAttr('stroke-width', '2');
        l1.addAttr('stroke', 'black');

        svg.appendChild(l1);
        // document.body.appendChild(svg.elem);
        return svg;

    }
}

class drawRect extends DrawBase {
    draw(svg, shape) {
        var rect = new HtmlDomElement('rect', "http://www.w3.org/2000/svg");
        rect.addAttr('x', shape.position.x);
        rect.addAttr('y', shape.position.y);
        rect.addAttr('width', shape.width);
        rect.addAttr('height', shape.height);

        rect.addAttr('fill', '#95B3D7');

        svg.appendChild(rect);
    }
}

class drawCircle extends DrawBase {
    draw(svg, shape) {
        var cir = new HtmlDomElement('circle', "http://www.w3.org/2000/svg");
        cir.addAttr('cx', shape.position.x);
        cir.addAttr('cy', shape.position.y);

        cir.addAttr('r', shape.radius);

        cir.addAttr('fill', 'black');

        svg.appendChild(cir);
    }
}

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