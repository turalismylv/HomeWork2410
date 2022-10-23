$(function () {
    var skipRow = 1
    $(document).on('click', '#loadMore', function () {
        console.log("salam")
        $.ajax({
            method: "GET",
            url: "/home/loadmore",
            data: {
                skipRow: skipRow

            },
            success: function (result) {
                $('#recentWorkComponent').append(result);
                skipRow++
            }
        })
    })

    var skipRoww = 0;
    $(document).on('click', '#load', function () {
        console.log("salam")
        $.ajax({
            method: "GET",
            url: "/pricing/loadmore",
            data: {
                skipRoww: skipRoww
            },
            success: function (result) {
                $('#pricingcomponent').append(result);
                skipRoww++;
            }
        })
    })
    
})
$(function () {
    var skipRowww = 0
    $(document).on('click', '#loader', function () {
        console.log("salam")
        $.ajax({
            method: "GET",
            url: "/about/loadmore",
            data: {
                skipRowww: skipRowww

            },
            success: function (result) {
                $('#ourPartnerComponent').append(result);
                skipRowww++
            }
        })
    })
})

