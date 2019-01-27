using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Weapon Interface
 * */
public interface IWeapon
{
    List<BaseStat> Stats { get; set; }
    void PerformAttack();
}

