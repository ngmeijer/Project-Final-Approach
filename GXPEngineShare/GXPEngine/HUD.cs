using System;
using GXPEngine;

public class HUD : GameObject
{
    public Sprite _rightButton;
    public Sprite _leftButton;
    public Sprite _lowerButton;

    public bool clickedBack { get; set; }
    public bool clickedLeft { get; set; }
    public bool clickedRight { get; set; }

    public bool mainAreaActive { get; set; }

    public bool showHUD { get; set; }

    public HUD()
    {
        _rightButton = new Sprite("RightButton.png");
        AddChild(_rightButton);
        _rightButton.x = 1793;
        _rightButton.y = 416;

        _leftButton = new Sprite("LeftButton.png");
        AddChild(_leftButton);
        _leftButton.x = 15;
        _leftButton.y = 416;

        _lowerButton = new Sprite("LowerButton.png");
        AddChild(_lowerButton);
        _lowerButton.x = 560;
        _lowerButton.y = 966;
    }

    private void Update()
    {
        CheckForBackRequest();
    }

    private void CheckForBackRequest()
    {
        if (_lowerButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedBack = true;
                mainAreaActive = true;
            }
        }

        if (_leftButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedLeft = true;
            }
        }

        if (_rightButton.HitTestPoint(Input.mouseX, Input.mouseY))
        {
            if (Input.GetMouseButtonDown(0))
            {
                clickedRight = true;
            }
        }
    }
}
