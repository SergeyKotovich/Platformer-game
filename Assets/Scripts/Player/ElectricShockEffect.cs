using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Player
{
    public class ElectricShockEffect : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float duration = 0.1f;
        [SerializeField] private int flashCount = 10;
        
        public async UniTask StartFlashEffect()
        {
            for (int i = 0; i < flashCount; i++)
            {
                await spriteRenderer.DOColor(Color.black, duration).AsyncWaitForCompletion();


                await spriteRenderer.DOColor(Color.yellow, duration).AsyncWaitForCompletion();
            }


            await spriteRenderer.DOColor(Color.white, duration).AsyncWaitForCompletion();
        }
    }
}