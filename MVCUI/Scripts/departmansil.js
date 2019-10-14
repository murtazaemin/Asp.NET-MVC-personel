$(function () {
    $("#tblDepartmanlar").on("click", ".DepartmanSil", function () {
        var btn = $(this);

        bootbox.confirm("Silmek istediğinize emin misiniz ?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Departman/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }


        });

       
        
    });
});


