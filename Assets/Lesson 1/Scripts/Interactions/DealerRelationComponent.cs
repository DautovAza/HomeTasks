using UnityEngine;

namespace HomeTask.Lesson1
{
    [RequireComponent(typeof(DealerComponent))]
    internal class DealerRelationComponent : MonoBehaviour
    {
        [SerializeField]
        private PlayerRaitingComponent _playerRaitingComponent;

        private DealerComponent _dealerComponent;
        
        private void Awake()
        {
            _dealerComponent = GetComponent<DealerComponent>();
            _dealerComponent.SetDealBehaviour(new NoDealBehaviour());
        }

        private void OnEnable()
        {
            _playerRaitingComponent.RaitingChanged += OnRaitingChanged;
        }
        private void OnDisable()
        {
            _playerRaitingComponent.RaitingChanged -= OnRaitingChanged;
        }

        private void OnRaitingChanged(int playerRaiting)
        {
            switch (playerRaiting)
            {
                case 0:
                    _dealerComponent.SetDealBehaviour(new NoDealBehaviour());
                    break;
                case 1:
                    _dealerComponent.SetDealBehaviour(new ArmorDealBehaviour());
                    break;
                case 2:
                    _dealerComponent.SetDealBehaviour(new FruitDealBehaviour());
                    break;
                default:
                    break;
            }
        }
    }
}
