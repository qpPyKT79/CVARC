﻿using CVARC.Basic;
using RepairTheStarship.Robots;
using RepairTheStarship;

namespace RepairTheStarship.Levels
{
    public class Level3 : BaseLevel
    {
        public override ISceneSettings ParseSettings(CVARC.Network.HelloPackage helloPackage)
        {
            return SceneSettings.GetRandomMap(helloPackage.MapSeed);
        }

        public override Robot CreateRobot(int robotNumber)
        {
            return new DestinationGemsRobot(this, robotNumber);
        }
    };
}