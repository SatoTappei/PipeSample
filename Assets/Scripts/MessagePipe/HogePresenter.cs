using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

/// <summary>
/// エントリーポイント
/// MVPパターンのPresenter
/// </summary>
public class HogePresenter : IStartable
{
    readonly ItemData _model;
    readonly HogeView _hogeView;

    public HogePresenter(ItemData data, HogeView view)
    {
        _model = data;
        _hogeView = view;
    }

    public void Start()
    {
        Debug.Log("すたーと");

        // Viewのロジックはここに書いてある(制御の反転)
        _hogeView.Button.onClick.AddListener(() =>
        {
            //_model.Hello();
            Debug.Log(_model);
        });
    }
}

public class HelloWorldModel
{
    public void Hello()
    {
        Debug.Log("Hello");
    }
}