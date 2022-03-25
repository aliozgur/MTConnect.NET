// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Observations.Samples.Values
{
    /// <summary>
    /// The measurement of temperature.
    /// </summary>
    public class TemperatureValue : SampleValue
    {
        public TemperatureValue(double nativeValue, string nativeUnits = Devices.Samples.TemperatureDataItem.DefaultUnits)
        {
            Value = nativeValue;
            _units = Devices.Samples.TemperatureDataItem.DefaultUnits;
            _nativeUnits = nativeUnits;
        }
    }
}