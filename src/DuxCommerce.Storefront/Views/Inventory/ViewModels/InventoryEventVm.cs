using System.Collections.Generic;
using System.Linq;
using DuxCommerce.StoreBuilder.Catalog.SimpleTypes;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DuxCommerce.Storefront.Views.Inventory.ViewModels;

public class InventoryEventVm
{
    public string EventId { get; set; }
    public string EventName { get; set; }

    public static IEnumerable<SelectListItem> GetAll()
    {
        var events = new List<InventoryEventVm>
        {
            new()
            {
                EventId = nameof(InventoryEventType.Corrected),
                EventName = nameof(InventoryEventType.Corrected)
            },
            new()
            {
                EventId = nameof(InventoryEventType.Counted),
                EventName = nameof(InventoryEventType.Counted)
            },
            new()
            {
                EventId = nameof(InventoryEventType.Restocked),
                EventName = nameof(InventoryEventType.Restocked)
            },
            new()
            {
                EventId = nameof(InventoryEventType.Received),
                EventName = nameof(InventoryEventType.Received)
            },
            new()
            {
                EventId = nameof(InventoryEventType.Damaged),
                EventName = nameof(InventoryEventType.Damaged)
            },
            new()
            {
                EventId = nameof(InventoryEventType.Lost),
                EventName = nameof(InventoryEventType.Lost)
            },
            new()
            {
                EventId = nameof(InventoryEventType.Used),
                EventName = nameof(InventoryEventType.Used)
            }
        };

        return events.Select(x => new SelectListItem(x.EventId, x.EventName));
    }
}