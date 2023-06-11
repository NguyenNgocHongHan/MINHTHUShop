var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },

    registerEvent: function () {
        $('#btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();//xóa link mặc định
            var productID = parseInt($(this).data('id'));
            cart.addItem(productID);
        });
        $('.btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();//xóa link mặc định
            var productID = parseInt($(this).data('id'));
            cart.addItem(productID);
        });
        $('.btnDeleteItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productID = parseInt($(this).data('id'));
            cart.deleteItem(productID);
        });
        $('.txtQuantity').off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            var productID = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {
                var total = quantity * price;
                $('#total_' + productID).text(numeral(total).format('0,0'));
            }
            else {
                $('#total_' + productID).text(0);
            }
            $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));

        })
    },

    getTotalOrder: function () {
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseInt($(item).val()) * parseFloat($(item).data('price'));
        });
        return total;
    },

    addItem: function (productID) {
        $.ajax({
            url: '/Cart/Add',
            data: {
                productID: productID
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    alert('Đã thêm vào giỏ hàng!');
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
                            PromotionPrice: item.Product.PromotionPrice,
                            PromotionPriceF: numeral(item.Product.PromotionPrice).format('0,0'),
                            Quantity: item.Quantity,
                            Total: numeral(item.Quantity * item.Product.PromotionPrice).format('0,0')
                        });
                        stt = + 1;
                    });

                    $('#cartBody').html(html);
                    $('#lblTotalOrder').text(numeral(cart.getTotalOrder()).format('0,0'));
                    cart.registerEvent();
                }
            }
        })
    }
}
cart.init();