using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{        
    [SerializeField] private InterfaceUpdater _interfaceUpdater;
    
    private int _currentLevel = 1;
    private ILevelCreation _levelCreator;
    private UnityAction<Card> _cardChooseDispatcher;
    private Card _currentGoal;
    private List<Card> _selectedGoals = new List<Card>();

    void Start()
    {      
        _levelCreator = GetComponent<ILevelCreation>();
        _cardChooseDispatcher = ChooseCard;

        if (!HasNextLevel()) throw new System.Exception("No levels described!");

        LoadNextLevel();
    }

    private void LoadNextLevel()
    { 
        _levelCreator.CreateLevel(_currentLevel, _selectedGoals, _cardChooseDispatcher);
        SelectGoal(_levelCreator.GetLevelCards());
        _currentLevel++;
    }

    private bool HasNextLevel()
    {
        if (_currentLevel <= _levelCreator.GetNumberOfLevels()) return true;
        else return false;
    }

    private void SelectGoal(List<Card> cards)
    {
        _currentGoal = cards[Random.Range(0, cards.Count)];
        _selectedGoals.Add(_currentGoal);
        _interfaceUpdater.SetGoalText($"Find {_currentGoal.Identifier}");
    }

    private void ChooseCard(Card card)
    {
        if (card.Identifier == _currentGoal.Identifier)
        {
            Debug.Log("Correct!");
            if (HasNextLevel()) LoadNextLevel();
        }
        else Debug.Log("Incorrect");
    }
}
