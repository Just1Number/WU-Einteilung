using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WU_Einteilung;
namespace WU_Einteilung
{
    public partial class ConfigFrm : Form
    {
        public ConfigFrm()
        {
            InitializeComponent();
            tbx_names.AppendText(switchcollumntoalpha(MainFrm.SPALTE_NAME));
            tbx_firstnames.AppendText(switchcollumntoalpha(MainFrm.SPALTE_VORNAME));
            tbx_classes.AppendText(switchcollumntoalpha(MainFrm.SPALTE_KLASSE));
            tbx_teachers.AppendText(switchcollumntoalpha(MainFrm.SPALTE_KLASSENLEHRER));
            tbx_first.AppendText(switchcollumntoalpha(MainFrm.SPALTE_ERSTWAHL));
            tbx_second.AppendText(switchcollumntoalpha(MainFrm.SPALTE_ZWEITWAHL));
            tbx_third.AppendText(switchcollumntoalpha(MainFrm.SPALTE_DRITTWAHL));
            tbx_assignments.AppendText(switchcollumntoalpha(MainFrm.SPALTE_ZUORDNUNG));
        }

        private void Config_Load(object sender, EventArgs e)
        {
            
        }

        private void Config_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private string switchcollumntoalpha(int collumn)
        {
            if (collumn <= 26)
            {
                switch (collumn)
                {
                    case 1: return "A";
                    case 2: return "B";
                    case 3: return "C";
                    case 4: return "D";
                    case 5: return "E";
                    case 6: return "F";
                    case 7: return "G";
                    case 8: return "H";
                    case 9: return "I";
                    case 10: return "J";
                    case 11: return "K";
                    case 12: return "L";
                    case 13: return "M";
                    case 14: return "N";
                    case 15: return "O";
                    case 16: return "P";
                    case 17: return "Q";
                    case 18: return "R";
                    case 19: return "S";
                    case 20: return "T";
                    case 21: return "U";
                    case 22: return "V";
                    case 23: return "W";
                    case 24: return "X";
                    case 25: return "Y";
                    case 26: return "Z";
                    default: return "AA";
                }
            }
            return "AA";
        }

        private int switchcollumntonumber(string collumn)
        {
            if (collumn.Length == 1)
            {
                switch (collumn.ToUpper())
                {
                    case "A": return 1;
                    case "B": return 2;
                    case "C": return 3;
                    case "D": return 4;
                    case "E": return 5;
                    case "F": return 6;
                    case "G": return 7;
                    case "H": return 8;
                    case "I": return 9;
                    case "J": return 10;
                    case "K": return 11;
                    case "L": return 12;
                    case "M": return 13;
                    case "N": return 14;
                    case "O": return 15;
                    case "P": return 16;
                    case "Q": return 17;
                    case "R": return 18;
                    case "S": return 19;
                    case "T": return 20;
                    case "U": return 21;
                    case "V": return 22;
                    case "W": return 23;
                    case "X": return 24;
                    case "Y": return 25;
                    case "Z": return 26;
                    default: return 0;
                }
            }
            return 0;
        }

        private void tbx_names_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_NAME = switchcollumntonumber(tbx_names.Text);
        }

        private void tbx_firstnames_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_NAME = switchcollumntonumber(tbx_names.Text);
        }

        private void tbx_classes_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_KLASSE = switchcollumntonumber(tbx_names.Text);
        }

        private void tbx_teachers_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_KLASSENLEHRER = switchcollumntonumber(tbx_teachers.Text);
        }

        private void tbx_first_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_ERSTWAHL = switchcollumntonumber(tbx_first.Text);
        }

        private void tbx_second_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_ZWEITWAHL = switchcollumntonumber(tbx_second.Text);
        }

        private void tbx_third_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_DRITTWAHL = switchcollumntonumber(tbx_third.Text);
        }

        private void tbx_assignments_TextChanged(object sender, EventArgs e)
        {
            MainFrm.SPALTE_ZUORDNUNG = switchcollumntonumber(tbx_assignments.Text);
        }  
    }
}
