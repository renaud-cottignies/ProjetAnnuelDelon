var textObjects = [
	        {
	            offset: 0,
	            duration: 2000,
	            animation: 'leftToRight'
	        },
	        {
	            offset: 1000,
	            duration: 2000,
	            animation: 'rightToLeft'
	        },
            {
                offset: 2000,
                duration: 2000,
                animation: 'leftToRight'
            },
	        {
	            offset: 3000,
	            duration: 2000,
	            animation: 'rightToLeft'
	        },
	        {
	            offset: 4000,
	            duration: 4000,
	            animation: 'implode'
	        }
],
	    options = {
	        repeat: true
	    },
	    animations = {

	    };



$('document').ready(function () {

    $('#butCallRegister').click(function () {
        $('.contentPopupInscription').lightbox_me({
            centered: true,
            closeEsc: true,
            onLoad: function () {
                $('#sign_up').find('input:first').focus()
            }
        });
    });
   
    
    $('#banner-slide').bjqs({
        animtype: 'slide',
        height: 500,
        width: 1000,
        responsive: true,
        randomstart: true
    });
    $("#anims").animateText(textObjects, options, animations);
});
