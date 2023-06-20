function AddMedications() {

  let properties = {
    Id: $("#medicationId").val(),
    MedicationName: $("#medicationName").val(),
    MedicationDosage: $("#medicationDosage").val(),
    MedicationMethodUse: $("#medicationUse").val(),
    UseTime: $("#useTime").val(),
    DoseTime: $("#doseTime").val(),
    ReceituarioId: $("#receituarioId").val(),
  };

  $.post("/Medicacao/MedicationRegister", properties)

    .done(function (output) {
      if (output.stats == "OK") {

        alert("Medicação: " + properties.MedicationName + " - " + properties.MedicationDosage + " cadastrada com sucesso!")
        $(location).attr('href', '/Receituario/CompletePrescription?id=' + parseInt(properties.ReceituarioId));

      } else if (output.stats == "INVALID") {
        $(".alerta").html('<div class="alert alert-danger"> Não foi possível cadastrar essa medicação. Tente mais tarde!</div>');

      }
      
    })

    .fail(function () {
      alert("Falha ao adicionar medicamento!");
    });
}

$(document).ready(function () {
  $("#medic-form").submit(function (e) {
    e.preventDefault();
    AddMedications();
  });
});