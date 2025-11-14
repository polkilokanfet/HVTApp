using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HVTApp.Model;
using HVTApp.Model.POCOs;
using HVTApp.Model.Wrapper;

namespace HVTApp.UI.PriceEngineering.Tce.Second
{
    public class SccVersionWrapper : StructureCostVersionWrapper
    {
        public bool IsActual { get; }
        public string Name { get; }
        public string Constructor { get; set; }
        public string Department { get; set; }

        public SccVersionWrapper(StructureCostVersion model, string name, bool isActual) : base(model)
        {
            Name = name;
            IsActual = isActual;
            this.Validate();
        }

        protected override IEnumerable<ValidationResult> ValidateOther()
        {
            if (IsActual)
            {
                if (GlobalAppProperties.UserIsBackManager)
                {
                    if (Version.HasValue == false)
                        yield return new ValidationResult("Version is required", new[] {nameof(Version)});
                    else if (Version.Value < 1)
                        yield return new ValidationResult("Version should be greater then 0", new[] {nameof(Version)});
                    else if (Version.Value > 99)
                        yield return new ValidationResult("Version should be less then 99", new[] {nameof(Version)});
                }
            }
        }
    }
}