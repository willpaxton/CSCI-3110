'use strict';

export class MovieDOM {
    #movies = [];
    

    showMovies(parentElement, movies){
        this.#movies = movies;
        console.log(parentElement);
        console.log(movies);
        const skillContainer = document.getElementById('moviesGrid');

        if(this.#movies.length == 0){
            skillContainer.appendChild(this.#createEmptyState());
            return; // no movies, so exit immediately
        }

        for (var i = 0; i < this.#movies.length; i++){
            skillContainer.appendChild(this.#createMovieCard(this.#movies[i]));
            
        }
    }

    #createEmptyState(){
        const emptyMoviesDiv = document.createElement("div");
        emptyMoviesDiv.className = "col-12 text-center py-5";
        emptyMoviesDiv.id = "emptyState";
        emptyMoviesDiv.style.display = "block";
        emptyMoviesDiv.innerHTML = `
            <i class="bi bi-film display-1 text-muted"></i>
            <h4 class="mt-3 text-muted">No Movies Found</h4>
            <p class="text-muted">Start by adding your first movie above!</p>
        `;
        console.log("returning empty state");
        return emptyMoviesDiv;
    }

    #createMovieCard(movie){
        const movieCardDiv = document.createElement("div");
        movieCardDiv.className = "col-lg-3 col-md-4 col-sm-6 mb-4"
        movieCardDiv.style.display = "block";
        movieCardDiv.id = `movie-${movie.id}`
        // Format the release date
        const releaseDate = new Date(movie.releaseDate + 'T00:00:00');
        console.log(releaseDate);
        const formattedDate = releaseDate.toLocaleDateString('en-US', {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });
        var availabilityString = "";
        var availabilityClass = "";
        if (movie.isAvailable == true){
            availabilityString = "Available";
            availabilityClass = "bg-success";
        } else {
            availabilityString = "Unavailable";
            availabilityClass = "bg-danger";
        }
        movieCardDiv.innerHTML = `
            <div class="card h-100 shadow-sm movie-card">
                <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                    <h6 class="mb-0 text-truncate">${movie.title}</h6>
                    <span class="badge ${availabilityClass}">${availabilityString}</span>
                </div>
                <div class="card-body">
                    <p class="mb-2">
                        <strong><i class="bi bi-person-fill"></i> Director:</strong><br>
                        ${movie.director}
                    </p>
                    <p class="mb-3">
                        <strong><i class="bi bi-calendar-event"></i> Release Date:</strong><br>
                        ${formattedDate}
                    </p>
                </div>
                <div class="card-footer bg-transparent border-top-0">
                    <div class="d-flex gap-2">
                        <button class="btn btn-sm btn-outline-primary flex-fill" title="Edit">
                            <i class="bi bi-pencil-square"></i> Edit
                        </button>
                        <button class="btn btn-sm btn-outline-danger flex-fill" title="Delete">
                            <i class="bi bi-trash"></i> Delete
                        </button>
                    </div>
                </div>
            </div>
        `
        return movieCardDiv;
    }
}