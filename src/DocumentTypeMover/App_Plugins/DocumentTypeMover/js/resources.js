angular.module('umbraco.resources').factory('documentTypeMoverResource', function ($q, $http, umbRequestHelper) {
    return {
        getSiblings: function (doctypeId) {
            return umbRequestHelper.resourcePromise(
                $http.get("/umbraco/backoffice/documenttypemoverapi/documenttypemover/getsiblings/?doctypeid=" + doctypeId), 'Failed to retrieve siblings'
            );
        }
    }
});