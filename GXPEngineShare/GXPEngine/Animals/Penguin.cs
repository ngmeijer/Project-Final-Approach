using System;
using GXPEngine;

public class Penguin : AnimationSprite
{
    private int _animationSpeed = 290;
    private int _animationTimer;
    private bool idle;

    public bool feeding { get; set; }
    public bool petting { get; set; }
    public bool cleaning { get; set; }

    public Penguin() : base("PenguinSpritesheet.png", 15, 4)
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
            int frame = (int)(_animationTimer / _animationSpeed) % 15 + 0;

            SetFrame(frame);

            if (frame >= 14)
            {
                cleaning = false;
            }
        }

        if (feeding)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 15;

            SetFrame(frame);

            if (frame >= 22)
            {
                feeding = false;
            }
        }

        if (petting)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 9 + 30;

            SetFrame(frame);

            if (frame >= 38)
            {
                petting = false;
            }
        }

        if (idle)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 45;

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
