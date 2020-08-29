using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public event Action beforeChangeUniverse;
    
    public void BeforeChangeUniverse()
    {
        beforeChangeUniverse?.Invoke();
        
    }

    public event Action afterChangeUniverse;
    public void AfterChangeUniverse()
    {
        afterChangeUniverse?.Invoke();
    }
}
