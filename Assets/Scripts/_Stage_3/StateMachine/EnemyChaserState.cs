using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stage3
{
    using State = StateMachine.State;

    /// <summary>
    /// EnemyChaser�N���X����State�̋L�q�̕�����������
    /// </summary>
    public partial class EnemyChaser : MonoBehaviour
    {
        /// <summary>
        /// �A�C�h����Ԃ̃X�e�[�g
        /// </summary>
        class StateIdle : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            readonly float Range = 5f;

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // �m���ł��낤���ԂɑJ�ڂ���

                // �v���C���[�Ƃ̋��������ȉ��Ȃ�ǐՏ�ԂɑJ�ڂ���
                if ((Target.position - Actor.transform.position).sqrMagnitude < Range)
                {
                    StateMachine.Transition((int)StateID.Chase);
                    return;
                }
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// ���낤���Ԃ̃X�e�[�g
        /// </summary>
        class StateWander : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // ���낤�낪�I�������A�C�h����ԂɑJ�ڂ���
                // �i������������W�����v������
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// �v���C���[��ǐՂ��Ă����Ԃ̃X�e�[�g
        /// </summary>
        class StateChase : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            readonly float Range = 5f;
            readonly float Speed = 1;

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // �v���C���[�Ƃ̋��������ȏ㗣��Ă�����A�C�h����ԂɑJ�ڂ���
                if ((Target.position - Actor.transform.position).sqrMagnitude > Range)
                {
                    StateMachine.Transition((int)StateID.Idle);
                    return;
                }

                // �v���C���[�̕����ɉ����ĉE���Ɉړ�����
                float dir = Mathf.Sign(Target.position.x - Actor.transform.position.x);
                Rb.velocity = Vector2.right * dir * Speed;
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// �W�����v���Ă����Ԃ̃X�e�[�g
        /// </summary>
        class StateJump : State, IMoveChaseable
        {
            public GameObject Actor { get; set; }
            public Transform Target { get; set; }
            public Rigidbody2D Rb { get; set; }

            public override void SetField(params Object[] objs)
            {
                Actor = objs[0] as GameObject;
                Target = objs[1] as Transform;
                Rb = objs[2] as Rigidbody2D;
            }

            public override void OnEnter()
            {

            }

            public override void OnUpdate()
            {
                // �W�����v��̓A�C�h����ԂɑJ�ڂ���
            }

            public override void OnExit()
            {

            }
        }

        /// <summary>
        /// ����ȏ㓮�����Ȃ��ꍇ�ɑJ�ڂ����X�e�[�g
        /// </summary>
        class StateEnd : State
        {
            public override void SetField(params Object[] objs) { }

            public override void OnEnter()
            {
                Debug.Log("���S");
            }

            public override void OnUpdate() { }
            public override void OnExit() { }
        }
    }
}
