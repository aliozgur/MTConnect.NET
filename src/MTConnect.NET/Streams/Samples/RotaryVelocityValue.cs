// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Streams.Samples
{
    /// <summary>
    /// The measurement of the rotational speed of a rotary axis.
    /// </summary>
    public class RotaryVelocityValue : SampleValue
    {
        public RotaryVelocityValue(double nativeValue, string nativeUnits = Devices.Samples.RotaryVelocityDataItem.DefaultUnits)
        {
            Value = nativeValue;
            _units = Devices.Samples.RotaryVelocityDataItem.DefaultUnits;
            _nativeUnits = nativeUnits;
        }
    }
}
