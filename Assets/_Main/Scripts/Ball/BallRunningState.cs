using _Main.Scripts.End;
using _Main.Scripts.Good_Obstacles;
using _Main.Scripts.Obstacle;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallRunningState : BallState
    {
        public BallRunningState(Rigidbody ballRb, Transform modelHolder, BallStatsManager ballStatsManager, BallStateManager ballStateManager) : base(ballRb, modelHolder, ballStatsManager, ballStateManager)
        {
        }

        public override void OnEnter()
        {
            modelHolder.transform.localRotation = Quaternion.identity;
            modelHolder.transform.DOLocalRotate(360f * Vector3.right, 2f, RotateMode.FastBeyond360)
                .SetLoops(-1).SetEase(Ease.Linear).SetId("rotate");

            GameManager.Instance.MakeFogSolid();
        }

        public override void OnExit()
        {
            DOTween.Kill("rotate");
        }

        public override void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out ObstacleTag _obstacle)) {
                ScaleTheBall(_obstacle.Multiplier);
            }
            
            if (other.rigidbody == null)
                return;

            if (other.rigidbody.TryGetComponent(out RampPlatform _ramp)) {
                _ramp.jumpEvent.AddListener(ChangeStateToJumpingState);
            }
        }

        public override void OnCollisionExit(Collision other)
        {
            if (other.rigidbody == null)
                return;

            if (other.rigidbody.TryGetComponent(out RampPlatform _ramp)) {
                _ramp.jumpEvent.RemoveListener(ChangeStateToJumpingState);
            }
        }

        private void ChangeStateToJumpingState(Vector3 jumpPos)
        {
            ballStateManager.ChangeTheState(new BallJumpingState(ballRb, modelHolder, ballStatsManager, ballStateManager, jumpPos));
        }


        public override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Coin>()) {
                var _obj = ObjectPools.Instance.CoinFxPool.GetPooledObject();
                _obj.transform.position = other.transform.parent.parent.position;
                _obj.GetComponent<ParticleSystem>().Play();

                UIManager.Instance.uiCoinGoToIcon.GenerateCoinUIAndMoveIt(_obj.transform.position);

                Object.Destroy(other.transform.parent.parent.gameObject);

            }
            
            if (other.GetComponent<EndPlatformTag>()) {
                ballStateManager.ChangeTheState(new BallOnEndPlatform(ballRb, modelHolder, ballStatsManager, ballStateManager));
            }

            if (other.TryGetComponent(out GoodObstacleMono _goodObstacle)) {
                if(!_goodObstacle.isObjectLocked)
                    return;
                ScaleInAGoodWay(_goodObstacle.ballSkin, _goodObstacle.goodObstacleType);
            }
        }

        private void ScaleInAGoodWay(BallSkin ballSkin, GoodObstacleType goodObstacleType)
        {
            DOTween.Kill("ScaleBigger");
            ballRb.transform.DOScale((ballRb.transform.localScale.x + .2f) * Vector3.one, .3f).SetEase(Ease.Linear).SetDelay(1.5f)
                .SetId("ScaleBigger");

            ballStateManager.ballFX.StartAllFxForGoodObstacles(ballSkin, goodObstacleType);
        }

        public override void OnTriggerStay(Collider other)
        {
            if (other.gameObject.TryGetComponent(out ObstacleTag _obstacle)) {
                ScaleTheBall(_obstacle.Multiplier);
            }
        }

        public override void OnCollisionStay(Collision other)
        {
            if (other.gameObject.TryGetComponent(out ObstacleTag _obstacle)) {
                ScaleTheBall(_obstacle.Multiplier);
            }
        }

        public override void OnParticleCollision(GameObject other)
        {
            if (other.gameObject.TryGetComponent(out ObstacleTag _obstacle)) {
                ScaleTheBall(_obstacle.Multiplier);
            }
        }

        public override void OnFixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            var _vel = ballRb.velocity;
            _vel.z = ballStatsManager.BallCurrentStats.MoveSpeed * Time.deltaTime;
            ballRb.velocity = _vel;
        }

        private void ScaleTheBall(float scaleMultiplier)
        {
            DOTween.Kill("ScaleBigger");
            var _multiplier = -5f * scaleMultiplier;

            var _scale = ballRb.transform.localScale.x;
            _scale += Time.deltaTime * .05f * _multiplier;
            _scale = Mathf.Clamp(_scale, .5f, 2.5f);

            ballRb.transform.localScale = _scale * Vector3.one;
        }

    }
}
