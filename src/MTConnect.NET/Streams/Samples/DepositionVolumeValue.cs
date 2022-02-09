// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Streams.Samples
{
    /// <summary>
    /// The spatial volume of material deposited in an additive manufacturing process.
    /// </summary>
    public class DepositionVolumeValue : SampleValue
    {
        public DepositionVolumeValue(double nativeValue, string nativeUnits = Devices.Samples.DepositionVolumeDataItem.DefaultUnits)
        {
            Value = nativeValue;
            _units = Devices.Samples.DepositionVolumeDataItem.DefaultUnits;
            _nativeUnits = nativeUnits;
        }
    }
}
