// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace MTConnect.Buffers
{
    /// <summary>
    /// Buffer interface used to store Assets
    /// </summary>
    public interface IMTConnectAssetBuffer
    {
        /// <summary>
        /// Get a unique identifier for the Buffer
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Get the configured size of the Asset Buffer in the number of maximum number of Assets the buffer can hold at one time.
        /// </summary>
        long BufferSize { get; }

        /// <summary>
        /// Get the total number of Assets that are currently in the Buffer
        /// </summary>
        long AssetCount { get; }


        /// <summary>
        /// Get a list of all Assets from the Buffer
        /// </summary>
        IEnumerable<Assets.IAsset> GetAssets(string type = null, bool removed = false, int count = 0);

        /// <summary>
        /// Get a list of all Assets from the Buffer
        /// </summary>
        Task<IEnumerable<Assets.IAsset>> GetAssetsAsync(string type = null, bool removed = false, int count = 0);

        /// <summary>
        /// Get the specified Asset from the Buffer
        /// </summary>
        /// <param name="assetId">The ID of the Asset to return</param>
        Assets.IAsset GetAsset(string assetId);

        /// <summary>
        /// Get the specified Asset from the Buffer
        /// </summary>
        /// <param name="assetId">The ID of the Asset to return</param>
        Task<Assets.IAsset> GetAssetAsync(string assetId);


        /// <summary>
        /// Add an Asset to the Buffer
        /// </summary>
        /// <param name="asset">The Asset to add to the Buffer</param>
        bool AddAsset(Assets.IAsset asset);

        /// <summary>
        /// Add an Asset to the Buffer
        /// </summary>
        /// <param name="asset">The Asset to add to the Buffer</param>
        Task<bool> AddAssetAsync(Assets.IAsset asset);
    }
}