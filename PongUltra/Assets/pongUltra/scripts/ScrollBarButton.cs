using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarButton : MonoBehaviour {

    public Button scrollUp;
    public Button scrollDown;
    public ScrollRect scrollRect;

    public void scroll(Button thisbutton)
    {
        if (thisbutton == scrollUp)
            scrollRect.verticalNormalizedPosition = scrollRect.verticalNormalizedPosition + 0.05F;
        else if (thisbutton == scrollDown)
            scrollRect.verticalNormalizedPosition = scrollRect.verticalNormalizedPosition - 0.05F;
    }
}
