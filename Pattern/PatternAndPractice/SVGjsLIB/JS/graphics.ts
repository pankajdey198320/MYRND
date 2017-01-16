
import { Shape } from './shape';
import { Drawing } from './draw';
class graphicsBase {
    constructor(private Shape, private Drawing: Drawing) {

    }

    paint() {
        this.Drawing.draw(null, this.Shape);
    }
}
export {graphicsBase};