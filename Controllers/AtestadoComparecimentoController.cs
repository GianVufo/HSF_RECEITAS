using System;
using System.Collections.Generic;
using System.IO;
using FastReport.Export.PdfSimple;
using Hsf_Receitas.Models;
using Hsf_Receitas.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hsf_Receitas.Controllers
{
    public class AtestadoComparecimentoController : Controller
    {
        private readonly ILogger<AtestadoComparecimentoController> _logger;
         private readonly IWebHostEnvironment _environment;
        private readonly MedicacaoServices _MedicacaoServices;
        private readonly ReceituarioServices _ReceituarioServices;
        private readonly AtestadoComparecimentoServices _AtestadoComparecimentoServices;

        public AtestadoComparecimentoController(ILogger<AtestadoComparecimentoController> logger, IWebHostEnvironment environment, ReceituarioServices receituarioServices, MedicacaoServices medicacaoServices, AtestadoComparecimentoServices atestadoComparecimentoServices)
        {
            _logger = logger;
            _environment = environment; 
            _ReceituarioServices = receituarioServices;
            _MedicacaoServices = medicacaoServices;
            _AtestadoComparecimentoServices = atestadoComparecimentoServices;
        }

        public IActionResult ATCRegister()
        {
            return View();
        }

        [HttpPost]

        public IActionResult ATCRegister(AtestadoComparecimento novoATC)
        {
            try {

                AtestadoComparecimentoServices atcServ = new AtestadoComparecimentoServices();
                atcServ.AddATC(novoATC);

                return Json(new { stats = "OK"});

            }catch (Exception e){
                _logger.LogError("Erro ao adicionar atestado de comparecimento!" + e.Message);
                return Json(new { stats = "INVALID", message = "Falha ao gerar atestado de comparecimento!" });
            }
        }

        public IActionResult ATCPrescription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ATCPrescription(Receituario novaReceita, int id)
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

        public IActionResult ATCCompletePrescription(int id)
        {
            Receituario buscaReceita = new ReceituarioServices().SearchForId(id);
            return View(buscaReceita);
        }

        [HttpPost]
        public IActionResult ATCCompletePrescription(Receituario editReceita)
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

        [HttpGet]
        public IActionResult ATCCreateReport()
        {
            try
            {

                string reportFile = Path.Combine(_environment.WebRootPath, @"Print_Files\Rec_Atc.frx.frx"); 

                FastReport.Report r = new FastReport.Report();

                ICollection<Medicacao> medicationList = _MedicacaoServices.ListMedication(); 
                ICollection<Receituario> prescriptionList = _ReceituarioServices.ListPrescription();
                ICollection<AtestadoComparecimento> atcList = _AtestadoComparecimentoServices.ListATC();

                r.Report.Dictionary.RegisterBusinessObject(medicationList, "medicationList", 10, true);
                r.Report.Dictionary.RegisterBusinessObject(prescriptionList, "prescriptionList", 10, true);
                r.Report.Dictionary.RegisterBusinessObject(atcList, "atcList", 10, true);

                r.Report.Save(reportFile);

                return Ok($"OK! {reportFile}");

            }
            catch (Exception e)
            {
                _logger.LogError("Erro ao Gerar Report de Medicamentos via FastReporter !" + e.Message);
                return RedirectToAction("Index", "Home");

            }
        }

        [HttpGet]
        public IActionResult ATCPrescriptionPrintToPDF(int id)
        {

            try
            {

                string reportFile = Path.Combine(_environment.WebRootPath, @"Print_Files\Rec_Atc.frx"); 

                FastReport.Report r = new FastReport.Report();

                ICollection<Receituario> prescriptionList = _ReceituarioServices.ListPrescriptionsForId(id); 
                ICollection<Medicacao> medicationList = _MedicacaoServices.ListMedicationPrescriptions(id); 
                ICollection<AtestadoComparecimento> atcList = _AtestadoComparecimentoServices.ListATCPrescriptions(id); 

                r.Report.Load(reportFile); 
                r.Report.Dictionary.RegisterBusinessObject(prescriptionList, "prescriptionList", 10, true);
                r.Report.Dictionary.RegisterBusinessObject(medicationList, "medicationList", 10, true);
                r.Report.Dictionary.RegisterBusinessObject(atcList, "atcList", 10, true);
                r.Prepare();

                PDFSimpleExport pdfExport = new PDFSimpleExport();
                using MemoryStream ms = new MemoryStream(); 

                pdfExport.Export(r, ms);

                ms.Flush();

                return File(ms.ToArray(), "application/pdf");

            }
            catch (Exception e)
            {

                _logger.LogError("Erro ao Gerar Receita em PDF !" + e.Message);
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