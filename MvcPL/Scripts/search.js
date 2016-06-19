//$('#searchInput').oninput(findtags);
function findtags() {
    var autocompleteUrl = '@Url.Action("FindTags", "Search")';
    $("input#searchInput").autocomplete({
        source: autocompleteUrl,
        minLength: 2,
        data: {term : $('#searchInput').val()},
        select: function (event, ui) {
            alert("Selected " + ui.item.label);
        }
    });
};