
function mapProperty(propertyArray, object) {
    if (propertyArray == null)
        return;
    if (typeof (object) == "object") {
        for (var key in object) {
            if (object.hasOwnProperty(key)) {
                if (typeof (object[key]) == 'object') {
                    if (propertyArray[key] != undefined && typeof (propertyArray[key]) == 'object') {
                        mapProperty(propertyArray[key], object[key]);
                    }
                }
                else {
                    object[key] = propertyArray[key];
                }
            }
        }
    }
}

class Position {
    constructor(x, y) {
        this.x = x; this.y = y;

    }
}
class Shape {
    constructor(object) {
        this.position = new Position(0, 0);
        this.name = 'Shape';
        mapProperty(object, this);
    }

    get isShapeObject() {
        return true;
    }
}
class Rect extends Shape {
    constructor(object) {
        super(null);
        this.height = 0;
        this.width = 0;
        mapProperty(object, this);
        this.name = 'rect';
    }
}
class Square extends Rect {
    constructor(obj) {
        super(obj);
        this.height = this.width;
        this.name = 'square';
        console.log(this.position.x, this.position.y, this.name);
    }
}
class Line extends Shape {
    constructor(obj) {
        super(null);
        this.positionTo = new Position(0, 0);


        mapProperty(obj, this);
        this.name = 'line';
    }
}
class Circle extends Shape {
    constructor(obj) {
        super(null);
        this.radius = 0;
        mapProperty(obj, this);
        this.name = 'circle';
    }
}

class PolyLine extends Shape {
    constructor(obj) {
        super(null);
        this.points = [];
        mapProperty(obj, this);
        this.name = 'polygonLine';
    }
}