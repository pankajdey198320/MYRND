class Shape {

    private _width: number;
    public get width(): number {
        return this._width;
    }
    public set width(v: number) {
        this._width = v;
    }

    private _height: number;
    public get height(): number {
        return this._height;
    }
    public set height(v: number) {
        this._height = v;
    }


    private _position: ScreenCoordinate;
    public get position(): ScreenCoordinate {
        return this._position;
    }
    public set position(v: ScreenCoordinate) {
        this._position = v;
    }
}

class Rect extends Shape {
    constructor() {
        super();
        this.height = 0;
        this.width = 0;
    }
}
class Square extends Rect {
    constructor() {
        super();
        this.height = this.width;
        // console.log(this.position.x, this.position.y, this.name);
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

}
class Line extends Shape {
    
    private _positionTo : ScreenCoordinate;
    public get positionTo() : ScreenCoordinate {
        return this._positionTo;
    }
    public set positionTo(v : ScreenCoordinate) {
        this._positionTo = v;
    }
    
    constructor() {
        super();
        this.positionTo = new ScreenCoordinate();
    }
}
class Circle extends Shape {
    
    private _radius : number;
    public get radius() : number {
        return this._radius;
    }
    public set radius(v : number) {
        this._radius = v;
    }
    
    constructor() {
        super();
        this.radius = 0;
    }
}

class PolyLine extends Shape {
    
    private _points : ScreenCoordinate[]=[];
    public get points() : ScreenCoordinate[] {
        return this._points;
    }
    public set points(v : ScreenCoordinate[]) {
        this._points = v;
    }
    
    constructor() {
        super();
    }
}

export { Shape,Square,Rect,ScreenCoordinate,PolyLine,Circle,Line };