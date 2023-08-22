using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    internal sealed class Timer : MonoBehaviour
    {
        [SerializeField] private float timerTime;
        [SerializeField] public UnityEvent OnTimerEnd;

        private void OnEnable()
        {
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            yield return new WaitForSeconds(timerTime);
            OnTimerEnd?.Invoke();
        }
    }
}
