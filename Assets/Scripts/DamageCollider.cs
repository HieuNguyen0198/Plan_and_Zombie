﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollither)
    {
        FindObjectOfType<LiveDisplay>().TakeLife();
        Destroy(otherCollither.gameObject);
    }
}
