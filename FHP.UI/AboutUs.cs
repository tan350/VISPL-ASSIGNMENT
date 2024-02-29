using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHP.UI
{
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            titleLabel.Text = "ABOUT US";
            aboutLabel.Text = @"Headquartered in Mohali, India, Vertex Infosoft Solutions Pvt Ltd was incorporated 
in the year 1999. With over 20 years of experience, we have emerged as one of the 
fastest-growing companies in the marine IT field, serving numerous top shipping 
companies around the globe.

Our comprehensive and integrated Ship Management Software 
titled “SMMS – Ship Maintenance & Management System” has been 
successfully implemented on more than 1500 vessels worldwide.

OUR BUSINESS

- Development of Software Applications
- Creation of PMS & Inventory Databases for Vessels
- 24x7 Technical Support
- On-site Implementations and Trainings
- Remote and On-board I.T. Services
- Documents Digitization

For inquiries or collaborations, please contact us at +91 172 5288333.";
        }
    }
}
