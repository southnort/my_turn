using Game.Entities;
using UnityEngine;


namespace Game
{
    internal sealed class GridTile : MonoBehaviour
    {
        public IEntity EntityOnTile;
        public Vector2Int Coordinates { get; private set; }

        public void SetCoordinates(Vector2Int coords)
        {
            Coordinates = coords;
        }
    }
}
