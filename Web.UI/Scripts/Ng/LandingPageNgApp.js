var myApp = angular.module('LandingPageNgApp', []);

myApp.controller('LandingPageNgController', function ($scope) {
	//Scope
	$scope.isLoadingNews = false;
	$scope.isLoadingGarages = false;
	$scope.isLoadingVehicles = false;
	$scope.news = [];
	$scope.garages = [];
	$scope.vehicles = [];
	$scope.title = '';

	//Methods
	$scope.loadMore = function () {
		if (!$scope.isLoadingNews) {
			$scope.isLoadingNews = true;
			$.connection.newsHub.server.loadNews($scope.news.length, 4).done(function (data) {
				$scope.$apply(function () {
					$scope.news = $scope.news.concat(data);
				});

				$scope.isLoadingNews = false;
			});
		}

		if (!$scope.isLoadingGarages) {
			$scope.isLoadingGarages = true;
			$.connection.garageHub.server.loadGarages($scope.news.length, 5).done(function (data) {
				$scope.$apply(function () {
					$scope.garages = $scope.garages.concat(data);
				});

				$scope.isLoadingGarages = false;
			});
		}

		if (!$scope.isLoadingVehicles	) {
			$scope.isLoadingVehicles = true;
			$.connection.vehicleHub.server.loadVehiclesRandom(15).done(function (data) {
				$scope.$apply(function () {
					$scope.vehicles = $scope.vehicles.concat(data);
				});

				$scope.isLoadingVehicles = false;
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

