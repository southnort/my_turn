using UnityEngine;


namespace Game
{
    internal sealed class LookAtCamera : MonoBehaviour
    {
        [SerializeField] private bool UseCameraForward;
        [SerializeField] private bool Flat;
        [SerializeField] private bool Inverted;
        private Transform _mainCam;


        private void Update()
        {
            if (_mainCam == null)
            {
                _mainCam = Camera.main.transform;
            }
            Vector3 Dir = Vector3.zero;
            if (UseCameraForward)
            {
                Dir = _mainCam.forward;
            }
            else
            {
                Dir = _mainCam.transform.position - transform.position;
            }
            if (Flat)
            {
                Dir.y = 0;
            }
            transform.rotation = Quaternion.LookRotation(Inverted ? -Dir : Dir);
        }
    }
}
