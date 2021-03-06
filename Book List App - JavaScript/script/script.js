// Book class: Represent a book
class Book {
    constructor(title, author, year, isbn) {
        this.title = title;
        this.author = author;
        this.year = year;
        this.isbn = isbn;
    }
}

// UI Class: Handle UI Task
class UI {
    static displayBooks() {

        const books = Store.getBooks();

        books.forEach((book) => {
            UI.addBookToList(book);
        })
    }
    static addBookToList(book) {
        const list = document.querySelector('#book-list');
        const row = document.createElement('tr');
        row.innerHTML = `
        <td>${book.title}</td>
        <td>${book.author}</td>
        <td>${book.year}</td>
        <td>${book.isbn}</td>
        <td><a href="#" class="btn btn-info btn-sm delete">X</a></td>
        `;
        list.appendChild(row)
    }
    static deleteBook(el) {
        if (el.classList.contains('delete')) {
            el.parentElement.parentElement.remove()
            UI.showAlert('Book Removed', 'success')
        }
    }
    static clearFields() {
        document.querySelector('#title').value = ''
        document.querySelector('#author').value = ''
        document.querySelector('#isbn').value = ''
        document.querySelector('#year').value = ''
    }
    static showAlert(message, className) {
        const div = document.createElement('div');
        div.className = `alert alert-${className}`;
        div.appendChild(document.createTextNode(message));
        const container = document.querySelector('.container');
        const form = document.querySelector('#book-form')
        container.insertBefore(div, form);
        setTimeout(() => {
            document.querySelector('.alert').remove()
        }, 2000)
    }

}

// Store Class: Handles Storage
class Store {
    static getBooks() {
        let books;
        if (localStorage.getItem('books') === null) {
            books = [];
        } else {
            books = JSON.parse(localStorage.getItem('books'));
        }
        return books;
    }
    static addBook(book) {
        const books = Store.getBooks();
        books.push(book);
        localStorage.setItem("books", JSON.stringify(books))
    }
    static removeBook(isbn) {
        const books = Store.getBooks();
        books.forEach((book, index) => {
            if (book.isbn === isbn) {
                books.splice(index, 1)
            }
        });

        localStorage.setItem('books', JSON.stringify(books))
    }
}

// Event : Display books
document.addEventListener('DOMContentLoaded', UI.displayBooks)

// Event: Add a book
document.querySelector('#book-form').addEventListener('submit', (e) => {
    e.preventDefault()
    const title = document.querySelector('#title').value;
    const author = document.querySelector('#author').value;
    const year = document.querySelector('#year').value;
    const isbn = document.querySelector('#isbn').value;

    if (title === '' || author === '' || isbn === '' || year === '') {
        UI.showAlert('Please fill in all fields', 'danger')
    } else {
        const book = new Book(title, author, year, isbn);

        UI.addBookToList(book)

        Store.addBook(book)

        UI.showAlert('Book Added', 'success')

        UI.clearFields()
    }
});

// Event: Remove a book
document.querySelector('#book-list').addEventListener('click', (e) => {
    UI.deleteBook(e.target)

    

    Store.removeBook(e.target.parentElement.previousElementSibling.textContent)
})