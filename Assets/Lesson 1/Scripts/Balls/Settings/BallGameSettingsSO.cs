using UnityEngine;

namespace HomeTask.Lesson1
{
    [CreateAssetMenu(menuName ="Lesson1/Task4/CreateBallGameSettings")]
    internal class BallGameSettingsSO : ScriptableObject
    {
        [SerializeField]
        private BallsSettings _ballsSettings;

        public BallsSettings BallsSettings => _ballsSettings;
    }
}
