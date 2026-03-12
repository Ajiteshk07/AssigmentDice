using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpiritCard
{
    public string cardName;
    public int bonusPoints;
    public int multiplierBonus;

    public SpiritCard(string name, int points, int multiplier)
    {
        cardName = name;
        bonusPoints = points;
        multiplierBonus = multiplier;
    }
}