using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarFeatures.Queries.GetCarFeatureByCar
{
    public class GetCarFeatureByCarQueryResponse
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
