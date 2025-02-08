using System.Collections.Generic;

namespace DuxCommerce.Storefront.Views.StoreProfile.ViewModels;

public class MeasurementUnit
{
    public string Id { get; set; }
    public string Name { get; set; }
}

public abstract class UnitSystemVm
{
    public abstract string SystemId { get; }
    public abstract string SystemName { get; }
    public abstract List<MeasurementUnit> GetWeightUnits();
    public abstract List<MeasurementUnit> GetLengthUnits();
}