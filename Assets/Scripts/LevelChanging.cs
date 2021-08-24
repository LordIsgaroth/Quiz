using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{        
    [SerializeField] private InterfaceUpdater _interfaceUpdater;
    
    private int _currentLevel = 2;
    private ILevelCreation _levelCreator;
    private UnityAction<Card> _cardChooseDispatcher;
    private Card _currentGoal;    

    void Start()
    {      
        _levelCreator = GetComponent<ILevelCreation>();
        _cardChooseDispatcher = ChooseCard;
        LoadNextLevel();
    }

    private void LoadNextLevel()
    { 
        _levelCreator.CreateLevel(_currentLevel, _cardChooseDispatcher);
        SelectGoal(_levelCreator.GetLevelCards());
        _currentLevel++;
    }

    private void SelectGoal(List<Card> cards)
    {
        _currentGoal = cards[Random.Range(0, cards.Count)];
        _interfaceUpdater.SetGoalText($"Find {_currentGoal.Identifier}");
    }

    private void ChooseCard(Card card)
    {
        if (card.Identifier == _currentGoal.Identifier) Debug.Log("Correct!");
        else Debug.Log("Incorrect");        
    }
}
