using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesHospitalRoom.Models;
using RazorPagesHospitalRoom.Services;

namespace RazorPagesManager.Pages
{
    public class CRUDHospitalRoomsModel : PageModel
    {
        
        public List<HospitalRoom> rooms = new();
        public void OnGet()
        {
            rooms = HospitalRoomService.GetAll();
        }
        
        public IActionResult OnPostDelete(int id)
        {
            HospitalRoomService.Delete(id);
            return RedirectToAction("Get");
        }
        
    }
}
