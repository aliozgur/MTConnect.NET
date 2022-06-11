// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using MTConnect.Devices.Components;

namespace MTConnect.Models.Components
{
    /// <summary>
    /// WorkEnvelope is a System that organizes information about the physical process execution space within a piece of equipment. 
    /// The WorkEnvelope MAY provide information regarding the physical workspace and the conditions within that workspace.
    /// </summary>
    public class WorkEnvelopeModel : SystemModel, IWorkEnvelopeModel
    {
        public WorkEnvelopeModel()
        {
            Type = WorkEnvelopeComponent.TypeId;
        }

        public WorkEnvelopeModel(string componentId)
        {
            Id = componentId;
            Type = WorkEnvelopeComponent.TypeId;
        }
    }
}