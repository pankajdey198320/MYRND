import { Drawing, SVGDraw, drawLine, drawRect, drawCircle } from './exportd.def';
class DrawProviderFactory {
    createDrawProvider(shape)// Should be shape type
    {

        switch (shape.name) {
            case 'shape': {
                return new SVGDraw();
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
                return new SVGDraw();
            }
        }
    }
}

export { DrawProviderFactory };