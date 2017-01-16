import { ScreenCoordinate, SVGDraw, graphicsBase, Rect, Square } from './exportd.def';

function main() {
    var x = new Square();
    x.height = 100;
    x.width = 500;
    var crd = new ScreenCoordinate(20, 30);

    x.position = crd;
    var gr = new graphicsBase();
    gr.create(x).paint();

}
main();