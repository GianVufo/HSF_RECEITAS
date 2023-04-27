function inserirRemedios() {
  var medicId = document.getElementById("up-prescriptionId").value;
  document.getElementById("receituarioId").value = medicId;

}

function inserirRemediosATM() {
  var medicId = document.getElementById("atm-up-prescriptionId").value;
  document.getElementById("atm-receituarioId").value = medicId;

}