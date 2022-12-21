using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using MessagePipe;
using VContainer;
using System;

/// <summary>
/// UŒ‚‚ğó‚¯‚½‚ç”j‰ó‚³‚ê‚é” 
/// </summary>
public class Box : MonoBehaviour
{
    [Inject] ISubscriber<AttackData> _subscriber;
    [SerializeField] GameObject _particle;

    IDisposable _disposable;

    void Start()
    {
        DisposableBagBuilder builder = DisposableBag.CreateBuilder();

        _subscriber.AsObservable()
                   .Where(attackData => attackData.IsHit(transform.position))
                   .Subscribe(_ => 
                   {
                       Instantiate(_particle, transform.position, Quaternion.identity);
                       Destroy(gameObject);
                   }).AddTo(builder);

        _disposable = builder.Build();
    }

    void OnDestroy()
    {
        _disposable.Dispose();
    }
}
