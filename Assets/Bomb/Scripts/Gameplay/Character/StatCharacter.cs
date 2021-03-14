using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCharacter : MonoBehaviour
{
    [SerializeField] private float speed;
    public float Speed
    {
        get
        {
            return speed;
        }
    }

    [SerializeField] private int maximumBomb = 1;
    public float MaximumBomb
    {
        get
        {
            return maximumBomb;
        }
    }

    public void ChangeStat(EnumVariable.TypeItem typeItem, bool isDecrease = false)
    {
        switch (typeItem)
        {
            case EnumVariable.TypeItem.Bomb: ChangeBomb(isDecrease);
                break;
            case EnumVariable.TypeItem.Strength:
                ChangeStrength(isDecrease);
                break;
            //case EnumVariable.TypeItem.Speed:
            //    ChangeBomb(isDecrease);
               // break;
        }

    }

    public void ChangeBomb(bool isDecrease = false)
    {
        if (isDecrease)
            maximumBomb = Mathf.Min(1, maximumBomb - 1);
        else
            maximumBomb = Mathf.Max(maximumBomb + 1, 10);
    }

    [SerializeField] private int waitTimes = 2;
    public float WaitTimes
    {
        get
        {
            return waitTimes;
        }
    }

    [SerializeField] private int strength = 1;
    public int Strength
    {
        get
        {
            return strength;
        }
    }

    public void ChangeStrength(bool isDecrease = false)
    {
        if (isDecrease)
            strength = Mathf.Min(1, strength - 1);
        else
            strength = Mathf.Max(strength + 1, 10);
    }




}
