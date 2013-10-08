using System;

namespace CSEsMS.Engine
{
    public class PreferredSide
    {
        virtual public int Side
        {
            get
            {
                return innerValue;
            }
			
        }
		
        //UPGRADE_NOTE: Final was removed from the declaration of 'RIGHT '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
        public int RIGHT = 1;
        //UPGRADE_NOTE: Final was removed from the declaration of 'LEFT '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
        public int LEFT = 2;
        //UPGRADE_NOTE: Final was removed from the declaration of 'CENTER '. "ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?index='!DefaultContextWindowIndex'&keyword='jlca1003'"
        public int CENTER = 4;
		
        private int innerValue;
		
        public PreferredSide(string value_Renamed)
        {
            if (value_Renamed.Contains("R"))
                innerValue += RIGHT;
            if (value_Renamed.Contains("L"))
                innerValue += LEFT;
            if (value_Renamed.Contains("C"))
                innerValue += CENTER;
        }
		
        public PreferredSide(int value_Renamed)
        {
            innerValue = value_Renamed;
            // TODO: If value > 111b throw exception
        }
		
        public override string ToString()
        {
            System.Text.StringBuilder buf = new System.Text.StringBuilder();
            if ((innerValue & 1) != 0)
            {
                buf.Append('R');
            }
            if ((innerValue & 2) != 0)
            {
                buf.Append('L');
            }
            if ((innerValue & 4) != 0)
            {
                buf.Append('C');
            }
            return buf.ToString();
        }
		
        public virtual bool isCompatible(PreferredSide side)
        {
            if ((innerValue & side.Side) != 0)
                return true;
            else
                return false;
        }
    }
}