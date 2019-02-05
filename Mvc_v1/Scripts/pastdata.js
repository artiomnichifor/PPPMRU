$function(){

    $.validator.addMethod(
        "pastdata",
        function (value, element) {
            try {
                if ($(element).is('disabled'))
                    return true;
                if ($(element).is('[data-val-pastdata]')) {
                    if (isNaN($element).val(), 10);
                    return elementValue < DateTime.Now;
                }
            } catch (e) {
                return false;
            }
        },
        "");
    $.validator.unobtrusive.adapters.addBool("pastdata");
} (jQuery));