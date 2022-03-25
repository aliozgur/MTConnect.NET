// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Observations.Samples.Values
{
    /// <summary>
    /// The value of Wattage used or generated by a component over an interval of time.
    /// </summary>
    public class ElectricalEnergyValue : SampleValue
    {
        public ElectricalEnergyValue(double nativeValue, string nativeUnits = Devices.Samples.ElectricalEnergyDataItem.DefaultUnits)
        {
            Value = nativeValue;
            _units = Devices.Samples.ElectricalEnergyDataItem.DefaultUnits;
            _nativeUnits = nativeUnits;
        }
    }
}