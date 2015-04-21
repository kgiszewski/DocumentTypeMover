angular.module('umbraco.services').factory('documentTypeMoverService', function ($q, $http, umbRequestHelper) {
    return {
        moveDoctype: function (doctypeId, targetDocTypeId) {
            return umbRequestHelper.resourcePromise(
                $http.post("/umbraco/backoffice/documenttypemoverapi/documenttypemover/moveDoctype", { doctypeId: doctypeId, targetDoctypeId: targetDocTypeId }), 'Failed to move doctype'
            );
        }
    }
});