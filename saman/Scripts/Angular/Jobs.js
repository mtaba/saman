var app= angular.module("saman",[]);
app.controller("jobsContrl", function($scope,$http){
    debugger;

    $scope.GetAllJobs = function(){
        $http({
            url:"/Jobs/GetJobs" , 
            method: "get",
            datatype:JSON
        }).then(function (response) {
            alert(response);
            $scope.Jobs = response.data;
        }, function () {
            alert("خطا در دریافت اطلاعات");
          
        })
    };  //#function GetAllJobs

})  // # controller

