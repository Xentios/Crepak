using UnityEngine;

public class CharacterScoreHandler : MonoBehaviour
{
    [SerializeField]
    private float passiveIncomeTimer = 10f;
    private float internalTimer= 0f;


    [SerializeField]
    private FloatReference currency;

    [SerializeField]
    private GameEvent currencyUpdated;

    private void Start()
    {
        currency.Value = 0;
    }

    private void Update()
    {
        internalTimer += Time.deltaTime;
        if (internalTimer > passiveIncomeTimer)
        {
            internalTimer = 0f;
            currency.Value++;
            currencyUpdated.TriggerEvent();
        }
    }

    public void EnemyDied()
    {
        currency.Value+=10;
        currencyUpdated.TriggerEvent();
    }
}
