namespace HomeTask.Lesson1
{
    internal class ArmorDealBehaviour : DealerBehaviourBase
    {
        public override void ShowShop()
        {
            ShowMessage("Для тебя есть некачественная броня! (продажа экипировки)");
        }
    }
}
