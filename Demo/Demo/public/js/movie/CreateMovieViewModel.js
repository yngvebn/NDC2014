function CreateMovieViewModel() {
    var self = this;
    self.isSaving = ko.observable(false);
    self.title = ko.observable();
    self.description = ko.observable();

    self.save = function () {
        self.isSaving(true);
        $.post('/api/v1/movie', { title: self.title(), description: self.description() }, function() {
            window.location = '/movie/details?title=' + self.title();
            self.isSaving(false);
        });
    }
}
