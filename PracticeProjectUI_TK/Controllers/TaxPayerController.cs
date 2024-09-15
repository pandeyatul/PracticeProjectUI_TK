using AutoMapper;
using Entities_TK;
using Entities_TK.Interface;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using PracticeProjectUI_TK.Models.ViewModels;
using System.Globalization;

namespace PracticeProjectUI_TK.Controllers
{
    public class TaxPayerController : Controller
    {
        private readonly IUsers _users;
        private readonly IMapper _mapper;

        public TaxPayerController(IUsers users, IMapper mapper)
        {
            _users = users;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var resultlist = await _users.GetTaxpayerInfo();
            var totalofTC = 0;
            var annualyMPAmount = 0;
            var annualyslcspAmount = 0;
            List<TaxpayerViewModel> taxpayerlist = new();
            foreach (var item in resultlist.OrderByDescending(x=>x.Id))
            {
                var mappedata = _mapper.Map<TaxpayerViewModel>(item);
                for (int i = 0; i < mappedata.MonthlyInfo.Count; i++)
                {
                    totalofTC = totalofTC + Convert.ToInt32(mappedata.MonthlyInfo[i].TaxCredit);
                    mappedata.AnnualTaxCreditAmmount = totalofTC;
                }
                taxpayerlist.Add(mappedata);
            }
            return View(taxpayerlist);
        }
      
        public async Task<IActionResult> GetFormDataToupdate(int id)
        {
            if (id > 0)
            {
                var result = await _users.GetTaxpayerInfoById(id);
                var mappedData = _mapper.Map<TaxpayerViewModel>(result);
                return Json(mappedData);
            }
            return Json("");
        }
        //[HttpPost]
        //public async Task<IActionResult> Update(TaxpayerViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var taxpayerdata = _mapper.Map<Taxpayer>(model);
        //         await _users.UpdateRegisterTaxpayer(taxpayerdata);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        public IActionResult Save(int id)
        {
            ViewBag.Id=id;
            return View();
        }
        //public async Task<IActionResult> GetDataToUpdate(int id)
        //{
        //    var result = await _users.GetTaxpayerInfoById(id);
        //    var mappedData = _mapper.Map<TaxpayerViewModel>(result);
        //    return View();
        //}
        [HttpPost]
        public async Task<IActionResult> Save(TaxpayerViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var taxperdata = new Taxpayer()
                //{
                //    Identifier=model.Identifier,
                //    Policynumber=model.Policynumber,
                //    MonthlyInfo=model.MonthlyInfo
                //};
                var taxpayerdata = _mapper.Map<Taxpayer>(model);
                var result = await _users.RegisterTaxpayer(taxpayerdata);
                if (result == "success")
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false });
                }
            }
            return Json(new { success = false });
        }

    }
}
 