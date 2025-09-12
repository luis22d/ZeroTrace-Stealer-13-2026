using System;
using System.Media;
using System.Windows.Forms;

namespace ZeroTrace_Stealer
{
    public partial class ReportFrm : Form
    {
        private SoundPlayer soundPlayer;

        public ReportFrm()
        {
            InitializeComponent();
            InitializeSound();
        }

        private void InitializeSound()
        {
            try
            {
                // Initialize sound player with the chaos.wav file
                soundPlayer = new SoundPlayer(Properties.Resources.chaos);
                soundPlayer.LoadAsync(); // Load the sound file asynchronously
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sound: {ex.Message}");
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PlayNotificationSound();
        }

        private void PlayNotificationSound()
        {
            try
            {
                if (soundPlayer != null)
                {
                    soundPlayer.Play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Clean up sound resources
            if (soundPlayer != null)
            {
                soundPlayer.Dispose();
                soundPlayer = null;
            }
        }
    }
}