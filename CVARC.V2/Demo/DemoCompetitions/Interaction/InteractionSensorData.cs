﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using CVARC.V2;
using RepairTheStarship;

namespace Demo
{ 
    [DataContract]
    public class InteractionSensorData
    {
        [DataMember]
        [FromSensor(typeof(GripSensor))]
        public bool IsGripped { get; set; }
        
    }
}