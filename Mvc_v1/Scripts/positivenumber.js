$function(){

    $.validator.addMethod(
        "positivenumber",
        function (value, element) {
            try {
                if ($(element).is('disabled'))
                    return true;
                if ($(element).is('[data-val-positivenumber]')) {
                    if (isNaN($element).val(), 10);
                    var maxLong = 9223372036854775807;
                    return elementValue > 0 && element < maxLong;
                }
            } catch (e) {
                return false;
            }
        },
        "");
    $.validator.unobtrusive.adapters.addBool("positivenumber");
} (jQuery));