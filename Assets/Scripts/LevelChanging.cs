using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{        
    [SerializeField] private GoalTextController _goalTextController;
    [SerializeField] private LoadingPanelController _loadingPanelController;
    [SerializeField] private RestartButtonController _restartButtonController;
    [SerializeField] private float _delayBeforeLevelChange;

    private int _currentLevel = 1;
    private bool _inputAllowed = false;
    
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
            _goalTextController.GoalTextFadeIn();
        } 

        _currentLevel++;
        _inputAllowed = true;
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
        _goalTextController.SetGoalText($"Find {_currentGoal.Identifier}");
    }

    private void ChooseCard(CellController cellContrroller)
    {
        if (!_inputAllowed) return;

        if (cellContrroller.Card.Identifier == _currentGoal.Identifier)
        {            
            StartCoroutine(DisplayCorrectChose(cellContrroller));
        }
        else
        {            
            cellContrroller.CellEaseInBounce();
        }            
    }

    private IEnumerator DisplayCorrectChose(CellController cellContrroller)
    {
        _inputAllowed = false;
        cellContrroller.ContentBounce();
        _particleDisplayer.DisplayParticles(cellContrroller.gameObject);

        yield return new WaitForSeconds(_delayBeforeLevelChange);

        if (HasNextLevel()) LoadNextLevel();
        else GameOver();
    }

    private void GameOver()
    {
        _loadingPanelController.EndGameLoading();
        _restartButtonController.SetVisibility(true);
    }

    public void Restart()
    {
        _restartButtonController.SetVisibility(false);
        _currentLevel = 1;
        _selectedGoals.Clear();
        LoadNextLevel();
        _loadingPanelController.StartGameLoading();        
    }
}
