import { ScreenCoordinate, SVGDraw, graphicsBase, Rect } from './exportd.def';

function main() {
    var y = new Rect();
    y.height = 100;
    y.width = 200;
    let ct = new ScreenCoordinate();
    ct.x = 23; ct.y = 45;
    y.position = ct;
    


    var dx = new SVGDraw();
    var gx = new graphicsBase(y, dx);
    gx.paint();
}
main();