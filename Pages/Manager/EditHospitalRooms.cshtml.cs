using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesHospitalRoom.Models;
using RazorPagesHospitalRoom.Services;

namespace RazorPagesManager.Pages
{
    public class EditHospitalRoomsModel : PageModel
    {
        [BindProperty]
        public HospitalRoom? Hr {get;set;}
        public IActionResult OnGet(int id)
        {
            Hr = HospitalRoomService.Get(id);

            if (Hr == null)
            {
                return NotFound();
            }
            return Page();
        }
        public IActionResult OnPost(int id)
        { 
            HospitalRoomService.Update(id,Hr.Name,Hr.Type);
            return Redirect("CRUDHospitalRooms");
        }
    }
}
