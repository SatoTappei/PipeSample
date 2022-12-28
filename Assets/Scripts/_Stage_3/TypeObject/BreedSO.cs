using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    /// <summary>
    /// �^�I�u�W�F�N�g�Ŏ�������G�̌n����\��SO
    /// </summary>
    [CreateAssetMenu(menuName = "Stage_3/BreedSO")]
    public class BreedSO : ScriptableObject
    {
        [Header("�e�n��")]
        [SerializeField] BreedSO _parent;
        [Header("���̌n���̑���")]
        [SerializeField] string _attribute;

        /// <summary>�e�n��������ꍇ�͍ċA�I�ɐe��Type�v���p�e�B���Ăяo��</summary>
        public string Attribute { get => _attribute ?? _parent.Attribute; }
    }
}
