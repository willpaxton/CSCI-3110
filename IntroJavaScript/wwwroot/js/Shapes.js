'use strict';

class Shape{
    #name = "Shape";

    constructor(name){
        this.setName(name);
    }

    setName(name){
        this.#name = name;
    }

    getName(){
        return this.#name;
    }
}

class Rectangle extends Shape{
    #length = 0;
    #width = 0;

    constructor(length, width){
        super("Rectangle");
        this.#length = length;
        this.#width = width;


    }

    getArea(){
        return this.#length * this.#width;
    }

    getLength(){
        return this.#length;
    }    
    
    getWidth(){
        return this.#width;
    }
}

class Circle extends Shape{
    #radius = 0;

    constructor(radius){
        super("Circle");
        this.#radius = radius;
    }

    getArea(){
        return Math.PI * this.#radius * this.#radius;
    }

    getRadius(){
        return this.#radius;
    }
}

export {Shape, Rectangle, Circle}   