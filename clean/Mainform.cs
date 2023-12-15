using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using clean;
using clean.Models;
using clean.Services;

namespace CleaningManagementSystem
{
    public partial class MainForm : Form
    {
        private DateTimePicker dtpStartDate;
        private ComboBox cmbEmployeeSelection;

        private TextBox txtSelectedService;
        private OfferManager offerManager;
        private EmployeeManager employeeManager;
        private CleaningServiceManager cleaningServiceManager;
        private DiscountManager discountManager;

        private TextBox txtOfferTitle;
        private TextBox txtCustomerName;
        private TextBox txtCustomerAddress;
        private TextBox txtCustomerEmail;
        private TextBox txtCustomerPhone;

        private ListBox lstOffers;
        private ListBox lstEmployees;
        private Button btnCreateOffer;
        private ComboBox cmbEmployees;
        private Button btnAssignEmployee;
        private ComboBox cmbServices;
        private Button btnSelectService;
        private ComboBox cmbDiscounts;
        private Button btnApplyDiscount;
        private Label lblOfferDetails;

        public MainForm()
        {
            InitializeComponent();

            offerManager = new OfferManager();
            employeeManager = new EmployeeManager();
            cleaningServiceManager = new CleaningServiceManager();
            discountManager = new DiscountManager();
            offerManager.LoadOffersFromJson();  

            UpdateOffersListBox();
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new Size(1232, 690);

            InitializeTextboxes();
            InitializeListBox();
            InitializeButtons();
            InitializeLabels();
            InitializeComboBoxes();
           
            this.ResumeLayout(false);
        }
        private void InitializeComboBoxes()
        {
            cmbEmployees = CreateComboBox(new Point(400, 220));
            cmbEmployeeSelection = CreateComboBox(new Point(400, 270));
            cmbServices = CreateComboBox(new Point(400, 260));
            dtpStartDate = CreateDateTimePicker(new Point(400, 210));

            cmbEmployees.Hide();
            cmbEmployeeSelection.Hide();
            cmbServices.Hide();
            this.Controls.AddRange(new Control[] { cmbEmployees, cmbEmployeeSelection, cmbServices, dtpStartDate });
        }



        private void InitializeTextboxes()
        {
            txtOfferTitle = CreateTextBox(new Point(400, 20));
            txtCustomerName = CreateTextBox(new Point(400, 60));
            txtCustomerAddress = CreateTextBox(new Point(400, 100));
            txtCustomerEmail = CreateTextBox(new Point(400, 140));
            txtCustomerPhone = CreateTextBox(new Point(400, 180));
            
            
            
            
            this.Controls.Add(txtSelectedService);
            this.Controls.AddRange(new Control[] { txtOfferTitle, txtCustomerName, txtCustomerAddress, txtCustomerEmail, txtCustomerPhone, cmbEmployees, cmbServices, dtpStartDate });
        }

        private ComboBox CreateComboBox(Point location)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Location = location;
            comboBox.Size = new Size(200, 20);
            
            return comboBox;
        }

        private DateTimePicker CreateDateTimePicker(Point location)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Location = location;
            dateTimePicker.Size = new Size(200, 20);
            
            return dateTimePicker;
        }

