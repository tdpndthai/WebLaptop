var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvents();
    },
    registerEvents: function () {
        $('#frmPayment').validate({
            rules: {//tập các thuộc tính,quy tắc để validate form,validate theo name="" chứ không theo id
                name: "required",
                address: "required",
                email: {
                    required: true,
                    email: true
                },
                phone: {
                    required: true,
                    number: true
                },
                msg: {
                    required: true,
                }
            },
            messages: {
                name: "Yêu cầu nhập tên",
                address: "Yêu cầu nhập địa chỉ",
                email: {
                    required: "Bạn cần nhập email",
                    email: "Định dạng email chưa đúng"
                },
                phone: {
                    required: "Số điện thoại được yêu cầu",
                    number: "Số điện thoại phải là số."
                },
                msg: {
                    required:"Cần nhập message"
                }
            }
        });
        $(".btnDeleteItem").off('click').on('click', function (e) { //mỗi dòng bind ra nên đều phải có off
            e.preventDefault();//xóa điều hướng mặc định của thẻ a
            var productId = parseInt($(this).data('id')); //lấy ra giá trị của thuộc tính data-id
            cart.deleteItem(productId)
        });
        $("#btnContinue").off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/";
        });

        $("#btnDeleteAll").off('click').on('click', function (e) {
            e.preventDefault();
            cart.deleteAll();
        });
        $("#btnDeleteAll").off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/thanh-toan.html";
        });
        $("#btnCheckOut").off('click').on('click', function (e) {
            e.preventDefault();
            $('#divCheckout').show();
        });

        $("#checkUserLoginInfo").off('click').on('click', function () {
            cart.getLoginUser();
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
            cart.updateAll();
        });
        $('#btnCreateOrder').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frmPayment').valid();
            if (isValid) {
                cart.createOrder();
            }

        });
    },

    getLoginUser: function () {
        $.ajax({
            url: '/ShoppingCart/GetUser',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var user = response.data;
                    $("#txtName").val(user.FullName);
                    $("#txtAddress").val(user.Address);
                    $("#txtEmail").val(user.Email);
                    $("#txtPhone").val(user.PhoneNumber);
                }
            }
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

    deleteAll: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteAll',
            type: "POST",
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
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
                    if (html == '') {
                        $('#cartContent').html('Không có gì trong giỏ hàng');
                    }
                    $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    cart.registerEvents();
                }
            }
        })
    },

    updateAll: function () {
        var cartList = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartList.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            });
        });
        $.ajax({
            url: '/ShoppingCart/Update',
            type: "POST",
            data: {
                cartData: JSON.stringify(cartList)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                    console.log("ok")
                }
            }
        });
    },

    createOrder: function () {
        var order = {
            CustomerName: $('#txtName').val(),
            CustomerAddress: $('#txtAddress').val(),
            CustomerEmail: $('#txtEmail').val(),
            CustomerMobile: $('#txtPhone').val(),
            CustomerMessage: $('#txtMessage').val(),
            PaymentMethod: "Thanh toán tiền mặt",
            Status: false
        }
        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderVM: JSON.stringify(order)
            },
            success: function (response) {
                if (response.status) {
                    console.log('create order ok');
                    $('#divCheckout').hide();
                    cart.deleteAll();
                    setTimeout(function () {
                        $('#cartContent').html('Cảm ơn bạn đã đặt hàng thành công. Chúng tôi sẽ liên hệ sớm nhất.');
                    }, 2000);

                }
            },
            error: function (response) {
                console.log(response);
                alert("Thanh toán thất bại");
            }
        });
    }


}

cart.init();