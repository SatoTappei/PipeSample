using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stage3
{
    /// <summary>
    /// 敵の情報を表示するPresenter
    /// </summary>
    public class EnemyInfoPresenter : MonoBehaviour
    {
        [Header("敵の情報:Model")]
        [SerializeField] BreedSO _breed;
        [SerializeField] string _name;
        [Header("敵の情報を表示するテキストUI:View")]
        [SerializeField] Text _breedView;
        [SerializeField] Text _nameView;

        void Awake()
        {
            SetCharacterInfo();
        }

        /// <summary>UIにキャラクターの情報を表示する</summary>
        void SetCharacterInfo()
        {
            _breedView.text = _breed.Attribute;
            _nameView.text = _name;
        }
    }

}