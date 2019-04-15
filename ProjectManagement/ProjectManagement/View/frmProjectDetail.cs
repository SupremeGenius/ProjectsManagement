using ProjectManagement.DAO;
using ProjectManagement.DTO;
using ProjectManagement.Model.BLL;
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
    public partial class frmProjectDetail : Form
    {

        private static frmProjectDetail form;
        public string PartnerInfor { get; set; }
        public string ComName { get; set; }
        public int ProjectId { get; set; }
        List<tbl_EmployeeDTO> listEmployee;
        List<tbl_EmployeeDTO> listFirt;
        List<tbl_EmployeeDTO> listEmpAdd = new List<tbl_EmployeeDTO>();
        List<tbl_EmployeeDTO> listAllEmp = new List<tbl_EmployeeDTO>();
        bool SaveMode = true;
        tbl_ProjectDTO currentDTO;
        public frmProjectDetail()
        {
            InitializeComponent();
        }

        public static frmProjectDetail GetInstance()
        {
            if (form == null)
            {
                form = new frmProjectDetail();
            }
            return form;
        }
        //
        //load project detail
        //
        private void frmProjectManagement_Load(object sender, EventArgs e)
        {
            lbCompanyName.Text = ComName;
            lbPartnerInfor.Text = PartnerInfor;
            tbl_ProjectDAO dao = new tbl_ProjectDAO();
            tbl_ProjectDTO dto = dao.GetById(ProjectId);
            currentDTO = dto;

            txtID.Text = dto.Id.ToString();
            txtName.Text = dto.Name;
            txtDescription.Text = dto.Description;
            lbStatus.Text = dto.Status;
            txtAdPayment.Text = dto.AdvancePayment.ToString();
            txtCost.Text = dto.Cost.ToString();
            dateStart.Value = dto.BeginTime;
            if (dto.Deadline != null)
            {
                dateDeadline.Value = dto.Deadline.Value;
            }
            if (dto.Status.Equals("Doing..."))
            {
                chbDone.Visible = true;
                chbDone.Checked = false;
                dateEnd.Visible = false;
                lbStatus.BackColor = Color.Red;
            }
            else
            {
                chbDone.Checked = true;
                dateEnd.Visible = true;
                dateEnd.Value = dto.EndTime.Value;
                lbStatus.BackColor = Color.Blue;
            }
            // display list employee
            tbl_JoiningDAO joiningDAO = new tbl_JoiningDAO();
            List<int> employeeIDs = joiningDAO.GetListEmIDByProjectId(ProjectId);
            listEmployee = new List<tbl_EmployeeDTO>();
            listFirt = listEmployee;
            tbl_EmployeeDAO emDAO = new tbl_EmployeeDAO();
            foreach (var emId in employeeIDs)
            {
                listEmployee.Add(emDAO.GetById(emId));
            }
            gvListEmployee.DataSource = listEmployee;
            // display domainEmployee
            listAllEmp = emDAO.GetAllEmployee();
            List<String> itemsCbEmployee = new List<string>();
            foreach (tbl_EmployeeDTO employee in listAllEmp)
            {
                itemsCbEmployee.Add(employee.Name + " - ID :" + employee.Id + " (" + employee.Role + ")");
            }
            cbEmployee.DataSource = itemsCbEmployee;
        }
        //
        // close form
        //
        private void frmProjectManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Check_Save();
            if (!SaveMode)
            {
                if (MessageBox.Show("Project Information was edited. Do you want to save it?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnUpdate_Click(sender, e);
                }
            }
            SaveMode = true;
            form = null;
        }
        //
        // check done
        //
        private void chbDone_CheckedChanged(object sender, EventArgs e)
        {
            if (chbDone.Checked == true)
            {
                dateEnd.Visible = true;
                dateEnd.Value = DateTime.Now;
                lbStatus.Text = "Done";
                lbStatus.BackColor = Color.Blue;

            }
            else
            {
                dateEnd.Visible = false;
                lbStatus.Text = "Doing...";
                lbStatus.BackColor = Color.Red;
            }
        }
        //
        // add employee
        //
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            try
            {
                string[] employeeInf = cbEmployee.SelectedItem.ToString().Split(':');
                string id = employeeInf[1].Trim().Split('(')[0].Trim();
                int flag = 0;
                foreach (tbl_EmployeeDTO item in listEmployee)
                {
                    if (item.Id == int.Parse(id))
                    {
                        flag++;
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
                            tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                            joinDAO.Insert(int.Parse(txtID.Text), dto.Id);
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
        //
        //Remove Employee from project
        //
        private void btnDeleteEmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want remove " + gvListEmployee.CurrentRow.Cells[1].Value.ToString() + " from project?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int empID = int.Parse(gvListEmployee.CurrentRow.Cells[0].Value.ToString());
                    foreach (tbl_EmployeeDTO item in listEmployee)
                    {
                        if (item.Id == empID)
                        {
                            listEmployee.Remove(item);
                            tbl_JoiningDAO joinDAO = new tbl_JoiningDAO();
                            joinDAO.DeleteByProID_EmID(int.Parse(txtID.Text), empID);
                            gvListEmployee.DataSource = null;
                            gvListEmployee.DataSource = listEmployee;
                            return;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Remove employee not successfull!");
            }

        }

        //
        //update 
        //
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ValidData())
            {
                SaveMode = true;
                try
                {
                    tbl_ProjectDTO project = new tbl_ProjectDTO()
                    {
                        Id = int.Parse(txtID.Text),
                        Name = txtName.Text,
                        AdvancePayment = float.Parse(txtAdPayment.Text),
                        Cost = float.Parse(txtCost.Text),
                        BeginTime = dateStart.Value,
                        Deadline = dateDeadline.Value,
                        Description = txtDescription.Text,
                        Status = lbStatus.Text
                    };
                    if (lbStatus.Text.Equals("Done"))
                    {
                        project.EndTime = dateEnd.Value;
                    } else
                        project.EndTime = null;
                    tbl_ProjectDAO dao = new tbl_ProjectDAO();
                    bool result = dao.Update(project);
                    if (result)
                    {
                        SaveMode = true;
                        MessageBox.Show("Update successfull!");
                    }
                    else MessageBox.Show("Update not successfull!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Update not successfull!");
                }
            }


        }
        //
        //Valid data update
        //
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
            if (lbStatus.Text.Equals("Done"))
            {
                if (dateEnd.Value < dateStart.Value || dateEnd.Value < dateDeadline.Value)
                {
                    error.SetError(dateEnd, "End date must be larger time start project and deadline time");
                    valid = false;
                }
            }
            return valid;
        }

        //
        //check save
        //
        public void Check_Save()
        {
            if (!SaveMode)
            {
                if (ValidData())
                {
                    tbl_ProjectDTO now = new tbl_ProjectDTO()
                    {
                        Id = int.Parse(txtID.Text),
                        Name = txtName.Text,
                        Status = lbStatus.Text,
                        AdvancePayment = float.Parse(txtAdPayment.Text),
                        Cost = float.Parse(txtCost.Text),
                        BeginTime = dateStart.Value,
                        Deadline = dateDeadline.Value,
                        EndTime = dateEnd.Value,
                        Description = txtDescription.Text
                    };
                    tbl_ProjectBLL bll = new tbl_ProjectBLL();
                    if (bll.Check_Save(currentDTO, now))
                    {
                        SaveMode = true;
                    }
                    else
                        SaveMode = false;
                }
            }


        }
        //
        // button close
        //
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
