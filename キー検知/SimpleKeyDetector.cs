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
    public class KeysActionPair
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
    [SerializeField] KeysActionPair[] keyActionPairs = new KeysActionPair[0];
    private void Update()
    {
        foreach (var item in OnGetKey)
        {
            if (Input.GetKey(item.Key))
            {
                item.Run();
            }
        }
    }
}
