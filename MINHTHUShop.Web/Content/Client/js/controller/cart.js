var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },

    registerEvent: function () {
        $('.btnDeleteItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productID = parseInt($(this).data('id'));
            cart.deleteItem(productID);
        });
        $('#btnDeleteAll').off('click').on('click', function (e) {
            e.preventDefault();
            cart.deleteAll();
        });
        $('.txtQuantity').off('input').on('input', function () {
            var quantity = parseInt($(this).val());
            var productID = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false && quantity > 0) {
                var total = quantity * price;
                $('#total_' + productID).text(numeral(total).format('0,0'));
            }
            else {
                if (quantity < 1) {
                    alert('Số lượng phải lớn hơn 1');
                }
                $(this).val() = 1;
                quantity = parseInt($(this).val());
                var total = quantity * price;
                $('#total_' + productID).text(numeral(total).format('0,0'));
            }
            $('.lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
            cart.updateQuantity();
        });
        $('.txtShipping').off('change').on('change', function () {
            var cost = parseFloat($(this).data('cost'));
            var id = parseInt($(this).val());
            $('#txtShipping_' + id).text(numeral(cost).format('0,0'));
            var total = cart.getTotalOrder();
            var totalCost = total + cost;
            $('#lblShippingCost').text(numeral(cost).format('0,0'));
            $('#lblTotalCost').text(numeral(totalCost).format('0,0'));
        });
        $('.txtPayment').off('change').on('change', function () {
            var id = parseInt($(this).val());
            $('#txtPayment_' + id).text(id);
        });
        $('#btnContinue').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/";
        });
        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#divCheckout').show();
        });
        $('#btnCreateOrder').off('click').on('click', function (e) {
            e.preventDefault();
            var isValid = $('#frmPayment').valid();
            if (isValid) {
                cart.createOrder();
            }
        });
        $('#chkUserLoginInfo').off('click').on('click', function () {
            if ($(this).prop('checked'))
                cart.getLoginUser();
            else {
                $('#txtName').val('');
                $('#txtAddress').val('');
                $('#txtPhone').val('');
            }
        });
        $('#frmPayment').validate({
            rules: {
                name: "required",
                address: "required",
                phone: {
                    required: true,
                    number: true
                },
                payment: "required",
                shipping: "required"
            },
            messages: {
                name: "Bạn chưa nhập tên",
                address: "Bạn chưa nhập địa chỉ",
                phone: {
                    required: "Bạn chưa nhập số điện thoại",
                    number: "Số điện thoại phải là số"
                },
                payment: "Bạn chưa chọn phương thức thanh toán",
                shipping: "Bạn chưa chọn phương thức vận chuyển"
            }
        });
    },

    createOrder: function () {
        var shippingMethodId = '';
        if ($('.txtShipping:checked').length > 0) {
            shippingMethodId = $('.txtShipping:checked').attr('data-id').replace('txtShipping_', '');
        }

        var paymentMethodId = '';
        if ($('.txtPayment:checked').length > 0) {
            paymentMethodId = $('.txtPayment:checked').attr('data-id').replace('txtPayment_', '');
        }

        var order = {
            CustomerName: $('#txtName').val(),
            CustomerAddress: $('#txtAddress').val(),
            CustomerMobile: $('#txtPhone').val(),
            Note: $('#txtMessage').val(),
            ShippingMethodID: shippingMethodId,
            PaymentMethodID: paymentMethodId,
            OrderStatusID: 2
        }
        $.ajax({
            url: '/Cart/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderVM : JSON.stringify(order)
            },
            success: function (response) {
                if (response.status) {
                    console.log('Đặt hàng thành công!');
                    $('#divCheckout').hide();
                    cart.deleteAll();
                    setTimeout(function () {
                        $('#cartContent').html('Bạn đã đặt hàng thành công. Bấm <a href="/" style="text-decoration: none; color: #1DBAA5;">vào đây</a> để quay lại trang chủ.');
                    }, 2000);

                }
            }
        });
    },

    getLoginUser: function () {
        $.ajax({
            url: '/Cart/GetUser',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    var user = response.data;
                    $('#txtName').val(user.Name);
                    $('#txtAddress').val(user.Address);
                    $('#txtPhone').val(user.PhoneNumber);
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

    updateQuantity: function () {
        var cartList = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartList.push({
                ProductID: $(item).data('id'),
                Quantity: $(item).val()
            });
        });
        $.ajax({
            url: '/Cart/Update',
            type: 'POST',
            data: {
                cartData: JSON.stringify(cartList)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                    console.log('Cập nhật đơn hàng thành công!');
                }
            }
        });
    },

    deleteItem: function (productID) {
        $.ajax({
            url: '/Cart/DeleteItem',
            data: {
                productID: productID
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                }
            }
        });
    },

    deleteAll: function () {
        $.ajax({
            url: '/Cart/DeleteAll',
            type: 'POST',
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
            url: '/Cart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html();
                    var html = '';
                    var data = res.data;
                    var stt = 0;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            STT: stt + 1,
                            ProductID: item.ProductID,
                            Name: item.Product.Name,
                            Image: item.Product.Image,
                            PriceF: numeral(item.Product.Price).format('0,0'),
                            PromotionPrice: item.Product.PromotionPrice,
                            PromotionPriceF: numeral(item.Product.PromotionPrice).format('0,0'),
                            Quantity: item.Quantity,
                            Total: numeral(item.Quantity * item.Product.PromotionPrice).format('0,0')
                        });
                        stt += 1;
                    });

                    $('#cartBody').html(html);

                    if (html == '') {
                        $('#cartContent').html('Không có sản phẩm trong giỏ hàng. Bấm <a href="/" style="text-decoration: none; color: #1DBAA5;">vào đây</a> để quay lại trang chủ.');
                    }

                    $('.lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    var cost = parseFloat($(this).data('cost'));
                    $('#lblShippingCost').text(numeral(cost).format('0,0'));
                    $('#lblTotalCost').text(numeral(cart.getTotalOrder()+cost).format('0,0'));
                    cart.registerEvent();
                }
            }
        })
    }
}
cart.init();