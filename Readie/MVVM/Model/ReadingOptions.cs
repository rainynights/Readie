using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Readie.MVVM.Model;

public class ReadingOptions
{
    public int WordsPerMinute { get; set; } = 240;
    public int WordIndex { get; set; } = 0;
    public int WordCountPerStep { get; set; } = 1;

    public ReadingOptions()
    {

    }

    public ReadingOptions(int wordsPerMinute, int wordIndex, int wordCountPerStep)
    {
        WordsPerMinute = wordsPerMinute;
        WordIndex = wordIndex;
        WordCountPerStep = wordCountPerStep;
    }
}
