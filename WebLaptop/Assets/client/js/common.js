var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $("#txtKeyWord").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#txtKeyWord").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#txtKeyWord").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>")
                .append("<a>" + item.label + "</a>")
                .appendTo(ul);
        };
        //$('btnLogOut').off('click').on('click', function (e) {
        //    e.preventDefault(); //xóa mặc định của thẻ a là #
        //    $('frmLogout').submit();
        //})
        $(".btnAddToCart").off('click').on('click', function (e) {
            e.preventDefault();//xóa điều hướng mặc định của thẻ a
            var productId = parseInt($(this).data('id')); //lấy ra giá trị của thuộc tính data-id
            $.ajax({
                url: '/ShoppingCart/Add',
                data: {
                    productId: productId
                },
                type: "POST",
                dataType: 'json',
                success: function (response) {
                    if (response.status) {
                        alert("Thêm sản phẩm vào giỏ hàng thành công");
                    }
                }
            });
        });
    }
}
common.init();