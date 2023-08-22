namespace Game.Turn
{
    internal readonly struct TurnStartedEvent
    {
        public readonly string TurnOwnerName;

        public TurnStartedEvent(string turnOwner)
        {
            TurnOwnerName = turnOwner;
        }
    }
}
