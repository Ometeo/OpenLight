using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenPanelsControllerModels
{
    public class Panel
    {
        public byte Id
        {
            get; set;
        }

        public Color Color
        {
            get; set;
        }

        public byte Parent
        {
            get; set;
        }

        public Position Position
        {
            get; set;
        }

        public Orientation Orientation
        {
            get; set;
        }
    }
}