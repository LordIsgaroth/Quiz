using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ILevelCreation))]
public class LevelChanging : MonoBehaviour
{        
    private int _currentLevel = 2;
    private ILevelCreation _levelCreator;
    
    void Start()
    {
        _levelCreator = GetComponent<ILevelCreation>();
        _levelCreator.CreateLevel(_currentLevel);
    }       
}
