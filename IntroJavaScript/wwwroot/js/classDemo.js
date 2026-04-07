'use strict';

import { Rectangle  } from "./Rectangle.js";
import { Rectangle2 } from "./Rectangle2.js";

let r1 = new Rectangle(2, 3);
let r2 = new Rectangle(6.7, 21.3);
console.log(r1.getArea());
console.log(r1.area);
console.log(r1.getPerimeter());
console.log(r2.getArea());
console.log(r2.area);
console.log(r2.getPerimeter());

let r3 = new Rectangle2(3, 4);
let r4 = new Rectangle2(3.1, 4.2);
console.log(r3.getArea()); // using method
console.log(r3.area); // using getter
console.log(r3.getPerimeter()); // using prototypical method
// console.log(r3.#length); // error!

r4.length = 5.7;
console.log(r4.area);