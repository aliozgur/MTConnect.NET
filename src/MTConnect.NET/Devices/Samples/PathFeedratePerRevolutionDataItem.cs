// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Devices.Samples
{
    /// <summary>
    /// The measurement of the feedrate for the axes, or a single axis, associated with a Path component-a vector.
    /// </summary>
    public class PathFeedratePerRevolutionDataItem : DataItem
    {
        public const DataItemCategory CategoryId = DataItemCategory.SAMPLE;
        public const string TypeId = "PATH_FEEDRATE_PER_REVOLUTION";
        public const string NameId = "pathFeedPerRev";
        public const string DefaultUnits = Devices.Units.MILLIMETER_PER_REVOLUTION;

        public enum SubTypes
        {
            /// <summary>
            /// The measured or reported value of an observation.
            /// </summary>
            ACTUAL,

            /// <summary>
            /// Directive value including adjustments such as an offset or overrides.
            /// </summary>
            COMMANDED,

            /// <summary>
            /// Directive value without offsets and adjustments.
            /// </summary>
            PROGRAMMED
        }


        public PathFeedratePerRevolutionDataItem()
        {
            Category = CategoryId;
            Type = TypeId;
            Units = DefaultUnits;
        }

        public PathFeedratePerRevolutionDataItem(
            string parentId,
            SubTypes subType)
        {
            Id = CreateId(parentId, NameId, GetSubTypeId(subType));
            Category = CategoryId;
            Type = TypeId;
            SubType = subType.ToString();
            Name = NameId;
            Units = DefaultUnits;
        }

        public static string GetSubTypeId(SubTypes subType)
        {
            switch (subType)
            { 
                case SubTypes.ACTUAL: return "act";
                case SubTypes.COMMANDED: return "cmd";
                case SubTypes.PROGRAMMED: return "prg";
            }

            return null;
        }
    }
}
