﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.Model;

public class ReadingOptions
{
    public int Speed { get; set; } = 3;
    public int WordIndex { get; set; } = 0;
    public int WordCountPerStep { get; set; } = 1;

    public ReadingOptions()
    {

    }

    public ReadingOptions(int speed, int wordIndex, int wordCountPerStep)
    {
        Speed = speed;
        WordIndex = wordIndex;
        WordCountPerStep = wordCountPerStep;
    }
}