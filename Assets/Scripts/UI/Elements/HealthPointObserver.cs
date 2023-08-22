using Game.Entities;
using TMPro;
using UnityEngine;


namespace Game.UI
{
    internal sealed class HealthPointObserver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI hpTmp;
        [SerializeField] private Entity observableEntity;
        private HealthComponent _health;


        private void Start()
        {
            _health = observableEntity.Get<HealthComponent>();
            _health.Health.OnChange += UpdateText;
        }

        private void OnDestroy()
        {
            _health.Health.OnChange -= UpdateText;
        }

        private void UpdateText(int obj)
        {
            hpTmp.text = $"{obj}/{_health.MaxHp}";
        }
    }
}
