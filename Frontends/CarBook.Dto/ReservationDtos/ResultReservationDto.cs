namespace CarBook.Dto.ReservationDtos
{
    public class ResultReservationDto
    {
        public int ReservationID { get; set; }
        public int AppUserID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int CarID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int? PickUpLocationID { get; set; }
        public string PickUpLocationName { get; set; }
        public int? DropOffLocationID { get; set; }
        public string DropOffLocationName { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; }
    }
}
