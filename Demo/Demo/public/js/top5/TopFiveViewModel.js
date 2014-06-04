function TopFiveViewModel() {
    var self = this;
    self.movies = ko.observableArray([]);
    self.isLoading = ko.observable(true);
    $.get('/api/v1/movies?take=5', function (result) {
        var results = ko.utils.arrayMap(result, function (item) {
            return {
                title: item.Title,
                description: item.Description,
            };
        });

        self.movies(results);
        self.isLoading(false);
    });
}