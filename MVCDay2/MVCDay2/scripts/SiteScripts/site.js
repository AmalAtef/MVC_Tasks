function confirmDelete(id) {
    let res = confirm("Are you sure to Delete");
    if (res) {
        $.ajax({
            url: "/Employees/Delete/" + id,
            type: "POST",
            success: function (res) {
                if (res) {
                    let tr = $("#" + id);
                    tr.remove();
                }
            },
            error: function (xhr, staus, err) {
                console.log(err)
            }
        });
    }
}

function onSuccess() {
    document.getElementById("form0").reset();
    $("#employee-model").modal("hide");
}
