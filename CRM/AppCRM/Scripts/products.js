function showAddInventory(id) {
    Swal.fire({
        title: 'Change Password',
        html:
            '<div class="form-group">' +
            '<label for="addInventory">Add Quantity</label>' +
            '<input type="text" id="addInventory" class="form-control mb-3"' +
            '</div>',
        showCancelButton: true,
        confirmButtonText: 'Add',
        showLoaderOnConfirm: true,
        preConfirm: () => {
            //call AddInventory with AJAX
            var addInventory = $("#addInventory").val();
            $.ajax({
                type: "POST",
                url: "/Products/AddInventory/",
                data: {
                    addInventory: addInventory,
                    id: id
                },
                cache: false,
                dataType: "json",
                success: function (data) {
                    return (
                        Swal.fire('Inventory Saved!', '', 'success').then(() => {
                            window.location.reload();
                        })
                    )
                },
                error: function (xhr) {
                    return (
                        Swal.fire('Inventory Unsaved!', '', 'error')
                    )
                }
            });
        },
        allowOutsideClick: () => !Swal.isLoading()
    });
}