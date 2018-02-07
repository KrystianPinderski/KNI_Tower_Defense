using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  EInterface  {

    void OnEnter(Control_Enemy enemy);
    void OnTriggerEnter();
    void OnUpdate();
    void OnExit();
	
}
