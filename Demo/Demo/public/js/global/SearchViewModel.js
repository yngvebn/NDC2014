function SearchViewModel() {
	var self = this;

	self.term = ko.observable();

    self.search = function() {
        if (self.term().length < 3) {
            alert('Please enter at least 3 characters');
            return;
        }

        window.location = '/search?q=' + self.term();

    };
}

$(function() {
    ko.applyBindings(new SearchViewModel(), document.getElementById('search-form'));
})