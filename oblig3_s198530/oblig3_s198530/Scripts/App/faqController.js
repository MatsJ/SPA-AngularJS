var App = angular.module("App", []);

App.controller("faqController", function ($scope, $http) {

    var url = '/api/Faq/';
    var url2 = '/api/Ques/';
    var url3 = '/api/Cat/';
    var url4 = '../../api/Faq/GetFAQ/';

    //get all FAQ
    function getAllFAQ() {
        $http.get(url).
          success(function (allFAQ) {
              $scope.faqs = allFAQ;
              $scope.loading = false;
              $scope.showFAQ = true;
              $scope.main = true;
              $scope.showCatsMenu = true;
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
    $scope.newQuestionHeader = false;
    $scope.showQuestionForm = false;
    $scope.showFAQ = true;
    $scope.loading = true;
    $scope.regKnapp = true;
    $scope.showCatsMenu = true;
    getAllFAQ();

    //get all new questions
    function getNewQuestions() {
        $http.get(url2).
            success(function (unanswered) {
                $scope.unanswered = unanswered;
                $scope.show_new_questions = true;
                $scope.showFAQ = false;
                $scope.showQuestionForm = false;
                $scope.sentQuestion = false;
                $scope.categoryfaq = false;
            }).
            error(function (data, status) {
                console.log(status + data);
            });
    };

    $scope.getNewQuestions = function () {
        getNewQuestions();
    }

    function getFAQCategories() {
        $http.get(url3).
        success(function (cats) {
            $scope.cats = cats;

        }).
        error(function (data, status) {
            console.log(status + data);
        });
    };

    $scope.allCats = getFAQCategories();

    $scope.getFAQCategory = function (categoryid) {
        $scope.questionForm = false;
        $scope.showFAQ = false;
        $scope.sentQuestion = false;
        $scope.categoryfaq = true;
        $scope.show_new_questions = false;
        $http({
            url: url4,
            params: {categoryid: categoryid }}).
            success(function (faqsfromcats) {
                $scope.faqsfromcats = faqsfromcats;
            }).
            error(function (data, status) {
                console.log("Error: " + status + " " + data);
            });
    };

    $scope.showFaqsFunction = function () {
        $scope.showFAQ = true;
        $scope.showQuestionForm = false;
        $scope.show_new_questions = false;
        $scope.regKnapp = true;
        $scope.sentQuestion = false;
        $scope.showEveryFAQ = false;
        $scope.categoryfaq = false;
    };

    $scope.showMsgFunction = function () {
        $scope.sentQuestion = true;
        $scope.showQuestionForm = false;
    };

    $scope.questionForm = function () {
        $scope.name = "";
        $scope.email = "";
        $scope.category = "";
        $scope.question = "";
        $scope.showQuestionForm = true;
        $scope.newQuestionHeader = true;
        $scope.showFAQ = false;
        $scope.regKnapp = false;
        // for å unngå at noen av feltene gir "falske" feilmeldinger 
        $scope.skjema.$setPristine();
        $scope.sendBtn = true;
    };

    $scope.detailFAQ = function (id) {
        getAFAQ(id);
        $scope.detail = true;
    }

    $scope.addFAQ = function () {
        // lag et object for overføring til server via post
        console.log("Inne i addFAQ");
        var faq = {
            name: $scope.name,
            email: $scope.email,
            title: $scope.title,
            category: $scope.category,
            question: $scope.question
        };

        console.log("Rett før post");
        $http.post(url, faq).
          success(function (data) {
              $scope.showMsgFunction();
              console.log("Added FAQ OK!")
          }).
          error(function (data, status) {
              console.log(status + data);
          });
    };
});