using UnityEngine;


namespace Game
{
    internal sealed class ObjectInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        public void InstantiateObject()
        {
            var obj = Instantiate(prefab);
            obj.transform.position = transform.position;
        }
    }
}
