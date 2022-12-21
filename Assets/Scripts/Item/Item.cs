using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using MessagePipe;
using UniRx;
using UniRx.Triggers;

/// <summary>
/// プレイヤーが獲得するアイテム
/// </summary>
public class Item : MonoBehaviour
{
    [Inject] IPublisher<string> _publisher;
    [SerializeField] string _name;

    void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Subscribe(c =>
            {
                if (c.gameObject.CompareTag("Player"))
                {
                    _publisher.Publish(_name);
                    Destroy(gameObject);
                }
            });
    }
}
