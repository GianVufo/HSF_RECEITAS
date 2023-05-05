using System;
using System.Collections.Generic;
using System.Linq;
using Hsf_Receitas.Data;
using Hsf_Receitas.Models;
using Hsf_Receitas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hsf_Receitas.Controllers
{

    public class MedicacaoController : Controller
    {
        private readonly ILogger<MedicacaoController> _logger;

        public MedicacaoController(ILogger<MedicacaoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]

        public IActionResult MedicationRegister(Medicacao novaMedicacao)
        {
            try
            {

                MedicacaoServices medServ = new MedicacaoServices();
                medServ.AddMedicacao(novaMedicacao);

                return Json(new { stats = "OK" });

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao adicionar medicamento!" + e.Message);
                return Json(new { stats = "INVALID", message = "Falha ao inserir medicamento!" });
            }
        }

        [HttpPost]
        public IActionResult DeleteMedication(int id, string decision, Medicacao medication) 
        {

            try
            {

                MedicacaoServices medic = new MedicacaoServices();
                
                using HSFContext database = new HSFContext();

                switch (decision)
                {
                    case "Delete":

                        List<Medicacao> listMedication = database.Medicamentos.Where(m => m.ReceituarioId == id).ToList();

                        id = listMedication.Select(l => l.Id).First();

                        medic.DelMedication(id);
                        return Redirect("/Receituario/CompletePrescription?id=" + medication.Id);

                    case "Cancel":

                        return Redirect("/Receituario/CompletePrescription?id=" + medication.Id);
                }

                return Redirect("/Receituario/CompletePrescription?id=" + medication.Id);
            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao medicamento do Receituário!" + e.Message);
                return RedirectToAction("Index", "Home");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}