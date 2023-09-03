using System;
using System.Collections;
using Cinemachine;
using DG.Tweening;
using EMA.InputEma;
using EMA.MyShortcuts;
using EMA.PatternClasses;
using UnityEngine;

namespace _Main.Scripts
{
    public class GameManager : MonoSingleton<GameManager>
    {
        [SerializeField] private SwerveInput swerveInput;

        [Header("Sens")][SerializeField] private float globalSensitivity;
        [Header("Camera")][SerializeField] private CinemachineVirtualCamera vCam1;
        [SerializeField] private CinemachineVirtualCamera vCam2;
        [SerializeField] private CinemachineVirtualCamera vCam3;
        [SerializeField] private CinemachineVirtualCamera vCam4;

        [Header("Fog")][SerializeField] private Renderer fog;

        public SwerveInput SwerveInput => swerveInput;

        public float GlobalSensitivity => globalSensitivity;

        public void ChangeCameraToVCam2()
        {
            vCam2.gameObject.SetActive(true);
            vCam2.m_Priority = 11;


            vCam1.gameObject.SetActive(false);
            vCam3.gameObject.SetActive(false);
            vCam4.gameObject.SetActive(false);

            vCam1.m_Priority = 9;
            vCam3.m_Priority = 9;
            vCam4.m_Priority = 9;
        }

        public void ChangeCameraToVCam1()
        {
            vCam1.gameObject.SetActive(true);
            vCam1.m_Priority = 11;

            vCam2.gameObject.SetActive(false);
            vCam3.gameObject.SetActive(false);
            vCam4.gameObject.SetActive(false);

            vCam2.m_Priority = 9;
            vCam3.m_Priority = 9;
            vCam4.m_Priority = 9;
        }

        public void ChangeCameraToVCam4()
        {
            vCam4.gameObject.SetActive(true);
            vCam4.m_Priority = 11;

            vCam1.gameObject.SetActive(false);
            vCam2.gameObject.SetActive(false);
            vCam3.gameObject.SetActive(false);

            vCam1.m_Priority = 9;
            vCam2.m_Priority = 9;
            vCam3.m_Priority = 9;

        }

        public void ChangeCameraToVCam4WDelay()
        {
            StartCoroutine(ChangeCameraVCam4Routine());
        }

        private IEnumerator ChangeCameraVCam4Routine()
        {
            yield return new WaitForSeconds(1f);
            ChangeCameraToVCam4();
        }

        public void ChangeCameraToVCam3()
        {
            vCam3.gameObject.SetActive(true);
            vCam3.m_Priority = 11;

            vCam1.gameObject.SetActive(false);
            vCam2.gameObject.SetActive(false);
            vCam4.gameObject.SetActive(false);

            vCam1.m_Priority = 9;
            vCam2.m_Priority = 9;
            vCam4.m_Priority = 9;
        }

        public void MakeFogFullyTransparent()
        {
            var _color = fog.material.GetColor("_Color");
            fog.material.DOColor(new Color(_color.r, _color.g, _color.b, 0f), "_Color", .5f)
                .SetEase(Ease.Linear);
        }

        public void MakeFogSolid()
        {
            var _color = fog.material.GetColor("_Color");
            fog.material.DOColor(new Color(_color.r, _color.g, _color.b, .54f), "_Color", .5f)
                .SetEase(Ease.Linear);
        }

        public void ShakeCamera()
        {
            MyShortcuts.ShakeCamera(vCam2, .3f, 1f);
        }

    }
}
