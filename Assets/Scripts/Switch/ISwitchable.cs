using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スイッチのオンオフで呼ばれる処理のインターフェース
/// </summary>
public interface ISwitchable
{
    public void OnSwitchOn();
    public void OnSwitchOff();
}
