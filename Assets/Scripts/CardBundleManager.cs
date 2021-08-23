using UnityEngine;

public class CardBundleManager : MonoBehaviour, ICardBundleGetter
{
    [SerializeField] private CardBundle[] _cardBundles;

    public CardBundle ChooseCardBundle()
    {
        if (_cardBundles.Length == 0) throw new System.Exception("No card bundle specified!");

        int bundleNumber = Random.Range(0, _cardBundles.Length);
        return _cardBundles[bundleNumber];
    }
}
