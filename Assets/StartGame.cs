public class StartGame
{
    private DragonManager _dragonManager;

    public StartGame(DragonManager dragonManager)
    {
        _dragonManager = dragonManager;
    }

    public void SelectDragon(string dragonType)
    {
        _dragonManager.SetActiveDragon(dragonType);
    }
}
