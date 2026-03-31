'use strict';

class Rectangle{
    constructor(length, width){
        this.length = length;
        this.width = width;
    }

    // method
    getArea() {
        return this.length * this.width;
    }

    // Getter
    get area(){
        return this.getArea();
    }
}

Rectangle.prototype.getPerimeter = function _getPerimeter(){
    return 2 * (this.length + this.width);
}

export { Rectangle };