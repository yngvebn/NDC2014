
function MovieDetailsViewModel() {
    var self = this;

    self.title = ko.observable('');
    self.description = ko.observable('');

    var queryString = {};
    window.location.search.replace(
        new RegExp("([^?=&]+)(=([^&]*))?", "g"),
        function ($0, $1, $2, $3) { queryString[$1] = $3; }
    );
    $.get('/api/v1/movie/' + queryString.title, function (result) {
        self.title(result.Title);
        self.description(result.Description);

    });
}