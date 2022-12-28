using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Stage3
{
    /// <summary>
    /// �G�̏���\������Presenter
    /// </summary>
    public class EnemyInfoPresenter : MonoBehaviour
    {
        [Header("�G�̏��:Model")]
        [SerializeField] BreedSO _breed;
        [SerializeField] string _name;
        [Header("�G�̏���\������e�L�X�gUI:View")]
        [SerializeField] Text _breedView;
        [SerializeField] Text _nameView;

        void Awake()
        {
            SetCharacterInfo();
        }

        /// <summary>UI�ɃL�����N�^�[�̏���\������</summary>
        void SetCharacterInfo()
        {
            _breedView.text = _breed.Attribute;
            _nameView.text = _name;
        }
    }

}