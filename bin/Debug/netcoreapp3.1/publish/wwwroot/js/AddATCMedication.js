function AddATCMedications() {

  let properties = {
    Id: $("#atc-medicationId").val(),
    MedicationName: $("#atc-medicationName").val(),
    MedicationDosage: $("#atc-medicationDosage").val(),
    MedicationMethodUse: $("#atc-medicationUse").val(),
    UseTime: $("#atc-useTime").val(),
    DoseTime: $("#atc-doseTime").val(),
    ReceituarioId: $("#atc-receituarioId-medication").val(),
  };

  $.post("/Medicacao/MedicationRegister", properties)

    .done(function (output) {
      if (output.stats == "OK") {

        alert("Medicação: " + properties.MedicationName + " cadastrada com sucesso!")
        $(location).attr('href', '/AtestadoComparecimento/ATCCompletePrescription?id=' + parseInt(properties.ReceituarioId));

      } else if (output.stats == "INVALID") {
        $(".alerta").html('<div class="alert alert-danger"> Não foi possível cadastrar essa medicação. Tente mais tarde!</div>');

      }
    })

    .fail(function () {
      alert("Falha ao adicionar medicamento!");
    });
}

$(document).ready(function () {
  $("#atc-medic-form").submit(function (e) {
    e.preventDefault();
    AddATCMedications();
  });
});