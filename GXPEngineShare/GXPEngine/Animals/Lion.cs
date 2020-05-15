using System;
using GXPEngine;

public class Lion : AnimationSprite
{
    public bool feeding { get; set; }
    public bool petting { get; set; }
    public bool cleaning { get; set; }
    private bool idle;

    private int _animationSpeed = 290;
    private int _animationTimer;

    public Lion() : base("LionSpriteSheet.png", 14, 4)
    {

    }

    private void Update()
    {
        HandleAnimation();
    }

    private void HandleAnimation()
    {
        if (cleaning)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 14 + 0;

            SetFrame(frame);

            if (frame >= 13)
            {
                cleaning = false;
            }
        }

        if (feeding)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 10 + 14;

            SetFrame(frame);

            if (frame >= 23)
            {
                feeding = false;
            }
        }

        if (petting)
        {
            cleaning = false;

            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 28;
            SetFrame(frame);

            if (frame >= 35)
            {
                petting = false;
            }
        }

        if (idle)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 10 + 42;

            SetFrame(frame);
        }

        if (!petting && !cleaning && !feeding)
        {
            idle = true;
            petting = false;
            feeding = false;
            cleaning = false;
        }
        else
        {
            idle = false;
        }
    }
}
