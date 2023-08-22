using Game.Events;
using Game.Turn;
using TMPro;
using UnityEngine;
using VContainer;

namespace Game
{
    internal sealed class TurnStartedObserver : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI turnTmp;
        [Inject] private EventBus _eventBus;


        private void Start()
        {
            _eventBus.Subscribe<TurnStartedEvent>(UpdateTurnInfo);
        }

        private void OnDestroy()
        {
            _eventBus.Unsubscribe<TurnStartedEvent>(UpdateTurnInfo);
        }

        private void UpdateTurnInfo(TurnStartedEvent evnt)
        {
            turnTmp.text = $"{evnt.TurnOwnerName}'s turn";
        }
    }
}
