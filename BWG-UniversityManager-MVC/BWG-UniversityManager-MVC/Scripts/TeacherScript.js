
var timetable = document.getElementById("timeTable");
var giveStudentPointZone = document.getElementById("givestudentpointzone");
var tablegivepoint = document.getElementById("givePoints");
function getTimeTable() {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxTeacher/GetTimeTable");
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);
        timetable.style.display = "table";
        giveStudentPointZone.style.display = 'none';

        let table = '<tr><th style="text-align:center">Subject</th><th style="text-align:center">StartTime</th><th style="text-align:center">TimeEnd</th><th style="text-align:center">Time</th><th style="text-align:center">Status</th><th style="text-align:center"></th></tr>';
        for (let i = 0; i < parsed.length; i++) {
            table += "<tr><td>" +
                parsed[i].Subject +
                "</td><td>" +
                convert(parsed[i].StartDate) +
                "</td>" + "<td>" + convert(parsed[i].EndDate) + "</td>" +
                "<td>" + parsed[i].Time + '</td>' +
                "<td>" + parsed[i].Status + '</td>' +
                "<td>" + '<button onclick="giveThisCoursePoint((\'' + parsed[i].Id + '\'))" class="btn btn-info">Give Point</button>' + "</td>" +
                "</tr>";
        }
        timetable.innerHTML = table;
    }

}
function savePoints() {
    alert("Point Saved!");
    var listofID = document.getElementsByClassName("studentId");
    var listOfPoint = document.getElementsByClassName("pointvalue");
    for (var i = 0; i < listofID.length; i++) {
        if (isValidScore(listOfPoint[i].value)) {
            const xhttp = new XMLHttpRequest();
            xhttp.open("POST", "..//../AjaxTeacher/SavePoints?id=" + listofID[i].innerHTML + "&point=" + listOfPoint[i].value);
            xhttp.send();
        }
        else alert("score'" + listOfPoint[i].value + "' is not valid score");
    }
}
function giveThisCoursePoint(subjectid) {
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxTeacher/GetListRegisteredCourseFromRegisteredCourse?courseid=" + subjectid);
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);
      
        if (parsed == "cannot get") {
            alert("there are no student int this class");
            tablegivepoint.innerHTML = "";
            return;
        }
        else if (parsed.length > 0) {
            timetable.style.display = 'none';
            giveStudentPointZone.style.display = 'block';
            let table = '<tr><th style="text-align:center">Name</th><th style="text-align:center">ID</th><th style="text-align:center">Point</th></tr>';
            for (let i = 0; i < parsed.length; i++) {
                table += "<tr>" +
                    "<td>" +
                    '<div class="student">' + parsed[i].Student + '</div>' +
                    "</td>" +
                    "<td>" +
                    '<div class="studentId">' + parsed[i].Id + '</div>' +
                    "</td><td>" +
                    '<input class="pointvalue" type="text" value=' + parsed[i].Point + ' >' +
                    "</td>" +
                    "</tr>";
            }
            tablegivepoint.innerHTML = table;
        }
        else alert("Sorry, there are no student to give point :( ");
    }
}

function onStartLoad() {
    //hideOtherTabs();
    helloTextWithName();
}
function hideOtherTabs() {
    document.getElementById("StudentTab").remove();
    document.getElementById("ClassTab").remove();
    document.getElementById("DepartmentTab").remove();
    document.getElementById("UniversityTab").remove();
    document.getElementById("AdminTab").remove();
}

function helloTextWithName() {

    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxTeacher/ReturnName");
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);

        var hellotext = document.getElementById("hellotext");
        hellotext.innerHTML = 'Hello, teacher ' + parsed;
        let quotes = ['I cannot teach anybody anything; I can only make them think.', 'Tell me and I forget. Teach me and I remember. Involve me and I learn.', 'Teaching is the greatest act of optimism.', 'If you are planning for a year, sow rice; if you are planning for a decade, plant trees; if you are planning for a lifetime, educate people.', 'Education is not preparation for life; education is life itself.', 'What sculpture is to a block of marble, education is to a human soul.'];
        let famousnames = ['Socrates', 'Benjamin Franklin', 'Colleen Wilcox', 'Chinese Proverb', 'John Dewey', 'Joseph Addison'];
        let index = Math.floor(Math.random() * 6);
        document.getElementById("quote").innerHTML = quotes[index];
        document.getElementById("famousname").innerHTML = famousnames[index];




    }
}


function convert(value) {
    if (("" + value) == "NULL" || ("" + value) == "null") {
        return "not determined";
    }
    var str = new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    var date = new Date(str),
        mnth = ("0" + (date.getMonth() + 1)).slice(-2),
        day = ("0" + date.getDate()).slice(-2);
    return [mnth, day, date.getFullYear()].join("/");
}
window.onload = onStartLoad();
function isValidScore(score) {
    if (isNumeric(score)){
        if (parseFloat(score) <= 10 && parseFloat(score) >= 0) return true;
    }
    if (score == "null") return true;
    return false;
}

function isNumeric(str) {
    if (typeof str != "string") return false 
    return !isNaN(str) && 
        !isNaN(parseFloat(str)) 
}
function getTrueTimeTable() {
    document.getElementById("trueTimeTable").style.display = "block";
    console.log("getting timetable");
    const xhttp = new XMLHttpRequest();
    xhttp.open("GET", "..//../AjaxTeacher/GetTimeTable");
    xhttp.send();
    xhttp.onload = function () {
        const parsed = JSON.parse(this.responseText);
        for (let i = 0; i < parsed.length; i++) {
            let dayCol=0;
            if(parsed[i].Date=='Monday') dayCol=1;
            if(parsed[i].Date=='Tuesday') dayCol=3;
    
            if(parsed[i].Date=='Wednesday') dayCol=5;
    
            if(parsed[i].Date=='Thursday') dayCol=7;
    
            if(parsed[i].Date=='Friday') dayCol=9;
    
            if(parsed[i].Date=='Saturday') dayCol=11;
    
            if(parsed[i].Date=='Sunday') dayCol=13;
            console.log(dayCol);
            console.log(parsed[i].Sulibject);
            var startPer=parsed[i].Time.slice(0,1);
            console.log(startPer);
            var endPer=parsed[i].Time.slice(2,3);
            console.log(endPer);
            for(let k=startPer;k<=endPer;k++){
                document.getElementById("pe"+k.toString()).childNodes[dayCol].innerHTML=parsed[i].Subject;
            }
        }
    }

}