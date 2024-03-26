using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperianceManager : MonoBehaviour
{
    public static ExperianceManager Instance;
    
    public delegate void ExperianceChangeHandler(int amount);
    public event ExperianceChangeHandler OnExperianceChange;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    

    public void AddExperience(int amount)
    {
        OnExperianceChange?.Invoke(amount);
    }
}
