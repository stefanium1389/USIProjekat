using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPagesManager.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult OnPostCRUDHospitalRooms()
        {
            return Redirect("Manager/CRUDHospitalRooms");
        }
        public IActionResult OnPostManagerEquipment()
        {
            return Redirect("Manager/ManagerEquipment");
        }
    }
}
