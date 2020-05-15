using System;
using GXPEngine;

public class Zebra : AnimationSprite
{
    private int _animationSpeed = 290;
    private int _animationTimer;
    private bool idle;

    public bool feeding { get; set; }
    public bool petting { get; set; }
    public bool cleaning { get; set; }

    public Zebra() : base("ZebraSpritesheet.png", 15, 4)
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

            if (frame >= 14)
            {
                cleaning = false;
            }
        }

        if (feeding)
        {
            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 14;

            SetFrame(frame);

            if (frame >= 22)
            {
                feeding = false;
            }
        }

        if (petting)
        {
            cleaning = false;

            _animationTimer += Time.deltaTime;
            int frame = (int)(_animationTimer / _animationSpeed) % 8 + 29;
            SetFrame(frame);

            if (frame >= 36)
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
