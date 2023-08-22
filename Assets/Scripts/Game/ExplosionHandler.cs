using Game.Entities;
using System.Collections.Generic;
using UnityEngine;
using VContainer;


namespace Game
{
    internal sealed class ExplosionHandler
    {
        [Inject] private ApplyDirectionHandler _directionHandler;

        internal void HandleExplosion(Vector2Int explosionCoordinates, IEnumerable<IEntity> explodedEntities)
        {
            foreach (var entity in explodedEntities)
            {
                if (!entity.TryGet<GridCoordinatesComponent>(out var coords)) continue;

                var delta = coords.GridCoordinates - explosionCoordinates;
                if (delta.x != 0 && delta.y != 0) continue;

                _directionHandler.ApplyDirection(entity, delta);
            }
        }
    }
}
