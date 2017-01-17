import { ScreenCoordinate, SVGDraw, graphicsBase, Rect, Square, PolyLine } from './exportd.def';

function main() {
    var x = new Square();
    x.height = 100;
    x.width = 500;
    var crd = new ScreenCoordinate(20, 30);

    let y = new PolyLine();
    y.points.push(new ScreenCoordinate(100, 10));
    y.points.push(new ScreenCoordinate(40, 198));
    y.points.push(new ScreenCoordinate(190, 78));
    y.points.push(new ScreenCoordinate(10, 78));
    y.points.push(new ScreenCoordinate(160, 198));
    y.position = crd;
    var gr = new graphicsBase();
    gr.create(y).paint();

}
main();