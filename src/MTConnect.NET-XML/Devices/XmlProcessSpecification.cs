// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using MTConnect.Devices.Configurations.Specifications;
using System.Xml;
using System.Xml.Serialization;

namespace MTConnect.Devices.Xml
{
    [XmlRoot("ProcessSpecification")]
    public class XmlProcessSpecification : XmlAbstractSpecification
    {
        [XmlElement("ControlLimits")]
        public XmlControlLimits ControlLimits { get; set; }

        [XmlElement("SpecificationLimits")]
        public XmlSpecificationLimits SpecificationLimits { get; set; }

        [XmlElement("AlarmLimits")]
        public XmlAlarmLimits AlarmLimits { get; set; }


        public override IAbstractSpecification ToSpecification()
        {
            var specification = new ProcessSpecification();
            specification.Id = Id;
            specification.Name = Name;
            specification.Type = Type;
            specification.SubType = SubType;
            specification.DataItemIdRef = DataItemIdRef;
            specification.Units = Units;
            specification.CompositionIdRef = CompositionIdRef;
            specification.CoordinateIdRef = CoordinateIdRef;
            specification.Originator = Originator;

            if (ControlLimits != null) specification.ControlLimits = ControlLimits.ToControlLimits();
            if (SpecificationLimits != null) specification.SpecificationLimits = SpecificationLimits.ToSpecificationLimits();
            if (AlarmLimits != null) specification.AlarmLimits = AlarmLimits.ToAlarmLimits();

            return specification;
        }
    }
}
