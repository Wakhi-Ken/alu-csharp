using System;
using System.Collections.Generic;

public class RoomObjects
{
    public static void IterateAction(List<Base> roomObjects, Type type)
    {
        foreach (Base obj in roomObjects)
        {
            if (type == typeof(IInteractive) && obj is IInteractive interactiveObj)
            {
                interactiveObj.Interact();
            }
            else if (type == typeof(IBreakable) && obj is IBreakable breakableObj)
            {
                breakableObj.Break();
            }
            else if (type == typeof(ICollectable) && obj is ICollectable collectableObj)
            {
                collectableObj.Collect();
            }
        }
    }
}