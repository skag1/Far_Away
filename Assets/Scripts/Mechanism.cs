using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Mechanism : MonoBehaviour
{
    abstract public void Activate();
    abstract public void Deactivate();

    public bool isActivated;
}
