namespace Exercise2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker1.Value;
            label1.Text = $"Selected Date: {selectedDate.ToShortDateString()}";
            int age = DateTime.Now.Year - selectedDate.Year;
            if (selectedDate > DateTime.Now.AddYears(-age)) age--;
            label2.Text = $"Age: {age} years";

        }
    }
}
