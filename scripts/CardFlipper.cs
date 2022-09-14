using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : MonoBehaviour
{
    private Sprite CardFront;
    private Sprite CardBack;
    public Sprite spiderCardFront;
    public Sprite spiderCardBack;
    public Sprite dragonFlyCardFront;
    public Sprite dragonFlyCardBack;

    public void SetSprite (string type)
    {
        if (type == "dragonFly")
        {
            gameObject.GetComponent<Image>().sprite = dragonFlyCardFront;
            CardFront = dragonFlyCardFront;
            CardBack = dragonFlyCardBack;
        } else if (type == "spider")
        {
            gameObject.GetComponent<Image>().sprite = spiderCardFront;
            CardFront = spiderCardFront;
            CardBack = spiderCardBack;
        }
    }
    public void Flip()
    {
        if(gameObject.GetComponent<Image>().sprite == CardFront)
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
        } else
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
    }
}
