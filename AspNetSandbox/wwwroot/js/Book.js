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
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <a href="/Edit?id=${book.id}">Edit</a> |
            <a href="/Delete?id=${book.id}">Delete</a>
        </td>
    </tr>
    `);
});

connection.on("BookUpdated", function (book) {
    console.log(`book updated: ${JSON.stringify(book)}`);
    $(`#${book.id}`).html(`<td>
            ${book.title}
        </td>
        <td>
            ${book.author}
        </td>
        <td>
            ${book.language}
        </td>
        <td>
            <a href="/Edit?id=${book.id}">Edit</a> |
            <a href="/Delete?id=${book.id}">Delete</a>
        </td>`)
});

connection.on("BookDeleted", function (book) {
    console.log(`book deleted: ${JSON.stringify(book)}`);
    $(`#${book.id}`).remove();
});