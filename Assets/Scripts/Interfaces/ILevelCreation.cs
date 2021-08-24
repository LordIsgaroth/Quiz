using System.Collections.Generic;

public interface ILevelCreation
{
    public int GetNumberOfLevels();
    public void CreateLevel(int number);
    public List<Card> GetLevelCards();
}
