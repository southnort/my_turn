using System;
using UnityEngine;

namespace Game
{
    [Serializable]
    internal sealed class LevelConfig
    {
        public Vector2Int LevelSize = new Vector2Int(5, 5);
        public int TilesCount = 19;
        public float TileSize = 1f;
    }
}
