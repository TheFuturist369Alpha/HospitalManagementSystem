using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModels;

namespace ViewModels
{

    public class RoomViewModel
    {
        public Guid Id { get; set; }
        public string RoomCode { get; set; }
        public string RoomType { get; set; }
        public int floor { get; set; }
        public RoomStatus? status { get; set; } = null;

        public RoomViewModel()
        {

        }

        public RoomViewModel(Room room)
        {
            Id = room.Id;
            RoomCode = room.RoomCode;
            RoomType = room.RoomType;
            floor = room.floor;
            status =(RoomStatus) Enum.Parse(typeof(RoomStatus), room.status);
        }

        public Room ToRoom()
        {
            return new Room()
            {
                Id = Id,
                RoomCode = RoomCode,
                RoomType = RoomType,
                floor = floor,
                status = status.ToString()
            };
        }
    }

    public enum RoomStatus
    {
        Occupied, Free
    }
}
