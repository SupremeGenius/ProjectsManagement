using ProjectManagement.GUI;
using ProjectManagement.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectManagement.DTO;
using ProjectManagement.Utils;

namespace ProjectManagement.View
{
    public partial class frmNewProject : Form
    {
        private static frmNewProject form;
        List<tbl_CompanyDTO> listCompany = new List<tbl_CompanyDTO>();
        List<tbl_PartnerDTO> listPartner = new List<tbl_PartnerDTO>();
        List<tbl_EmployeeDTO> listEmployee = new List<tbl_EmployeeDTO>();
        List<tbl_EmployeeDTO> listEmpAdd = new List<tbl_EmployeeDTO>();
        List<tbl_EmployeeDTO> listAllEmp = new List<tbl_EmployeeDTO>();
        int flag = 0;
        public frmNewProject()
        {
            InitializeComponent();
        }
        public static frmNewProject GetInstance()
        {
            if (form == null)
            {
                form = new frmNewProject();
            }
            return form;
        }

        /// <summary>
        /// Close form
        /// </summary>
        private void frmNewProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            form = null;
        }

        /// <summary>
        /// Add new company of project
        /// </summary>
        private void btnAddNewCom_Click(object sender, EventArgs e)
        {
            frmPartnerManagement frmPartner = frmPartnerManagement.GetInstance();
            if (!frmPartner.Visible)
            {
                frmPartner.Page = "New_Project";
                flag = 0;
                frmPartner.Show();
            }
            else
            {
                frmPartner.BringToFront();
            }
        }
        private void btnNewPartner_Click(object sender, EventArgs e)
        {
            frmPartnerManagement frmPartner = frmPartnerManagement.GetInstance();
            if (!frmPartner.Visible)
            {
                if (string.IsNullOrWhiteSpace(cbCompany.Text))
                {
                    frmPartner.Page = "New_Project";
                    flag = 0;
                }
                else
                {
                    frmPartner.Page = "New_Project_CP";
                    flag = 1;
                    frmPartner.ComanyId = int.Parse(cbCompany.Text.Split(':')[1].Trim());
                }
                frmPartner.Show();
            }
            else
            {
                frmPartner.BringToFront();
            }
        }

