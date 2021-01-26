[System.Serializable]
public class UpgradeData
{
    public bool N1;
    public bool N2;

    public UpgradeData()
    {
            N1 = SaveTrigger.upgradeData["N1"];
            N2 = SaveTrigger.upgradeData["N2"];
    }
}
