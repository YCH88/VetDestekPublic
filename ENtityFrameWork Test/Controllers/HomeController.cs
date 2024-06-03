using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Models;
using ENtityFrameWork_Test.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ENtityFrameWork_Test.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITestServices _testServices;
        private readonly IDiseaseService _diseaseService ;
        private readonly ISymptomService _symptomService;
        public HomeController(ILogger<HomeController> logger
            ,ITestServices testServices
            ,IDiseaseService diseaseService
            ,ISymptomService symptomService)
        {
            _logger = logger;
            _testServices = testServices;
            _diseaseService = diseaseService;
            _symptomService = symptomService;
        }
        
        public IActionResult Index()
        {
            var model = _symptomService.GetSymptoms();
            return View(model);
        }
        
        public async Task<IActionResult> GetDiseaseList(int[] symptomIds,DataTablesResult dataTableDto)
        {
            var data =await  _diseaseService.GetDiseaseList(symptomIds,dataTableDto);
            return Json(new
            {
                draw = dataTableDto.draw,
                recordsTotal = data.First().TotalRecord,
                recordsFiltered =data.Count,
                data = data
			});
        } 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
