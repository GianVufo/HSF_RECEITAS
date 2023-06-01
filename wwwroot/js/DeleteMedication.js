function deleteMedication(idItem) {
  var url = "/Medicacao/DeleteMedication";
  $.ajax({
    url: url,
    data: { id: idItem },
    datatype: "json",
    type: "POST",
    success: function () {
      if (idItem != 0) {

        alert("Medicação excluída com sucesso!");

      }

      location.reload();
      
    }
  })
}
