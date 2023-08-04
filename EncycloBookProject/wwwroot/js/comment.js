"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/commentHub").build();
connection.start()
    .then(function () {
        // Enable the "Add comment" button after the connection is established.
        document.getElementById("addcomment").disabled = false;

        // In your JavaScript code
        connection.on("ReceiveComment", (user, comment, time) => {
            // Create a new comment element and append it to the comments section
            const newCommentElement = document.createElement("div");
            newCommentElement.innerHTML = `
                <div class="media">
                    <div class="media-body">
                        <h4 class="media-heading user_name">${user}</h4>
                        <p>${comment}</p>
                        <p class="pull-right"><small>${time}</small></p>
                    </div>
                </div>
            `;
            // Append the new comment at the beginning to show the latest comment first
            document.querySelector(".comments-list").prepend(newCommentElement);
        });
    })
    .catch(function (err) {
        return console.error(err.toString());
    });

// In your JavaScript code
document.getElementById("addcomment").addEventListener("click", () => {
    const commentInput = document.getElementById("messageInput");
    const userInput = document.getElementById("userName");
    const time = new Date().toISOString();
    const user = userInput.innerText;
    const comment = commentInput.value;
    document.getElementById("addcomment").setAttribute("asp-route-content", message);
    if (comment.trim() !== "") {
        // Call the server-side hub method to add the comment
        this.href = this.href.replace("COMMENT_VALUE_HERE", encodeURIComponent(comment));
    }

    // Clear the comment input field after adding the comment
    commentInput.value = "";
});