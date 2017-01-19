import { Drawing, SVGDraw, drawLine, drawRect, drawCircle, SHAPE_NAME_GLOBAL,drawPolygon,drawPolyLine } from './exportd.def';
class DrawProviderFactory {
    createDrawProvider(shape)// Should be shape type
    {

        switch (shape.name) {
            case SHAPE_NAME_GLOBAL.Base: {
                return new SVGDraw();
            }
            case SHAPE_NAME_GLOBAL.Line: {
                return new drawLine();
            }
            case SHAPE_NAME_GLOBAL.Rect:
            case SHAPE_NAME_GLOBAL.Square: {
                return new drawRect();
            } case SHAPE_NAME_GLOBAL.Circle: {
                return new drawCircle();
            }
            case SHAPE_NAME_GLOBAL.Polygon: {
                return new drawPolygon();
            }
             case SHAPE_NAME_GLOBAL.PolyLine: {
                return new drawPolyLine();
            }
            default: {
                return new SVGDraw();
            }
        }
    }
}

export { DrawProviderFactory };