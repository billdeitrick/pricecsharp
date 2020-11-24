﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Packt.Shared
{
    public interface IPlayable
    {

        void Play();

        void Pause();

        void Stop()
        {
            WriteLine("Default implementation of stop.");
        }
    }
}
