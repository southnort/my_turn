using UnityEngine;


namespace Yarigg.Game
{
    internal sealed class MaterialOffsetMover : MonoBehaviour
    {
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Vector2 offsetSpeed;



        private void Update()
        {
            meshRenderer.material.mainTextureOffset +=
                 offsetSpeed * Time.unscaledDeltaTime;
        }

        public void OnGamePaused()
        {
            enabled = false;
        }

        public void OnGameUnPaused()
        {
            enabled = true;
        }
    }
}
