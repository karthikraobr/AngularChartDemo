//Init
var app = angular.module("AngularCharts", ["ui.grid", "ui.grid.grouping", "ui.grid.resizeColumns", "chart.js"]);
app.controller('MainCtrl', function ($scope, $http) {
    $scope.loading = "Fetch";
    //Hide Grid on pageload
    $scope.showGrid = false;
    //Method for pie chart selection
    $scope.onClick = function (selection) {
        if (selection)
            $scope.gridOptions.data = $scope.empData.filter(function (emp) { return emp.Department == selection[0].label.replace(/\D/g, '') })
    };

    //Method for resetting grid to default state
    $scope.reset = function () { $scope.gridOptions.data = $scope.empData }

    //The grid options
    $scope.gridOptions = {
        enableGridMenu: true,
        showGridFooter: true,
        enableFiltering: true,
        enableColumnResizing: true,
        columnDefs:
            [
          { name: 'Id' },
          { name: 'Name' },
          { name: 'Department' },
          { name: 'Date Of Birth', field: 'DOB', type: 'date', cellFilter: 'date:\'yyyy-MM-dd\'' },
          { name: 'Address' },
          { name: 'Category' },
          { name: 'Salary' }
            ]
    }

    //The cgart options
    $scope.chartOptions = {
        //Boolean - Whether we should show a stroke on each segment
        segmentShowStroke: true,

        //String - The colour of each segment stroke
        segmentStrokeColor: "#fff",

        //Number - The width of each segment stroke
        segmentStrokeWidth: 2,

        //Number - Amount of animation steps
        animationSteps: 100,

        //String - Animation easing effect
        animationEasing: "easeOutBounce",

        //Boolean - Whether we animate the rotation of the Doughnut
        animateRotate: true,

        //Boolean - Whether we animate scaling the Doughnut from the centre
        animateScale: false

    }

    $scope.getData = function () {
        $scope.loading="Fetching..."
        $http.get("/Home/GetEmployees/" + 30000)
                     .success(function (response) {
                         //Global object for resetting grid to default state
                         $scope.empData = response.Employees;
                         //Actual data bound to grid
                         $scope.gridOptions.data = response.Employees;

                         $scope.showGrid = true;
                         //Filtering labels from ajax response
                         $scope.labels = response.Departments.map(function (dept) { return "Department " + dept });
                         //Data fro the charts
                         $scope.data = [];
                         response.Departments.forEach(function (dept) {
                             $scope.data.push($scope.empData.filter(function (emp) { return emp.Department == dept }).length)
                         });
                         $scope.loading = "Fetch"
                     })
                     .error(function (response) {
                         $scope.error = response.data;
                         $scope.status = "Page load failed.";
                     });


    }
});