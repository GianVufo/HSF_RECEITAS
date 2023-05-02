function AddATCPrescription() {

  let properties = {
    Id: $("#atc-prescriptionId").val(),
    PacientName: $("#atc-pacientName-prescription").val(),
    DoctorName: $("#atc-doctorName").val(),
    DateOfMedicalAppoiment: $("#atc-dataAppoiment").val(),
  };

  $.post("/AtestadoComparecimento/ATCPrescription", properties)

    .done(function (output) {
      if (output.id != null) {

        $(location).attr('href', '/AtestadoComparecimento/ATCCompletePrescription?id=' + output.id);

      } else if (output.stats == "INVALID") {
        $(".alerta").html('<div class="alert alert-danger"> Não foi possível salvar esta receita. Tente novamente mais tarde!</div>');

      }
    })

    .fail(function () {
      alert("Falha ao salvar receita!");
    });
}

$(document).ready(function () {
  $("#atc-receita-form").submit(function (e) {
    e.preventDefault();
    AddATCPrescription();
  });
});