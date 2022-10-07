using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.Model;

public class ReadingOptions
{
    public int Speed { get; set; } = 3;
    public int StepIndex { get; set; } = 0;
    public int WordCountPerStep { get; set; } = 1;

    public ReadingOptions()
    {

    }

    public ReadingOptions(int speed, int stepIndex, int wordCountPerStep)
    {
        Speed = speed;
        StepIndex = stepIndex;
        WordCountPerStep = wordCountPerStep;
    }
}
