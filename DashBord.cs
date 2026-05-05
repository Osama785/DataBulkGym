namespace Gym_Management
{
    public partial class DashBord : Form
    {
        public DashBord()
        {
            InitializeComponent();        
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Member mem = new Member();
            mem.FormClosed += (s, args) => Application.Exit(); ; 
            mem.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Trainers tre = new Trainers();
            tre.FormClosed += (s, args) => Application.Exit();
            tre.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClassScheduler sched = new ClassScheduler();
            sched.FormClosed += (s, args) => Application.Exit();
            sched.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Membership ms = new Membership();
            ms.FormClosed += (s, args) => Application.Exit(); ;
            ms.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Add Branch form logic here
        }

        private void Member_Load(object sender, EventArgs e) { }
    }
}
