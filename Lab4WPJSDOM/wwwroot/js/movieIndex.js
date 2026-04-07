'use strict';

let movies = [
    {
        id: 1,
        title: "The Shawshank Redemption",
        director: "Frank Darabont",
        releaseDate: "1994-09-23",
        isAvailable: true
    },
    {
        id: 2,
        title: "The Godfather",
        director: "Francis Ford Coppola",
        releaseDate: "1972-03-24",
        isAvailable: true
    },
    {
        id: 3,
        title: "The Dark Knight",
        director: "Christopher Nolan",
        releaseDate: "2008-07-18",
        isAvailable: false
    },
    {
        id: 4,
        title: "Pulp Fiction",
        director: "Quentin Tarantino",
        releaseDate: "1994-10-14",
        isAvailable: true
    }
];
// Your code will go here

// movies = [];

import { MovieDOM } from "./MovieDOM.js";
let MovieObj = new MovieDOM();
// const form = document.querySelector("#jobApplicationForm");
const movieGrid = document.querySelector("#moviesGrid");
MovieObj.showMovies(movieGrid, movies);
MovieObj.setUpEventListeners();