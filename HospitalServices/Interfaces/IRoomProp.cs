using HospitalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using ViewModels;

namespace HospitalServices.Interfaces
{
    public interface IRoomProp
    {
        public void AddRoom(RoomViewModel model);
        public void RemoveRoom(Guid id);
        public PageUtil<RoomViewModel> GetAllRooms(int pageNumber, int pageSize);
        public RoomViewModel GetRoom(Guid id);
        public void UpdateRoom(RoomViewModel room);

    }
}
