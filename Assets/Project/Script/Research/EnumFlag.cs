using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flag = System.UInt64;

public class EnumFlag
{
    public static bool Is(Flag flag, Flag enumeration)
    {
        bool result = false;
        Flag n;

        for (byte i = 0; i < 64; i++)
        {
            n = 1UL << i;
            if ((enumeration & n) != 0UL)
                if ((flag & n) != 0UL)
                    result = true;
                else
                    return false;
        }

        return result;
    }

}

public class Item : EnumFlag
{
    public const Flag Weapon = 1UL << 0;
    public const Flag OneHand = Weapon | 1UL << 1;
    public const Flag TwoHand = Weapon | 1UL << 2;
    public const Flag Iron = 1UL << 3;
    public const Flag Armor = 1UL << 4;
}

public class temp2 : MonoBehaviour
{
    void Start()
    {
        Flag Sword = Item.OneHand | Item.Iron;

        Debug.Log("Weapon: " + Item.Is(Sword, Item.Weapon)); //Inherit Weapon from OneHand
        Debug.Log("OneHand: " + Item.Is(Sword, Item.OneHand));
        Debug.Log("TwoHand: " + Item.Is(Sword, Item.TwoHand));
        Debug.Log("Iron: " + Item.Is(Sword, Item.Iron));
        Debug.Log("Armor: " + Item.Is(Sword, Item.Armor));
    }
}
