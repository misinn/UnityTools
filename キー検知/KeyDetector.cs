///
/// キー入力を検知し、対応するメソッドを実行する
///

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KeyDetector : MonoBehaviour
{
    [Serializable]
    public class KeyActionPair
    {
        public KeyCode Key => key;
        public UnityEvent UnityEvent => unityEvent;
        [SerializeField] KeyCode key;
        [SerializeField] UnityEvent unityEvent;
        public void Run()
        {
            unityEvent.Invoke();
        }
    }
    [SerializeField] KeyActionPair[] OnGetKey = new KeyActionPair[0];
    [SerializeField] KeyActionPair[] OnKeyDown = new KeyActionPair[0];
    [SerializeField] KeyActionPair[] OnKeyUp = new KeyActionPair[0];
    private void Update()
    {
        foreach (var item in OnGetKey)
        {
            if (Input.GetKey(item.Key))
            {
                item.Run();
            }
        }
        foreach (var item in OnKeyDown)
        {
            if (Input.GetKey(item.Key))
            {
                item.Run();
            }
        }
        foreach (var item in OnKeyUp)
        {
            if (Input.GetKey(item.Key))
            {
                item.Run();
            }
        }
    }
}
