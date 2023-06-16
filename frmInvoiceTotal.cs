namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        // declare class variables and initialize them with zero values
        int numberOfInvoices = 0;
        decimal totalOfInvoices = 0m;  //the m indicates a decimal value
        decimal invoiceAverage = 0m;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            /**********************************
             * this method calculates the total
             * for an invoice depending on a 
             * discount that's based on the subtotal
             **********************************/

            // get the subtotal amount from the Enter Subtotal text box
            decimal subTotal = Convert.ToDecimal(txtEnterSubTotal.Text);

            // set the discountPercent variable 
            decimal discountPercent = .25m;       

            // calculate and assign the value for the 
            // discountAmount and invoiceTotal variables
            // add rounding to the calculation for the discount amount so only exact amount of invoice is added to the total
            // for invoice
            decimal discountAmount = Math.Round(subTotal * discountPercent, 2);
            decimal invoiceTotal = Math.Round(subTotal - discountAmount);

            // format the values and diplay them in their text boxes
            txtSubTotal.Text = subTotal.ToString("c");    // currency format
            txtDiscountPercent.Text = discountPercent.ToString("p1");   // percent format with 1 decimal place
            txtDiscountAmount.Text = discountAmount.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            // add 1 to the numbe of invoices
            // add the invoice total to the total of invoices
            // calculate the invoice average
            numberOfInvoices++;
            totalOfInvoices+= invoiceTotal;
            invoiceAverage = totalOfInvoices / numberOfInvoices;

            // assign the new values of class variables to the text boxes that will display them
            txtNumberOfInvoices.Text = numberOfInvoices.ToString();
            txtTotalOfInvoices.Text = totalOfInvoices.ToString("c");
            txtInvoiceAverage.Text = invoiceAverage.ToString("c");

            // assign an empty string to the Enter Subtotal text box so the user can enter the subtotal for the next invoice
            // move the focus to the Enter Subtotal text box
            txtEnterSubTotal.Text = "";
            txtEnterSubTotal.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // reset class variables to zeros so the user can enter the subtotal for another batch of invoices
            numberOfInvoices = 0;
            totalOfInvoices = 0;
            invoiceAverage = 0;

            // set the text boxes to empty strings
            txtNumberOfInvoices.Text = "";
            txtTotalOfInvoices.Text = "";
            txtInvoiceAverage.Text = "";

            // move the focus to the Enter Subtotal text box so the user can start the first entry of another batch of invoices
            txtEnterSubTotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // end the application and close the form
            this.Close();
        }
    }
}
