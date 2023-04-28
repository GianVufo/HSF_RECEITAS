function AddATMMedications() {

  let properties = {
    Id: $("#atm-medicationId").val(),
    MedicationName: $("#atm-medicationName").val(),
    MedicationDosage: $("#atm-medicationDosage").val(),
    MedicationMethodUse: $("#atm-medicationUse").val(),
    UseTime: $("#atm-useTime").val(),
    DoseTime: $("#atm-doseTime").val(),
    ReceituarioId: $("#atm-receituarioId").val(),
  };

  $.post("/Medicacao/MedicationRegister", properties)

    .done(function (output) {
      if (output.stats == "OK") {

        alert("Medicação: " + properties.MedicationName + " cadastrada com sucesso!")
        $(location).attr('href', '/AtestadoMedico/ATMCompletePrescription?id=' + parseInt(properties.ReceituarioId));

      } else if (output.stats == "INVALID") {
        $(".alerta").html('<div class="alert alert-danger"> Não foi possível cadastrar essa medicação. Tente mais tarde!</div>');

      }
    })

    .fail(function () {
      alert("Falha ao adicionar medicamento!");
    });
}

$(document).ready(function () {
  $("#atm-medic-form").submit(function (e) {
    e.preventDefault();
    AddATMMedications();
  });
});