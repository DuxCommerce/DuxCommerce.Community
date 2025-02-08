using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DomainTypes;

namespace DuxCommerce.Storefront.Views.StoreProfile.ViewModels;

public class MetricSystemVm : UnitSystemVm
{
    public override string SystemId => nameof(UnitSystem.MetricSystem);
    public override string SystemName => "Metric System";

    public override List<MeasurementUnit> GetWeightUnits()
    {
        var gram = new MeasurementUnit
        {
            Id = nameof(MetricWeightUnit.Gram),
            Name = nameof(MetricWeightUnit.Gram)
        };

        var kilogram = new MeasurementUnit
        {
            Id = nameof(MetricWeightUnit.Kilogram),
            Name = nameof(MetricWeightUnit.Kilogram)
        };

        return new List<MeasurementUnit> { gram, kilogram };
    }

    public override List<MeasurementUnit> GetLengthUnits()
    {
        var centimeter = new MeasurementUnit
        {
            Id = nameof(MetricLengthUnit.Centimeter),
            Name = nameof(MetricLengthUnit.Centimeter)
        };

        var meter = new MeasurementUnit
        {
            Id = nameof(MetricLengthUnit.Meter),
            Name = nameof(MetricLengthUnit.Meter)
        };

        return new List<MeasurementUnit> { centimeter, meter };
    }
}