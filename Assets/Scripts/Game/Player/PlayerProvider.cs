using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Game
{
    internal sealed class PlayerProvider : MonoBehaviour
    {
        [SerializeField] private Player player;

        public Player Player => player;
    }
}
