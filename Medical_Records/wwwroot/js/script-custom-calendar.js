$(document).ready(function () {
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
        Id: parseInt($("#id").val().val()),
        Title: $("#tilte").val(),
        Description: $("#descriptions").val(),
        Location: $("#location").val(),
        StartDate: $("#appointmentDate").val(),
        PatientId: $("#patientId").val(),
        Duration: $("#duration").val(),

    };
}
