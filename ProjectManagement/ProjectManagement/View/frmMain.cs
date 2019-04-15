using ProjectManagement.DAO;
using ProjectManagement.DTO;
using ProjectManagement.GUI;
using ProjectManagement.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement
{
    public partial class frmMain : Form
    {
        private string page;
        private int flagCbPartners;


        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
            page = "Project-Company";
            InitProject_Company();

        }
        // init data
        public void InitProject_Company()
        {
            picNew.Visible = true;
            picDelete.Visible = true;
            picUpdate.Visible = true;
            flagCbPartners = 0;
            //load lable all project
            lbAllProject.Visible = true;
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            companyDAO.GetAllCompany(ref gvSmallList);
            // get list project by company of row 1
            lbCompanyName.Text = gvSmallList.Rows[0].Cells[1].Value.ToString();
            int companyId = int.Parse(gvSmallList.Rows[0].Cells[0].Value.ToString());
            tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            projectDAO.GetProjectsOfCompany(partnerDAO.GetListPartnerId(companyId), ref gvBigList);

            // display combobox partner
            DisplayComboboxPartner(companyId);
        }

        public void InitEmployee_Project()
        {
            picNew.Visible = false;
            picDelete.Visible = false;
            picUpdate.Visible = false;
            flagCbPartners = 0;
            // load lable AllProject
            lbAllProject.Visible = false;
            tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
            projectDAO.GetAllProject(ref gvSmallList);
            // load lable company name
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            int companyId = partnerDAO.GetCompanyIdById(int.Parse(gvSmallList.CurrentRow.Cells[3].Value.ToString()));
            lbCompanyName.Text = companyDAO.GetNameById(companyId);
            // load partner infor
            int parnerId = int.Parse(gvSmallList.CurrentRow.Cells[3].Value.ToString());
            DisplayPartnerInfor(parnerId);
            // display employees
            tbl_JoiningDAO joiningDAO = new tbl_JoiningDAO();
            List<int> employeeIDs = joiningDAO.GetListEmIDByProjectId(int.Parse(gvSmallList.CurrentRow.Cells[0].Value.ToString()));
            List<tbl_EmployeeDTO> listEmployee = new List<tbl_EmployeeDTO>();
            tbl_EmployeeDAO emDAO = new tbl_EmployeeDAO();
            foreach (var emId in employeeIDs)
            {
                listEmployee.Add(emDAO.GetById(emId));
            }
            gvBigList.DataSource = listEmployee;

        }

        // display combobox
        public void DisplayComboboxPartner(int companyId)
        {
            tbl_PartnerDAO dao = new tbl_PartnerDAO();
            List<tbl_PartnerDTO> listPartnerId = dao.GetListPartners(companyId);
            List<string> items = new List<string>();
            foreach (tbl_PartnerDTO dto in listPartnerId)
            {
                items.Add(dto.Name + " - " + dto.Phone);
            }
            cbPartners.DataSource = items;
        }

        public void DisplayPartnerInfor(int partnerId)
        {
            tbl_PartnerDAO dao = new tbl_PartnerDAO();
            String[] partner = { dao.GetPartnerById(partnerId) };
            cbPartners.DataSource = partner;
        }

        //Search function
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (page.Equals("Project-Company"))
            {
                Search_PC_Page();
            }
            if (page.Equals("Employee-Project"))
            {
                Search_EP_Page();
            }
        }
        public void Search_PC_Page()
        {
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            companyDAO.SearchCompanyByName(ref gvSmallList, txtSearchSmall.Text);
            lbNotFound.Visible = false;
            gvSmallList.Visible = true;
            cbPartners.Visible = true;
            gvBigList.Visible = true;

            if (gvSmallList.RowCount == 0)
            {
                lbNotFound.Visible = true;
                gvSmallList.Visible = false;
                lbCompanyName.Text = "";
                cbPartners.Visible = false;
                gvBigList.Visible = false;
            }
            else
            {
                lbCompanyName.Text = gvSmallList.Rows[0].Cells[1].Value.ToString();
            }
        }

        public void Search_EP_Page()
        {
            tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
            projectDAO.SearchByName(txtSearchSmall.Text, ref gvSmallList);
            lbNotFound.Visible = false;
            gvSmallList.Visible = true;
            cbPartners.Visible = true;
            gvBigList.Visible = true;
            if (gvSmallList.RowCount == 0)
            {
                lbNotFound.Visible = true;
                gvSmallList.Visible = false;
                lbCompanyName.Text = "";
                cbPartners.Visible = false;
                gvBigList.Visible = false;
            }
            else
            {
                tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
                tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
                lbCompanyName.Text = companyDAO.GetNameById(partnerDAO.GetCompanyIdById(int.Parse(gvSmallList.CurrentRow.Cells[3].Value.ToString())));
            }
        }

        // load All function
        private void llbAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lbNotFound.Visible = false;
            gvSmallList.Visible = true;
            cbPartners.Visible = true;
            gvBigList.Visible = true;
            if (page.Equals("Project-Company"))
            {
                LoadAll_PC_Page();
            }
            if (page.Equals("Employee-Project"))
            {
                LoadAll_EP_Page();
            }

        }

        public void LoadAll_PC_Page()
        {
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            companyDAO.GetAllCompany(ref gvSmallList);
            //tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            //tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
            //for (int i = 0; i < gvSmallList.Rows.Count; i++)
            //{
            //    int comId = int.Parse(gvSmallList.Rows[i].Cells[0].Value.ToString());
            //    if (projectDAO.GetNumberProjectsOfCompany(partnerDAO.GetListPartnerId(comId)) == 0)
            //    {
            //        gvSmallList.Rows[i].Visible = false;
            //    }
            //}
            InitProject_Company();
        }
        public void LoadAll_EP_Page()
        {
            tbl_ProjectDAO dao = new tbl_ProjectDAO();
            dao.GetAllProject(ref gvSmallList);
            InitEmployee_Project();
        }

        // handling in left screen
        private void gvSmallList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            flagCbPartners = 0;
            try
            {
                if (page.Equals("Project-Company"))
                {
                    CellClick_PC_Page();
                }
                if (page.Equals("Employee-Project"))
                {
                    CellClick_EP_Page();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CellClick_PC_Page()
        {
            int companyId = int.Parse(gvSmallList.CurrentRow.Cells[0].Value.ToString());
            // load company name in list project
            lbCompanyName.Text = gvSmallList.CurrentRow.Cells[1].Value.ToString();
            // load combobox partners
            DisplayComboboxPartner(companyId);

            // with company selected, display list project
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();

            projectDAO.GetProjectsOfCompany(partnerDAO.GetListPartnerId(companyId), ref gvBigList);
        }

        public void CellClick_EP_Page()
        {
            //load company name
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            int companyId = partnerDAO.GetCompanyIdById(int.Parse(gvSmallList.CurrentRow.Cells[3].Value.ToString()));
            lbCompanyName.Text = companyDAO.GetNameById(companyId);
            // load partner infor
            int parnerId = int.Parse(gvSmallList.CurrentRow.Cells[3].Value.ToString());
            DisplayPartnerInfor(parnerId);
            // display employees
            tbl_JoiningDAO joiningDAO = new tbl_JoiningDAO();
            List<int> employeeIDs = joiningDAO.GetListEmIDByProjectId(int.Parse(gvSmallList.CurrentRow.Cells[0].Value.ToString()));
            List<tbl_EmployeeDTO> listEmployee = new List<tbl_EmployeeDTO>();
            tbl_EmployeeDAO emDAO = new tbl_EmployeeDAO();
            foreach (var emId in employeeIDs)
            {
                listEmployee.Add(emDAO.GetById(emId));
            }
            gvBigList.DataSource = listEmployee;

        }

        //handling in right screen
        private void gvBigList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (page.Equals("Project-Company"))
            {
                CellClickBIgList_PC_Page();
            }
        }

        public void CellClickBIgList_PC_Page()
        {
            int projectId = int.Parse(gvBigList.CurrentRow.Cells[0].Value.ToString());
            tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            string infor = partnerDAO.GetPartnerById(projectDAO.GetPartnerId(projectId));
            cbPartners.Text = infor;
        }

        private void gvBigList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (page.Equals("Project-Company"))
            {
                frmProjectDetail frmProject = frmProjectDetail.GetInstance();
                if (!frmProject.Visible)
                {

                    frmProject.ComName = lbCompanyName.Text;
                    frmProject.PartnerInfor = cbPartners.Text;
                    frmProject.ProjectId = int.Parse(gvBigList.CurrentRow.Cells[0].Value.ToString());

                    frmProject.Show();
                }
                else
                {
                    frmProject.BringToFront();
                }
            }
            if (page.Equals("Employee-Project"))
            {
                frmEmployeeDetail frmEm = frmEmployeeDetail.GetInstance();
                if (!frmEm.Visible)
                {
                    frmEm.EmId = int.Parse(gvBigList.CurrentRow.Cells[0].Value.ToString());
                    frmEm.Show();
                }
                else
                {
                    frmEm.BringToFront();
                }
            }

        }


        // view Project by company function
        private void projectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page = "Project-Company";
            lbCompany.Text = "COMPANY";
            lbProject.Text = "PROJECT";
            InitProject_Company();
            lbNotFound.Visible = false;
            gvSmallList.Visible = true;

        }

        // view employee by project function
        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            page = "Employee-Project";
            lbCompany.Text = "PROJECT";
            lbProject.Text = "EMPLOYEE";
            InitEmployee_Project();
            lbNotFound.Visible = false;
            gvSmallList.Visible = true;
        }

        // view detail partner and company
        private void btnViewDetailPartner_Click(object sender, EventArgs e)
        {
            if (cbPartners.Visible)
            {
                frmPartnerManagement frmPartner = frmPartnerManagement.GetInstance();
                if (!frmPartner.Visible)
                {
                    if (page.Equals("Project-Company"))
                    {
                        frmPartner.Page = "Project-Company";
                        int companyId = int.Parse(gvSmallList.CurrentRow.Cells[0].Value.ToString());
                        string partnerInfo = cbPartners.SelectedValue.ToString();
                        frmPartner.ComanyId = companyId;
                        frmPartner.PartnerInfor = partnerInfo;
                    }
                    if (page.Equals("Employee-Project"))
                    {
                        frmPartner.Page = "Employee-Project";
                        int partnerId = int.Parse(gvSmallList.CurrentRow.Cells[3].Value.ToString());
                        tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
                        int companyId = partnerDAO.GetCompanyIdById(partnerId);
                        string partnerInfo = cbPartners.SelectedValue.ToString();
                        frmPartner.ComanyId = companyId;
                        frmPartner.PartnerInfor = partnerInfo;
                    }
                    frmPartner.Show();

                }
                else
                {
                    frmPartner.BringToFront();
                }
            }

        }

        // change item in combo box partner
        private void cbPartners_SelectedIndexChanged(object sender, EventArgs e)
        {
            ++flagCbPartners;
            if (flagCbPartners > 1)
            {
                string[] partnerInfor = cbPartners.SelectedValue.ToString().Split('-');
                tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
                int partId = partnerDAO.GetIdByPhone(partnerInfor[1].Trim());
                tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
                projectDAO.GetByPartnerId(partId, ref gvBigList);
            }

        }

        //load all project of company
        private void lbAllProject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CellClick_PC_Page();
        }

        private void picDelete_Click(object sender, EventArgs e)
        {
            if (page.Equals("Project-Company"))
            {
                if (MessageBox.Show("Do you want delete this project?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int projectID = int.Parse(gvBigList.CurrentRow.Cells[0].Value.ToString());
                    tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
                    bool result = projectDAO.Delete(projectID);
                    LoadAll_PC_Page();
                    CellClick_PC_Page();
                }
            }
        }

        private void picUpdate_Click(object sender, EventArgs e)
        {
            if (page.Equals("Project-Company"))
            {
                frmProjectDetail frmProject = frmProjectDetail.GetInstance();
                if (!frmProject.Visible)
                {

                    frmProject.ComName = lbCompanyName.Text;
                    frmProject.PartnerInfor = cbPartners.Text;
                    frmProject.ProjectId = int.Parse(gvBigList.CurrentRow.Cells[0].Value.ToString());

                    frmProject.Show();
                }
                else
                {
                    frmProject.BringToFront();
                }
            }
            if (page.Equals("Employee-Project"))
            {
                frmEmployeeDetail frmEm = frmEmployeeDetail.GetInstance();
                if (!frmEm.Visible)
                {
                    frmEm.EmId = int.Parse(gvBigList.CurrentRow.Cells[0].Value.ToString());
                    frmEm.Show();
                }
                else
                {
                    frmEm.BringToFront();
                }
            }
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            frmNewProject formNewProject = frmNewProject.GetInstance();
            if (!formNewProject.Visible)
            {
                formNewProject.Show();
            }
            else
            {
                formNewProject.BringToFront();
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewProject formNewProject = frmNewProject.GetInstance();
            if (!formNewProject.Visible)
            {
                formNewProject.Show();
            }
            else
            {
                formNewProject.BringToFront();
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                this.Close();
            }
        }
    }
}
