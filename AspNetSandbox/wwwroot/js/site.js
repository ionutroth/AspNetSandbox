"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/messageHub").build();

connection.start().then(function () {
    console.log("connection established");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("BookCreated", function (book) {
    console.log(`book created: ${JSON.stringify(book)}`);
    $("tbody").append(`<tr id="${book.id}">
        <td>
            ${book.id}
        </td>
        <td>
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <button class="btn btn-danger" onclick="DeleteBook(${book.id})">Delete</button>
        </td>
    </tr>
    `);
});

connection.on("BookUpdated", function (book) {
    console.log(`book updated: ${JSON.stringify(book)}`);
    $(`#${book.id}`).html(`<td>
            ${book.id}
        </td>
        <td>
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <button class="btn btn-danger" onclick="DeleteBook(${book.id})">Delete</button>
        </td>`)
});

connection.on("BookDeleted", function (book) {
    console.log(`book deleted: ${JSON.stringify(book)}`);
    $(`#${book.id}`).remove();
});

connection.on("BooksShown", function () {
    console.log(`all book shown`);
});

function showBooks() {
    var settings = {
        "url": "https://localhost:5001/api/books/",
        "method": "GET",
        "timeout": 0,
    };

    $.ajax(settings).done(function (response) {
        response.forEach(book => {
            $("tbody").append(`
                <tr id="${book.id}">
                    <td>
                        ${book.id}
                    </td>
                    <td>
                        ${book.title}
                    </td>
                    <td>
                        ${book.author}
                    </td>
                    <td>
                        ${book.language}
                    </td>
                    <td>
                        <button class="btn btn-danger" onclick="DeleteBook(${book.id})">Delete</button>
                    </td>
                </tr>`)
        })
    });
}
showBooks();


function DeleteBook(id) {
    var urlString = "https://localhost:5001/api/books/" + id;
    console.log(urlString);
    var settings = {
        "url": urlString,
        "method": "DELETE",
        "timeout": 0,
    };

    $.ajax(settings).done(function () {
       
    });
}

var formAdd = document.getElementById("add");
formAdd.addEventListener("submit", function (event) {
    event.preventDefault();

    var settings = {
        "url": "https://localhost:5001/api/books",
        "method": "POST",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            "title": $("#title-field-add").val(),
            "author": $("#author-field-add").val(),
            "language": $("#language-field-add").val(),
        }),
    };

    $.ajax(settings).done(function () {

    });
});


var formEdit = document.getElementById("edit")
formEdit.addEventListener("submit", function (event) {
    event.preventDefault();
    var urlEdit = "https://localhost:5001/api/books/" + String($("#id-field-edit").val());
    console.log(urlEdit)
    var settings = {
        "url": urlEdit,
        "method": "PUT",
        "timeout": 0,
        "headers": {
            "Content-Type": "application/json"
        },
        "data": JSON.stringify({
            "title": $("#title-field-edit").val(),
            "author": $("#author-field-edit").val(),
            "language": $("#language-field-edit").val(),
        }),
    };

    $.ajax(settings).done(function (response) {
    });
})