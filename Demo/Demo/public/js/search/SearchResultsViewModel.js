function SearchResultsViewModel() {
    var self = this;

    self.isLoading = ko.observable(true);
    self.results = ko.observableArray([]);

    function search(searchTerm) {
        $.get('/api/v1/search?term=' + searchTerm, function (result) {
            self.results(result);
            self.isLoading(false);
        });
    }
    var queryString = {};
    window.location.search.replace(
        new RegExp("([^?=&]+)(=([^&]*))?", "g"),
        function ($0, $1, $2, $3) { queryString[$1] = $3; }
    );
    search(queryString.q);

}