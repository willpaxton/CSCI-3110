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
                        <button class="btn btn-sm btn-outline-primary flex-fill edit-btn" data-movie-id="${movie.id}" title="Edit">
                            <i class="bi bi-pencil-square"></i> Edit
                        </button>
                        <button class="btn btn-sm btn-outline-danger flex-fill delete-btn" data-movie-id="${movie.id}" title="Delete">
                            <i class="bi bi-trash"></i> Delete
                        </button>
                    </div>
                </div>
            </div>
        `
        return movieCardDiv;
    }

    setUpEventListeners(){
        document.addEventListener("submit", (e) => {
            if(e.target.getAttribute('id') === "movieForm") {
                e.preventDefault();
                console.log("Form submitted");
                const movie = this.#processForm();
                const movieGrid = document.getElementById('moviesGrid');
                const isEditing = document.getElementById('submitBtn').innerHTML.includes('Update');

                if (isEditing) {
                    const existingCard = document.getElementById(`movie-${movie.id}`);
                    const newCard = this.#createMovieCard(movie);
                    existingCard.replaceWith(newCard);
                } else {
                    this.#createAndAppendMovieCard(movie, movieGrid);
                }

                this.#resetForm();
            }
        });

        document.addEventListener("click", (e) => {
            const editBtn = e.target.closest('.edit-btn');
            const cancelBtn = e.target.closest('#cancelBtn');
            const deleteBtn = e.target.closest('.delete-btn');
            if (cancelBtn) {
                this.#resetForm();
                return;
            }
            if (editBtn) {
                const movieId = editBtn.getAttribute('data-movie-id');
                console.log(movieId);
                this.#populateFormForEdit(movieId);
            }            
            if (deleteBtn) {
                const movieId = deleteBtn.getAttribute('data-movie-id');
                console.log(movieId);
                this.#deleteMovie(movieId);
            }
        });
    }

    #processForm(){
        const form = document.getElementById('movieForm');
        const submitBtn = document.getElementById('submitBtn');
        const isEditing = submitBtn.innerHTML.includes('Update');

        const movie = {
            id: isEditing ? document.getElementById('movieId').value : this.#movies.length + 1,
            title: document.getElementById('title').value,
            director: document.getElementById('director').value,
            releaseDate: document.getElementById('releaseDate').value,
            isAvailable: (document.getElementById('isAvailable').value === 'true')
        }

        if (isEditing) {
            const index = this.#movies.findIndex(m => String(m.id) === String(movie.id));
                this.#movies[index] = movie;
            } else {
                this.#movies.push(movie);
            }
        


        console.log(movie);
        return movie;
    }

    #createAndAppendMovieCard(movie, parentElement) {
        // Create the movie card
        const cardCol = this.#createMovieCard(movie);

        // Hide it initially for animation
        $(cardCol).hide();

        // Append to parent and animate
        $(parentElement).append(cardCol);
        $(cardCol).fadeIn(600);
    }

    #resetForm() {
        document.getElementById('movieForm').reset();
        document.getElementById('movieId').value = '0';
        document.querySelector('.card-title').innerHTML = '<i class="bi bi-plus-circle"></i> Add New Movie';
        document.getElementById('submitBtn').innerHTML = '<i class="bi bi-plus-lg"></i> Add Movie';
        document.getElementById('cancelBtnRow').style.display = 'none';
    }


    #populateFormForEdit(movieId) {
        const movie = this.#movies.find(movie => String(movie.id) === String(movieId));
        if (!movie) {
            console.log('no movie :(');
            return;
        }
        console.log('movie found');
        document.getElementById('movieId').value = movie.id;
        document.getElementById('title').value = movie.title;
        document.getElementById('director').value = movie.director;
        document.getElementById('releaseDate').value = movie.releaseDate;
        document.getElementById('isAvailable').value = movie.isAvailable ? 'true' : 'false';

        document.querySelector('.card-title').innerHTML = '<i class="bi bi-pencil-square"></i> Edit Movie';
        document.getElementById('submitBtn').innerHTML = '<i class="bi bi-pencil-square"></i> Update Movie';
        document.getElementById('cancelBtnRow').style.display = 'block';
        document.getElementById('movieForm').scrollIntoView({ behavior: 'smooth', block: 'start' });
    }

    #deleteMovie(movieId) {
        console.log("delete movie triggered")
        // Find the movie
        const movie = this.#movies.find(movie => String(movie.id) === String(movieId));
        if (!movie) return;

        // Show confirmation dialog
        const confirmed = confirm(`Are you sure you want to delete "${movie.title}"?`);
        console.log("confirmed?");
        if (confirmed) {
            // Remove from array
            const index = this.#movies.findIndex(m => m.id === movieId);
            if (index !== -1) {
                this.#movies.splice(index, 1);
            }

            // Remove the card with animation
            const card = document.getElementById(`movie-${movieId}`);
            $(card).fadeOut(400, function () {
                $(this).remove();

                // Check if there are no movies left and show empty state
                const movieGrid = document.querySelector('#moviesGrid');
                if (this.#movies.length === 0) {
                    const emptyState = this.#createEmptyState();
                    movieGrid.appendChild(emptyState);
                }
            }.bind(this));
        }
    }


}