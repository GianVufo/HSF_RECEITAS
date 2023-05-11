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

/* Mostrar dados do paciente em Receituário */

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

/* Mostrar dados do paciente em tempo real em atestado médico */

function ATMShowPrescriptionPacient() {
  var pacientName = document.getElementById("atm-pacientName").value;
  document.querySelector('#atm-nameP').textContent = pacientName;
}

function ATMShowPrescriptionData() {
  var dataAppoiment = new Date(document.getElementById("atm-dataAppoiment").value);
  document.querySelector('#atm-dataA').textContent = dataAppoiment.toLocaleDateString('pt-BR', { timeZone: 'UTC' });
}

function ATMShowPrescriptionMedic() {
  var doctorName = document.getElementById("atm-doctorName").value;
  document.querySelector('#atm-nameM').textContent = doctorName;
}