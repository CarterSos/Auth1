using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Auth1.Models;
using Auth1.Models.ViewModels;

namespace Auth1.Components
{
    public class FieldsViewComponent : ViewComponent
    {
        private IMummyRepository repo { get; set; }

        public FieldsViewComponent(IMummyRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            var sex = repo.masterburialsummary
                .Select(x => x.sex)
                .Distinct();

            var color = repo.masterburialsummary
                .Select(x => x.color)
                .Distinct();

            var model = new FieldsViewModel
            {
                Sex = sex,
                TextileColor = color
            };

            return View(model);
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Auth1.Models;

//namespace Auth1.Components
//{
//    public class FieldsViewComponent : ViewComponent
//    {
//        private IMummyRepository repo { get; set; }

//        public IEnumerable<string> Sex { get; set; }
//        public IEnumerable<string> TextileColor { get; set; }

//        public FieldsViewComponent(IMummyRepository temp)
//        {
//            repo = temp;
//        }

//        public IViewComponentResult Invoke()
//        {
//            var sex = repo.masterburialsummary
//                .Select(x => x.sex)
//                .Distinct();

//            var color = repo.masterburialsummary
//                .Select(x => x.color)
//                .Distinct();

//            var model = new FieldsViewComponent
//            {
//                Sex = sex,
//                TextileColor = color
//            };

//            return View(model);
//        }
//    }
//}

//public IViewComponentResult Invoke()
//{
//    var sex = repo.masterburialsummary
//        .Select(x => x.sex)
//        .Distinct();

//    return View(sex);
//}

