using UnityEngine;


namespace Game
{
    internal sealed class ForwardMover : MonoBehaviour
    {
        [SerializeField] private float speed;

        private void Update()
        {
            transform.position = 
                Vector3.MoveTowards(transform.position, transform.position + transform.forward, speed * Time.deltaTime);
        }
    }
}
