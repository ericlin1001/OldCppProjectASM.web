using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication3
{
  
    
    public partial class WebForm1 : System.Web.UI.Page
    {
        //new added: needn't to change
        private string seqs="";
        private string matches = "";
        private int color1 = 0xff0000;
        private int color2 = 0x00ff00;
        //
        public int getColor1() {return color1;  }
        public int getColor2() {return color2;  }
        public string getSeqs() { return seqs; }
        public string getMatches() { return matches; }
        //
        private void setColor1(int c) { color1 = c; }
        private void setColor2(int c) { color2 = c; }
        private void setSeqs(string s) { seqs = s; }
        private void setMatches(string s) { matches = s; }
        //
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            int top=1;
            int minTTailSequenceLength=5;
            bool tailScoreAlgorithm=true;
            bool autoExtendTail=true;
            bool spacer=true;
            double HairpinscoreUpbounded=-2;
            double ttailscoreUpbounded=-2.5;
            string sequence = TextBox1.Text;
            //you code has a nasty bug....
            /*IO.input(sequence, top, minTTailSequenceLength, tailScoreAlgorithm, autoExtendTail, spacer, HairpinscoreUpbounded, ttailscoreUpbounded);
            string terminatorEfficiency = Convert.ToString(IO.terminatorEfficiency[0]);
            Label1.Text = terminatorEfficiency;*/

            //new added:(make your logic here to control what to show)
            //for example:
            //setSeqs("augcagucaugc");setMatches("010101010101");
            //howere,you must ensure that 1.the lenght of seqs equals to the matches
            //                            2.the var:matches contains even '1'
            //otherwise,the flash won't show them!
            //I have tested this application in IE9,i works perfectly!.
            setSeqs("augcagucaugc"); setMatches("010101010101");
            RNAViewerLabel.Visible = true;//this is just a label,you can delete it in aspx~
            
        }
    }
}