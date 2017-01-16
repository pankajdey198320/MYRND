
import { Shape } from './shape';
import { SvgComponent } from './helper';
interface Drawing {
    draw(svg: SvgComponent, shape: Shape);
}

class SVGDraw implements Drawing {
    draw(svg, shape) {
        if (svg == undefined || svg == null)
            svg = new SvgComponent('svg');
        svg.addAttr('width', 320);
        svg.addAttr('height', 320);

        var rect = new SvgComponent('rect')
            .addAttr('x', shape.position.x)
            .addAttr('y', shape.position.y)
            .addAttr('width', shape.width)
            .addAttr('height', shape.height)
            .addAttr('fill', '#95B3D7');

        svg.appendChild(rect);
        document.body.appendChild(svg.elem);
        return svg;
    }

}

export { Drawing, SVGDraw };