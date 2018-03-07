function BasketModel() {
    var _self = this;
    this.basketItems = [];

    this.addItem = function (tyreId, description) {
        $.ajax({
            url: "Home/AddTyreToBasket", //controller-Home si metoda
            type: "post",
            data: { tyreId: tyreId, description: description },
            success: function (response) {
                if (!response.exists) {
                    _self.basketItems.push(tyreId);
                }
                else
                    alert("Tyre already added");
                updateCartCount();
            }
        });
        
    }

  this.getItems = function () {
        $.ajax({
            url: "Home/GetBasketItems", //controller-Home si metoda
            type: "get",
            success: function (response) {
                if (response) {
                    _self.basketItems = response;
                }
                updateCartCount();
            }
        });

    }

  this.getBasketHtml = function () {
      $.ajax({
          url: "Home/GetBasketHtml", //controller-Home si metoda
          type: "get",
          success: function (response) {
              if (response) {
                  $.colorbox({
                      html: response,
                      open: true,
                      iframe: false,
                      width: "50%",
                      height: "50%",
                  });
              }
            
          }
      });
  }

  this.deleteItem = function (itemId) {
      $.ajax({
          url: "Home/RemoveItemFromBasket", //controller-Home si metoda
          type: "get",
          data: { itemId: itemId },
          success: function (response) {
              if (response.length > 2) {
                  $('#cboxContent').find('.table').html(response);
              }
              else
                  $.colorbox.close();

              _self.basketItems.pop();
              updateCartCount();
          }
      });
  }
    
}