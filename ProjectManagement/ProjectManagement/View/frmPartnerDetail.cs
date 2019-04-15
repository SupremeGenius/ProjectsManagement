using ProjectManagement.BLL;
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

namespace ProjectManagement.GUI
{
    public partial class frmPartnerManagement : Form
    {
        public string Page { get; set; }
        public int ComanyId { get; set; }
        public string PartnerInfor { get; set; }
        public tbl_PartnerDTO NewPartner { get; set; }

        bool saveFrmPartner;
        tbl_CompanyDTO currentCom;
        tbl_PartnerDTO currentPartner;
        private static frmPartnerManagement frmPartner;
        public frmPartnerManagement()
        {
            InitializeComponent();
        }

        public static frmPartnerManagement GetInstance()
        {
            if (frmPartner == null)
            {
                frmPartner = new frmPartnerManagement();
            }
            return frmPartner;
        }
        // load partner and company infor with 2 case
        private void frmPartnerManagement_Load(object sender, EventArgs e)
        {
            saveFrmPartner = true;
            if (Page.Equals("Project-Company") || Page.Equals("Employee-Project"))
            {
                LoadFrm_PC_Page(ComanyId, PartnerInfor);
            }
            if (Page.Equals("New_Project"))
            {
                btnUpdate.Text = "ADD NEW";
            }
            if (Page.Equals("New_Project_CP"))
            {
                LoadCompanyInfor();
            }

        }

        public void LoadFrm_PC_Page(int companyId, string partnerInfor)
        {
            btnUpdate.Text = "UPDATE";
            // load company infor
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            tbl_CompanyDTO company = companyDAO.GetById(companyId);
            txtComId.Text = companyId.ToString();
            txtCompanyName.Text = company.Name.ToUpper();
            txtComAddress.Text = company.Address;
            txtCompanyEmail.Text = company.Email.ToLower();
            txtBankNumber.Text = company.BankNumber;

            currentCom = company;

            // load partner infor
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            tbl_PartnerDTO partner = partnerDAO.GetByName_Phone_CompanyId(partnerInfor, companyId);
            txtPartnerId.Text = partner.Id.ToString();
            txtPartnerName.Text = partner.Name.ToUpper();
            txtPosition.Text = partner.Position;
            txtPartnerPhone.Text = partner.Phone;
            txtPartnerEmail.Text = partner.Email;
            txtPartnerAdd.Text = partner.Address;

            currentPartner = partner;
        }

        public void LoadCompanyInfor()
        {
            // load company infor
            tbl_CompanyDAO companyDAO = new tbl_CompanyDAO();
            tbl_CompanyDTO company = companyDAO.GetById(ComanyId);
            txtComId.Text = ComanyId.ToString();
            txtCompanyName.Text = company.Name.ToUpper();
            txtCompanyName.Enabled = false;
            txtComAddress.Text = company.Address;
            txtComAddress.Enabled = false;
            txtCompanyEmail.Text = company.Email.ToLower();
            txtCompanyEmail.Enabled = false;
            txtBankNumber.Text = company.BankNumber;
            txtBankNumber.Enabled = false;

            btnUpdate.Text = "ADD NEW";

        }
        // close
        private void frmPartnerManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            Check_Save();
            if (!saveFrmPartner)
            {
                if (MessageBox.Show("Partner Information was edited. Do you want to save it?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnUpdate_Click(sender, e);
                }
            }
            saveFrmPartner = true;
            frmPartner = null;
        }



