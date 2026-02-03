namespace FinalTest
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

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "Name: " + textBox1.Text + "\r\n" +
                         "Email: " + textBox2.Text + "\r\n" +
                         "Date of Birth: " + dateTimePicker1.Value.ToShortDateString() + "\r\n" +
                         "Country: " + comboBox1.SelectedItem + "\r\n" +
                         "Comments: " + textBox3.Text;
            MessageBox.Show(str, "Submitted Information");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
    }
}
