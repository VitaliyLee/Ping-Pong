using System.Collections.Generic;
using UnityEngine;

public static class BallPooller
{
    private static List<Animator> effectList;
    private static int index = 0;

    public static void Warm(Animator effectAnimator, int count)
    {
        effectList = new List<Animator>();

        for (int i = 0; i < count; i++)
        {
            Animator effect = Object.Instantiate(effectAnimator);
            effect.gameObject.SetActive(false);
            effectList.Add(effect);
        }
    }

    public static void SetPosition(Vector2 effectPosition)
    {
        index %= effectList.Count;

        effectList[index].gameObject.SetActive(true);

        effectList[index].transform.position = effectPosition;
        effectList[index].SetTrigger("play");

        index++;
    }
}
