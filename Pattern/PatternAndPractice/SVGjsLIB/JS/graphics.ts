
import { Drawing, DrawProviderFactory, Shape } from './exportd.def';
import { SvgComponent } from './helper';
class graphicsBase {
    private svg: SvgComponent;
    private drawing:Drawing;
    private shape:Shape;
    constructor() {


        if (this.svg == undefined || this.svg == null)
           this.svg = new SvgComponent('svg')
                .addAttr('width', 320)
                .addAttr('height', 320);

        document.body.appendChild(this.svg.elem);
    }
    create(shape) {
        this.shape=shape;

        this.drawing = new DrawProviderFactory().createDrawProvider(shape);
        return this;
    }
    paint() {
        this.drawing.draw(this.svg, this.shape);
        return this;
    }

}
export { graphicsBase };