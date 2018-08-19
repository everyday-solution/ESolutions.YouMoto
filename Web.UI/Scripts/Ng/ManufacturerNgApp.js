var myApp = angular.module('ManufacturerNgApp', ['ngMaterial']);

myApp.controller('ShowManufacturersNgController', function ($scope) {
	//Scope
	$scope.manufacturers = [];
	$scope.isLoading = false;

	//Methods
	$scope.loadMore = function () {
		if (!$scope.isLoading) {
			$scope.isLoading = true;
			$.connection.manufacturerHub.server.loadManufacturers($scope.manufacturers.length, 28).done(function (data) {
				$scope.$apply(function () {
					$scope.manufacturers = $scope.manufacturers.concat(data);
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
