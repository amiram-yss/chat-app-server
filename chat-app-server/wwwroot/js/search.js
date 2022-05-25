$(function () {
    $('form').submit(e => {
        e.preventDefault()

        const q = $('#search').val()

        $('tbody').load('/Ratings/SearchPartialView?query='+q)
    })
});