private void lstEmployees_SelectedIndexChanged(object sender, EventArgs e)
{
    
    
}

        private void InitializeListBox()
        {
            lstOffers = new ListBox();
            lstOffers.SelectedIndexChanged += lstOffers_SelectedIndexChanged;
            lstOffers.Location = new Point(10, 300);
            lstOffers.Size = new Size(1228, 300); 

            lstEmployees = new ListBox();
            lstEmployees.SelectedIndexChanged += lstEmployees_SelectedIndexChanged;
            lstEmployees.Location = new Point(220, 600);
            lstEmployees.Size = new Size(0, 0); 

            this.Controls.AddRange(new Control[] { lstOffers, lstEmployees });
        }
        private void InitializeButtons()
        {
            btnCreateOffer = CreateButton("Create Offer", new Point(10, 240), btnCreateOffer_Click);
            btnAssignEmployee = CreateButton("Assign Employee", new Point(180, 240), btnAssignEmployee_Click);
            
            

            
            btnApplyDiscount = CreateButton("Apply Discount", new Point(350, 240), btnApplyDiscount_Click);

            this.Controls.AddRange(new Control[] { btnCreateOffer, btnAssignEmployee, btnSelectService, btnApplyDiscount });
        }

        private void InitializeLabels()
        {
            Label lblOfferTitle = CreateLabel("Offer Title", new Point(10, 20));
            Label lblCustomerName = CreateLabel("Customer Name", new Point(10, 60));
            Label lblCustomerAddress = CreateLabel("Customer Address", new Point(10, 100));
            Label lblCustomerEmail = CreateLabel("Customer Email", new Point(10, 140));
            Label lblCustomerPhone = CreateLabel("Customer Phone", new Point(10, 180));

            
            
            
            

            Label lblOfferDetailsTitle = CreateLabel("Offer Details", new Point(10, 380));

            this.Controls.AddRange(new Control[] { lblOfferTitle, lblCustomerName, lblCustomerAddress, lblCustomerEmail, lblCustomerPhone,
                                           lblOfferDetailsTitle });
        }

        private TextBox CreateTextBox(Point location)
        {
            TextBox textBox = new TextBox();
            textBox.Location = location;
            textBox.Size = new Size(300, 20);
            return textBox;
        }

        private void btnSelectService_Click(object sender, EventArgs e)
        {
            
            List<CleaningService> availableServices = cleaningServiceManager.GetAllCleaningServices();

            
            CleaningService selectedService = ShowServiceSelectionDialog(availableServices);

            if (selectedService != null)
            {
                
                
                txtSelectedService.Text = selectedService.ToString();
            }
        }

        
        private CleaningService ShowServiceSelectionDialog(List<CleaningService> availableServices)
        {
            
            
            
            return null;
        }


        private Button CreateButton(string text, Point location, EventHandler clickHandler)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = location;
            button.Click += clickHandler;
            button.BackColor = Color.FromArgb(0, 122, 204);
            button.ForeColor = Color.White;
            button.FlatStyle = FlatStyle.Flat;
            button.Size = new Size(150, 30);
            return button;
        }

        private Label CreateLabel(string text, Point location)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = location;
            label.Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold);
            label.ForeColor = Color.Black;
            label.Size = new Size(150, 20);
            return label;
        }

        private void InitializeSampleData()
        {

            Label lblOfferTitle = CreateLabel("Offer Title", new Point(10, 10));
            Label lblCustomerName = CreateLabel("Customer Name", new Point(10, 40));
            Label lblCustomerAddress = CreateLabel("Customer Address", new Point(10, 70));
            Label lblCustomerEmail = CreateLabel("Customer Email", new Point(10, 100));
            Label lblCustomerPhone = CreateLabel("Customer Phone", new Point(10, 130));


            Label lblSelectedOffer = CreateLabel("Selected Offer: ", new Point(10, 170));
            Label lblSelectedEmployee = CreateLabel("Selected Employee: ", new Point(10, 200));
            Label lblSelectedService = CreateLabel("Selected Service: ", new Point(10, 230));
            Label lblSelectedDiscount = CreateLabel("Selected Discount: ", new Point(10, 260));


            Label lblOfferDetailsTitle = CreateLabel("Offer Details", new Point(10, 300));


            this.Controls.AddRange(new Control[] { lblOfferTitle, lblCustomerName, lblCustomerAddress, lblCustomerEmail, lblCustomerPhone,
                                           lblSelectedOffer, lblSelectedEmployee, lblSelectedService, lblSelectedDiscount, lblOfferDetailsTitle });


            employeeManager.AddEmployee(new Employee { EmployeeNumber = 1, Name = "John Doe" });
            cleaningServiceManager.AddCleaningService(new CleaningService { ServiceNumber = 1, ServiceName = "General Cleaning", Price = 100 });
            discountManager.AddDiscount(new Discount { DiscountName = "Employee Discount", Percentage = 0.05m });
        }

        private void btnCreateOffer_Click(object sender, EventArgs e)
        {

            string offerTitle = txtOfferTitle.Text;
            string customerName = txtCustomerName.Text;
            string customerAddress = txtCustomerAddress.Text;
            string customerEmail = txtCustomerEmail.Text;
            string customerPhone = txtCustomerPhone.Text;


            Customer customer = new Customer
            {
                Name = customerName,
                Address = customerAddress,
                Email = customerEmail,
                Phone = customerPhone
            };

            Employee contactPerson = GetContactPerson();
            List<CleaningService> selectedServices = GetSelectedServices();

            offerManager.CreateOffer(offerTitle, customer, contactPerson, selectedServices);

            UpdateOffersListBox();

            MessageBox.Show("Offer created successfully!");
        }

        private void UpdateEmployeesListBox()
        {
            List<Employee> allEmployees = employeeManager.GetAllEmployees();

            
            lstEmployees.DisplayMember = "Name";  

            lstEmployees.DataSource = null;
            lstEmployees.DataSource = allEmployees;
        }


        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            if (lstOffers.SelectedItem != null)
            {
                Offer selectedOffer = (Offer)lstOffers.SelectedItem;

                List<Employee> availableEmployees = employeeManager.GetAllEmployees();

                
                cmbEmployeeSelection.Items.Clear();
                cmbEmployeeSelection.Items.AddRange(availableEmployees.ToArray());

                Employee selectedEmployee = ShowEmployeeSelectionDialog(availableEmployees);

                if (selectedEmployee != null)
                {
                    
                    employeeManager.AddEmployee(selectedEmployee);

                    MessageBox.Show($"Employee {selectedEmployee.Name} assigned to Offer {selectedOffer.Title}!");
                }
            }
            else
            {
                MessageBox.Show("Please select an offer before assigning an employee.");
            }
        }



        private void UpdateOffersListBox()
        {

            List<Offer> allOffers = offerManager.GetAllOffers();

            
            lstOffers.DisplayMember = "Title";  

            lstOffers.DataSource = null;
            lstOffers.DataSource = allOffers;
        }


        private void lstOffers_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private List<Employee> GetAllEmployees()
        {


            return employeeManager.GetAllEmployees();
        }
        private Employee GetContactPerson()
        {
            List<Employee> allEmployees = GetAllEmployees();
            Employee selectedEmployee = ShowEmployeeSelectionDialog(allEmployees);

            return selectedEmployee;
        }
        private Employee ShowEmployeeSelectionDialog(List<Employee> availableEmployees)
        {
            cmbEmployeeSelection.Items.AddRange(availableEmployees.ToArray());

            DialogResult result = MessageBox.Show("Select an employee:", "Employee Selection", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK && cmbEmployeeSelection.SelectedItem != null)
            {
                return (Employee)cmbEmployeeSelection.SelectedItem;
            }
            else
            {
                return null;
            }
        }

        private List<CleaningService> GetSelectedServices()
        {
            List<CleaningService> services = new List<CleaningService>();


            List<CleaningService> availableServices = new List<CleaningService>
    {
        new CleaningService { ServiceNumber = 1, ServiceName = "Service 1", Price = 50 },
        new CleaningService { ServiceNumber = 2, ServiceName = "Service 2", Price = 75 },

    };


            foreach (var service in availableServices)
            {
                DialogResult result = MessageBox.Show($"Include {service.ServiceName}?", "Service Selection", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    services.Add(service);
                }
            }

            return services;
        }
        private void btnApplyDiscount_Click(object sender, EventArgs e)
        {
            
            if (lstOffers.SelectedItem != null)
            {
                Offer selectedOffer = (Offer)lstOffers.SelectedItem;

                
                List<Discount> availableDiscounts = discountManager.GetAllDiscounts();

                
                Discount selectedDiscount = ShowDiscountSelectionDialog(availableDiscounts);

                if (selectedDiscount != null)
                {
                    
                    offerManager.ApplyDiscountToOffer(selectedOffer.OfferNumber, selectedDiscount);

                    
                    

                    MessageBox.Show($"Discount {selectedDiscount.DiscountName} applied to Offer {selectedOffer.Title}!");

                    
                    

                    
                    UpdateOffersListBox();
                }
            }
            else
            {
                MessageBox.Show("Please select an offer before applying a discount.");
            }
        }


        private Discount ShowDiscountSelectionDialog(List<Discount> availableDiscounts)
        {
            
            using (var discountSelectionForm = new DiscountSelectionForm(availableDiscounts))
            {
                DialogResult result = discountSelectionForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return discountSelectionForm.SelectedDiscount;
                }

                
                return null;
            }
        }

    }
}
