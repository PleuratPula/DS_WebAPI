$(function () {
    getStudentsList();
});

// Get all students to display
function getStudentsList() {
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
        success: function (students) {
            studentListSuccess(students);
        },
        error: function (request, message, error) {
            handleException(request, message, error);
        },
    });
}

// Display all students returned from Web API call
function studentListSuccess(students) {
    // Iterate over the collection of data
    $('#studentsTable tbody').remove();
    $.each(students, function (index, student) {
        // Add a row to the students table
        studentAddRow(student);
    });
}

// Add student row to <table>
function studentAddRow(student) {
    // First check if a <tbody> tag exists, add one if not
    if ($('#studentsTable tbody').length == 0) {
        $('#studentsTable').append('<tbody></tbody>');
    }

    // Append row to <table>
    $('#studentsTable tbody').append(studentBuildTableRow(student));
}

// Build a <tr> for a row of table data
function studentBuildTableRow(student) {
    var newRow =
        '<tr>' +
        '<td>' +
        student.id +
        '</td>' +
        "<td><input  class='input-name' type='text' value='" +
        student.name +
        "'/></td>" +
        "<td><input  class='input-surname'  type='text' value='" +
        student.surname +
        "'/></td>" +
        "<td><input  class='input-dateOfBirth' type='text' value='" +
        student.dateOfBirth +
        "'/></td>" +
        "<td><input  class='input-index' type='text' value='" +
        student.index +
        "'/></td>" +
        "<td><input  class='input-departmentId' type='text' value='" +
        student.departmentId +
        "'/></td>" +
        "<td><input  class='input-status' type='text' value='" +
        student.status +
        "'/></td>" +
        '<td>' +
        "<button type='button' " +
        "onclick='studentUpdate(this);' " +
        "class='btn btn-default' " +
        "data-id='" +
        student.id +
        "' " +
        "data-name='" +
        student.name +
        "' " +
        "data-surname='" +
        student.surname +
        "' " +
        "data-dateOfBirth='" +
        student.dateOfBirth +
        "' " +
        "data-index='" +
        student.index +
        "' " +
        "data-departmentId='" +
        student.departmentId +
        "' " +
        "data-status='" +
        student.status +
        "' " +
        '>' +
        "<span class='glyphicon glyphicon-edit' /> Update" +
        '</button> ' +
        " <button type='button' " +
        "onclick='studentDelete(" +
        student.id +
        ");'" +
        "class='btn btn-default' " +
        "<span class='glyphicon glyphicon-remove'>Delete</span>" +
        '</button>' +
        '</td>' +
        '</tr>';

    return newRow;
}

function onAddStudent(item) {
    var options = {};
    options.url = 'http://localhost:50995/api/students/Add';
    options.type = 'POST';
    options.contentType = 'application/json; charset=utf-8';
    options.crossOrigin = true;
    options.crossDomain = true;
    options.headers = {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
    };
    var student = {
        name: $('#name').val(),
        surname: $('#surname').val(),
        dateOfBirth: $('#dateOfBirth').val(),
        index: $('#index').val(),
        departmentId: parseInt($('#department').val()),
        status: parseInt($('#status').val()),
    };
    clearForm();
    console.dir(student);
    options.data = JSON.stringify(student);
    options.dataType = 'html';

    (options.success = function (msg) {
        getStudentsList();
        $('#msg').html(msg);
    }),
        (options.error = function () {
            $('#msg').html('Error while calling the Web API!');
        });
    $.ajax(options);
}

function clearForm() {
    $('#name').val('');
    $('#surname').val('');
    $('#dateOfBirth').val('');
    $('#index').val('');
    $('#department').val('0');
    $('#status').val('0');
}

function studentUpdate(item) {
    var id = $(item).data('id');
    var options = {};
    options.url = 'http://localhost:50995/api/students/' + id;
    options.type = 'PUT';
    options.contentType = 'application/json; charset=utf-8';
    options.crossOrigin = true;
    options.crossDomain = true;
    options.headers = {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
    };

    var student = {
        id: $(item).data('id'),
        name: $('.input-name', $(item).parent().parent()).val(),
        surname: $('.input-surname', $(item).parent().parent()).val(),
        dateOfBirth: $('.input-dateOfBirth', $(item).parent().parent()).val(),
        index: $('.input-index', $(item).parent().parent()).val(),
        departmentId: parseInt(
            $('.input-departmentId', $(item).parent().parent()).val()
        ),
        status: parseInt($('.input-status', $(item).parent().parent()).val()),
    };
    console.log(student);

    console.dir(student);
    options.data = JSON.stringify(student);
    options.dataType = 'html';
    options.success = function (msg) {
        getStudentsList();
        $('#msg').html(msg);
    };
    options.error = function () {
        $('#msg').html('Error while calling the Web API!');
    };
    $.ajax(options);
}

function studentDelete(id) {
    var options = {};
    options.url = 'http://localhost:50995/api/students/' + id;
    options.type = 'DELETE';
    options.headers = {
        Authorization: 'Bearer ' + localStorage.getItem('token'),
    };
    options.dataType = 'html';
    options.crossOrigin = true;
    options.crossDomain = true;
    options.success = function (msg) {
        getStudentsList();
        $('#msg').html(msg);
    };
    options.error = function () {
        $('#msg').html('Error while calling the Web API!');
    };
    $.ajax(options);
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

function createSelectElement(element, data, selected) {
    var id = element.id.replace('Element', '');

    var select = document.createElement('select');
    // select.classList.add('form-control');
    select.id = id;

    data.forEach((item) => {
        var option = document.createElement('option');
        option.value = item.value;
        option.text = item.name;
        option.selected = selected ?? '';
        select.appendChild(option);
    });
    if (element) {
        element.appendChild(select);
    }
}
