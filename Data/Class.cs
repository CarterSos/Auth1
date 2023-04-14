using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth1.Data
{
    public class MummyPredict
    {
        public float depth { get; set; }
        public float sex_F { get; set; }
        public float sex_M { get; set; }
        public float sex_U { get; set; }
        public float facebundles_N { get; set; }
        public float facebundles_Y { get; set; }
        public float goods_N { get; set; }
        public float goods_Y { get; set; }
        public float wrapping_B { get; set; }
        public float wrapping_H { get; set; }
        public float wrapping_U { get; set; }
        public float wrapping_W { get; set; }
        public float haircolor_A { get; set; }
        public float haircolor_B { get; set; }
        public float haircolor_D { get; set; }
        public float haircolor_K { get; set; }
        public float haircolor_R { get; set; }
        public float haircolor_U { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_IN { get; set; }
        public float ageatdeath_N { get; set; }

        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
            depth, sex_F, sex_M,
            sex_U, facebundles_N, facebundles_Y, goods_N,
            goods_Y, wrapping_B, wrapping_H, wrapping_U,
            wrapping_W, haircolor_A, haircolor_B, haircolor_D,
            haircolor_K, haircolor_R, haircolor_U, ageatdeath_A,
            ageatdeath_C, ageatdeath_I, ageatdeath_IN, ageatdeath_N
            };
            int[] dimensions = new int[] { 1, 23 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
    public class Prediction
    {
        public string PredictedValue { get; set; }
    }
}
