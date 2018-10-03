public class TickCounter
{
    public int coolDown = 300;
    public int coolDownTimer = 0;

    public float Rate
    {
        get { return (float)(coolDown - coolDownTimer) / (float)coolDown; }
    }

    public TickCounter(int CD)
    {
        coolDown = CD;
    }

    public void Reset()
    {
        coolDownTimer = coolDown;
    }

    public bool Tick()
    {
        if (coolDownTimer == 0)
        {
            return true;
        }
        else
        {
            if (coolDownTimer > 0)
            {
                coolDownTimer--;
            }
        }
        return false;
    } 
}

