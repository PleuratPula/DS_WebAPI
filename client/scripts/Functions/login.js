$(function () {
    $('#btnLogin').on('click', function (e) {
        e.preventDefault();

        var username = document.getElementById('txtUsername').value;
        var password = document.getElementById('txtPassword').value;

        $.ajax({
            url: 'http://localhost:50995/api/users/authenticate',
            type: 'POST',
            data: JSON.stringify({ username, password }),
            dataType: 'json',
            crossOrigin: true,
            crossDomain: true,
            contentType: 'application/json; charset=utf-8',

            success: function (e) {
                localStorage.setItem('tokendata', JSON.stringify(e));
                localStorage.setItem('token', e.token);
                window.location.href = 'index.html';
            },
            error: function (e) {
                console.log(e);
            },
        });
    });
});
