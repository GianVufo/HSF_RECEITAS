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

function ATM() {
  var pacientName = document.getElementById("atm-up-pacientName").value;
  document.getElementById("atm-pacientName").value = pacientName;
}

function ATC() {
  var pacientName = document.getElementById("atc-up-pacientName").value;
  document.getElementById("atc-pacientName").value = pacientName;
}

function ShowPrescriptionPacient() {
  var pacientName = document.getElementById("pacientName").value;
  document.querySelector('#nameP').textContent = pacientName;
}

function ShowPrescriptionData() {
  var dataAppoiment = new Date(document.getElementById("dataAppoiment").value);
  document.querySelector('#dataA').textContent = dataAppoiment.toLocaleDateString('pt-BR', { timeZone: 'UTC' });
}

function ShowPrescriptionMedic() {
  var doctorName = document.getElementById("doctorName").value;
  document.querySelector('#nameM').textContent = doctorName;
}