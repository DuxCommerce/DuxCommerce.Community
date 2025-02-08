using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Catalog.DataStores;
using DuxCommerce.StoreBuilder.Catalog.DataTypes;
using DuxCommerce.StoreBuilder.Catalog.Requests;
using DuxCommerce.Storefront.Views.ProductOption.ViewModels;
using DuxCommerce.Storefront.Views.Shared.ViewModels;
using DuxCommerce.Storefront.Views.SharedOption.ViewModels;

namespace DuxCommerce.Storefront.Views.SharedOption.VmBuilders;

public class SharedOptionVmBuilder(IOptionStore optionStore)
{
    public async Task<OptionIndexVm> BuildIndexModel()
    {
        var optionRows = await optionStore.GetAll();

        return new OptionIndexVm
        {
            Options = optionRows
        };
    }

    public SharedOptionVm BuildCreateModel()
    {
        return new SharedOptionVm
        {
            Option = new OptionModel(),
            Choices = new List<ChoiceRow>(),
            DisplayTypes = OptionDisplayType.GetAll()
        };
    }

    public SharedOptionVm BuildCreateModel(SharedOptionVm model)
    {
        var types = OptionDisplayType.GetAll();

        model.DisplayTypes = types;

        return model;
    }

    public async Task<SharedOptionVm> BuildEditModel(string optionId)
    {
        var optionRow = await optionStore.Get(optionId);

        var choices = (optionRow.Choices ?? Array.Empty<ChoiceRow>())
            .OrderBy(x => x.DisplayOrder)
            .ThenBy(x => x.CreatedAtUtc);

        return new SharedOptionVm
        {
            Option = ToOptionModel(optionRow),
            Choices = choices,
            DisplayTypes = OptionDisplayType.GetAll()
        };
    }

    public async Task<SharedOptionVm> BuildEditModel(SharedOptionVm model)
    {
        var optionRow = await optionStore.Get(model.Option.OptionId);

        var choices = (optionRow.Choices ?? Array.Empty<ChoiceRow>())
            .OrderBy(x => x.DisplayOrder)
            .ThenBy(x => x.CreatedAtUtc);

        model.Choices = choices;
        model.DisplayTypes = OptionDisplayType.GetAll();

        return model;
    }

    public async Task<SharedOptionChoiceVm> BuildEditChoiceModel(string optionId, string choiceId)
    {
        var optionRow = await optionStore.Get(optionId);

        var choice = optionRow.Choices.Single(x => x.Id == choiceId);

        var choiceModel = new OptionChoiceModel
        {
            ChoiceId = choiceId,
            OptionId = optionId,
            Name = choice.Name,
            IsDefault = choice.IsDefault,
            DisplayOrder = choice.DisplayOrder
        };

        return new SharedOptionChoiceVm { Choice = choiceModel };
    }

    private OptionModel ToOptionModel(OptionRow option)
    {
        return new OptionModel
        {
            OptionId = option.Id,
            OptionName = option.OptionName,
            DisplayName = option.DisplayName,
            DisplayType = option.DisplayType,
            DisplayOrder = option.DisplayOrder
        };
    }
}