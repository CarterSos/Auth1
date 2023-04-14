using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;

namespace Auth1.Controllers
{
    [ApiController]
    [Route("/score")]
    public class ONNXController : ControllerBase
    {
        private InferenceSession _session;

        public ONNXController(InferenceSession session)
        {
            _session = session;
        }

        //[HttpPost]
        //public ActionResult Score(MummyData data)
        //{
        //    var result = _session.Run(new List<NamedOnnxValue>
        //    {
        //        NamedOnnxValue.CreateFromTensor("float_input", data.AsTensor())
        //    });
        //    Tensor<float> score = result.First().AsTensor<float>();
        //    var prediction = new Prediction { PredictedValue = score.First() * 100000 };
        //    result.Dispose();
        //    return Ok(prediction);
        //}
    }
}