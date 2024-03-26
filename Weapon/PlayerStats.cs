using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.Collections;

public class PlayerStats : MonoBehaviour
{
    //¬ыносливость
    public Slider staminaBar;

    public static PlayerStats instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    //здоровье
    public int health;

    //повышение уровн€
    [SerializeField] int currentHealth, maxHealth, 
                         currentExperience, maxExperience, 
                         currentStamina, maxStamina,
                         currentLevel, 
                         remainderExp, remainderNewExperience;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    //повышение уровн€
    private void OnEnable()
    {
        ExperienceManager.Instance.OnExperienceChange += HandleExperienceChange;
    }

    private void OnDisable()
    {
        ExperienceManager.Instance.OnExperienceChange -= HandleExperienceChange;
    }

    private void HandleExperienceChange(int newExperience)
    {
        currentExperience += newExperience;
        remainderNewExperience = newExperience;
    }

    private void LevelUp()
    {
        maxHealth += 100;
        currentHealth = maxHealth;

        maxStamina += 50;
        currentStamina = maxStamina;

        currentLevel++;

        if (remainderNewExperience > remainderExp)
        {
            
            remainderNewExperience -= remainderExp;
            currentExperience = 0;
            currentExperience += remainderNewExperience;
        }
        else
        {
        remainderNewExperience = 0;
        currentExperience = 0;
        }

        maxExperience += 100 + (20 * currentLevel);

    }

    //¬ыносливость
    public void UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
            StopCoroutine(regen);

            regen = StartCoroutine(RegenStamina());
        }
        else
        {
            Debug.Log("no stamina");
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }

    //смерть персонажа
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (currentExperience >= maxExperience)
        {
            LevelUp();
        }
        remainderExp = maxExperience - currentExperience;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
