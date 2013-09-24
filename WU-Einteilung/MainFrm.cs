using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WU_Einteilung
{
    public partial class MainFrm : Form
    {
        private Worksheet slist;
        private Worksheet klist;
        private Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
        private Microsoft.Office.Interop.Excel.Workbook wb;
        private string document_path;
        private int[] schueler_id;
        private string[] schueler_namen;
        private string[] schueler_vornamen;
        private string[] schueler_klasse;
        private string[] schueler_klassenlehrer;
        private string[] schueler_erstwahl;
        private string[] schueler_zweitwahl;
        private string[] schueler_drittwahl;
        private string[] kurse_id;
        private int[] kurse_maxpersonen;
        private int[] kurse_minpersonen;
        private bool[] kurse_klasse8;
        private bool[] kurse_klasse9;

        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            
        }
        private void Read_Document(string path)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            document_path = tbx_path.Text;
            wb = app.Workbooks.Open(@document_path);
            slist = (Worksheet)wb.Sheets[1];
            klist = (Worksheet)wb.Sheets[2];
            Range slist_range = slist.UsedRange;
            Range klist_range = klist.UsedRange;
            for (int i = 0; String.Equals(slist_range.Cells[i+2, 2].Value,""); i++)
            {
                slist_range.Cells[i+2, 1].Value = i;
                schueler_id[i]           = slist_range.Cells[i+2, 1].Value;
                schueler_namen[i]        = slist_range.Cells[i+2, 2].Value;
                schueler_vornamen[i]     = slist_range.Cells[i+2, 3].Value;
                schueler_klasse[i]       = slist_range.Cells[i+2, 4].Value;
                schueler_klassenlehrer[i]= slist_range.Cells[i+2, 5].Value;
                schueler_erstwahl[i]     = slist_range.Cells[i+2, 6].Value;
                schueler_zweitwahl[i]    = slist_range.Cells[i+2, 7].Value;
                schueler_drittwahl[i]    = slist_range.Cells[i+2, 8].Value;
            }
            for (int i = 0; String.Equals(klist_range.Cells[i+2, 1].Value,""); i++)
            {
                kurse_id[i] = klist_range.Cells[i + 2, 1].value;
                kurse_maxpersonen[i] = klist_range.Cells[i + 2, 8].value;
                kurse_minpersonen[i] = klist_range.Cells[i + 2, 7].value;
                if (klist_range.Cells[i + 2, 4].Value == 1) kurse_klasse8[i] = true; else kurse_klasse8[i] = false;
                if (klist_range.Cells[i + 2, 5].Value == 1) kurse_klasse9[i] = true; else kurse_klasse9[i] = false;
            }
            //a1.Value = "1";
            //string cellValue=a1.Value;
            //MessageBox.Show(cellValue);
            wb.Save();
            wb.Close();
        }

        private void tbx_path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
