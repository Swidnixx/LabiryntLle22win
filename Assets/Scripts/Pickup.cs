﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
    public virtual void Pick()
    {
        Destroy(this.gameObject);
        Debug.Log("Podniesiono Pickup");
    }
}
