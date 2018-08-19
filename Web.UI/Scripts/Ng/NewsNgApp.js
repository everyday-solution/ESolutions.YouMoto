var myApp = angular.module('NewsNgApp', ['ngMaterial']);

myApp.controller('EditNewsNgController', function ($scope) {
	//Scope
	$scope.selectedItem = undefined;
	$scope.searchHits = [];
	$scope.searchText = '';
	$scope.panelStates = {
		create: '',
		title: '',
		picture: '',
		text: '',
		related: '',
		source: ''
	};

	//Private Methods
	var createTextBlocks = function () {
		$scope.textBlocks = $.map($scope.model.text.split("\n"), $.trim).filter(function (element) {
			return element !== '\r' && !isNaN(element.charCodeAt(0));
		});
	};

	//Methods
	$scope.updateNews = function () {
		$.connection.newsHub.server.updateNews($scope.model.guid, $scope.model.title, $scope.model.text, $scope.model.sourceLink).done(function () {
			$scope.$apply(function () {
				createTextBlocks();
				$scope.panelStates['title'] = '';
				$scope.panelStates['text'] = '';
				$scope.panelStates['source'] = '';
				$scope.panelStates['related'] = '';
			});
		});
	};

	$scope.addPicture = function () {
		$.connection.newsHub.server.addPicture($scope.model.guid, $scope.addPictureLink).done(function (newsJson) {
			$scope.$apply(function () {
				$scope.init(newsJson);
				$scope.togglePanel('picture');
			});
		});
	};

	$scope.deletePicture = function (newsPictureGuid) {
		$.connection.newsHub.server.deletePicture(newsPictureGuid).done(function (newsJson) {
			$scope.$apply(function () {
				$scope.init(newsJson);
			});
		});
	};

	$scope.addVehicle = function () {
		if ($scope.selectedItem !== null) {
			$.connection.newsHub.server.addVehicle($scope.model.guid, $scope.selectedItem.guid).done(function (newsJson) {
				$scope.$apply(function () {
					$scope.init(newsJson);
					$scope.togglePanel('related');
				});
			});
		}
	};

	$scope.deleteVehicle = function (newsVehicleGuid) {
		$.connection.newsHub.server.deleteVehicle(newsVehicleGuid).done(function (newsJson) {
			$scope.$apply(function () {
				$scope.init(newsJson);
			});
		});
	};

	$scope.searchVehicles = function (searchText) {
		return $.connection.searchHub.server.searchVehicles(searchText).done(function (vehicles) {
			return vehicles;
		});
	};

	$scope.togglePanel = function (panel) {
		var currentState = $scope.panelStates[panel] !== '';
		var newState = !currentState;
		$scope.panelStates[panel] = newState ? 'expanded' : '';
	};

	$scope.getToggleState = function (panel) {
		return $scope.panelStates[panel];
	};

	$scope.init = function (newsJson) {
		$scope.model = newsJson;
		createTextBlocks();
	};
});

myApp.controller('ShowNewsNgController', function ($scope) {
	//Scope
	$scope.news = [];
	$scope.title = '';
	$scope.isLoading = false;
	$scope.panelStates = {
		create: '',
		title: '',
		text: '',
		related: '',
		source: ''
	};

	//Methods
	$scope.loadMore = function () {
		if (!$scope.isLoading) {
			$scope.isLoading = true;
			$.connection.newsHub.server.loadNews($scope.news.length, 9).done(function (data) {
				$scope.$apply(function () {
					$scope.news = $scope.news.concat(data);
				});

				$scope.isLoading = false;
			});
		}
	};

	$scope.createNews = function () {
		$.connection.newsHub.server.createNews($scope.title).done(function (news) {
			$scope.$apply(function () {
				var temp = [];
				temp.push(news);
				$scope.news = temp.concat($scope.news);
				$scope.togglePanel('create');
			});
		});
	};

	$scope.togglePanel = function (panel) {
		var currentState = $scope.panelStates[panel] !== '';
		var newState = !currentState;
		$scope.panelStates[panel] = newState ? 'expanded' : '';
	};

	$scope.getToggleState = function (panel) {
		return $scope.panelStates[panel];
	};

	//Constructor
	$scope.loadMore();
	$(document).scroll(function () {
		if ($(document).scrollTop() + $(window).height() >= $(document).height() - 50) {
			$scope.loadMore();
		}
	});
});