        public bool ValidData()
        {
            bool valid = true;
            error.Clear();
            // partner
            if (string.IsNullOrWhiteSpace(txtPartnerName.Text))
            {
                error.SetError(txtPartnerName, "Partner's name must not be blank!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                error.SetError(txtPosition, "Partner's postiton must not be blank!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtPartnerPhone.Text))
            {
                error.SetError(txtPartnerPhone, "Partner's phone must not be blank!");
                valid = false;
            }
            else
            {
                if (!FormatData.FormatNumber(txtPartnerPhone.Text))
                {
                    error.SetError(txtPartnerPhone, "Wrong format!");
                    valid = false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtPartnerEmail.Text))
            {
                error.SetError(txtPartnerEmail, "Partner's email must not be blank!");
                valid = false;
            }
            else
            {
                if (!FormatData.FormatEmail(txtPartnerEmail.Text.Trim()))
                {
                    error.SetError(txtPartnerEmail, "Wrong format!");
                    valid = false;
                }
            }
            // company
            if (string.IsNullOrWhiteSpace(txtCompanyName.Text))
            {
                error.SetError(txtCompanyName, "Company's name must not be blank!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtCompanyEmail.Text))
            {
                error.SetError(txtCompanyEmail, "Company's email must not be blank!");
                valid = false;
            }
            else
            {
                if (!FormatData.FormatEmail(txtCompanyEmail.Text.Trim()))
                {
                    error.SetError(txtCompanyEmail, "Wrong format!");
                    valid = false;
                }
            }
            if (string.IsNullOrWhiteSpace(txtComAddress.Text))
            {
                error.SetError(txtComAddress, "Company's address must not be blank!");
                valid = false;
            }
            if (string.IsNullOrWhiteSpace(txtBankNumber.Text))
            {
                error.SetError(txtBankNumber, "Company's bank number must not be blank!");
                valid = false;
            }
            else
            {
                if (!FormatData.FormatNumber(txtBankNumber.Text))
                {
                    error.SetError(txtBankNumber, "Wrong format!");
                    valid = false;
                }
            }
            return valid;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Page.Equals("Project-Company") || Page.Equals("Employee-Project"))
            {
                if (ValidData())
                {
                    try
                    {
                        // company
                        int comId = int.Parse(txtComId.Text.Trim());
                        string comName = txtCompanyName.Text.Trim();
                        string email = txtCompanyEmail.Text.Trim();
                        string address = txtComAddress.Text.Trim();
                        string bankNumber = txtBankNumber.Text.Trim();
                        tbl_CompanyDTO company = new tbl_CompanyDTO(comId, comName, address, email, bankNumber, false);
                        tbl_CompanyDAO comDAO = new tbl_CompanyDAO();
                        bool updateCompany = comDAO.Update(company);
                        if (updateCompany)
                        {
                            int partnerId = int.Parse(txtPartnerId.Text.Trim());
                            string name = txtPartnerName.Text.Trim();
                            string position = txtPosition.Text.Trim();
                            string partAdd = txtPartnerAdd.Text.Trim();
                            string phone = txtPartnerPhone.Text.Trim();
                            string partEmail = txtPartnerEmail.Text.Trim();
                            tbl_PartnerDTO partner = new tbl_PartnerDTO(partnerId, name, position, partAdd, phone, comId, partEmail);
                            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
                            bool updatePartner = partnerDAO.Update(partner);

                            if (updatePartner)
                            {
                                currentPartner = partner;
                                currentCom = company;
                                saveFrmPartner = true;
                                MessageBox.Show("Update Successful!");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            // add
            if (Page.Equals("New_Project"))
            {
                AddNewCompany();
            }
            if (Page.Equals("New_Project_CP"))
            {
                AddNewPartner();
            }
        }

        public void AddNewCompany()
        {
            if (ValidData())
            {
                try
                {
                    // company
                    tbl_CompanyDTO company = new tbl_CompanyDTO()
                    {
                        Name = txtCompanyName.Text.Trim(),
                        Email = txtCompanyEmail.Text.Trim(),
                        Address = txtComAddress.Text.Trim(),
                        BankNumber = txtBankNumber.Text.Trim(),
                    };
                    tbl_CompanyDAO comDAO = new tbl_CompanyDAO();
                    bool insertCompany = comDAO.Insert(company);
                    if (insertCompany)
                    {
                        int comId = int.Parse(comDAO.GetEndCom().Split(':')[1].Trim());
                        tbl_PartnerDTO partner = new tbl_PartnerDTO()
                        {
                            Name = txtPartnerName.Text.Trim(),
                            Position = txtPosition.Text.Trim(),
                            Address = txtPartnerAdd.Text.Trim(),
                            Phone = txtPartnerPhone.Text.Trim(),
                            Email = txtPartnerEmail.Text.Trim(),
                            CompanyId = comId,
                        };
                    tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
                    bool insetPartner = partnerDAO.Insert(partner);

                    if (insetPartner)
                    {
                        currentPartner = partner;
                        currentCom = company;
                        saveFrmPartner = true;
                        this.Close();
                    }
                }

                }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public void AddNewPartner()
    {
        if (ValidData())
        {
            NewPartner = new tbl_PartnerDTO()
            {
                Name = txtPartnerName.Text.Trim(),
                Position = txtPosition.Text.Trim(),
                Address = txtPartnerAdd.Text.Trim(),
                Phone = txtPartnerPhone.Text.Trim(),
                Email = txtPartnerEmail.Text.Trim(),
                CompanyId = int.Parse(txtComId.Text.Trim()),
            };
            tbl_PartnerDAO partnerDAO = new tbl_PartnerDAO();
            bool result = partnerDAO.Insert(NewPartner);
            if (result)
            {
                this.Close();
            }

        }
    }

    // close

    public void Check_Save()
    {
        if (Page.Equals("Project-Company") || Page.Equals("Employee-Project"))
        {
            int comId = int.Parse(txtComId.Text.Trim());
            string comName = txtCompanyName.Text.Trim();
            string email = txtCompanyEmail.Text.Trim();
            string address = txtComAddress.Text.Trim();
            string bankNumber = txtBankNumber.Text.Trim();
            tbl_CompanyDTO company = new tbl_CompanyDTO(comId, comName, address, email, bankNumber, false);

            int partnerId = int.Parse(txtPartnerId.Text.Trim());
            string name = txtPartnerName.Text.Trim();
            string position = txtPosition.Text.Trim();
            string partAdd = txtPartnerAdd.Text.Trim();
            string phone = txtPartnerPhone.Text.Trim();
            string partEmail = txtPartnerEmail.Text.Trim();
            tbl_PartnerDTO partner = new tbl_PartnerDTO(partnerId, name, position, partAdd, phone, comId, email);

            tbl_CompanyBLL companyBLL = new tbl_CompanyBLL();
            tbl_PartnerBLL partnerBLL = new tbl_PartnerBLL();
            if (companyBLL.Check_Save(currentCom, company) && partnerBLL.Check_Save(currentPartner, partner))
            {
                saveFrmPartner = true;
            }
            else
                saveFrmPartner = false;
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("Do you want to exit?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            this.Close();
        }

    }
}
}
