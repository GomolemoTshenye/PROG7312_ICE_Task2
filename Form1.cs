using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SafeUnsafeAdder
{
    public partial class Form1 : Form
    {
        private readonly NumberRepository _repository = new NumberRepository();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// On start-up, make sure the database exists and show whatever is already stored.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                _repository.EnsureDatabaseExists();
                LoadNumbersFromDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to the local SQL Server database." + Environment.NewLine + Environment.NewLine +
                    ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Validates the input, stores it in SQL Server, then reloads the list from
        /// the database so the ListBox always reflects what is actually stored.
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int value;

            if (!int.TryParse(txtNumber.Text.Trim(), out value))
            {
                MessageBox.Show(
                    "Please enter a valid whole number.",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNumber.Focus();
                txtNumber.SelectAll();
                return;
            }

            try
            {
                _repository.Insert(value);
                LoadNumbersFromDatabase();

                txtNumber.Clear();
                txtNumber.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The number could not be saved." + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds the stored numbers using ordinary managed (safe) code.
        /// </summary>
        private void btnCalculateSafe_Click(object sender, EventArgs e)
        {
            int[] numbers = GetNumbersFromList();
            int total = Calculator.AddSafe(numbers);

            lblSafeTotal.Text = "Safe total: " + total + "  (" + numbers.Length + " number(s))";
        }

        /// <summary>
        /// Adds the stored numbers using pointer arithmetic inside an unsafe block.
        /// </summary>
        private void btnCalculateUnsafe_Click(object sender, EventArgs e)
        {
            int[] numbers = GetNumbersFromList();
            int total = Calculator.AddUnsafe(numbers);

            lblUnsafeTotal.Text = "Unsafe total: " + total + "  (" + numbers.Length + " number(s))";
        }

        /// <summary>
        /// Removes every stored number so the demonstration can be repeated.
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult answer = MessageBox.Show(
                "Delete all stored numbers from the database?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _repository.DeleteAll();
                LoadNumbersFromDatabase();

                lblSafeTotal.Text = "Safe total: -";
                lblUnsafeTotal.Text = "Unsafe total: -";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The numbers could not be deleted." + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Retrieves the numbers from SQL Server and displays them in the ListBox.
        /// </summary>
        private void LoadNumbersFromDatabase()
        {
            List<int> numbers = _repository.GetAll();

            lstNumbers.Items.Clear();

            for (int i = 0; i < numbers.Count; i++)
            {
                lstNumbers.Items.Add("Number " + (i + 1) + ":  " + numbers[i]);
            }
        }

        /// <summary>
        /// Reads the numbers straight from the database into an array, ready for adding.
        /// </summary>
        private int[] GetNumbersFromList()
        {
            try
            {
                return _repository.GetAll().ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The numbers could not be retrieved." + Environment.NewLine + Environment.NewLine + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return new int[0];
            }
        }
    }
}
