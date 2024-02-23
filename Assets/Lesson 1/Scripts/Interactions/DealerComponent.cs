using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class DealerComponent : MonoBehaviour, IInteractable
    {
        private DealerBehaviourBase _dealerBehaviour;

        internal void SetDealBehaviour(DealerBehaviourBase dealerBehaviour)
        {
            _dealerBehaviour = dealerBehaviour;
        }

        public void Interract()
        {
            _dealerBehaviour.ShowShop();
        }
    }
}