        /// <summary>
        /// Load form
        /// </summary>
        private void frmNewProject_Load(object sender, EventArgs e)
        {
            // load all company
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            listCompany = companyDAO.GetAllCompany();
            foreach (tbl_CompanyDTO company in listCompany)
            {
                cbCompany.Items.Add(company.Name + " - ID :" + company.Id);
            }

            tbl_EmployeeDAO emDAO = new tbl_EmployeeDAO();
            // display domainEmployee
            listAllEmp = emDAO.GetAllEmployee();
            List<String> itemsCbEmployee = new List<string>();
            foreach (tbl_EmployeeDTO employee in listAllEmp)
            {
                itemsCbEmployee.Add(employee.Name + " - ID :" + employee.Id + " (" + employee.Role + ")");
            }
            cbEmployee.DataSource = itemsCbEmployee;
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            string company = cbCompany.SelectedItem.ToString();
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            listPartner = partnerDAO.GetListPartners(int.Parse(company.Split(':')[1].Trim()));
            foreach (tbl_PartnerDTO partner in listPartner)
            {
                cbPartner.Items.Add(partner.Name + " - ID :" + partner.Id);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cbCompany.Text) && string.IsNullOrWhiteSpace(cbPartner.Text))
                {
                    tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
                    cbPartner.Text = partnerDAO.GetEndPartner();
                    if (flag == 0)
                    {
                        tbl_CompanyDAO comDAO = new tbl_CompanyDAO();
                        cbCompany.Text = comDAO.GetEndCom();
                    }
                }
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidData())
                {
                    tbl_ProjectDTO project = new tbl_ProjectDTO()
                    {
                        Name = txtName.Text,
                        PartnerId = int.Parse(cbPartner.Text.Split(':')[1].Trim()),
                        AdvancePayment = float.Parse(txtAdPayment.Text),
                        Cost = float.Parse(txtCost.Text),
                        BeginTime = dateStart.Value
                    };

                    if (!string.IsNullOrWhiteSpace(txtDescription.Text))
                    {
                        project.Description = txtDescription.Text;
                    }
                    if (chbDone.Checked)
                    {
                        project.Status = "Done";
                        project.Deadline = dateDeadline.Value;
                        project.EndTime = dateEnd.Value;
                    }
                    else
                    {
                        project.Status = "Doing...";
                    }

                    tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
                    bool result = projectDAO.Insert(project);
                    if (result)
                    {
                        if (listEmployee.Count() > 0)
                        {
                            tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                            foreach (tbl_EmployeeDTO employee in listEmployee)
                            {
                                joinDAO.Insert(projectDAO.GetEndId(), employee.Id);
                            }
                        }
                        MessageBox.Show("Add new project successfull");
                    } else
                    {
                        tbl_PartnerDAO dao = new tbl_PartnerDAO();
                        dao.Delete(project.PartnerId);
                        if (flag == 0)
                        {
                            tbl_CompanyDAO comDAO = new tbl_CompanyDAO();
                            comDAO.Delete(int.Parse(cbCompany.Text.Split(':')[1].Trim()));
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public bool ValidData()
        {
            bool valid = true;
            error.Clear();
            // partner
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                error.SetError(txtName, "Partner's name must not be blank!");
                valid = false;
            }
            if (!FormatData.FormatFloat(txtAdPayment.Text))
            {
                error.SetError(txtAdPayment, "Wrong format!");
                valid = false;
            }
            if (!FormatData.FormatFloat(txtCost.Text))
            {
                error.SetError(txtCost, "Wrong format!");
                valid = false;
            }
            if (FormatData.FormatFloat(txtAdPayment.Text) && FormatData.FormatFloat(txtCost.Text))
            {
                if (float.Parse(txtCost.Text) < float.Parse(txtAdPayment.Text))
                {
                    error.SetError(txtCost, "Not valid!");
                    valid = false;
                }
            }
            if (dateStart.Value > dateDeadline.Value)
            {
                error.SetError(dateDeadline, "Deadline time must smaller time start project");
                valid = false;
            }
            if (chbDone.Checked)
            {
                if (dateEnd.Value < dateStart.Value || dateEnd.Value < dateDeadline.Value)
                {
                    error.SetError(dateEnd, "End date must be larger time start project and deadline time");
                    valid = false;
                }
            }
            if (string.IsNullOrWhiteSpace(cbCompany.Text))
            {
                error.SetError(cbCompany, "Please set company!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(cbPartner.Text))
            {
                error.SetError(cbPartner, "Please set partner!");
                valid = false;
            }

            return valid;
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
        {

            try
            {
                string[] employeeInf = cbEmployee.SelectedItem.ToString().Split(':');
                string id = employeeInf[1].Trim().Split('(')[0].Trim();
                int flag = 0;
                if (listEmployee.Count() != 0)
                {
                    foreach (tbl_EmployeeDTO item in listEmployee)
                    {
                        if (item.Id == int.Parse(id))
                        {
                            flag++;
                        }
                    }
                }

                if (flag > 0)
                {
                    MessageBox.Show("The employee is already exited in project!");
                }
                else
                {
                    foreach (tbl_EmployeeDTO dto in listAllEmp)
                    {
                        if (dto.Id == int.Parse(id))
                        {
                            listEmployee.Add(dto);
                            //tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                            //joinDAO.Insert(int.Parse(txtID.Text), dto.Id);
                            gvListEmployee.DataSource = null;
                            gvListEmployee.DataSource = listEmployee;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Add employee not successfull!");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (gvListEmployee.RowCount > 0)
            {
                int empID = int.Parse(gvListEmployee.CurrentRow.Cells[0].Value.ToString());
                foreach (tbl_EmployeeDTO item in listEmployee)
                {
                    if (item.Id == empID)
                    {
                        listEmployee.Remove(item);
                        //tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                        //joinDAO.DeleteByProID_EmID(int.Parse(txtID.Text), empID);
                        gvListEmployee.DataSource = null;
                        gvListEmployee.DataSource = listEmployee;
                        return;
                    }
                }
            }
        }
    }
}
