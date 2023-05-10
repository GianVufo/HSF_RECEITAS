function abreModal() {
  $('#myModal').modal('show');
}

function deleteMedication(idItem) {
  var url = "/Medicacao/DeleteMedication";
  $.ajax({
    url: url,
    data: { id: idItem },
    datatype: "json",
    type: "POST",
    success: function () {
      if (idItem != null) {

        alert("Medicação excluída com sucesso!");
        location.reload();

      }
    }
  })
}
