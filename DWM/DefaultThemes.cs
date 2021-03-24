using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DWM
{
    class DefaultThemes
    {
        public Dictionary<string, string> themes = new Dictionary<string, string>();
        public DefaultThemes()
        {
            themes.Add("default", "[Gradient 1 Color 1]\r\n#FF516395\r\n[Gradient 1 Color 2]\r\n#FF2B5876\r\n[Gradient 2 Color 1]\r\n#FF2B5876\r\n[Gradient 2 Color 2]\r\n#FF4E4376\r\n[Background Gradient Color 1]\r\n#FF04619F\r\n[Background Gradient Color 2]\r\n#000000\r\n[Sidebar Gradient Color 1]\r\n#FF232220\r\n[Sidebar Gradient Color 2]\r\n#FF232220\r\n");
            themes.Add("sunset", "[Gradient 1 Color 1]\r\n#000048\r\n[Gradient 1 Color 2]\r\n#830048\r\n[Gradient 2 Color 1]\r\n#000048\r\n[Gradient 2 Color 2]\r\n#830048\r\n[Background Gradient Color 1]\r\n#FF232220\r\n[Background Gradient Color 2]\r\n#00002A\r\n[Sidebar Gradient Color 1]\r\n#FF232220\r\n[Sidebar Gradient Color 2]\r\n#FF232220\r\n");
            themes.Add("solid", "[Gradient 1 Color 1]\r\n#38383d\r\n[Gradient 1 Color 2]\r\n#38383d\r\n[Gradient 2 Color 1]\r\n#38383d\r\n[Gradient 2 Color 2]\r\n#38383d\r\n[Background Gradient Color 1]\r\n#2a2a2e\r\n[Background Gradient Color 2]\r\n#2a2a2e\r\n[Sidebar Gradient Color 1]\r\n#2a2a2e\r\n[Sidebar Gradient Color 2]\r\n#2a2a2e\r\n");
        }
    }
}