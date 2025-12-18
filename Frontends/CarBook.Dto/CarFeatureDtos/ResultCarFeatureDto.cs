using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CarFeatureDtos
{
    public class ResultCarFeatureDto
    {
        public int CarFeatureID { get; set; }
        public int CarID { get; set; }
        public string Name { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
