using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyColor
{ 
    Red,
    Green, 
    Gold
}

public class Key : Pickup
{
    public KeyColor keyColor;

    public override void Pick()
    {
        GameManager.Instance.AddKey(keyColor);
        base.Pick();
    }
}
