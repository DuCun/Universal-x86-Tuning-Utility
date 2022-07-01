﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RyzenSmu;
using RyzenSMUBackend;
using AATUV3.Scripts.SMU_Backend_Scripts;
using System.Windows.Forms;

namespace AATUV3.Scripts.SMU_Backend_Scripts
{
    internal class GetSensor
    {
        public static float getSensorValve(string SensorName)
        {
            int i = -1;
            string[] SensorNames = { };
            uint[] SensorOffset = { };

            if (string.Format("{0:x}", Addresses.PMTableVersion).Contains("400005") || string.Format("{0:x}", Addresses.PMTableVersion).Contains("400004"))
            {
                SensorNames = pmtables.PMT_Sensor_400005;
                SensorOffset = pmtables.PMT_Offset_400005;
            }

            do{i++;} while (SensorNames[i] != SensorName && i <= SensorNames.Length);

            if (SensorNames[i] == SensorName)
            {
                return Smu.ReadFloat(Addresses.Address, SensorOffset[i]);
            }

            return 0;
        }
    }
}
