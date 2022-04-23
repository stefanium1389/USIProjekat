using System.ComponentModel.DataAnnotations;

namespace RazorPagesHospitalRoom.Models;

public class HospitalRoom
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }
    public RoomType Type {get;set;}


}
public enum RoomType {OPERATIONS, WAITING, STORAGE, EXAMINATIONS}