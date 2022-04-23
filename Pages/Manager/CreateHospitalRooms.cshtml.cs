using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesHospitalRoom.Models;
using RazorPagesHospitalRoom.Services;

namespace RazorPagesManager.Pages
{
    public class CreateHospitalRoomsModel : PageModel

    {
        [BindProperty]
        public HospitalRoom NewRoom { get; set; } = new();
        public IActionResult  OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            HospitalRoomService.Add(NewRoom);
            return Redirect("CRUDHospitalRooms");
        }
    }
}
