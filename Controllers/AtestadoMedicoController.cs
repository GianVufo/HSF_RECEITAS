using System;
using Hsf_Receitas.Models;
using Hsf_Receitas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hsf_Receitas.Controllers
{

    public class AtestadoMedicoController : Controller
    {
        private readonly ILogger<AtestadoMedico> _logger;

        public AtestadoMedicoController(ILogger<AtestadoMedico> logger)
        {
            _logger = logger;
        }

        public IActionResult ATMRegister()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ATMRegister(AtestadoMedico novoATM)
        {
            try {

                AtestadoMedicoServices medServ = new AtestadoMedicoServices();
                medServ.AddATM(novoATM);

                return Json(new { stats = "OK"});

            }catch (Exception e){
                _logger.LogError("Erro ao adicionar atestado médico!" + e.Message);
                return Json(new { stats = "INVALID", message = "Falha ao gerar atestado médico!" });
            }
        }

        public IActionResult ATMPrescription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ATMPrescription(Receituario novaReceita, int id)
        {
            try
            {
                ReceituarioServices recServ = new ReceituarioServices();
                recServ.AddReceita(novaReceita);

                id = novaReceita.Id;

                return Json(new { stats = "OK", id = id });

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao adicionar receita!" + e.Message);
                return Json(new { stats = "INVALID", message = "Falha ao cadastrar Receita!" });
            }

        }

        public IActionResult ATMCompletePrescription(int id)
        {
            Receituario buscaReceita = new ReceituarioServices().SearchForId(id);
            return View(buscaReceita);
        }

        [HttpPost]
        public IActionResult CompletePrescription(Receituario editReceita)
        {
            try
            {

                new ReceituarioServices().EditReceita(editReceita);
                return Json(new { stats = "OK" });

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao completar o receituário !" + e.Message);
                return Json(new { stats = "INVALID", message = "Falha ao Salvar Receita!" });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}