function AddPrescription() {

  let properties = {
    Id: $("#prescriptionId").val(),
    PacientName: $("#pacientName").val(),
    DoctorName: $("#doctorName").val(),
    DateOfMedicalAppoiment: $("#dataAppoiment").val(),
  };

  $.post("/Receituario/Prescription", properties)

    .done(function (output) {
      if (output.id != null) {

        $(location).attr('href', '/Receituario/CompletePrescription?id=' + output.id);

      } else if (output.stats == "INVALID") {
        $(".alerta").html('<div class="alert alert-danger"> Não foi possível salvar esta receita. Tente novamente mais tarde!</div>');

      }
    })

    .fail(function () {
      alert("Falha ao salvar receita!");
    });
}

$(document).ready(function () {
  $("#receita-form").submit(function (e) {
    e.preventDefault();
    AddPrescription();
  });
});