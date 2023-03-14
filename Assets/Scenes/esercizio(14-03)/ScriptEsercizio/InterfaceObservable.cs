using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InterfaceObservable 
{
    void AddObserver(InterfaceObserver observer);
    void RemoveObserver(InterfaceObserver observer);
}
