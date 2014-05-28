function SearchResultsViewModel(term) {
    var self = this;

    self.isLoading = ko.observable(true);
    self.results = ko.observableArray([]);

    function search(searchTerm) {
        $.get('/api/v1/search?term=' + searchTerm, function(result) {
            var results = ko.utils.arrayMap(result, function(item) {
                return {
                    title: item.Title,
                    description: item.Description,
                };
            });

            self.results(results);
            self.isLoading(false);
        });
    }

    search(term);

}