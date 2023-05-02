function AddATC() {

  let properties = {
    Id: $("#atcId").val(),
    PacientName: $("#atc-pacientName").val(),
    Turno: $("#atc-turn").val(),
    ReceituarioId: $("#atc-receituarioId").val(),
  };

  $.post("/AtestadoComparecimento/ATCRegister", properties)

    .done(function (output) {
      if (output.stats == "OK") {

        alert("Atestado de: " + properties.PacientName + " gerado com sucesso!")
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
  $("#atc-form").submit(function (e) {
    e.preventDefault();
    AddATC();
  });
});