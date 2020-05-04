using System;
using GXPEngine;

public class Menu : GameObject
{
    private StartButton _startButton;
    private Environment _environment;

    public bool levelStarted { get; set; }

    public Menu()
    {
        _startButton = new StartButton();
        AddChild(_startButton);

        _startButton.SetXY(game.width / 2 - _startButton.width / 2, game.height / 2 - _startButton.height / 2);
    }
    
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_startButton.HitTestPoint(Input.mouseX, Input.mouseY))
            {
                levelStarted = true;
            }
        }
    }
}
