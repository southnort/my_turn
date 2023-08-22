using UnityEngine;


namespace Game
{
    internal sealed class DestroyByTimer : MonoBehaviour
    {
        [SerializeField] private float time = 5f;

        private void OnEnable()
        {
            Destroy(gameObject, time);
        }
    }
}
