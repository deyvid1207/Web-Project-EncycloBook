document.getElementById('sort').addEventListener('change', function () {
    var selectedValue = this.value;


    var posts = document.querySelectorAll('.card');

    var postsArray = Array.from(posts);


    postsArray.sort(function (a, b) {
        if (selectedValue === '1') {

            var dateA = new Date(a.getAttribute('data-published-date'));
            var dateB = new Date(b.getAttribute('data-published-date'));
            return dateB - dateA;
        } else if (selectedValue === '2') {

            var likesA = parseInt(a.getAttribute('data-likes-count'));
            var likesB = parseInt(b.getAttribute('data-likes-count'));
            return likesB - likesA;
        } else if (selectedValue === '3') {

            var commentsA = parseInt(a.getAttribute('data-comments-count'));
            var commentsB = parseInt(b.getAttribute('data-comments-count'));
            return commentsB - commentsA;
        } else if (selectedValue === '4') {

            var titleA = a.querySelector('.card-title').textContent;
            var titleB = b.querySelector('.card-title').textContent;
            return titleA.localeCompare(titleB);
        } else if (selectedValue === '5') {

            var dateA = new Date(a.getAttribute('data-published-date'));
            var dateB = new Date(b.getAttribute('data-published-date'));
            return dateA - dateB;
        } else if (selectedValue === '6') {

            var userA = a.getAttribute('data-publisher-name').toLowerCase();
            var userB = b.getAttribute('data-publisher-name').toLowerCase();
            return userA.localeCompare(userB);
        }
    });

    var container = document.querySelector('.row-post');
    container.innerHTML = '';
    postsArray.forEach(function (post) {
        container.appendChild(post);
    });
});
