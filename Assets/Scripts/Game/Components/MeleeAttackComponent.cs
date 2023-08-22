using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    [Serializable]
    internal sealed class MeleeAttackComponent : MonoBehaviour
    {
        [SerializeField] public UnityEvent OnAttack;
        [SerializeField] private DamageDealer damageDealer;

        internal void Attack(Vector2Int direction, Action callback = null)
        {
            OnAttack?.Invoke();
            StartCoroutine(AttackCoroutine(callback));
        }

        private IEnumerator AttackCoroutine(Action callback)
        {
            damageDealer.gameObject.SetActive(true);
            yield return new WaitForSeconds(1);
            damageDealer.gameObject.SetActive(false);

            callback?.Invoke();
        }
    }
}
