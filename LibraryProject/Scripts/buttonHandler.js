//$(".button-saver").click(function () {
//    alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/booksList.txt")
//});

//$(".db-saver").click(function () {
//    alert("Saved to Data Base")
//});

$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".viewDialog").on("click", function (e) {
        e.preventDefault();

        $("<div></div>")
            .addClass("dialog")
            .appendTo("body")
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true
            })
            .load(this.href);
    });
});

$("#SaveBooksTxtList").click(function (e) {
    e.preventDefault();
    $.get(
        'api/values/SaveBooksTxtList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/booksList.txt")
    );
});

$("#SaveBooksXmlList").click(function (e) {
    e.preventDefault();
    $.get(
        '/api/values/SaveBooksXmlList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/booksList.xml")
    );
});

$("#SaveNewspapersTxtList").click(function (e) {
    e.preventDefault();
    $.get(
        'api/values/SaveNewspapersTxtList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/newspaperList.txt")
    );
});

$("#SaveNewspapersXmlList").click(function (e) {
    e.preventDefault();
    $.get(
        '/api/values/SaveNewspapersXmlList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/newspaperList.xml")
    );
});

$("#SaveBukletsTxtList").click(function (e) {
    e.preventDefault();
    $.get(
        'api/values/SaveBukletsTxtList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/bukletList.txt")
    );
});

$("#SaveBukletsXmlList").click(function (e) {
    e.preventDefault();
    $.get(
        '/api/values/SaveBukletsXmlList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/bukletList.xml")
    );
});

$("#SaveMagazinesTxtList").click(function (e) {
    e.preventDefault();
    $.get(
        'api/values/SaveMagazinesTxtList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/magazineList.txt")
    );
});

$("#SaveMagazinesXmlList").click(function (e) {
    e.preventDefault();
    $.get(
        '/api/values/SaveMagazinesXmlList',
        alert("Get your list from: ~/visual studio 2015/Projects/LibraryProject/LibraryProject/App_Data/magazineList.xml")
    );
});