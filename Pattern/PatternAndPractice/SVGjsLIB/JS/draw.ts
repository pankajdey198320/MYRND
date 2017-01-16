
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
class drawLine implements Drawing {
    //<line x1="0" y1="0" x2="200" y2="200" style="stroke:rgb(255,0,0);stroke-width:2" />
    draw(svg, shape) {

        let l1 = new SvgComponent('svg');
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

class drawRect implements Drawing {
    draw(svg, shape) {
        var rect = new SvgComponent('rect');
        rect.addAttr('x', shape.position.x);
        rect.addAttr('y', shape.position.y);
        rect.addAttr('width', shape.width);
        rect.addAttr('height', shape.height);

        rect.addAttr('fill', '#95B3D7');

        svg.appendChild(rect);
    }
}

class drawCircle implements Drawing {
    draw(svg, shape) {
        var cir = new SvgComponent('circle');
        cir.addAttr('cx', shape.position.x);
        cir.addAttr('cy', shape.position.y);

        cir.addAttr('r', shape.radius);

        cir.addAttr('fill', 'black');

        svg.appendChild(cir);
    }
}

export { Drawing, SVGDraw, drawLine, drawRect, drawCircle };