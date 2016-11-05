using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_2_1
{
    public partial class Latihan_2_1 : Form
    {
        private int[] tanggal;
        private string[] blan;
        public Latihan_2_1()
        {
            InitializeComponent();
            DateTime mulai = new DateTime(2016, 1, 1);
            DateTime akhir = new DateTime(2016, 12, 31);
            DateTime ulang_tahun = new DateTime(2016,06,27);

            monthCalendar1.AddMonthlyBoldedDate(ulang_tahun);
            while (mulai < akhir)
            {
                if (mulai.DayOfWeek == DayOfWeek.Saturday)
                {
                    monthCalendar1.AddBoldedDate(mulai);
                    mulai = mulai.AddDays(1);
                    if (mulai != akhir)
                        monthCalendar1.AddBoldedDate(mulai);

                    mulai = mulai.AddDays(5);
                }
                mulai = mulai.AddDays(1);
            }
            blan = new string[] { "JANUARY", "FEBRUARY", "MARCH", "APRIL", "MAY", "JUNE", "JULY", "AUGUST", "SEPTEMBER", "OCTOBER", "NOVEMBER", "DECEMBER" };
            tanggal = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };


            for (int a = 1; a < tanggal[0]; a++)
            {
                domainUpDown1.Items.Add(a);
            }
            for (int a = 0; a < 12; a++)
                domainUpDown2.Items.Add(blan[a]);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int buln = domainUpDown2.SelectedIndex + 1;
            int tgl = domainUpDown1.SelectedIndex + 1;


            monthCalendar1.AddAnnuallyBoldedDate(new DateTime(2016, buln, tgl));
            monthCalendar1.UpdateBoldedDates();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            monthCalendar1.RemoveAllAnnuallyBoldedDates();
            monthCalendar1.UpdateBoldedDates();
        }

        private void Latihan_2_1_Load_1(object sender, EventArgs e)
        {
            monthCalendar1.UpdateBoldedDates();
        }

        private void domainUpDown2_SelectedItemChanged_1(object sender, EventArgs e)
        {
            for (int a = 0; a < 12; a++)
            {
                if (domainUpDown2.SelectedItem == blan[a])
                {
                    domainUpDown1.Items.Clear();
                    for (int b = 1; b <= tanggal[a]; b++)
                        domainUpDown1.Items.Add(b);

                    domainUpDown1.SelectedItem = 1;
                    break;
                }
            }
        }
    }
}
