using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{        
    [SerializeField] private InterfaceUpdater _interfaceUpdater;
    [SerializeField] private float _delayBeforeLevelChange;

    private int _currentLevel = 1;
    
    private ILevelCreation _levelCreator;
    private UnityAction<CellController> _cardChooseDispatcher;
    private Card _currentGoal;
    private List<Card> _selectedGoals = new List<Card>();
    private ParticleDisplayer _particleDisplayer;
    
    void Start()
    {
        _particleDisplayer = new ParticleDisplayer();
        _levelCreator = GetComponent<ILevelCreation>();
        _cardChooseDispatcher = ChooseCard;

        if (!HasNextLevel()) throw new System.Exception("No levels described!");

        LoadNextLevel();
    }

    private void LoadNextLevel()
    { 
        _levelCreator.CreateLevel(_currentLevel, _selectedGoals, _cardChooseDispatcher);
        SelectGoal(_levelCreator.GetLevelCards());

        if (_currentLevel == 1)
        {            
            _interfaceUpdater.GoalTextFadeIn();
        } 

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

    private void ChooseCard(CellController cellContrroller)
    {
        if (cellContrroller.Card.Identifier == _currentGoal.Identifier)
        {
            Debug.Log("Correct!");

            StartCoroutine(DisplayCorrectChose(cellContrroller));            
        }
        else
        {
            Debug.Log("Incorrect");
            cellContrroller.CellEaseInBounce();
        }            
    }

    private IEnumerator DisplayCorrectChose(CellController cellContrroller)
    {
        cellContrroller.ContentBounce();
        _particleDisplayer.DisplayParticles(cellContrroller.gameObject);

        yield return new WaitForSeconds(_delayBeforeLevelChange);

        if (HasNextLevel()) LoadNextLevel();
    }        
}
