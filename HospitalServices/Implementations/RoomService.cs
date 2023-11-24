using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalModels;
using HospitalRepos;
using HospitalRepos.Interfaces;
using HospitalServices.Interfaces;
using Utilities;
using ViewModels;

namespace HospitalServices.Implementations
{
    public class RoomService:IRoomProp
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public void AddRoom(RoomViewModel model)
        {
            _unitOfWork.GenericRepo<Room>().Add(model.ToRoom());
            _unitOfWork.Save();
        }

        public PageUtil<RoomViewModel> GetAllRooms(int pageNumber, int pageSize)
        {
            RoomViewModel hvm = new RoomViewModel();
            int count;
            List<RoomViewModel> viewList = new List<RoomViewModel>();
            try
            {
                int ExcludedRecords = pageNumber * pageSize - pageSize;
                var models = _unitOfWork.GenericRepo<Room>().GetAll()
                    .Skip(ExcludedRecords).Take(pageSize).ToList();
                count = _unitOfWork.GenericRepo<Room>().GetAll().ToList().Count;
                viewList = ToHospitalVMList(models);
            }
            catch (Exception ex)
            {
                throw;
            }

            return new PageUtil<RoomViewModel>()
            {
                Data = viewList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                PageCount = count


            };

        }

        private List<RoomViewModel> ToHospitalVMList(List<Room> Rooms)
        {

            return Rooms.Select(x => new RoomViewModel(x)).ToList();

        }

        public RoomViewModel GetRoom(Guid id)
        {
            Room room = _unitOfWork.GenericRepo<Room>().GetById(x => x.Id == id);
            return new RoomViewModel(room);
        }

        public void RemoveRoom(Guid id)
        {
            _unitOfWork.GenericRepo<Room>().Remove(x=> x.Id == id);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            Room hld = _unitOfWork.GenericRepo<Room>().Update(x=>x.Id==room.Id);
            hld.status = room.status.ToString();
            hld.RoomCode = room.RoomCode;
            hld.RoomType= room.RoomType;
            hld.floor=room.floor;

            _unitOfWork.Save();
        }
    }
}
