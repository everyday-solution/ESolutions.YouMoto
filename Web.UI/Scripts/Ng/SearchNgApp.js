var myApp = angular.module('SearchNgApp', ['ngMaterial']);

myApp.controller('SearchNgController', function ($scope) {
	//Scope
	$scope.isLoading = false;
	$scope.noMoreHits = false;
	$scope.takeHits = 20;
	$scope.hits = [];
	$scope.searchTerm = globalSearchTerm;
	$scope.matchingSearchTerm = 'searching...';


	//Methods
	$scope.loadMore = function () {
		if (!$scope.isLoading && !$scope.noMoreHits) {
			$scope.isLoading = true;
			$.connection.searchHub.server.search($scope.searchTerm, $scope.hits.length, $scope.takeHits).done(function (data) {
				$scope.$apply(function () {
					$scope.noMoreHits = data.searchHits.length < $scope.takeHits;
					$scope.hits = $scope.hits.concat(data.searchHits);
					$scope.matchingSearchTerm = data.searchTerm;
					$scope.isLoading = false;
				});
			});
		}
	};

	//Constructor
	$scope.loadMore();
	$(document).scroll(function () {
		if ($(document).scrollTop() + $(window).height() >= $(document).height() - 50) {
			$scope.loadMore();
		}
	});
});
