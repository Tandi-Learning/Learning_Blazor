using BethanysPieShopHRM.Wasm.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShopHRM.ComponentsLibrary.Map;

namespace BethanysPieShopHRM.Wasm.Pages
{
    public class EmployeeDetailBase: ComponentBase
    {
        [Parameter]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; } = new Employee();

        public List<Marker> MapMarkers { get; set; } = new List<Marker>();

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));

            System.Diagnostics.Debug.WriteLine(".........");
            System.Diagnostics.Debug.WriteLine(Employee.Longitude);

            MapMarkers = new List<Marker> 
            {
                new Marker 
                {
                    Description = $"{Employee.FirstName}  {Employee.LastName}",
                    ShowPopup = false,
                    X = Employee.Longitude,
                    Y = Employee.Latitude
                }
            };
        }

    }
}
