﻿var routeURL = location.protocol + "//" + location.host;
$(document).ready(function () {
    appointmentDate
    $("#appointmentDate").kendoDateTimePicker({
        value: new Date(),
        dateInput: false
    });
    InitializeCalendar();
});

function InitializeCalendar() {
    try {

        var calendarEl = document.getElementById('calendar');
        if (calendarEl != null) {
            calendar = new FullCalendar.Calendar(calendarEl, {
                initialView: 'dayGridMonth',
                headerToolbar: {
                    left: 'prev,next,today',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                selectable: true,
                editable: false,
                select: function (event) {
                    onShowModal(event, null);
                },
               
               
            }); // end if
            calendar.render();
        }

    }
    catch (e) {
        alert(e);
    }

} 

function onShowModal(obj, isEventDetail) {
    $("#appointmentInput").modal("show");
}

function onCloseModal() {
    $("#appointmentInput").modal("hide");
}

function onSubmitForm() {
   
    var requestData = {
        Id: parseInt($("#id").val()),
        Title: $("#tilte").val(),
        Description: $("#descriptions").val(),
        Location: $("#location").val(),
        StartDate: $("#appointmentDate").val(),
        PatientId: $("#patientId").val(),
        Duration: $("#duration").val(),

    };

    $.ajax({
        url: routeURL + '/api/Appointment/SaveCalendarData',
        type: 'POST',
        data: JSON.stringify(requestData),
        contentType: 'application/json',
        success: function (response) {
            if (response.status === 1 || response.status === 2) {
                //calendar.refetchEvents();
                $.notify(response.message, "success");
                onCloseModal();
            }
            else {
                $.notify(response.message, "error");
            }
        },
        error: function (xhr) {
            $.notify("Error", "error");
        }
    });
   
}// end SubmitForm

