'use strict';

console.log("Naming  Identifiers");
let tax = 1.4;
let tax2 = 3.4;
let $tax3 = 5.6;
let _tax4 = 7.8;
console.log(`tax=${tax}, tax2=${tax2}, $tax3=${$tax3}, _tax4=${_tax4}`);

console.log('\nObject Initializer');
let o1 = {};
let o2 = {name: "jeff", age: 23, grades: ['A', 'B', 'C']}
console.log(o1);
console.log(o2);
console.log(o2.name);
console.log(o2["name"]);
console.log(o2.grades[1]);

console.log("\nFunctions");

sayHello('Will');
// Function definition
function sayHello(name){
    console.log("Hello, " + name + "!");
}
sayHello("Kaylee");

// you can't use sayhello2 here

// Function expressions
let sayHello2 = function(name){
    console.log("hello, " + name + "!!")
};

sayHello2("Kailee");

let sayHello3 = (name) => {
    console.log("Hello, " + name + "!!!");
}

sayHello3("Wilma");

// This is a self-invoking function to create a localized scope.
(function _selfInvoking(){
    console.log("Self-invoking function");
})()

console.log("\nArrays");
let fruits = ["apple", "banana", "cherry"];
let mixed = [42, "hello", true, null];
let scores = [];

console.log(fruits);
console.log(fruits[0]);
console.log(mixed[2]);
console.log(mixed.length);

let fruits2 = ["apple", "banana"];
console.log(fruits2);
fruits2.push("cherry");
console.log(fruits2);
fruits2.pop();
console.log(fruits2);
fruits2.unshift("mango");
console.log(fruits2);
fruits2.shift();
console.log(fruits2);

console.log(fruits2.includes("apple"));
console.log(fruits2.indexOf("banana"));

for(let i = 0; i < fruits.length; i++){
    console.log(fruits[i]);
}

for(let fruit of fruits){
    console.log(fruit);
}

fruits.forEach((fruit) => {
    console.log(fruit); 
});


// Transforming arrays

let numbers = [1, 2, 3, 4, 5];
let doubled = numbers.map((n) => {
    return n * 2; 
});
console.log(doubled);

let numbers2 = [1, 2, 3, 4, 5, 6];
let evens = numbers2.filter((n) => {
    return n % 2 === 0;
});
console.log(evens);

let total = numbers.reduce((accumulator, n) => {
    return accumulator + n;
}, 0);

console.log(total);

let students = [
    {name: "Alice", grade: 88},
    {name: "Bob", grade: 74,
    {name: "Carol", grade: 95}
]

let names = students.map((student) => {
    return students.name;
});
console.log(names);

let passing = students.filter((student) => {
    return student.grade >= 75;
})
console.log(passing);

let distinctions = students.reduce((count, student) => {
    return student.grade >= 90 ? count + 1 : count;
}, 0);
console.log(distinctions);