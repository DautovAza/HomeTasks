using UnityEngine;

namespace HomeTask.Lesson1
{
    internal class InteractionZoneComponent : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _interactionView;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out PlayerInteractableComponent _))
            {
                ShowInteractionZone();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out PlayerInteractableComponent _))
            {
                HideInteractionZone();
            }
        }

        private void ShowInteractionZone()
        {
            _interactionView.SetActive(true);
        }

        private void HideInteractionZone()
        {
            _interactionView.SetActive(false);
        }
    }
}
