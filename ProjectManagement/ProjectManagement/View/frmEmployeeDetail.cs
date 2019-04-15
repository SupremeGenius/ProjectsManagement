using ProjectManagement.DAO;
using ProjectManagement.DTO;
using ProjectManagement.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectManagement.View
{
    public partial class frmEmployeeDetail : Form
    {
        public int EmId { get; set; }
        private static frmEmployeeDetail form;
        private tbl_EmployeeDTO currentEm;
        List<tbl_ProjectDTO> listProject;
        bool SaveMode = true;
        public frmEmployeeDetail()
        {
            InitializeComponent();
        }

        public static frmEmployeeDetail GetInstance()
        {
            if (form == null)
            {
                form = new frmEmployeeDetail();
            }
            return form;
        }

        private void frmEmployeeDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            Check_Save();
            if (!SaveMode)
            {
                if (MessageBox.Show("Employee Information was edited. Do you want to save it?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnUpdate_Click(sender, e);
                }
            }
            SaveMode = true;
            form = null;
        }

        /// <summary>
        /// Load employee information
        /// </summary>
        private void frmEmployeeDetail_Load(object sender, EventArgs e)
        {
            try
            {
                tbl_EmployeeDAO emDAO = new tbl_EmployeeDAO();
                currentEm = emDAO.GetById(EmId);
                txtId.Text = currentEm.Id.ToString();
                txtName.Text = currentEm.Name;
                txtAddress.Text = currentEm.Address;
                birthday.Value = currentEm.Birthday;
                txtPhone.Text = currentEm.Phone;
                txtEmail.Text = currentEm.Email;
                string[] role = currentEm.Role.Split('-');
                cbPosition.Text = role[1].Trim().ToUpper();
                tbl_RoleDAO roleDAO = new tbl_RoleDAO();
                roleDAO.GetAll(ref cbPosition);
                txtSalary.Text = currentEm.Salary.ToString();

                // display list project
                tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                List<int> listProId = joinDAO.GetListProjectByEmId(EmId);
                tbl_ProjectDAO projectDAO = new tbl_ProjectDAO();
                listProject = new List<tbl_ProjectDTO>();
                foreach (int id in listProId)
                {
                    listProject.Add(projectDAO.GetById(id));
                }
                gvProject.DataSource = listProject;

                // load all project
                List<string> items = projectDAO.GetAllProject();
                cbProject.DataSource = items;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// add project
        /// </summary>
        private void btnJoin_Click(object sender, EventArgs e)
        {
            try
            {
                string projectItem = cbProject.SelectedItem.ToString();
                int projectID = int.Parse(projectItem.Split(':')[1].Trim());
                tbl_ProjectDAO dao = new tbl_ProjectDAO();
                int flag = 0;
                foreach (tbl_ProjectDTO dto in listProject)
                {
                    if (dto.Id == projectID)
                    {
                        MessageBox.Show(txtName.Text + " already joined in this project!");
                        flag++;
                        return;
                    }
                }
                if (flag == 0)
                {
                    tbl_ProjectDTO project = dao.GetById(projectID);

                    // insert db
                    tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                    bool resutl = joinDAO.Insert(projectID, int.Parse(txtId.Text));
                    if (resutl)
                    {
                        listProject.Add(project);
                        gvProject.DataSource = null;
                        gvProject.DataSource = listProject;
                    }
                    else
                        MessageBox.Show("Error");

                }
            }
            catch (Exception)
            {
            }


        }

        /// <summary>
        /// Update employee information
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                SaveMode = true;
                try
                {
                    tbl_EmployeeDTO employee = new tbl_EmployeeDTO()
                    {
                        Id = int.Parse(txtId.Text),
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Birthday = birthday.Value,
                        Phone = txtPhone.Text,
                        Role = cbPosition.Text.ToString(),
                        Email = txtEmail.Text,
                        Salary = float.Parse(txtSalary.Text),
                    };
                    tbl_EmployeeDAO dao = new tbl_EmployeeDAO();
                    bool result = dao.Update(employee);
                    if (result)
                    {
                        SaveMode = true;
                        MessageBox.Show("Update successfull!");
                    }
                    else MessageBox.Show("Update not successfull!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// valid employee data edit
        /// </summary>
        public bool ValidData()
        {
            bool valid = true;
            error.Clear();
            // partner
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                error.SetError(txtName, "Employee's name must not be blank!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                error.SetError(txtAddress, "Employee's address must not be blank!");
                valid = false;
            }
            if (birthday.Value >= DateTime.Now)
            {
                error.SetError(birthday, "Not valid!");
                valid = false;
            }
            if (!FormatData.FormatPhone(txtPhone.Text))
            {
                error.SetError(txtPhone, "Wrong format!");
                valid = false;
            }
            if (!FormatData.FormatEmail(txtEmail.Text))
            {
                error.SetError(txtEmail, "Wrong format!");
                valid = false;
            }
            if (!FormatData.FormatFloat(txtSalary.Text))
            {
                error.SetError(txtSalary, "Wrong format!");
                valid = false;
            }
            return valid;
        }
        /// <summary>
        /// Check save
        /// </summary>
        public void Check_Save()
        {
            if (!SaveMode)
            {
                if (ValidData())
                {
                    tbl_EmployeeDTO now = new tbl_EmployeeDTO()
                    {
                        Id = int.Parse(txtId.Text),
                        Name = txtName.Text,
                        Address = txtAddress.Text,
                        Birthday = birthday.Value,
                        Phone = txtPhone.Text,
                        Role = cbPosition.Text.ToString(),
                        Email = txtEmail.Text,
                        Salary = float.Parse(txtSalary.Text),
                    };
                    FormatData format = new FormatData();
                    if (format.Check_Save(currentEm, now))
                    {
                        SaveMode = true;
                    }
                    else
                        SaveMode = false;
                }
            }


        }

        /// <summary>
        /// Remove project
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want remove "+ txtName.Text + " from project "+ gvProject.CurrentRow.Cells[1].Value.ToString()+" ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int projectID = int.Parse(gvProject.CurrentRow.Cells[0].Value.ToString());
                    foreach (tbl_ProjectDTO item in listProject)
                    {
                        if (item.Id == projectID)
                        {
                            listProject.Remove(item);
                            tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                            joinDAO.DeleteByProID_EmID(projectID, int.Parse(txtId.Text));
                            gvProject.DataSource = null;
                            gvProject.DataSource = listProject;
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        /// <summary>
        /// button close
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }

}

