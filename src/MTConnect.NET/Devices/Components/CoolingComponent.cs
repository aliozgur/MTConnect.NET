// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace MTConnect.Devices.Components
{
    /// <summary>
    /// Cooling is a System used to to extract controlled amounts of heat to achieve a target temperature at a specified cooling rate.
    /// </summary>
    public class CoolingComponent : Component 
    {
        public const string TypeId = "Cooling";
        public const string NameId = "cooling";

        public CoolingComponent()  { Type = TypeId; }
    }
}