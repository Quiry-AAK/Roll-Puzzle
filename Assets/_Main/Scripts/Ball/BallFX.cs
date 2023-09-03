using System;
using System.Collections.Generic;
using _Main.Scripts.Good_Obstacles;
using DG.Tweening;
using UnityEngine;

namespace _Main.Scripts.Ball
{
    public class BallFX : MonoBehaviour
    {
        [SerializeField] private GameObject ballJumpFx;
        [SerializeField] private GameObject ballEndFx;
        [SerializeField] private GameObject endConfettiFx;

        [Header("For Good Obstacles")][SerializeField] private GameObject radialFillObject;
        [SerializeField] private Material radialFillMat;
        [SerializeField] private GameObject mainBall;

        [SerializeField] private List<BallSkinStruct> ballSkinStructs;

        private GameObject newBall;
        private GameObject oldBall;

        private void Start()
        {
            oldBall = mainBall;
        }

        public void SetBallJumpFxActiveness(bool value)
        {
            ballJumpFx.SetActive(value);
        }

        public void SetBallEndFxActiveness(bool value)
        {
            ballEndFx.SetActive(value);
        }

        public void CallEndConfettiFx()
        {
            endConfettiFx.SetActive(true);
        }

        public void StartAllFxForGoodObstacles(BallSkin ballSkin, GoodObstacleType goodObstacleType)
        {
            var _scOb = GetScOb(ballSkin);
            radialFillObject.SetActive(true);
            radialFillObject.transform.localScale = Vector3.one;
            radialFillObject.transform.rotation = Quaternion.Euler(GetNewAngleOfRadialFillerObject(goodObstacleType));

            radialFillMat.SetTexture("_MainTex", _scOb.texture);
            radialFillMat.SetFloat("_FillAmount", 0f);
            
            newBall = _scOb.ball;
            radialFillMat.DOFloat(1f, "_FillAmount", 1f).SetEase(Ease.Linear).OnComplete(EndAnimationOfRadialFillMaterial);
        }

        private BallSkinStruct GetScOb(BallSkin ballSkin)
        {
            foreach (var _ballSkinStruct in ballSkinStructs) {
                if (_ballSkinStruct.ballSkin == ballSkin)
                    return _ballSkinStruct;
            }
            Debug.LogError("Not Valid Ball Skin !");
            return ballSkinStructs[0];
        }

        private void EndAnimationOfRadialFillMaterial()
        {
            oldBall.SetActive(false);
            newBall.SetActive(true);
            oldBall = newBall;
            radialFillObject.transform.DOScale(Vector3.one * .9f, 1f).SetEase(Ease.Linear).OnComplete(SetPassiveRadialFillerObject);
        }

        private Vector3 GetNewAngleOfRadialFillerObject(GoodObstacleType goodObstacleType)
        {
            switch (goodObstacleType) {

                case GoodObstacleType.Pipe:
                    return new Vector3(180f, 180f, 0f);
                case GoodObstacleType.Pool:
                    return new Vector3(0f, 180f, 0f);
            }

            Debug.LogError("Not Valid Good Obstacle Type !");
            return Vector3.zero;
        }

        private void SetPassiveRadialFillerObject()
        {
            radialFillObject.SetActive(false);
        }
    }
}
