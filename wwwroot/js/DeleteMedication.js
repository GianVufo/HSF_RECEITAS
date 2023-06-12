function deleteMedication(idItem) {
  var url = "/Medicacao/DeleteMedication";
  $.ajax({

    url: url,
    data: { id: idItem },
    datatype: "json",
    type: "POST",

    success: function (output) {

      if (output.stats == "OK") {

        alert("Medicação excluída com suesso !")

      } else if (output.stats == "ERROR") {

        alert("Falha ao tentar excluir a medicação. Tente novamente em alguns instantes !");

      }

      location.reload();

    }

  })
}
