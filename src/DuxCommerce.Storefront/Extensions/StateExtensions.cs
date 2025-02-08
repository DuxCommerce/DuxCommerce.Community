using System.Collections.Generic;
using DuxCommerce.StoreBuilder.Settings.DataTypes;

namespace DuxCommerce.Storefront.Extensions;

public static class StateExtensions
{
    public static Dictionary<string, List<StateRow>> GetStateMap(this IEnumerable<StateRow> allStates)
    {
        var stateMap = new Dictionary<string, List<StateRow>>();

        foreach (var state in allStates)
            if (!stateMap.ContainsKey(state.CountryCode))
            {
                var states = new List<StateRow> { state };
                stateMap.Add(state.CountryCode, states);
            }
            else
            {
                var states = stateMap[state.CountryCode];
                states.Add(state);
            }

        return stateMap;
    }
}