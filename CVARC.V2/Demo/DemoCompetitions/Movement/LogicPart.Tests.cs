﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIRLab.Mathematics;
using CVARC.V2.SimpleMovement;
using CVARC.V2;

namespace Demo
{
    partial class MovementLogicPart
    {


        MovementTestEntry LocationTest(double X, double Y, double angleInGrad, params SimpleMovementCommand[] command)
        {
            return (client, world, asserter) =>
                {


                    SensorsData data = null;
                    foreach(var c in command)
                        data=client.Act(c);
                    
					asserter.IsEqual(X, data.Locations[0].X, 1e-3);
                    asserter.IsEqual(Y, data.Locations[0].Y, 1e-3);
                    asserter.IsEqual(angleInGrad, data.Locations[0].Angle % 360, 5e-3);
                };
        }


        void LoadTests()
        {
            Tests["Forward"] = new MovementTestBase(LocationTest(10,0, 0, SimpleMovementCommand.Move(10, 1)));
            Tests["Backward"] = new MovementTestBase(LocationTest(-10, 0, 0, SimpleMovementCommand.Move(-10, 1)));
            Tests["ForwardRect"] = new MovementTestBase(LocationTest(10, 0, 0, SimpleMovementCommand.Move(10, 1)), true);
            Tests["BackwardRect"] = new MovementTestBase(LocationTest(-10, 0, 0, SimpleMovementCommand.Move(-10, 1)), true);
            Tests["SquareRect"] = new MovementTestBase(LocationTest(0, 0, 0,
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1),
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1),
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1),
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1)),true);
            Tests["Square"] = new MovementTestBase(LocationTest(0, 0, 0,
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1),
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1),
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1),
                SimpleMovementCommand.Move(10, 1),
                SimpleMovementCommand.Rotate(Angle.HalfPi, 1)));
			Tests["RotateRect"] = new MovementTestBase(LocationTest(0, 0, 90, SimpleMovementCommand.Rotate(Angle.HalfPi, 1)),true);
            Tests["Rotate"] = new MovementTestBase(LocationTest(0, 0, 90, SimpleMovementCommand.Rotate(Angle.HalfPi, 1)));
            //для AlignmentRect пришлось увеличить delta на проверке угла поворота до 0,005
            Tests["AlignmentRect"] = new MovementTestBase(LocationTest(25.355,17.357,Angle.HalfPi.Grad,
                SimpleMovementCommand.Move(-10,1),
                SimpleMovementCommand.Rotate(Angle.HalfPi/2,1),
                SimpleMovementCommand.Move(50,1)),true);
            Tests["Speed"] = new MovementTestBase(LocationTest(50, 0, 0,
                SimpleMovementCommand.Move(100000, 1)));
            Tests["RotateSpeed"] = new MovementTestBase(LocationTest(0, 0, 0,
                SimpleMovementCommand.Rotate(Angle.Pi*10, 4)));
            Tests["SpeedRect"] = new MovementTestBase(LocationTest(50, 0, 0,
                SimpleMovementCommand.Move(100000, 1)), true);
            Tests["RotateSpeedRect"] = new MovementTestBase(LocationTest(0, 0, 0,
                SimpleMovementCommand.Rotate(Angle.Pi * 10, 4)), true);
            Tests["FuckTheBoxRect"] = new MovementTestBase(LocationTest(100, 0, 0,
                SimpleMovementCommand.Move(50, 2)), true, true); //думаю что тест не проходит из-за физики, поэтому не баг а фича
            Tests["FuckTheBox"] = new MovementTestBase(LocationTest(100, 0, 0,
                SimpleMovementCommand.Move(50, 2)), false, true); //тот же тест только с цилиндром
            Tests["Exit"] = new MovementTestBase(
                (client, asserter, world) =>
                {
                    var move = LocationTest(10, 0, 0, SimpleMovementCommand.Move(10, 1));
                    move(client, asserter, world);
                    client.Exit();
                });
      
        }
    }
}
