namespace HomeTask.Lesson1
{
    internal class NoDealBehaviour : DealerBehaviourBase
    {
        public override void ShowShop()
        {
            ShowMessage("Тебе ничего не продам! (продажа недоступна)");
        }
    }
}
