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
            var burialID = repo.masterburialsummary3
                .Where(x => x.burialid != null && x.burialid != "")
                .Select(x => x.burialid)
                .Distinct();

            var sex = repo.masterburialsummary3
                .Where(x => x.sex != null && x.sex != "")
                .Select(x => x.sex)
                .Distinct();

            var color = repo.masterburialsummary3
                .Where(x => x.color != null && x.color != "")
                .Select(x => x.color)
                .Distinct();

            var ageatdeath = repo.masterburialsummary3
                .Where(x => x.ageatdeath != null && x.ageatdeath != "")
                .Select(x => x.ageatdeath)
                .Distinct();

            var headDirection = repo.masterburialsummary3
                .Where(x => x.headdirection != null && x.headdirection != "")
                .Select(x => x.headdirection)
                .Distinct();

            var hairColor = repo.masterburialsummary3
                .Where(x => x.haircolor != null && x.haircolor != "")
                .Select(x => x.haircolor)
                .Distinct();

            var textileStructure = repo.masterburialsummary3
                .Where(x => x.structure != null && x.structure != "")
                .Select(x => x.structure)
                .Distinct();

            var textileFunction = repo.masterburialsummary3
                .Where(x => x.textilefunction != null && x.textilefunction != "")
                .Select(x => x.textilefunction)
                .Distinct();

            var estimateStature = repo.masterburialsummary3
                .Where(x => x.estimatestature != null)
                .Select(x => (float)x.estimatestature)
                .Distinct();

            var area = repo.masterburialsummary3
                .Where(x => x.area != null && x.area != "")
                .Select(x => x.area)
                .Distinct();

            var femur = repo.masterburialsummary3
                .Where(x => x.femur != null && x.femur != "")
                .Select(x => x.femur)
                .Distinct();

            var model = new FieldsViewModel
            {
                BurialID = burialID,
                Sex = sex,
                TextileColor = color,
                AgeAtDeath = ageatdeath,
                HeadDirection = headDirection,
                HairColor = hairColor,
                TextileStructure = textileStructure,
                TextileFunction = textileFunction,
                EstimateStature = estimateStature,
                Area = area,
                Femur = femur
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

