var myApp = angular.module('GarageNgApp', ['ngMaterial']);

myApp.controller('ShowGaragesNgController', function ($scope) {
	//Scope
	$scope.garages = [];
	$scope.isLoading = false;

	//Methods
	$scope.loadMore = function () {
		if (!$scope.isLoading) {
			$scope.isLoading = true;
			$.connection.garageHub.server.loadGarages(garageMode, $scope.garages.length, 9).done(function (data) {
				$scope.$apply(function () {
					$scope.garages = $scope.garages.concat(data);
				});

				$scope.isLoading = false;
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

