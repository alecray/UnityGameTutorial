using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * StatBonus Class
 */
public class StatBonus 
{
    public int BonusValue { get; set; }

    public StatBonus(int bonusValue)
    {
        this.BonusValue = bonusValue;
        Debug.Log("New stat bonus initiated.");

    }
}
