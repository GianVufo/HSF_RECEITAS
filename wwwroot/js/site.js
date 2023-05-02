function inserirRemedios() {
  var medicId = document.getElementById("up-prescriptionId").value;
  document.getElementById("receituarioId").value = medicId;

}

function inserirRemediosATM() {
  var medicId = document.getElementById("atm-up-prescriptionId").value;
  document.getElementById("atm-receituarioId").value = medicId;

}

function inserirRemediosATC() {
  var medicId = document.getElementById("atc-up-prescriptionId").value;
  document.getElementById("atc-receituarioId-medication").value = medicId;

}

function ATM()
{
  var pacientName = document.getElementById("atm-up-pacientName").value;
  document.getElementById("atm-pacientName").value = pacientName;
}

function ATC()
{
  var pacientName = document.getElementById("atc-up-pacientName").value;
  document.getElementById("atc-pacientName").value = pacientName;
}