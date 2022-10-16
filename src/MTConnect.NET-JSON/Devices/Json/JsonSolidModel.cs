// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using MTConnect.Devices.Configurations.SolidModel;
using System.Text.Json.Serialization;

namespace MTConnect.Devices.Json
{
    public class JsonSolidModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("solidModelIdRef")]
        public string SolidModelIdRef { get; set; }

        [JsonPropertyName("href")]
        public string Href { get; set; }

        [JsonPropertyName("itemRef")]
        public string ItemRef { get; set; }

        [JsonPropertyName("mediaType")]
        public SolidModelMediaType MediaType { get; set; }

        [JsonPropertyName("coordinateSystemIdRef")]
        public string CoordinateSystemIdRef { get; set; }

        [JsonPropertyName("transformation")]
        public JsonTransformation Transformation { get; set; }

        [JsonPropertyName("scale")]
        public string Scale { get; set; }


        public JsonSolidModel() { }

        public JsonSolidModel(ISolidModel solidModel)
        {
            if (solidModel != null)
            {
                Id = solidModel.Id;
                SolidModelIdRef = solidModel.SolidModelIdRef;
                Href = solidModel.Href;
                MediaType = solidModel.MediaType;
                CoordinateSystemIdRef = solidModel.CoordinateSystemIdRef;
                if (solidModel.Transformation != null) Transformation = new JsonTransformation(solidModel.Transformation);
                Scale = solidModel.Scale;
            }
        }


        public ISolidModel ToSolidModel()
        {
            var solidModel = new SolidModel();
            solidModel.Id = Id;
            solidModel.SolidModelIdRef = Id;
            solidModel.Href = Href;
            solidModel.ItemRef = ItemRef;
            solidModel.MediaType = MediaType;
            solidModel.CoordinateSystemIdRef = CoordinateSystemIdRef;
            if (Transformation != null) solidModel.Transformation = Transformation.ToTransformation();
            solidModel.Scale = Scale;
            return solidModel;
        }
    }
}