using System.Threading.Tasks;
using DuxCommerce.StoreBuilder.Taxes.Core;
using DuxCommerce.StoreBuilder.Taxes.DataStores;
using DuxCommerce.StoreBuilder.Taxes.Requests;
using DuxCommerce.StoreBuilder.Taxes.UseCases;
using DuxCommerce.Storefront.Views.TaxCode.ViewModels;

namespace DuxCommerce.Storefront.Views.TaxCode.VmBuilders;

public class TaxCodeVmBuilder(
    TaxCodeUseCases codeUseCases,
    TaxZoneUseCases zoneUseCases,
    ITaxCodeStore taxCodeStore)
{
    public async Task<TaxCodeIndexVm> BuildIndexModel()
    {
        var allCodes = await codeUseCases.GetAll();
        var taxZones = await zoneUseCases.GetAll();

        return new TaxCodeIndexVm
        {
            TaxCodes = allCodes,
            UsedTaxCodeIds = TaxCodeCore.getTaxCodeIds(taxZones)
        };
    }

    public async Task<TaxCodeVm> BuildEditCodeModel(string taxCodeId)
    {
        var taxCode = await taxCodeStore.Get(taxCodeId);

        return new TaxCodeVm
        {
            CodeModel = new TaxCodeModel
            {
                Id = taxCodeId,
                Name = taxCode.Name
            }
        };
    }
}