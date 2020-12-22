var btn = $('#back-to-top-btn');

$(window).scroll(function () {
    if ($(window).scrollTop() > 300) {
        btn.addClass('show');
    } else {
        btn.removeClass('show');
    }
});

btn.on('click', function (e) {
    e.preventDefault();
    $('html, body').animate({ scrollTop: 0 }, '300');
});


$('[data-toggle="popover-hover"]').popover({
    html: true,
    trigger: 'hover',
    placement: 'right',
    content: function () { return '<img class="hover-image" src="' + $(this).data('img') + '" />'; }
});

const applyArrowHide = {
    name: 'applyArrowHide',
    enabled: true,
    phase: 'write',
    fn({ state }) {
        const { arrow } = state.elements;

        if (arrow) {
            if (state.modifiersData.arrow.centerOffset !== 0) {
                arrow.setAttribute('data-hide', '');
            } else {
                arrow.removeAttribute('data-hide');
            }
        }
    },
};