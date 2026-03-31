'use strict';

class Rectangle{
    #length = 0;
    #width = 0;

    constructor(length, width){
        this.#length = length;
        this.#width = width;
    }

    getArea(){
        return this.#length * this.#width;
    }

    set length(length){
        this.#length = length;
    }

    set width(width){
        this.#width = width;
    }

    get area(){
        return this.getArea();
    }
}

Rectangle2.prototype.getPerimeter = function _getPerimeter(){
    return 2 * (this.length * this.width);
}

export {Rectangle2};