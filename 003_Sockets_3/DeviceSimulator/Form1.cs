using CommonLibs;
using Socket_client;

namespace DeviceSimulator
{
    public partial class Form1 : Form
    {
        private ClientService _socketService;
        private System.Timers.Timer _timer;
        private bool _socketConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateSocketControls(true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!_socketConnected) 
            {
                if (!DataIsValid())
                {
                    return;
                }

                StartWorking();
            }
            else
            {
                _timer.Stop();
                _socketConnected = false;
                _socketService.Stop();
                UpdateSocketControls(true);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtIpAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void StartWorking()
        {
            if(_socketService == null)
            {
                _socketService = new ClientService(txtIpAddress.Text, txtPort.Text);
            }

            if(!_socketConnected) 
            { 
                _socketService.Connect();
            }

            _socketConnected = true;
            
            UpdateSocketControls(!_socketConnected);


            _timer = new System.Timers.Timer(Constants.MILISECONDS_TO_CREATE_A_NEW_MOCK_PRODUCT);
            _timer.Elapsed += CreateProduct;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private bool DataIsValid()
        {
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtIpAddress.Text))
            {
                errorProvider1.SetError(txtIpAddress, "Tiene que asignar una dirección IP");
                //MessageBox.Show("Tiene que asignar una dirección IP", "Información inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtPort.Text))
            {
                errorProvider1.SetError(txtPort, "Tiene que asignar un puerto.");
                //MessageBox.Show("Tiene que asignar un puerto.", "Información inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (cboProductType.SelectedItem == null)
            {
                errorProvider1.SetError(cboProductType, "Tiene que seleccionar un tipo de producto.");
                //MessageBox.Show("Tiene que seleccionar un tipo de producto.", "Información inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (string.IsNullOrEmpty(txtProductDescription.Text))
            {
                errorProvider1.SetError(txtProductDescription, "Tiene que asignar una descripción al producto.");
                //MessageBox.Show("Tiene que asignar una descripción al producto.", "Información inválida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        private void CreateProduct(object? sender, System.Timers.ElapsedEventArgs e)
        {
            _timer.Enabled = false;
            Random rnd = new Random();
            int thereIsError = rnd.Next(0, 10); //>7 hay error

            if(thereIsError > 7)
            { 
                int errorNo = rnd.Next(0, Constants.MOCK_ERRORS.Count());
                _socketService.SendDataToServer($"error:{Constants.MOCK_ERRORS[errorNo]}");
            }
            else
            {
                string productType = string.Empty;
                Invoke(() =>
                {
                    _socketService.SendDataToServer($"ok:{cboProductType.SelectedItem}[{txtProductDescription.Text}]");
                });
            }
            
            _timer.Enabled = true;
        }

        private void UpdateSocketControls(bool enabled)
        {
            txtIpAddress.Enabled = enabled;
            txtPort.Enabled = enabled;
            lblStatus.Visible = !enabled;

            if(enabled) 
            {
                button1.BackColor = Color.LightSteelBlue;
                button1.ForeColor = Color.Black;
                button1.Text = "Start";
            }
            else
            {
                button1.BackColor = Color.Red;
                button1.ForeColor = Color.White;
                button1.Text = "Stop";
            }
        }
    }
}
