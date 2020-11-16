var passwordExist = false;

function showChangePassword() {
    Swal.fire({
        title: 'Change Password',
        html:
            '<div class="form-group">'+
                '<label for="oldPassword">Old Password</label>' +
                '<input type="text" id="oldPassword" class="form-control mb-3" onblur="existPassword()"' +
                '<label for="oldPassword">New Password</label>' +
                '<input type="text" id="newPassword" class="form-control mb-3" onkeyup="passwordMatch()"'+
                '<label for="oldPassword">Confirm Password</label>' +
                '<input type="text" id="confirmPassword" class="form-control mb-3" onkeyup="passwordMatch()"' +
            '</div>',
        showCancelButton: true,
        confirmButtonText: 'Change',
        showLoaderOnConfirm: true,
        preConfirm: () => {
            //call ChangePassword with AJAX
            var password = $("#newPassword").val();
            $.ajax({
                type: "POST",
                url: "/Home/ChangePassword/",
                data: {
                    password: password
                },
                cache: false,
                dataType: "json",
                success: function (data) {
                    return (
                        Swal.fire('Password Saved!', '', 'success')
                    )
                },
                error: function (xhr) {
                    return (
                        Swal.fire('Password Unsaved!', '', 'error')
                    )
                }
            });
        },
        allowOutsideClick: () => !Swal.isLoading()
    });
}

function existPassword() {
    var password = $("#oldPassword").val();
    var newPassword = $("#newPassword").val();
    var confirmPassword = $("#confirmPassword").val();
    if (password != "") {
        $.ajax({
            type: "POST",
            url: "/Home/PasswordExist/",
            data: {
                password: password
            },
            cache: false,
            dataType: "json",
            success: function (data) {
                if (!data.passwordExist && newPassword == confirmPassword && newPassword != "" && confirmPassword != "" && newPassword != password) {
                    $(".swal2-confirm").prop("disabled", false);
                } else {
                    $(".swal2-confirm").prop("disabled", true);
                }
                passwordExist = data.passwordExist;
            },
            error: function (xhr) {
                $(".swal2-confirm").prop("disabled", true);
                passwordExist = false;
            }
        });
    }
}

function passwordMatch() {
    var newPassword = $("#newPassword").val();
    var confirmPassword = $("#confirmPassword").val();
    var oldPassword = $("#oldPassword").val();
    if (newPassword == confirmPassword && passwordExist && newPassword != "" && confirmPassword != "" && newPassword != oldPassword) {
        $(".swal2-confirm").prop("disabled", false);
    } else {
        $(".swal2-confirm").prop("disabled", true);
    }
}

function showChangeUserName() {
    Swal.fire({
        title: 'Change Password',
        html:
            '<div class="form-group">' +
                '<label for="newUserName">New User Name</label>' +
                '<input type="text" id="newUserName" class="form-control mb-3" onkeyup="existUserName()"' +
            '</div>',
        showCancelButton: true,
        confirmButtonText: 'Change',
        showLoaderOnConfirm: true,
        preConfirm: () => {
            //call ChangeUserName with AJAX
            var userName = $("#newUserName").val();
            $.ajax({
                type: "POST",
                url: "/Home/ChangeUserName/",
                data: {
                    userName: userName
                },
                cache: false,
                dataType: "json",
                success: function (data) {
                    return (
                        Swal.fire('User Name Saved!', '', 'success')
                    )
                },
                error: function (xhr) {
                    return (
                        Swal.fire('User Name Unsaved!', '', 'error')
                    )
                }
            });
        },
        allowOutsideClick: () => !Swal.isLoading()
    });
}

function existUserName() {
    var userName = $("#newUserName").val();
    if (userName != "") {
        $.ajax({
            type: "POST",
            url: "/Home/UserNameExist/",
            data: {
                userName: userName
            },
            cache: false,
            dataType: "json",
            success: function (data) {
                if (!data.userNameExist) {
                    $(".swal2-confirm").prop("disabled", false);
                } else {
                    $(".swal2-confirm").prop("disabled", true);
                }
            },
            error: function (xhr) {
                $(".swal2-confirm").prop("disabled", true);
                userNameExist = false;
            }
        });
    }
}