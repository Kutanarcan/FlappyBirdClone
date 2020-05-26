using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject priceSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagHelper.PLAYER_TAG))
        {
            GameObject tmp = Instantiate(priceSound);
            Destroy(tmp.gameObject, 2f);

            GameManager.Instance.Score++;
            UIEvents.OnScoreChangedFunction();
        }
    }
}
