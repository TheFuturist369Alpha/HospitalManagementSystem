namespace HospitalModels
{
   
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomCode { get; set; }
        public string RoomType { get; set; }
        public int floor { get; set; }
        public string status { get; set; }


    }
}