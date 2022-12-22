using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (GameManager.Instance.IsGame)
            {
                ScoreManager.Instance.DecreaseScore(10);
                GameManager.Instance.GameEnd();
            }
        }
        //SceneLoader.Instance.FadeIn("SampleScene");
    }
}
