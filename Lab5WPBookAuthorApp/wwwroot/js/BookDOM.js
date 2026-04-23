export class BookDOM {
    static createBookCard(book) {
        const col = document.createElement("div");
        col.className = "col";
        col.id = `book-${book.id}`;

        col.innerHTML = `
            <div class="card h-100 shadow-sm">
                <div class="card-body">
                    <h5 class="card-title">${book.title}</h5>
                    <p class="card-text text-muted">
                        <small>Published: ${book.publicationYear}</small>
                        <br/>
                        <small>Number of Authors: ${book.authors.length}</small>
                    </p>
                </div>
                <div class="card-footer bg-white border-0 d-flex gap-2 justify-content-end">
                    <button class="btn btn-outline-info btn-sm details-btn" data-book-id="${book.id}">
                        Details
                    </button>
                    <button class="btn btn-outline-warning btn-sm" data-book-id="${book.id}">
                        Edit
                    </button>
                    <button class="btn btn-outline-danger btn-sm" data-book-id="${book.id}">
                        Delete
                    </button>
                </div>
            </div>
        `;

        return col;
    }

    static populateBookDetailsModal(book) {
        document.getElementById("bookTitle").textContent = book.title;
        document.getElementById("bookPublicationYear").textContent = book.publicationYear;
        document.getElementById("numberOfAuthors").textContent = book.authors.length;
        document.querySelector(".add-author-btn").dataset.bookId = book.id;

        const authorsBody = document.getElementById("bookAuthors");
        authorsBody.innerHTML = "";

        if (book.authors.length === 0) {
            authorsBody.innerHTML = `
                <tr>
                    <td colspan="2" class="text-muted text-center">No authors listed</td>
                </tr>
            `;
        } else {
            for (const author of book.authors) {
                const row = BookDOM.createAuthorRow(author);
                authorsBody.appendChild(row);
            }
        }
    }

    static createAuthorRow(author) {
        const tr = document.createElement("tr");

        tr.innerHTML = `
            <td>${author.id}</td>
            <td>${author.firstName ?? ""} ${author.lastName}</td>
        `;

        return tr;
    }
}