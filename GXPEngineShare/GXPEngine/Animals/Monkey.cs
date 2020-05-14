using System;
using GXPEngine;

public class Monkey : AnimationSprite
{
    public bool feeding { get; set; }
    public bool petting { get; set; }
    public bool cleaning { get; set; }
    private bool idle;

    private int _endFrame;
    private int _startFrame;

    private int _startFrameCleaning = 0;
    private int _endFrameCleaning = 14;

    private int _animationSpeed = 350;
    private int _animationTimer;

    public Monkey() : base("MonkeySpriteSheet.png", 15, 4)
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
            int frame = (int)(_animationTimer / _animationSpeed) % 10 + 15;

            SetFrame(frame);

            if (frame >= 24)
            {
                feeding = false;
            }
        }

        if (petting)
        {
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
