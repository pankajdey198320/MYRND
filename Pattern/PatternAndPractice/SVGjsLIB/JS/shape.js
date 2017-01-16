System.register([], function (exports_1, context_1) {
    "use strict";
    var __extends = (this && this.__extends) || function (d, b) {
        for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
    var __moduleName = context_1 && context_1.id;
    var Shape, Rect, Square, ScreenCoordinate;
    return {
        setters: [],
        execute: function () {
            Shape = (function () {
                function Shape() {
                }
                Object.defineProperty(Shape.prototype, "width", {
                    get: function () {
                        return this._width;
                    },
                    set: function (v) {
                        this._width = v;
                    },
                    enumerable: true,
                    configurable: true
                });
                Object.defineProperty(Shape.prototype, "height", {
                    get: function () {
                        return this._height;
                    },
                    set: function (v) {
                        this._height = v;
                    },
                    enumerable: true,
                    configurable: true
                });
                Object.defineProperty(Shape.prototype, "position", {
                    get: function () {
                        return this._position;
                    },
                    set: function (v) {
                        this._position = v;
                    },
                    enumerable: true,
                    configurable: true
                });
                return Shape;
            }());
            exports_1("Shape", Shape);
            Rect = (function (_super) {
                __extends(Rect, _super);
                function Rect() {
                    var _this = _super.call(this) || this;
                    _this.height = 0;
                    _this.width = 0;
                    return _this;
                }
                return Rect;
            }(Shape));
            exports_1("Rect", Rect);
            Square = (function (_super) {
                __extends(Square, _super);
                function Square() {
                    var _this = _super.call(this) || this;
                    _this.height = _this.width;
                    return _this;
                    // console.log(this.position.x, this.position.y, this.name);
                }
                return Square;
            }(Rect));
            exports_1("Square", Square);
            ScreenCoordinate = (function () {
                function ScreenCoordinate() {
                }
                Object.defineProperty(ScreenCoordinate.prototype, "x", {
                    get: function () {
                        return this._x;
                    },
                    set: function (v) {
                        this._x = v;
                    },
                    enumerable: true,
                    configurable: true
                });
                Object.defineProperty(ScreenCoordinate.prototype, "y", {
                    get: function () {
                        return this._y;
                    },
                    set: function (v) {
                        this._y = v;
                    },
                    enumerable: true,
                    configurable: true
                });
                return ScreenCoordinate;
            }());
            exports_1("ScreenCoordinate", ScreenCoordinate);
        }
    };
});
//# sourceMappingURL=shape.js.map