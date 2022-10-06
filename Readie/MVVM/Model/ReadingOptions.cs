using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.Model;

public struct ReadingOptions
{
    public int Speed { get; set; }
    public int WordCountPerStep { get; set; }

    public ReadingOptions()
    {
        Speed = 120;
        WordCountPerStep = 1;
    }
}
