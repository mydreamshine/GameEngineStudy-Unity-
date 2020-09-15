using System;
using System.Collections;
using System.Collections.Generic;
using KPU.Manager;
using UnityEngine;

namespace Rewind.Rewind
{
    public class RewindableObject : MonoBehaviour
    {
        private bool _isRecordOn;
        private IList<RewindRecord> _rewindRecords;
        private Rigidbody _rigidbody;

        private Coroutine _rewindRoutine;

        private void Start()
        {
            EventManager.On("rewind", OnRewind);
            EventManager.On("play", OnPlay);
        }

        private void OnPlay(object obj)
        {
            _isRecordOn = true;
            
            _rewindRecords.Clear();
            
            if(_rewindRoutine != null)
                StopCoroutine(_rewindRoutine);
            
            _rigidbody.isKinematic = false;
        }

        private void OnRewind(object obj)
        {
            _isRecordOn = false;
            
            // Unity Cycle과는 별개로 독자적인 루틴을 생성
            _rewindRoutine = StartCoroutine(RewindRoutine());
        }

        private IEnumerator RewindRoutine()
        {
            foreach (var record in _rewindRecords)
            {
                // isKinematic: 물리 시뮬레이션을 쓰지 않고
                // 직접 Transform을 변경하는 경우.
                _rigidbody.isKinematic = true;
                
                transform.position = record.Position;
                transform.rotation = record.Rotation;
                _rigidbody.velocity = record.Velocity;
                _rigidbody.angularVelocity = record.AngularVelocity;
                // 반복의 주기를 사용할 때는 yield return을 사용
                // WaitForFixedUpdate(): FixedUpdate만큼 기다림
                // FixedUpdate: 1/50초만큼 기다림 (Unity에서 FixedUpdate는 1/50초로 기본 설정이 되어있다) 
                yield return new WaitForFixedUpdate();
            }
        }

        private void Awake()
        {
            _isRecordOn = true;
            _rewindRecords = new List<RewindRecord>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_isRecordOn)
            {
                _rewindRecords.Insert(0,new RewindRecord
                {
                    Position = transform.position,
                    Rotation = transform.rotation,
                    Velocity = _rigidbody.velocity,
                    AngularVelocity = _rigidbody.angularVelocity
                });
            }
        }
    }
}
