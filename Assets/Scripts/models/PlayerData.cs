using System;

[Serializable]
public class PlayerData
{
    public int unlockedCheckpoint;
    public bool soundEnabled;

    public PlayerData(int unlockedCheckpoint, bool soundEnabled)
    {
        this.unlockedCheckpoint = unlockedCheckpoint;
        this.soundEnabled = soundEnabled;
    }
}
