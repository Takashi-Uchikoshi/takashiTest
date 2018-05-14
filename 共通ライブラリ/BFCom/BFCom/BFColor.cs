using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace B2.BestFunction
{
    //******************************************************************************
    /// <summary>
    /// BestFunction 使用色定義
    /// </summary>
    /// <remarks>
    /// ※ Color に合わせて class ではなく struct で定義
    /// </remarks>
    //******************************************************************************
    public struct BFColor
    {
        /// <summary>白色</summary>
        static public Color White { get { return Color.FromArgb(255, 255, 255); } }
        /// <summary>水色</summary>
        static public Color Water { get { return Color.FromArgb(91, 201, 244); } }
        /// <summary>桃色</summary>
        static public Color Pink { get { return Color.FromArgb(220, 130, 171); } }
        /// <summary>ピスタチオ緑色</summary>
        static public Color Pistachio { get { return Color.FromArgb(130, 220, 184); } }
        /// <summary>暗灰色</summary>
        static public Color DarkGray { get { return Color.FromArgb(86, 86, 86); } }
        /// <summary>明灰色</summary>
        static public Color PearlGray { get { return Color.FromArgb(239, 239, 239); } }
        /// <summary>灰色</summary>
        static public Color Gray { get { return Color.FromArgb(149, 152, 154); } }
        /// <summary>橙色</summary>
        static public Color Orange { get { return Color.FromArgb(244, 173, 91); } }
        /// <summary>赤色</summary>
        static public Color Red { get { return Color.FromArgb(244, 91, 91); } } 
    }
}
