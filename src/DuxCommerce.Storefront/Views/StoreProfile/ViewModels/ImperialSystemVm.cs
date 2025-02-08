using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DomainTypes;

namespace DuxCommerce.Storefront.Views.StoreProfile.ViewModels;

public class ImperialSystemVm : UnitSystemVm
{
    public override string SystemId => nameof(UnitSystem.ImperialSystem);
    public override string SystemName => "Imperial System";

    public override List<MeasurementUnit> GetWeightUnits()
    {
        var ounce = new MeasurementUnit
        {
            Id = nameof(ImperialWeightUnit.Ounce),
            Name = nameof(ImperialWeightUnit.Ounce)
        };

        var pound = new MeasurementUnit
        {
            Id = nameof(ImperialWeightUnit.Pound),
            Name = nameof(ImperialWeightUnit.Pound)
        };

        return new List<MeasurementUnit> { ounce, pound };
    }

    public override List<MeasurementUnit> GetLengthUnits()
    {
        var inch = new MeasurementUnit
        {
            Id = nameof(ImperialLengthUnit.Inch),
            Name = nameof(ImperialLengthUnit.Inch)
        };

        var foot = new MeasurementUnit
        {
            Id = nameof(ImperialLengthUnit.Foot),
            Name = nameof(ImperialLengthUnit.Foot)
        };

        return new List<MeasurementUnit> { inch, foot };
    }
}