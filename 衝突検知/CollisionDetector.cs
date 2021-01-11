using System;
using UnityEngine;
using UnityEngine.Events;
//Colliderがアタッチされる。
[RequireComponent(typeof(Collider))] 
public class CollisionDetector : MonoBehaviour
{
    //ヒエラルギーウィンドウで実行したいイベントを指定
    [SerializeField] TriggerEvent onTriggerEnter = new TriggerEvent();
    [SerializeField] TriggerEvent onTriggerStay = new TriggerEvent();

    //アタッチしたオブジェクトがトリガーに入った時,イベントを実行
    private void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke(other);
    }
    //トリガーの中にいる時
    private void OnTriggerStay(Collider other)
    {
        onTriggerStay.Invoke(other);
    }

    public class TriggerEvent : UnityEvent<Collider> { }
}
