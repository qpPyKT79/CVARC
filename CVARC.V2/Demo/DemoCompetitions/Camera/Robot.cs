﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CVARC.V2.SimpleMovement;
using CVARC.V2;

namespace Demo
{
    public class CameraRobot : SimpleMovementRobot<IActorManager, CameraWorld, SensorsWithCamera>
    {

        public override void ProcessCustomCommand(string commandName, out double nextRequestTimeSpan)
        {
            nextRequestTimeSpan = 1;
        }

     
    }
}
