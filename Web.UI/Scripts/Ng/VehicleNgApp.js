var myApp = angular.module('VehicleNgApp', ['ngMaterial']);

myApp.controller('ShowVehiclesNgController', function ($scope) {
	//Scope
	$scope.vehicles = [];
	$scope.isLoading = false;

	//Methods
	$scope.loadMore = function () {
		if (!$scope.isLoading) {
			$scope.isLoading = true;
			$.connection.vehicleHub.server.loadVehicles($scope.vehicles.length, 18).done(function (data) {
				$scope.$apply(function () {
					$scope.vehicles = $scope.vehicles.concat(data);
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
