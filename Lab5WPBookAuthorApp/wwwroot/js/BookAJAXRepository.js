export class BookAJAXRepository {
    #baseURL;

    constructor(baseURL) {
        this.#baseURL = baseURL;
    }

    async readAll() {
        const address = `${this.#baseURL}/all`;
        const response = await fetch(address);
        if (!response.ok) {
            throw new Error("There was an HTTP error getting the book data.");
        }
        return await response.json();
    }

    async read(id) {
        const address = `${this.#baseURL}/one/${id}`;
        const response = await fetch(address);
        if (!response.ok) {
            throw new Error("There was an HTTP error getting the book data.");
        }
        return await response.json();
    }

    async addAuthor(formData) {
        const address = `${this.#baseURL}/author/add`;
        const response = await fetch(address, {
            method: "POST",
            body: formData
        });

        if (!response.ok) {
            throw new Error("There was an HTTP error adding the author.");
        }

        return await response.json();
    }
}