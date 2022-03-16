using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    public UnityEvent leftClicked;
    public UnityEvent upClicked;
    public UnityEvent rightClicked;
    public UnityEvent downClicked;
    public UnityEvent wClicked;
    public UnityEvent rClicked;
    public UnityEvent pClicked;
    public UnityEvent nClicked;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            leftClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            upClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            rightClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            downClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.W))
            wClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.R))
            rClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.P))
            pClicked.Invoke();
        else if (Input.GetKeyDown(KeyCode.N))
            nClicked.Invoke();
    }

}
