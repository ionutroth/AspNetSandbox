"use strict";

var connection = new signalR.HubConnectinBuilder().withUrl("/messageHub").build();

connection.start().then(function () {
    console.log("connection established");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("BookCreated", function (book) {
    console.log(`book created: ${JSON.stringify(book)}`);
    $("tbody").append(`<tr>
        <td>
            ${book.Title}
        </td>
        <td>
            ${book.Author}
        </td>
        <td>
            ${book.Language}
        </td>
        <td>
            <button><a asp-page="./Edit" asp-route-id=${book.Id}>Edit</a></button>
            <button><a asp-page="./Delete" asp-route-id=${book.Id}>Delete</a></button>
        </td>
    </tr>
    `);
});