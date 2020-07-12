using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondValues : MonoBehaviour
{
    private int value = 1;
    private bool collected = false;

    public int Collect()
    {
        if (!collected) {
            collected = true;
            return value;
        } else {
            return 0;
        }
    }
}
