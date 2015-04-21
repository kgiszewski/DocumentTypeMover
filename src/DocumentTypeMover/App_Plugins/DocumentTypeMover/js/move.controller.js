angular.module('umbraco').controller('DocumentTypeMoverController', function ($scope, documentTypeMoverService, documentTypeMoverResource, iconHelper, treeService, navigationService) {

    documentTypeMoverResource.getSiblings($scope.currentNode.id).then(function (data) {
        
        //hack to handle the case-sensitivity for the iconHelper
        for (var i in data) {
            data[i].icon = data[i].Icon;
        }

        $scope.siblings = iconHelper.formatContentTypeIcons(data);
    });

    $scope.move = function (targetDocType) {
        
        if (confirm("Are you sure you want to move this?  This cannot be undone.")) {

            documentTypeMoverService.moveDoctype($scope.currentNode.id, targetDocType.Id).then(function (data) {
                treeService.loadNodeChildren({ node: $scope.currentNode.parent(), section: $scope.section });
                navigationService.hideNavigation();
            });
        }
    }
});