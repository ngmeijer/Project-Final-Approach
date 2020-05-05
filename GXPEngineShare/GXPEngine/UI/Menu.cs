using System;
using GXPEngine;

public class Menu : GameObject
{
    #region Variables

    //Script references
    private StartButton _startButton;

    //Bools
    public bool clickedStart { get; private set; }
    public bool destroyMenu { get; set; }

    public bool levelStarted { get; set; }

    //Sprites

    #endregion

    #region Constructor & Update method

    public Menu() : base()
    {
        _startButton = new StartButton();
        AddChild(_startButton);
        _startButton.x = (game.width / 2) - (_startButton.width / 2);
        _startButton.y = 200;
    }

    private void Update()
    {
        ManageButtonVisibility();
        CheckStartInput();
    }

    #endregion

    private void ManageButtonVisibility()
    {
        
    }

    private void CheckStartInput()
    {
        
    }
}