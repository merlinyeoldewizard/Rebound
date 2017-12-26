using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Tooltips : MonoBehaviour, IEventSystemHandler {

    public GameObject panel;
    public RectTransform panelRect;
    public RectTransform rectTransform;
    public Text tooltip;

    //Try keep this in alphabetical order (for tidyness' sake).
    private string acceleratorTooltip = "Increases the speed of a ball whenever it bounces off a player. Changing the speed multiplier will affect the rate at which balls will gain speed.";
    private string ballCountTooltip = "Changes the number of balls in play.";
    private string ballSizeTooltip = "Changes the size of all of the balls.";
    private string ballSpeedTooltip = "Changes the initial speed of all balls in play.";
    private string hitFactorTooltip = "Affects how the ball bounces off the player. A higher hit factor will make the ball bounce off the player at steeper angles, whereas a lower hit factor will make the ball bounce at a more shallow angle.";
    private string playerSpeedTooltip = "Changes the speed the players move at.";
    private string scoreLimitTooltip = "Changes the score a player needs to win the game.";


    public void Start()
    {
        panel.SetActive(false);
    }
    public void onPointEnter(string tooltipName)
    {
        panel.SetActive(true);

        if (tooltipName == "UIAcceleratorMode")
            changeTooltip(acceleratorTooltip);
        if (tooltipName == "UIBallSizeMode")
            changeTooltip(ballSizeTooltip);
        if (tooltipName == "UIBallSpeed")
            changeTooltip(ballSpeedTooltip);
        if (tooltipName == "UIHitFactor")
            changeTooltip(hitFactorTooltip);
        if (tooltipName == "UIPlayerSpeed")
            changeTooltip(playerSpeedTooltip);
        if (tooltipName == "UIScoreLimit")
            changeTooltip(scoreLimitTooltip);
        if (tooltipName == "UIBallCount")
            changeTooltip(ballCountTooltip);
    }


    //Affects panel size and tooltip text being displayed.
    private void LateUpdate()
    {
        panelRect.sizeDelta = new Vector2(rectTransform.sizeDelta.x + 10, rectTransform.sizeDelta.y + 10);
    }

    public void onPointExit()
    {
        panel.SetActive(false);
    }

    public void changeTooltip(string passedToolTip)
    {
        tooltip.text = passedToolTip;
            panel.transform.position = Input.mousePosition + new Vector3(rectTransform.sizeDelta.x, -rectTransform.sizeDelta.y / 2, 0);
            tooltip.transform.position = Input.mousePosition + new Vector3(rectTransform.sizeDelta.x / 1.5F, -rectTransform.sizeDelta.y / 2, 0);
    }
}
