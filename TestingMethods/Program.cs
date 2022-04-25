using System;
using System.Collections;

public class Program
{
    public static void Main()
    {        
        Fire fire = new Fire();
        Ambulance ambulance = new Ambulance();
        Police police = new Police();

        Call911 c911 = new Call911();

        c911.CallForAssistance += fire.OnCallTo911;
        c911.CallForAssistance += ambulance.OnCallTo911;
        c911.CallForAssistance += police.OnCallTo911;

        c911.createNotification("Need Help at Kipling station");

    }
}

public class Fire
{
    public void OnCallTo911(object sender, EmergencyInfo e)
    {
        Console.WriteLine("Fire Brigade needs at " + e.address);
    }

}
public class Ambulance
{
    public void OnCallTo911(object sender, EmergencyInfo e)
    {
        Console.WriteLine("Ambulance needs at " + e.address);
    }

}

public class Police
{
    public void OnCallTo911(object sender, EmergencyInfo e)
    {
        Console.WriteLine("Police needs at " + e.address);
    }

}

public class Call911
{
    
    public event EmergencyEvent CallForAssistance;
      public void createNotification(string msg)
    {       
        if (CallForAssistance != null)
        {
            CallForAssistance(this, new EmergencyInfo(msg));
        }
    }
}

public delegate void EmergencyEvent(object sender, EmergencyInfo e);

public class EmergencyInfo : EventArgs
{
    public string address { get; set; }
    public EmergencyInfo(string Address)
    {
        address = Address;
    }
}
