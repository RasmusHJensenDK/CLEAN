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
            cmbEmployees = CreateComboBox(new Point(200, 220));
            cmbEmployeeSelection = CreateComboBox(new Point(200, 270));
            cmbServices = CreateComboBox(new Point(200, 260));
            dtpStartDate = CreateDateTimePicker(new Point(200, 300));

            this.Controls.AddRange(new Control[] { cmbEmployees, cmbEmployeeSelection, cmbServices, dtpStartDate });
        }



        private void InitializeTextboxes()
        {
            txtOfferTitle = CreateTextBox(new Point(200, 20));
            txtCustomerName = CreateTextBox(new Point(200, 60));
            txtCustomerAddress = CreateTextBox(new Point(200, 100));
            txtCustomerEmail = CreateTextBox(new Point(200, 140));
            txtCustomerPhone = CreateTextBox(new Point(200, 180));
            cmbEmployees = CreateComboBox(new Point(200, 220));
            cmbServices = CreateComboBox(new Point(200, 260));
            dtpStartDate = CreateDateTimePicker(new Point(200, 300));
            txtSelectedService = CreateTextBox(new Point(200, 220));
            this.Controls.Add(txtSelectedService);
            this.Controls.AddRange(new Control[] { txtOfferTitle, txtCustomerName, txtCustomerAddress, txtCustomerEmail, txtCustomerPhone, cmbEmployees, cmbServices, dtpStartDate });
        }

        private ComboBox CreateComboBox(Point location)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Location = location;
            comboBox.Size = new Size(200, 20);
            // You may need to populate the combo box with employees or services here if needed
            return comboBox;
        }

        private DateTimePicker CreateDateTimePicker(Point location)
        {
            DateTimePicker dateTimePicker = new DateTimePicker();
            dateTimePicker.Location = location;
            dateTimePicker.Size = new Size(200, 20);
            // Set any additional properties as needed, such as format, min date, max date, etc.
            return dateTimePicker;
        }


        private void InitializeListBox()
        {
            lstOffers = new ListBox();
            lstOffers.SelectedIndexChanged += lstOffers_SelectedIndexChanged;
            lstOffers.Location = new Point(10, 450);
            lstOffers.Size = new Size(1200, 200);

            this.Controls.Add(lstOffers);
        }

        private void InitializeButtons()
        {
            btnCreateOffer = CreateButton("Create Offer", new Point(10, 400), btnCreateOffer_Click);
            btnAssignEmployee = CreateButton("Assign Employee", new Point(180, 400), btnAssignEmployee_Click);
            //btnSelectService = CreateButton("Select Service", new Point(400, 250), null);
            // btnApplyDiscount = CreateButton("Apply Discount", new Point(600, 250), null);

            // btnSelectService = CreateButton("Select Service", new Point(400, 250), btnSelectService_Click);
            btnApplyDiscount = CreateButton("Apply Discount", new Point(350, 400), btnApplyDiscount_Click);

            this.Controls.AddRange(new Control[] { btnCreateOffer, btnAssignEmployee, btnSelectService, btnApplyDiscount });
        }

        private void InitializeLabels()
        {
            Label lblOfferTitle = CreateLabel("Offer Title", new Point(10, 20));
            Label lblCustomerName = CreateLabel("Customer Name", new Point(10, 60));
            Label lblCustomerAddress = CreateLabel("Customer Address", new Point(10, 100));
            Label lblCustomerEmail = CreateLabel("Customer Email", new Point(10, 140));
            Label lblCustomerPhone = CreateLabel("Customer Phone", new Point(10, 180));

            Label lblSelectedOffer = CreateLabel("Selected Offer:", new Point(10, 240));
            Label lblSelectedEmployee = CreateLabel("Selected Employee:", new Point(10, 270));
            Label lblSelectedService = CreateLabel("Selected Service:", new Point(10, 300));
            Label lblSelectedDiscount = CreateLabel("Selected Discount:", new Point(10, 330));

            Label lblOfferDetailsTitle = CreateLabel("Offer Details", new Point(10, 380));

            this.Controls.AddRange(new Control[] { lblOfferTitle, lblCustomerName, lblCustomerAddress, lblCustomerEmail, lblCustomerPhone,
                                           lblSelectedOffer, lblSelectedEmployee, lblSelectedService, lblSelectedDiscount, lblOfferDetailsTitle });
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
            // Assuming you have a method to get available services from your service manager
            List<CleaningService> availableServices = cleaningServiceManager.GetAllCleaningServices();

            // Assuming you have a method to show a dialog for service selection
            CleaningService selectedService = ShowServiceSelectionDialog(availableServices);

            if (selectedService != null)
            {
                // Assuming you have a TextBox to display the selected service
                // Replace "txtSelectedService" with the actual name of your TextBox
                txtSelectedService.Text = selectedService.ToString();
            }
        }

        // Helper method to show a dialog for service selection
        private CleaningService ShowServiceSelectionDialog(List<CleaningService> availableServices)
        {
            // Implement your logic to show a dialog for service selection
            // You can use MessageBox, custom dialog form, or any other method
            // Return the selected service or null if the user cancels the selection
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

        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
            if (lstOffers.SelectedItem != null)
            {
                Offer selectedOffer = (Offer)lstOffers.SelectedItem;

                List<Employee> availableEmployees = employeeManager.GetAllEmployees();

                // Populate cmbEmployeeSelection with available employees
                cmbEmployeeSelection.Items.Clear();
                cmbEmployeeSelection.Items.AddRange(availableEmployees.ToArray());

                Employee selectedEmployee = ShowEmployeeSelectionDialog(availableEmployees);

                if (selectedEmployee != null)
                {
                    // Your existing logic...
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

            // Set the DisplayMember to the property you want to display in the ListBox
            lstOffers.DisplayMember = "Title";  // Change this to the property you want

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
            // Example:
            if (lstOffers.SelectedItem != null)
            {
                Offer selectedOffer = (Offer)lstOffers.SelectedItem;

                // Assuming you have a method in DiscountManager to get available discounts
                List<Discount> availableDiscounts = discountManager.GetAllDiscounts();

                // Assuming you have a method in your UI to show a dialog for discount selection
                Discount selectedDiscount = ShowDiscountSelectionDialog(availableDiscounts);

                if (selectedDiscount != null)
                {
                    // Assuming you have a method in OfferManager to apply a discount to an offer
                    offerManager.ApplyDiscountToOffer(selectedOffer.OfferNumber, selectedDiscount);

                    // Update the UI to reflect the applied discount
                    // For example, you can update a label or TextBox to display the applied discount.

                    MessageBox.Show($"Discount {selectedDiscount.DiscountName} applied to Offer {selectedOffer.Title}!");

                    // Additional logic as needed
                    // ...

                    // Update the list of offers
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
            // Create a form or dialog to display available discounts and allow the user to select one
            using (var discountSelectionForm = new DiscountSelectionForm(availableDiscounts))
            {
                DialogResult result = discountSelectionForm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    return discountSelectionForm.SelectedDiscount;
                }

                // User canceled the selection
                return null;
            }
        }

    }
}
