function CreateMovieViewModel() {
    var self = this, _genres = [];


    self.isSaving = ko.observable(false);
    self.title = ko.observable();
    self.description = ko.observable();
    self.genres = ko.computed({
        read: function() {
            var genres = '';
            for (var i = 0; i < _genres.length; i++) {
                genres += _genres[i];
                if (i < _genres.length - 1) {
                    genres += ',';
                }
            }
            return genres;
        },
        write: function(value) {
            _genres = [];
            var splitGenres = value.split(',');
            for (var i = 0; i < splitGenres.length; i++) {
                _genres.push(splitGenres[i].trim());
            }
        }
    });

    self.save = function () {
        self.isSaving(true);
        $.post('/api/v1/movie', { title: self.title(), genres: _genres, description: self.description() || '' }, function() {
            window.location = '/movie/details?title=' + self.title();
            self.isSaving(false);
        });
    }
}
