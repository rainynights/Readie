using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.Model;

public struct ReadingOptions
{
    public int Speed { get; set; }
    public int StepIndex { get; set; }
    public int WordCountPerStep { get; set; }

    public ReadingOptions(int speed = 1, int stepIndex = 0, int wordCountPerStep = 1)
    {
        Speed = speed;
        StepIndex = stepIndex;
        WordCountPerStep = wordCountPerStep;
    }
}
