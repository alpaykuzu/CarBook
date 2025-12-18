namespace CarBook.Dto.CarFeatureDtos
{
    public class CreateCarFeatureDto
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
