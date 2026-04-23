import { BookDOM } from "./BookDOM.js";
import { BookAJAXRepository } from "./BookAJAXRepository.js";

class Main {
    #bookRepo;
    #bookDetailsModal;
    #authorModal;

    constructor() {
        this.#bookRepo = new BookAJAXRepository("/api/book");
        this.#bookDetailsModal = new bootstrap.Modal(document.getElementById('bookDetailsModal'));
        this.#authorModal = new bootstrap.Modal(document.getElementById('authorModal'));
    }

    async loadBooks() {
        const bookContainer = document.getElementById("bookContainer");
        const books = await this.#bookRepo.readAll();

        bookContainer.innerHTML = "";

        for (const book of books) {
            const card = BookDOM.createBookCard(book);
            bookContainer.appendChild(card);
        }
    }

    setupEventListeners() {
        const bookContainer = document.getElementById("bookContainer");

        // Details button
        bookContainer.addEventListener("click", async (event) => {
            const detailsBtn = event.target.closest(".details-btn");

            if (detailsBtn) {
                const bookId = detailsBtn.dataset.bookId;
                const book = await this.#bookRepo.read(bookId);
                console.log(book);

                BookDOM.populateBookDetailsModal(book);
                this.#bookDetailsModal.show();
            }
        });

        // Add Author button
        document.addEventListener("click", async (event) => {
            const addAuthorBtn = event.target.closest(".add-author-btn");

            if (addAuthorBtn) {
                const bookId = addAuthorBtn.dataset.bookId;

                this.#bookDetailsModal.hide();

                document.getElementById("bookId").value = bookId;

                this.#authorModal.show();
            }
        });

        document.addEventListener("submit", async (event) => {
            const addAuthorForm = event.target.closest("#addAuthorForm");

            if (addAuthorForm) {
                event.preventDefault();

                const formData = new FormData(addAuthorForm);
                await this.#bookRepo.addAuthor(formData);

                this.#authorModal.hide();
                await this.loadBooks();
            }
        });
    }

    async run() {
        await this.loadBooks();
        this.setupEventListeners();
    }
}

const main = new Main();
main.run();