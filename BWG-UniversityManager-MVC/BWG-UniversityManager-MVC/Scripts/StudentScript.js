var timetable = document.getElementById("timeTable");
var coursesToRegisterTable = document.getElementById("coursesToRegisterTable");

function getTimeTable() {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxStudentForStudent/GetTimeTable");
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);
        timetable.style.display = "table";
        coursesToRegisterTable.style.display = 'none';

        let table = '<tr><th style="text-align:center">Subject</th><th style="text-align:center">StartTime</th><th style="text-align:center">TimeEnd</th><th>  </th></tr>';
        for (let i = 0; i < parsed.length; i++) {
            table += "<tr><td>" +
                parsed[i].Subject +
                "</td><td>" +
                convert(parsed[i].StartDate) +
                "</td>" + "<td>" + convert(parsed[i].EndDate) + "</td>" +
                "<td>" + showPayBtnOrNot(parsed[i].Fee, parsed[i].Student, parsed[i].Id) + "</td>" +
                "</tr>";
        }
        timetable.innerHTML = table;
    }

}
function showPayBtnOrNot(feeStatus, student, course) {
    // alert(student+" is check if paid or not");
    if (feeStatus != "paid") {
        return '<button onclick="payThisCourse(\'' + student + '\',\'' + course + '\')" class="btn btn-info">Pay Fee</button>';
    }
    else return '<button  class="btn btn-light"> You paid </button>';

}

function payThisCourse(student, course) {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxStudentForStudent/PayThisCourse?student=" + student + "&course=" + course);
    xhttp.send();
    xhttp.onload = function () {
        getTimeTable();
    }
}

function showCoursesToRegister() {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxStudentForStudent/ShowCoursesToRegister");
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);
        timetable.style.display = "none";
        coursesToRegisterTable.style.display = 'table';

        let table = '<tr> <th style="text-align:center">Subject</th>          <th style="text-align:center">StartTime</th>           <th style="text-align:center">TimeEnd</th>            <th style="text-align:center">Day in week</th>         <th style="text-align:center">Preiod</th>            <th style="text-align:center">Register</th></tr>';
        for (let i = 0; i < parsed.length; i++) {
            table += "<tr><td>" +
                parsed[i].Subject +
                "</td><td>" +
                convert(parsed[i].StartDate) +
                "</td>" + "<td>" + convert(parsed[i].EndDate) + "</td>" +
                "<td>" + parsed[i].Date + "</td>"+
                "<td>" + parsed[i].Time + "</td>" +
                "<td>" + '<button onclick="registerToCourse((\'' + parsed[i].Id + '\'))" class="btn btn-success">Register</button>' + "</td>" +
                "</tr>";
        }
        coursesToRegisterTable.innerHTML = table;
    }

}
function registerToCourse(course) {

    const xhttp = new XMLHttpRequest();
    xhttp.open("POST", "..//../AjaxStudentForStudent/RegisterToCourse?course=" + course);
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);
        if (parsed == "Registered") {
            alert(parsed);
            showCoursesToRegister();
        }
        else {
            alert(parsed);
            if (confirm("Still register")) {
                xhttp.open("POST", "..//../AjaxStudentForStudent/RegisterToCourse?course=" + course + "&keepConflict=keepConflict");
                xhttp.send();
            } else {
                txt = "You pressed Cancel!";
            }

        }
    }

}


function onStartLoad() {
    helloTextWithName();
}


function helloTextWithName() {

    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxStudentForStudent/ReturnName");
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);

        var hellotext = document.getElementById("hellotext");
        hellotext.innerHTML = 'Hello, Student ' + parsed;
        let quotes = ['No matter how busy you may think you are, you must find time for reading, or surrender yourself to self-chosen ignorance.', 'Let us study things that are no more. It is necessary to understand them, if only to avoid them.', 'The authority of those who teach is often an obstacle to those who want to learn.', 'To acquire knowledge, one must study;but to acquire wisdom, one must observe.', 'You can not study the darkness by flooding it with light.', 'The art of reading and studying consists in remembering the essentials and forgetting what is not essential.'];
        let famousnames = ['Atwood H. Townsend', 'Victor Hugo, Les Misérables', 'Marcus Tullius Cicero', 'Marilyn vos Savant', 'Edward Abbey', 'Adolf Hitler, Mein Kampf'];
        let index = Math.floor(Math.random() * 6);
        document.getElementById("quote").innerHTML = quotes[index];
        document.getElementById("famousname").innerHTML = famousnames[index];
    }
}


function convert(value) {
    if ((""+value) == "NULL" ||(""+ value )== "null") {
        return "not determined";
    }
    var str = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [mnth, day, date.getFullYear()].join("/");
}
window.onload = onStartLoad();