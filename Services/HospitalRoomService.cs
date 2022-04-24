using RazorPagesHospitalRoom.Models;

namespace RazorPagesHospitalRoom.Services;

public static class HospitalRoomService {

    static List<HospitalRoom> HospitalRooms { get; set;}

    static HospitalRoomService()
    {
        HospitalRooms = new List<HospitalRoom> //TODO: read from a database (or file), for now i hardcoded some accounts to have something to work with
                {
                    new HospitalRoom { Id = 0, Name = "Storage", Type = RoomType.STORAGE},
                    new HospitalRoom { Id = 1, Name = "Syrgery", Type = RoomType.Operations},
                    new HospitalRoom { Id = 2, Name = "Waiting room", Type = RoomType.Waiting},
                    new HospitalRoom { Id = 3, Name = "Pediatritian", Type = RoomType.Examinations},
                    new HospitalRoom { Id = 4, Name = "Dentist", Type = RoomType.Operations}
                };
    }

    public static List<HospitalRoom> GetAll() => HospitalRooms;

    public static HospitalRoom? Get(int id) => HospitalRooms.FirstOrDefault(p => p.Id == id);

    public static void Add(HospitalRoom hroom)
    {
        hroom.Id = HospitalRooms.Last().Id + 1; 
        HospitalRooms.Add(hroom);
    }
    public static void Delete(int id)
    {
        var hroom = Get(id);
        if (hroom is null)
            return;
        if (id == 0)
        {
            return;
        }
        HospitalRooms.Remove(hroom);
    }
    public static void Update(int id, string newName, RoomType newType)
    {
        var roomToUpdate = Get(id);
        if(roomToUpdate==null){
            return;
        }
        if (roomToUpdate.Type == RoomType.STORAGE)
        {
            return;
        }
        if(id == 0){
            return;
        }
        if(newType == RoomType.STORAGE){
            return;
        }
        roomToUpdate.Id = id;
        roomToUpdate.Name = newName;
        roomToUpdate.Type = newType;
    }
}