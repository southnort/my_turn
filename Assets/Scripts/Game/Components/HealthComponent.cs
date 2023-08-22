using System;
using UnityEngine;
using UnityEngine.Events;
using Yrr.Utils;

namespace Game
{
    [Serializable]
    internal sealed class HealthComponent : MonoBehaviour
    {
        [field: SerializeField] public int MaxHp { get; private set; }
        public ReactiveInt Health { get; private set; } = new ReactiveInt(0);

        [Space]
        [SerializeField] public UnityEvent OnTakeDamage;
        [SerializeField] public UnityEvent OnDie;


        private void Start()
        {
            Health.Value = MaxHp;
            Health.OnChange += HealthChanged;
        }

        private void OnDestroy()
        {
            Health.OnChange -= HealthChanged;
        }

        private void HealthChanged(int obj)
        {
            OnTakeDamage?.Invoke();

            if (obj <= 0)
                OnDie?.Invoke();
        }
    }
}
