using System;

namespace LogApp.Application.Businesses.Queries
{
    public class BusinessVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int CostCentre { get; set; }
    }
}
