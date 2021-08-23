using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundle", menuName = "Card Bundle", order = 10)]
public class CardBundle : ScriptableObject
{
    [SerializeField] private Card[] _cards;

    public Card[] CardData => _cards;
}
