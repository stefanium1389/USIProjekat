using System.ComponentModel.DataAnnotations;

namespace RazorPagesHospitalEquipment.Models;

public class HospitalEquipment
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
    public int Amount { get; set; }
    public int RoomId { get; set; }
    public EquipmentType Type {get;set;}
}
public enum EquipmentType {Operations, RoomFurniture, Hallway, Examinations}

