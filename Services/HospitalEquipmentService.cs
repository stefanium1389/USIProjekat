using RazorPagesHospitalEquipment.Models;
using RazorPagesHospitalRoom.Models;
using RazorPagesHospitalRoom.Services;

namespace RazorPagesHospitalEquipment.Services;

public static class HospitalEquipmentService 
{
    static List<HospitalEquipment> HospitalEquipmentList { get; set;}

    static HospitalEquipmentService()
    {
        HospitalEquipmentList = new List<HospitalEquipment> //TODO: read from a database (or file), for now i hardcoded some accounts to have something to work with
                {
                    new HospitalEquipment { Id = 1, Name = "Syrgery Knife", RoomId = 1, Amount = 6, Type = EquipmentType.Operations},
                    new HospitalEquipment { Id = 2, Name = "Operating Table", RoomId = 1, Amount = 2, Type = EquipmentType.RoomFurniture},
                    new HospitalEquipment { Id = 3, Name = "Bench", RoomId = 2, Amount = 4, Type = EquipmentType.Hallway},
                    new HospitalEquipment { Id = 4, Name = "Dental Mirror", RoomId = 4, Amount = 10, Type = EquipmentType.Examinations},
                    new HospitalEquipment { Id = 5, Name = "Sickle Probe", RoomId = 4, Amount = 10, Type = EquipmentType.Examinations}
                };
    }
    public static List<HospitalEquipment> GetAll() => HospitalEquipmentList;

    public static HospitalEquipment? Get(int id) => HospitalEquipmentList.FirstOrDefault(p => p.Id == id);

    public static void Add(HospitalEquipment heq)
    {
        heq.Id = HospitalEquipmentList.Last().Id + 1; 
        HospitalEquipmentList.Add(heq);
    }
    public static void Delete(int id)
    {
        var heq = Get(id);
        if (heq is null)
            return;
        HospitalEquipmentList.Remove(heq);
    }
    public static void AddToRoom(int eqId, int roomId)
    {
        var heq = Get(eqId);
        if (heq is null)
            return;
        heq.RoomId = roomId;
    }
    public static List<HospitalEquipment> Search(string searchTerm)
    {
        searchTerm = searchTerm.ToLower();
        var results = new List<HospitalEquipment>();
        foreach(var item in HospitalEquipmentList)
        {
            if(item.Name.ToLower().Contains(searchTerm) || item.Type.ToString().ToLower().Contains(searchTerm) || HospitalEquipmentService.Get(item.RoomId).Name.ToLower().Contains(searchTerm))
            {
                results.Add(item);
            }
        }
        return results;
    }
    public static List<HospitalEquipment> FilterByEqType(List<HospitalEquipment> inputList, EquipmentType type)
    {
        var results = new List<HospitalEquipment>();
        foreach(var item in inputList)
        {
            if(item.Type == type)
            {
                results.Add(item);
            }
        }
        return results;
    }
    public static List<HospitalEquipment> FilterByRoomType(List<HospitalEquipment> inputList, RoomType type)
    {
        var results = new List<HospitalEquipment>();
        foreach(var item in inputList)
        {
            if(HospitalRoomService.Get(item.RoomId).Type == type)
            {
                results.Add(item);
            }
        }
        return results;
    }
    public static List<HospitalEquipment> FilterByNumbers(List<HospitalEquipment> inputList, int lowerBound, int upperBound)
    {
        var results = new List<HospitalEquipment>();
        foreach(var item in inputList)
        {
            if(item.Amount >= lowerBound && item.Amount <= upperBound)
            {
                results.Add(item);
            }
        }
        return results;
    }
}