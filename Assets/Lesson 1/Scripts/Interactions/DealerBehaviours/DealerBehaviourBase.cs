using UnityEngine;

namespace HomeTask.Lesson1
{
    internal abstract class DealerBehaviourBase
    {
        public abstract void ShowShop();

        protected void ShowMessage(string message)
        {
            Debug.Log("Торговец: " + message);
        }
    }
}
