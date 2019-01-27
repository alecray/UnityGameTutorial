using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * BaseStat class
 */
public class BaseStat
{
    public List<StatBonus> BaseAdditives { get; set; }
    public int BaseValue { get; set; }
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }
    
    public void RemoveStatBonus(StatBonus statBonus)
    {
        // go thru base additives list, find value that we passed it, apply result to value it finds
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);
        this.FinalValue += BaseValue;
        return FinalValue;
    }
}
