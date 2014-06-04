function TopFiveViewModel() {
    var self = this;
    self.movies = ko.observableArray([]);
    self.isLoading = ko.observable(true);
    $.get('/api/v1/movies?take=5', function (result) {
        self.movies(result);
        self.isLoading(false);
    });
}