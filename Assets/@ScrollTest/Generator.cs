using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using System.Threading;

namespace Scroll
{
    /// <summary>
    /// ��ނ𐶐�����R���|�[�l���g
    /// </summary>
    public class Generator : MonoBehaviour
    {
        [SerializeField] GameObject[] _item;
        [SerializeField] Transform _leftBorder;
        [SerializeField] Transform _rightBorder;
        [SerializeField] Transform _itemParent;
        [SerializeField] int _distance;

        CancellationTokenSource _tokenSource;

        async UniTaskVoid Start()
        {
            _tokenSource = new CancellationTokenSource();

            await Generate(this.GetCancellationTokenOnDestroy());
        }

        async UniTask Generate(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                // ���������A��X�I�u�W�F�N�g�v�[���ɒ�����Β���
                int r = Random.Range(0, _item.Length);
                float posX = Random.Range(_leftBorder.position.x, _rightBorder.position.x);
                Instantiate(_item[r], new Vector3(posX, transform.position.y, 0), Quaternion.identity, _itemParent);

                await UniTask.Delay(_distance * 1000);
            }
        }

        void OnDestroy()
        {
            _tokenSource.Cancel();
        }
    }
}