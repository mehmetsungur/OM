$(function () {
    $("#btnProductSave").click(function () {
        var vm =
        {
            BrandName: $("#txtProductBrandName").val(),
            Model: $("#txtProductModel").val(),
            Serial: $("#txtProductSerial").val(),
            WorkHeight: $("#txtProductWorkHeight").val(),
            WorkCapacity: $("#txtProductWorkCapacity").val(),
            Periodic: $("#txtProductPeriodic").val(),
            State: $("#txtProductState").val(),
            Description: $("#txtProductDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Product/CreateProduct",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                $("#CreateProduct").hide();
                if (response.Result) {
                    swal({
                        type: 'success',
                        title: 'İşlem Başarılı',
                        text: response.Message
                    }).then((result) => {
                        window.location.reload();
                    });
                }
                else {
                    swal({
                        type: 'error',
                        title: 'İşlem Başarısız',
                        html: "Ürün Kaydedilemedi! <br><h5>Tüm Alanları Doldurarak</h5> Tekrar Deneyiniz ..."
                    }).then((result) => {
                        window.location.reload();
                    });
                }
            },
            error: function () {
                swal({
                    type: 'error',
                    title: 'İşlem Başarısız',
                    text: response.Message
                }).then((result) => {
                    window.location.reload();
                });
            }
        });
    });

    $("body").on("click", "#imgProductEdit", function () {
        var ProductId = $(this).attr("ProductId");
        var tr = $(this).parent("td").parent("tr");

        var UpBrandName = tr.find("#spnBrandName").html();
        var UpModel = tr.find("#spnModel").html();
        var UpSerial = tr.find("#spnSerial").html();
        var UpWorkHeight = tr.find("#spnWorkHeight").html();
        var UpWorkCapacity = tr.find("#spnWorkCapacity").html();
        var UpPeriodic = tr.find("#spnPeriodic").html();
        var UpState = tr.find("#spnState").html();
        var UpDescription = tr.find("#spnDescription").html();

        $("#hfProductIdEdit").val(ProductId);
        $("#txtProductEditBrandName").val(UpBrandName);
        $("#txtProductEditModel").val(UpModel);
        $("#txtProductEditSerial").val(UpSerial);
        $("#txtProductEditWorkHeight").val(UpWorkHeight);
        $("#txtProductEditWorkCapacity").val(UpWorkCapacity);
        $("#txtProductEditPeriodic").val(UpPeriodic);
        $("#txtProductEditState").val(UpState);
        $("#txtProductEditDescription").val(UpDescription);

        $("#divProductEdit").modal('show');
    });

    $("body").on("click", "#imgProductDelete", function () {
        var ProductId = $(this).attr("ProductId");
        swal({
            title: 'Silmek istediğinizden emin misiniz?',
            text: "Ürün kaydı silinecektir!",
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#67d630',
            cancelButtonColor: '#d33',
            cancelButtonText: "Hayır, vazgeç!",
            confirmButtonText: 'Evet, Silme işlemine devam edilsin!'
        }).then((result) => {
            if (result.value) {
                $.ajax({
                    url: "/DashBoard/Product/DeleteProduct/" + ProductId,
                    method: "post",
                    success: function (response) {
                        if (response.Result) {
                            swal({
                                type: 'success',
                                title: 'İşlem Başarılı',
                                text: "Ürün Başarıyla Silindi"
                            }).then((result) => {
                                window.location.reload();
                            });
                        }
                    }
                });
            }
        })
    });

    $("#btnProductUpdate").click(function () {
        var id = $("#hfProductIdEdit").val();
        var vm =
        {
            Id: id,
            BrandName: $("#txtProductEditBrandName").val(),
            Model: $("#txtProductEditModel").val(),
            Serial: $("#txtProductEditSerial").val(),
            WorkHeight: $("#txtProductEditWorkHeight").val(),
            WorkCapacity: $("#txtProductEditWorkCapacity").val(),
            Periodic: $("#txtProductEditPeriodic").val(),
            State: $("#txtProductEditState").val(),
            Description: $("#txtProductEditDescription").val()
        };
        $.ajax({
            url: "/DashBoard/Product/UpdateProduct",
            method: "post",
            datatype: "json",
            data: vm,
            success: function (response) {
                if (response.Result) {
                    swal({
                        type: 'success',
                        title: 'İşlem Başarılı',
                        text: response.Message
                    }).then((result) => {
                        window.location.reload();
                    });
                }
                else {
                    swal({
                        type: 'error',
                        title: 'İşlem Başarısız',
                        text: 'Ürün güncellenemedi. Lütfen tekrar deneyiniz!'
                    }).then((result) => {
                        window.location.reload();
                    });
                }
            },
            error: function () {
                swal({
                    type: 'error',
                    title: 'İşlem Başarısız',
                    text: response.Message
                }).then((result) => {
                    window.location.reload();
                });
            }
        });
    });
});