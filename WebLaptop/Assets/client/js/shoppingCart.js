var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvents();
    },
    registerEvents: function () {
        $("#btnAddToCart").off('click').on('click', function (e) {
            e.preventDefault();//xóa điều hướng mặc định của thẻ a
            var productId = parseInt($(this).data('id')); //lấy ra giá trị của thuộc tính data-id
            cart.addItem(productId)
        });
        $(".btnDeleteItem").off('click').on('click', function (e) { //mỗi dòng bind ra nên đều phải có off
            e.preventDefault();//xóa điều hướng mặc định của thẻ a
            var productId = parseInt($(this).data('id')); //lấy ra giá trị của thuộc tính data-id
            cart.deleteItem(productId)
        });
        $('.txtQuantity').off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            var productId = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {
                var amount = quantity * price;

                $('#amount_' + productId).text(numeral(amount).format('0,0'));
            }
            else {
                $('#amount_' + productId).text(0);
            }
            $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
        });
    },
    getTotalOrder: function () {
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseInt($(item).val()) * parseFloat($(item).data('price'));
        });
        return total;
    },
    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            data: {
                productId: productId
            },
            type:"POST",
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    alert("Thêm sản phẩm vào giỏ hàng thành công");
                }
            }
        });
    },
    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: {
                productId: productId
            },
            type: "POST",
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                }
            }
        });
    },
    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: "GET",
            dataType: 'json',
            success: function (res) { //res==data trong controller
                if (res.status) {
                    var template = $('#tplCart').html();//lấy ra chuỗi html
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            ProductName: item.Product.Name,
                            Image: item.Product.Image,
                            Price: item.Product.Price,
                            PriceF: numeral(item.Product.Price).format('0,0'),
                            Quantity: item.Quantity,
                            Amount: numeral(item.Quantity * item.Product.Price).format('0,0') //định dạng giá tiền
                        });
                    });

                    $('#cartBody').html(html);
                    $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    cart.registerEvents();
                }
            }
        })
    }
}

cart.init();