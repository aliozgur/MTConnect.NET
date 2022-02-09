// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using MTConnect.Devices;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace MTConnect.Streams
{
    public class DataItem : IDataItem
    {
        /// <summary>
        /// If an Agent cannot determine a Valid Data Value for a DataItem, the value returned for the CDATA for the Data Entity MUST be reported as UNAVAILABLE.
        /// </summary>
        public const string Unavailable = "UNAVAILABLE";


        /// <summary>
        /// The unique identifier for the DataItem. 
        /// The DataItemID MUST match the id attribute of the data item defined in the Device Information Model that this DataItem element represents.
        /// </summary>
        [XmlAttribute("dataItemId")]
        [JsonPropertyName("dataItemId")]
        public string DataItemId { get; set; }

        /// <summary>
        /// The time the data for the DataItem was reported or the statistics for the DataItem was computed.
        /// The timestamp MUST always represent the end of the collection interval when a duration or a TIME_SERIES is provided.
        /// The most accurate time available to the device MUST be used for the timestamp.
        /// </summary>
        [XmlAttribute("timestamp")]
        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The name of the DataItem.
        /// The name MUST match the name of the data item defined in the Device Information Model that this DataItem represents.
        /// </summary>
        [XmlAttribute("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A number representing the sequential position of an occurence of the DataItem in the data buffer of the Agent.
        /// The value MUST be represented as an unsigned 64 bit with valid values from 1 to 2^64-1.
        /// </summary>
        [XmlAttribute("sequence")]
        [JsonPropertyName("sequence")]
        public long Sequence { get; set; }

        /// <summary>
        /// Category of DataItem (Condition, Event, or Sample)
        /// </summary>
        [XmlAttribute("category")]
        [JsonPropertyName("category")]
        public DataItemCategory Category { get; set; }

        /// <summary>
        /// Type associated with the DataItem
        /// </summary>
        [XmlIgnore]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The subtype of the DataItem defined in the Device Information Model that this DataItem element represents
        /// </summary>
        [XmlAttribute("subType")]
        [JsonPropertyName("subType")]
        public string SubType { get; set; }

        /// <summary>
        /// The identifier of the Composition element defined in the MTConnectDevices document associated with the data reported for the DataItem.
        /// </summary>
        [XmlAttribute("compositionId")]
        [JsonPropertyName("compositionId")]
        public string CompositionId { get; set; }

        /// <summary>
        /// For those DataItem elements that report data that may be periodically reset to an initial value, 
        /// resetTriggered identifies when a reported value has been reset and what has caused that reset to occur.
        /// </summary>
        [XmlAttribute("resetTriggered")]
        [JsonPropertyName("resetTriggered")]
        public ResetTriggered ResetTriggered { get; set; }

        /// <summary>
        /// The number of Entry elements for the observation.
        /// </summary>
        [XmlAttribute("count")]
        [JsonPropertyName("count")]
        public long Count { get; set; }

        [XmlText]
        [JsonPropertyName("cdata")]
        public string CDATA { get; set; }

        [XmlElement("Entry")]
        [JsonPropertyName("entries")]
        public List<Entry> Entries { get; set; }


        /// <summary>
        /// Convert the specified value from NativeUnits specified to the Units specified
        /// </summary>
        /// <param name="value">The Value to Convert</param>
        /// <param name="units">The Units to Convert To</param>
        /// <param name="nativeUnits">The NativeUnits to Convert From</param>
        /// <returns>The Converted Sample Value</returns>
        public static double ConvertUnits(double value, string units, string nativeUnits)
        {
            if (!string.IsNullOrEmpty(units) && !string.IsNullOrEmpty(nativeUnits))
            {
                switch (units)
                {   
                    case NativeUnits.BAR:
                        switch (nativeUnits)
                        {
                            case Units.PASCAL: return value / 100000;
                            case NativeUnits.MILLIMETER_MERCURY: return value / 750.06375542;
                            case NativeUnits.POUND_PER_INCH_SQUARED: return value / 14.503773773;
                            case NativeUnits.TORR: return value / 750.0616827;
                        }
                        break;

                    case Units.CELSIUS:
                        switch (nativeUnits)
                        {
                            case NativeUnits.FAHRENHEIT:
                                double x = value - 32;
                                double y = (double)5 / (double)9;
                                double z = x * y;
                                return z;

                            case NativeUnits.KELVIN: return value / 274.15;
                        }
                        break;

                    case NativeUnits.CENTIPOISE:
                        switch (nativeUnits)
                        {
                            case Units.PASCAL_SECOND: return value * 1000;
                        }
                        break;

                    case Units.DEGREE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.RADIAN: return value * 57.2957795;
                            case Units.MICRO_RADIAN: return value / 17453.2925;
                        }
                        break;

                    case NativeUnits.DEGREE_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case Units.DEGREE_PER_SECOND: return value * 60;
                            case NativeUnits.RADIAN_PER_MINUTE: return value * 57.2957795 / 60;
                            case NativeUnits.RADIAN_PER_SECOND: return value * 57.2957795;
                            case Units.REVOLUTION_PER_MINUTE: return value * 360 / 60;
                            case Units.REVOLUTION_PER_SECOND: return value * 360;
                        }
                        break;

                    case Units.DEGREE_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.DEGREE_PER_MINUTE: return value / 60;
                            case NativeUnits.RADIAN_PER_MINUTE: return value * 57.2957795 / 60;
                            case NativeUnits.RADIAN_PER_SECOND: return value * 57.2957795;
                            case Units.REVOLUTION_PER_MINUTE: return value * 360 / 60;
                            case Units.REVOLUTION_PER_SECOND: return value * 360;
                        }
                        break;

                    case Units.DEGREE_PER_SECOND_SQUARED:
                        switch (nativeUnits)
                        {
                            case NativeUnits.RADIAN_PER_SECOND_SQUARED: return value * 57.2957795;
                            case Units.REVOLUTION_PER_SECOND_SQUARED: return value * 360;
                        }
                        break;

                    case NativeUnits.FAHRENHEIT:
                        switch (nativeUnits)
                        {
                            case Units.CELSIUS: return (value * (9 / 5)) + 32;
                            case NativeUnits.KELVIN: return value / 255.927778;
                        }
                        break;


                    case NativeUnits.FOOT:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER: return value / 25.4 / 12;
                            case NativeUnits.INCH: return value / 12;
                        }
                        break;

                    case NativeUnits.FOOT_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER_PER_SECOND: return value / 25.4 / 12 * 60;
                            case NativeUnits.FOOT_PER_SECOND: return value * 60;
                            case NativeUnits.INCH_PER_MINUTE: return value / 12;
                            case NativeUnits.INCH_PER_SECOND: return value / 12 * 60;
                        }
                        break;

                    case NativeUnits.FOOT_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER_PER_SECOND: return value / 25.4 / 12;
                            case NativeUnits.FOOT_PER_MINUTE: return value / 60;
                            case NativeUnits.INCH_PER_MINUTE: return value / 12 / 60;
                            case NativeUnits.INCH_PER_SECOND: return value / 12;
                        }
                        break;

                    case NativeUnits.FOOT_PER_SECOND_SQUARED:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER_PER_SECOND_SQUARED: return value / 25.4 / 12;
                            case NativeUnits.INCH_PER_SECOND_SQUARED: return value / 12;
                        }
                        break;

                    case NativeUnits.GALLON_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case Units.LITER_PER_SECOND: return value / 3.78541178 * 60;
                        }
                        break;

                    case NativeUnits.HOUR:
                        switch (nativeUnits)
                        {
                            case NativeUnits.MINUTE: return value / 60;
                            case Units.SECOND: return value / 60 / 60;
                        }
                        break;

                    case NativeUnits.INCH:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER: return value / 25.4;
                            case NativeUnits.FOOT: return value * 12;
                        }
                        break;

                    case NativeUnits.INCH_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER_PER_SECOND: return value / 25.4 * 60;
                            case NativeUnits.FOOT_PER_MINUTE: return value * 12;
                            case NativeUnits.FOOT_PER_SECOND: return value * 12 / 60;
                            case NativeUnits.INCH_PER_SECOND: return value * 60;
                        }
                        break;

                    case NativeUnits.INCH_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case Units.MILLIMETER_PER_SECOND: return value / 25.4;
                            case NativeUnits.FOOT_PER_MINUTE: return value * 12 / 60;
                            case NativeUnits.FOOT_PER_SECOND: return value * 12;
                            case NativeUnits.INCH_PER_MINUTE: return value / 60;
                        }
                        break;

                    case NativeUnits.INCH_POUND:
                        switch (nativeUnits)
                        {
                            case Units.NEWTON_METER: return value / 8.85075;
                        }
                        break;

                    case Units.JOULE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.KILOWATT_HOUR: return value * 3.78541178 / 60;
                        }
                        break;

                    case NativeUnits.KELVIN:
                        switch (nativeUnits)
                        {
                            case Units.CELSIUS: return value * 274.15;
                            case NativeUnits.FAHRENHEIT: return value * 255.927778;
                        }
                        break;

                    case Units.KILOGRAM:
                        switch (nativeUnits)
                        {
                            case Units.MILLIGRAM: return value / 1000000;
                            case NativeUnits.POUND: return value / 2.20462262;
                        }
                        break;

                    case NativeUnits.KILOWATT:
                        switch (nativeUnits)
                        {
                            case Units.WATT: return value / 1000;
                        }
                        break;

                    case NativeUnits.KILOWATT_HOUR:
                        switch (nativeUnits)
                        {
                            case Units.WATT_SECOND: return value / 3600000;
                        }
                        break;

                    case Units.LITER:
                        switch (nativeUnits)
                        {
                            case Units.MILLILITER: return value / 1000;
                        }
                        break;

                    case NativeUnits.LITER_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.GALLON_PER_MINUTE: return value * 3.78541178;
                            case Units.LITER_PER_SECOND: return value * 60;
                        }
                        break;

                    case Units.LITER_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.GALLON_PER_MINUTE: return value * 3.78541178 / 60;
                            case NativeUnits.LITER_PER_MINUTE: return value / 60;
                        }
                        break;

                    case Units.MILLIGRAM:
                        switch (nativeUnits)
                        {
                            case Units.KILOGRAM: return value * 1000000;
                            case NativeUnits.POUND: return value / 2.20462262 * 1000000;
                        }
                        break;

                    case Units.MILLILITER:
                        switch (nativeUnits)
                        {
                            case Units.LITER: return value * 1000;
                        }
                        break;

                    case Units.MILLIMETER:
                        switch (nativeUnits)
                        {
                            case NativeUnits.FOOT: return value * 25.4 * 12;
                            case NativeUnits.INCH: return value * 25.4;
                        }
                        break;

                    case NativeUnits.MILLIMETER_MERCURY:
                        switch (nativeUnits)
                        {
                            case NativeUnits.BAR: return value * 750.06375542;
                            case Units.PASCAL: return value / 133.322;
                            case NativeUnits.POUND_PER_INCH_SQUARED: return value * 51.71507548;
                            case NativeUnits.TORR: return value * 51.714932572;
                        }
                        break;

                    case Units.MILLIMETER_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.INCH_PER_MINUTE: return value * 25.4 / 60;
                            case NativeUnits.INCH_PER_SECOND: return value * 25.4;
                            case NativeUnits.FOOT_PER_MINUTE: return value * 25.4 * 12 / 60;
                            case NativeUnits.FOOT_PER_SECOND: return value * 25.4 * 12;
                            case NativeUnits.MILLIMETER_PER_MINUTE: return value / 60;
                        }
                        break;

                    case NativeUnits.MILLIMETER_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.INCH_PER_MINUTE: return value * 25.4;
                            case NativeUnits.INCH_PER_SECOND: return value * 25.4 * 60;
                            case NativeUnits.FOOT_PER_MINUTE: return value * 25.4 * 12;
                            case NativeUnits.FOOT_PER_SECOND: return value * 25.4 * 12 * 60;
                            case Units.MILLIMETER_PER_SECOND: return value * 60;
                        }
                        break;

                    case Units.MILLIMETER_PER_SECOND_SQUARED:
                        switch (nativeUnits)
                        {
                            case NativeUnits.INCH_PER_SECOND_SQUARED: return value * 25.4;
                            case NativeUnits.FOOT_PER_SECOND_SQUARED: return value * 25.4 * 12;
                        }
                        break;

                    case NativeUnits.MINUTE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.HOUR: return value * 60;
                            case Units.SECOND: return value / 60;
                        }
                        break;

                    case Units.NEWTON:
                        switch (nativeUnits)
                        {
                            case NativeUnits.POUND: return value * 4.448221615254;
                        }
                        break;

                    case Units.NEWTON_METER:
                        switch (nativeUnits)
                        {
                            case NativeUnits.INCH_POUND: return value * 8.85075;
                        }
                        break;

                    case Units.PASCAL:
                        switch (nativeUnits)
                        {
                            case NativeUnits.BAR: return value * 100000;
                            case NativeUnits.MILLIMETER_MERCURY: return value / 133.322;
                            case NativeUnits.POUND_PER_INCH_SQUARED: return value * 6894.75729;
                            case NativeUnits.TORR: return value * 133.322368;
                        }
                        break;

                    case Units.PASCAL_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.PASCAL_PER_MINUTE: return value / 60;
                        }
                        break;

                    case NativeUnits.PASCAL_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case Units.PASCAL_PER_SECOND: return value * 60;
                        }
                        break;

                    case Units.PASCAL_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.CENTIPOISE: return value / 1000;
                        }
                        break;

                    case NativeUnits.POUND:
                        switch (nativeUnits)
                        {
                            case Units.MILLIGRAM: return value / 453592;
                            case Units.KILOGRAM: return value * 2.20462262;
                        }
                        break;

                    case NativeUnits.POUND_PER_INCH_SQUARED:
                        switch (nativeUnits)
                        {
                            case NativeUnits.BAR: return value * 14.503773773;
                            case NativeUnits.MILLIMETER_MERCURY: return value / 51.71507548;
                            case Units.PASCAL: return value / 6894.7572932;
                            case NativeUnits.TORR: return value / 51.714932572;
                        }
                        break;

                    case NativeUnits.RADIAN:
                        switch (nativeUnits)
                        {
                            case Units.DEGREE: return value / 57.2957795;
                        }
                        break;

                    case NativeUnits.RADIAN_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.DEGREE_PER_MINUTE: return value / 57.2957795;
                            case Units.DEGREE_PER_SECOND: return value / 57.2957795 * 60;
                            case NativeUnits.RADIAN_PER_SECOND: return value * 60;
                            case Units.REVOLUTION_PER_MINUTE: return value * 6.28318531;
                            case Units.REVOLUTION_PER_SECOND: return value * 6.28318531 * 60;
                        }
                        break;

                    case NativeUnits.RADIAN_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.DEGREE_PER_MINUTE: return value / 57.2957795 / 60;
                            case Units.DEGREE_PER_SECOND: return value / 57.2957795;
                            case NativeUnits.RADIAN_PER_MINUTE: return value / 60;
                            case Units.REVOLUTION_PER_MINUTE: return value * 6.28318531 / 60;
                            case Units.REVOLUTION_PER_SECOND: return value * 6.28318531;
                        }
                        break;

                    case NativeUnits.RADIAN_PER_SECOND_SQUARED:
                        switch (nativeUnits)
                        {
                            case Units.DEGREE_PER_SECOND_SQUARED: return value / 57.2957795;
                            case Units.REVOLUTION_PER_SECOND_SQUARED: return value * 6.28318531;
                        }
                        break;

                    case Units.REVOLUTION_PER_MINUTE:
                        switch (nativeUnits)
                        {
                            case NativeUnits.DEGREE_PER_MINUTE: return value / 360;
                            case Units.DEGREE_PER_SECOND: return value / 360 * 60;
                            case NativeUnits.RADIAN_PER_MINUTE: return value / 6.28318531;
                            case NativeUnits.RADIAN_PER_SECOND: return value / 6.28318531 * 60;
                            case Units.REVOLUTION_PER_SECOND: return value * 60;
                        }
                        break;

                    case Units.REVOLUTION_PER_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.DEGREE_PER_MINUTE: return value / 360 / 60;
                            case Units.DEGREE_PER_SECOND: return value / 360;
                            case NativeUnits.RADIAN_PER_MINUTE: return value * 57.2957795 * 360 / 60;
                            case NativeUnits.RADIAN_PER_SECOND: return value * 57.2957795 * 360;
                            case Units.REVOLUTION_PER_MINUTE: return value / 60;
                        }
                        break;

                    case Units.REVOLUTION_PER_SECOND_SQUARED:
                        switch (nativeUnits)
                        {
                            case Units.DEGREE_PER_SECOND_SQUARED: return value / 360;
                            case NativeUnits.RADIAN_PER_SECOND_SQUARED: return value / 6.28318531;
                        }
                        break;

                    case Units.SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.HOUR: return value * 60 * 60;
                            case NativeUnits.MINUTE: return value * 60;
                        }
                        break;

                    case NativeUnits.TORR:
                        switch (nativeUnits)
                        {
                            case NativeUnits.BAR: return value * 750.0616827;
                            case NativeUnits.MILLIMETER_MERCURY: return value / 1.0000027634;
                            case Units.PASCAL: return value / 133.32236842;
                            case NativeUnits.POUND_PER_INCH_SQUARED: return value * 51.714932572;
                        }
                        break;

                    case Units.WATT:
                        switch (nativeUnits)
                        {
                            case NativeUnits.KILOWATT: return value * 1000;
                        }
                        break;

                    case Units.WATT_SECOND:
                        switch (nativeUnits)
                        {
                            case NativeUnits.KILOWATT_HOUR: return value * 3600000;
                        }
                        break;
                }
            }

            return value;
        }
    }
}
