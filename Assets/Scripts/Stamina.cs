using System;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    [SerializeField]
    private float totalStamina;
    [SerializeField]
    private float actualStamina;

    [SerializeField]
    private PlayerMove playerMove;

    private void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        actualStamina = totalStamina;
    }
    private void Update()
    {
        EnergyReduction();
        SprintToggle();
        EnergyRecharge();
    }
    private void EnergyReduction()
    {
        if (!playerMove.isSprinting)
        {
            return;
        }

        else if (playerMove.isSprinting)
        {
            actualStamina -= Time.deltaTime;
        }
    }

    private void SprintToggle()
    {
        if (actualStamina <= 0)
        {
            playerMove.canRun = false;
            playerMove.isSprinting = false;
        }

        else if (actualStamina == totalStamina)
        {
            playerMove.canRun = true;
        }


    }

    private void EnergyRecharge()
    {
        if (playerMove.canRun)
        {
            return ;
        }
        else if (!playerMove.canRun)
        {
            actualStamina += Time.deltaTime;
            actualStamina = Math.Clamp(actualStamina, 0, totalStamina);
        }
    }
}
