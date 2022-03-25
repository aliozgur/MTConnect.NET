// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Observations.Samples.Values
{
    /// <summary>
    /// The density of the material deposited in an additive manufacturing process per unit of volume.
    /// </summary>
    public class DepositionDensityValue : SampleValue
    {
        public DepositionDensityValue(double nativeValue, string nativeUnits = Devices.Samples.DepositionDensityDataItem.DefaultUnits)
        {
            Value = nativeValue;
            _units = Devices.Samples.DepositionDensityDataItem.DefaultUnits;
            _nativeUnits = nativeUnits;
        }
    }
}