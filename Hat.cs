using System;
using System.Collections.Generic;

namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }

        public string ShininessDescription()
        {
            if(ShininessLevel < 2)
            {
                return "dull";
            }
            else if(ShininessLevel < 6)
            {
                return "noticeable";
            }
            else if(ShininessLevel < 10)
            {
                return "bright";
            }
            else
            {
                return "blinding";
            }
        }
    }
}