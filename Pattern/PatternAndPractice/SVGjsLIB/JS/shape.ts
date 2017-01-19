import { SHAPE_NAME_GLOBAL,ScreenCoordinate } from './exportd.def';
class Shape {



    private _position: ScreenCoordinate;
    public get position(): ScreenCoordinate {
        return this._position;
    }
    public set position(v: ScreenCoordinate) {
        this._position = v;
    }

    private _name: string;
    public get name(): string {
        return this._name;
    }
    public set name(v: string) {
        this._name = v;
    }
    constructor() {
        this.name = SHAPE_NAME_GLOBAL.Base;
    }
}

class Rect extends Shape {
    private _width: number;
    public get width(): number {
        if (this.name == SHAPE_NAME_GLOBAL.Square)
            return this._height;
        else if (this.name == SHAPE_NAME_GLOBAL.Rect)
            return this._width;
        else
            return 0;
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

    constructor() {
        super();
        this.height = 0;
        this.width = 0;
        this.name = SHAPE_NAME_GLOBAL.Rect;
    }
}
class Square extends Rect {
    constructor() {
        super();
        // this.height = this.width;
        // console.log(this.position.x, this.position.y, this.name);

        this.name = SHAPE_NAME_GLOBAL.Square;
    }

    // get width() {
    //     return this.height;
    // }
}


class Line extends Shape {

    private _positionTo: ScreenCoordinate;
    public get positionTo(): ScreenCoordinate {
        return this._positionTo;
    }
    public set positionTo(v: ScreenCoordinate) {
        this._positionTo = v;
    }

    constructor() {
        super();
        this.positionTo = new ScreenCoordinate();
        this.name = SHAPE_NAME_GLOBAL.Line;
    }
}
class Circle extends Shape {

    private _radius: number;
    public get radius(): number {
        return this._radius;
    }
    public set radius(v: number) {
        this._radius = v;
    }

    constructor() {
        super();
        this.radius = 0;
        this.name = SHAPE_NAME_GLOBAL.Circle;
    }
}

class PolyLine extends Shape {

    private _points: ScreenCoordinate[] = [];
    public get points(): ScreenCoordinate[] {
        return this._points;
    }
    public set points(v: ScreenCoordinate[]) {
        this._points = v;
    }

    constructor() {
        super();
        this.name = SHAPE_NAME_GLOBAL.PolyLine;
    }
}

export { Shape, Square, Rect, ScreenCoordinate, PolyLine, Circle, Line };   