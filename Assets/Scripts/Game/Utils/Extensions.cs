using UnityEngine;


namespace Game
{
    internal static class Extensions
    {
        public static Vector3 ToDirectionVector(this Vector3 origin)
        {
            var direction = origin.normalized;
            float angle = 0;

            if (direction.x == 1)
                angle = 90f;
            else if (direction.x == -1)
                angle = 270;
            else if (direction.z == 1)
                angle = 0f;
            else
                angle = 180f;

            return new Vector3(0, angle, 0);
        }

        public static Vector3 ToDirectionVector(this Vector2Int origin)
        {
            var direction = origin;
            float angle = 0;

            if (direction.x == 1)
                angle = 90f;
            else if (direction.x == -1)
                angle = 270;
            else if (direction.y == 1)
                angle = 0f;
            else
                angle = 180f;

            return new Vector3(0, angle, 0);
        }
    }
}
