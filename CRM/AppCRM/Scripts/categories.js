function registerCategory() {
    var categoryName = $('#categoryName').val();
    $.ajax({
        type: "POST",
        url: "/Categories/Register/",
        data: {
            categoryName: categoryName,
        },
        cache: false,
        dataType: "json",
        success: function (data) {
            Swal.fire('Category Saved!', '', 'success').then(() => {
                window.location.reload();
            });
        },
        error: function (xhr) {
            Swal.fire('Category Unsaved!', '', 'error')
        }
    });
}

function getOneById() {
    var categoryId = $('#categoryId').val();
    $.ajax({
        type: "POST",
        url: "/Categories/getOneById/",
        data: {
            id: categoryId,
        },
        cache: false,
        dataType: "json",
        success: function (data) {
            $('#categoryName').val(data.category.categoryName);
        },
        error: function (xhr) {
            Swal.fire('Error!', '', 'error')
        }
    });
}