function Delete(idCartItem) {
    
    var confirmation = confirm("Вы хотите удалить ");
    if (confirmar) {

        if (idPessoa != null) {
            $.ajax({
                type: 'POST',
                url: "/ShoppingCart/RemoveFromCart",
                
                data: { id: idPessoa },
                success: function () {
                   
                    Listar();
                    Mensagem("success", "Успешно удалено");

                },
                error: function () {
                    Mensagem("danger", "Ошибка");

                }

            });

        }
    }
}
function Message(clas, message) {
    $("#message").remove();

    setTimeout(function () {
        $('#formDados').append("<div class='alert alert-" + clas + "' id=mensagem role=alert>" + message + "</div>");
    }, 10);
}