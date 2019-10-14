$(function () {
    $("#tblPersoneller").on("click", ".PersonelSil", function () {
        var btn = $(this);

        bootbox.confirm("Silmek istediğinize emin misiniz ?", function (result) {
            if (result) {
                var id = btn.data("id");
                $.ajax({
                    type: "GET",
                    url: "/Personel/Sil/" + id,
                    success: function () {
                        btn.parent().parent().remove();
                    }

                });
            }


        });



    });
});


