function SingIn() {
    var userName = $("#userName").val();
    var password = $("#password").val();
    if (userName != "" && password != "") {
        $.ajax({
            type: "POST",
            url: "/Home/SingIn/",
            data: {
                userName: userName,
                password: password
            },
            cache: false,
            dataType: "json",
            success: function (data) {
                sessionStorage.setItem("rols", data.rols);
                window.location.href = "/Home/Home";
            },
            error: function (xhr) {
                alert("The credentials don't match with one user");
            }
        });
    } else {
        alert("Insert the user name and the password");
    }
}

function SingOut() {
    $.ajax({
        type: "GET",
        url: "/Home/SingOut/",
        cache: false,
        success: function (data) {
            sessionStorage.removeItem("rols");
            window.location.href = "/Home/Index";
        },
        error: function (xhr) {
            alert("AA");
        }
    });
}

function showNavBarMenu() {
    var navBar = $('#navBarMenu');

    var rols = sessionStorage.getItem("rols");

    if (rols.includes(2)) {
        navBar.append(showMenuOrders());
        navBar.append(showMenuClients());
    }

    if (rols.includes(2) && !rols.includes(1)) {
        navBar.append(showMenuProductsWithoutRegister());
    }

    if (rols.includes(1)) {
        navBar.append(showMenuProducts());
        navBar.append(showMenuEmployees());
    }

}

function showMenuOrders() {
    return (
        '<li class="nav-item dropdown">'+
            '<a class="nav-link">Orders</a>'+
            '<div class="dropdown-menu dropdown-menu-right   " aria-labelledby="navbarDropdown">'+
               '<a href="/Clients/Index" class="dropdown-item">List of Orders</a>'+
               '<div class="dropdown-divider"></div>'+
               '<a href="/Clients/Index" class="dropdown-item">Register Order</a>'+
             '</div>'+
         '</li>'
    )
}

function showMenuClients() {
    return (
        '<li class="nav-item dropdown">' +
        '<a class="nav-link">Clients</a>' +
        '<div class="dropdown-menu dropdown-menu-right   " aria-labelledby="navbarDropdown">' +
        '<a href="/Clients/Index" class="dropdown-item">List of Clients</a>' +
        '<div class="dropdown-divider"></div>' +
        '<a href="/Clients/Register" class="dropdown-item">Register Client</a>' +
        '</div>' +
        '</li>'
    )
}

function showMenuProducts() {
    return (
        '<li class="nav-item dropdown">' +
        '<a class="nav-link">Products</a>' +
        '<div class="dropdown-menu dropdown-menu-right   " aria-labelledby="navbarDropdown">' +
        '<a href="/Clients/Index" class="dropdown-item">List of Products</a>' +
        '<div class="dropdown-divider"></div>' +
        '<a href="/Clients/Index" class="dropdown-item">Register Product</a>' +
        '</div>' +
        '</li>'
    )
}

function showMenuEmployees() {
    return (
        '<li class="nav-item dropdown">' +
        '<a class="nav-link">Employees</a>' +
        '<div class="dropdown-menu dropdown-menu-right   " aria-labelledby="navbarDropdown">' +
        '<a href="/Employees/Index" class="dropdown-item">List of Employees</a>' +
        '<div class="dropdown-divider"></div>' +
        '<a href="/Employees/Register" class="dropdown-item">Register Employee</a>' +
        '</div>' +
        '</li>'
    )
}

function showMenuProductsWithoutRegister() {
    return (
        '<li class="nav-item dropdown">' +
        '<a class="nav-link">Products</a>' +
        '<div class="dropdown-menu dropdown-menu-right   " aria-labelledby="navbarDropdown">' +
        '<a href="/Clients/Index" class="dropdown-item">List of Products</a>' +
        '</div>' +
        '</li>'
    )
}