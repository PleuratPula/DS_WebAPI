$(function () {
    getExamsList();
    getStudents();
    getProfessors();
    getSubjects();
});

// Get all exams to display
function getExamsList() {
    // Call Web API to get a list of exams
    $.ajax({
        url: 'http://localhost:50995/api/exams',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        crossOrigin: true,
        crossDomain: true,
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
        success: function (exams) {
            examListSuccess(exams);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        },
    });
}

// Display all exams returned from Web API call
function examListSuccess(exams) {
    // Iterate over the collection of data
    $('#examsTable tbody').remove();
    $.each(exams, function (index, exam) {
        // Add a row to the exam table
        examAddRow(exam);
    });
}

// Add student row to <table>
function examAddRow(exam) {
    // First check if a <tbody> tag exists, add one if not
    if ($('#examsTable tbody').length == 0) {
        $('#examsTable').append('<tbody></tbody>');
    }

    // Append row to <table>
    $('#examsTable tbody').append(examBuildTableRow(exam));
}

// Build a <tr> for a row of table data
function examBuildTableRow(exam) {
    var newRow =
        '<tr>' +
        '<td>' +
        exam.id +
        '</td>' +
        "<td><input  class='input-studentId' type='text' value='" +
        exam.studentId +
        "'/></td>" +
        "<td><input  class='input-subjectId'  type='text' value='" +
        exam.subjectId +
        "'/></td>" +
        "<td><input  class='input-professorId' type='text' value='" +
        exam.professorId +
        "'/></td>" +
        "<td><input  class='input-points' type='number' value='" +
        exam.points +
        "'/></td>" +
        "<td><input  class='input-grade' type='number' value='" +
        exam.grade +
        "'/></td>" +
        "data-id='" +
        exam.id +
        "' " +
        "data-studentId='" +
        exam.studentId +
        "' " +
        "data-subjectId='" +
        exam.subjectId +
        "' " +
        "data-professorId='" +
        exam.professorId +
        "' " +
        "data-points='" +
        exam.points +
        "' " +
        "data-grade='" +
        exam.grade +
        '>' +
        '</tr>';

    return newRow;
}

function onAddExam(item) {
    var options = {};
    options.url = 'http://localhost:50995/api/exams';
    options.type = 'POST';
    options.contentType = 'application/json; charset=utf-8';
    options.crossOrigin = true;
    options.crossDomain = true;
    options.headers = {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
    };
    var exam = {
        studentId: parseInt($('#studentsDropdown').val()),
        subjectId: parseInt($('#subjectsDropdown').val()),
        professorId: parseInt($('#professorsDropdown').val()),
        points: parseInt($('#points').val()),
        grade: parseInt($('#grade').val()),
    };
    clearForm();
    console.dir(exam);
    options.data = JSON.stringify(exam);
    options.dataType = 'html';

    (options.success = function (msg) {
        getExamsList();
        $('#msg').html(msg);
    }),
        (options.error = function (response) {
            var info = JSON.parse(response.responseText);
            $('#msg').html(info.message);
        });
    $.ajax(options);
}

function clearForm() {
    $('#studentsDropdown').val('-1');
    $('#subjectsDropdown').val('-1');
    $('#professorsDropdown').val('-1');
    $('#points').val('');
    $('#grade').val('');
}

// Get all students to display
function getStudents() {
    // Call Web API to get a list of students
    $.ajax({
        url: 'http://localhost:50995/api/students',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        crossOrigin: true,
        crossDomain: true,
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
        success: function (data) {
            var s = '<option value="-1">Zgjedh Studentin</option>';
            for (var i = 0; i < data.length; i++) {
                s +=
                    '<option value="' +
                    data[i].id +
                    '">' +
                    data[i].name +
                    ' ' +
                    data[i].surname;
                ('</option>');
            }
            $('#studentsDropdown').html(s);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        },
    });
}

// Get all professors to display
function getProfessors() {
    // Call Web API to get a list of professors
    $.ajax({
        url: 'http://localhost:50995/api/professors',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        crossOrigin: true,
        crossDomain: true,
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
        success: function (data) {
            var s = '<option value="-1">Zgjedh Profesorin</option>';
            for (var i = 0; i < data.length; i++) {
                s +=
                    '<option value="' +
                    data[i].id +
                    '">' +
                    data[i].professorName;
                ('</option>');
            }
            $('#professorsDropdown').html(s);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        },
    });
}

// Get all subjects to display
function getSubjects() {
    // Call Web API to get a list of subjects
    $.ajax({
        url: 'http://localhost:50995/api/subjects',
        type: 'GET',
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        crossOrigin: true,
        crossDomain: true,
        headers: {
            Authorization: 'Bearer ' + localStorage.getItem('token'),
        },
        success: function (data) {
            var s = '<option value="-1">Zgjedh Lenden</option>';
            for (var i = 0; i < data.length; i++) {
                s +=
                    '<option value="' + data[i].id + '">' + data[i].subjectName;
                ('</option>');
            }
            $('#subjectsDropdown').html(s);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        },
    });
}

// Handle exceptions from AJAX calls
function handleException(request, message, error) {
    var msg = '';
    msg += 'Code: ' + request.status + '\n';
    msg += 'Text: ' + request.statusText + '\n';
    if (request.responseJSON != null) {
        msg += 'Message' + request.responseJSON.Message + '\n';
    }

    alert(msg);
}
