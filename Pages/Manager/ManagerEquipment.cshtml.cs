using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesHospitalEquipment.Models;
using RazorPagesHospitalRoom.Models;
using RazorPagesHospitalEquipment.Services;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesManager.Pages
{
    public class ManagerEquipmentModel : PageModel
    {
        [BindProperty]
        public SearchTerms STerms { get; set; } = new SearchTerms();
        public List<HospitalEquipment> Results {get; set;} = new List<HospitalEquipment>();
        
        public void OnGet()
        {
            Results = HospitalEquipmentService.GetAll();
        }
        public void OnPost()
        {
            if (STerms.SearchTerm is not null)
            {
                Results = HospitalEquipmentService.Search(STerms.SearchTerm);
            }
            else
            {
                Results = HospitalEquipmentService.GetAll();
            }
            if (STerms.FilterByEqTypeBool == true)
            {
                Results = HospitalEquipmentService.FilterByEqType(Results, STerms.FilterByEq);
            }
            if (STerms.FilterByRoomTypeBool == true)
            {
                Results = HospitalEquipmentService.FilterByRoomType(Results, STerms.FilterByRoom);
            }
            if (STerms.FilterByAmountBool == true)
            {
                switch(STerms.STAmount)
                {
                    case Amount.Zero:
                        Results = HospitalEquipmentService.FilterByNumbers(Results,0,0);
                        break;
                    case Amount.OneToTen:
                        Results = HospitalEquipmentService.FilterByNumbers(Results,1,10);
                        break;
                    case Amount.AboveTen:
                        Results = HospitalEquipmentService.FilterByNumbers(Results,11,10000000);
                        break;
                }
            }

        }
        public class SearchTerms 
        {
        public string SearchTerm { get; set; }
        public bool FilterByEqTypeBool { get; set; }
        public EquipmentType FilterByEq { get; set; }
        public bool FilterByAmountBool { get; set; }
        public Amount STAmount { get; set; }
        public bool FilterByRoomTypeBool { get; set; }
        public RoomType FilterByRoom { get; set; }
        }
        public enum Amount { Zero, OneToTen, AboveTen }
        
    }
}
