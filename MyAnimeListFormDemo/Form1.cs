using System.Windows.Forms;
using MyAnimeListSharp.Auth;
using MyAnimeListSharp.Facade.Async;

namespace MyAnimeListFormDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            ICredentialContext credential = new CredentialContext();

            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(tbSearch.Text))
                {
                    MessageBox.Show("Nothing to Search for.....");
                }
                else
                {
                    string response;

                    var asyncAnimeSearch = new AnimeSearchMethodsAsync(credential);
                    response = await asyncAnimeSearch.SearchAsync(tbSearch.Text); // Error occurs here when i try to search again . Error disappears when i try to search after it. ( line 238 )

                    if (string.IsNullOrWhiteSpace(response)) // After this the error occurs when i try to search again.
                    {
                        MessageBox.Show("No such entry");
                    }
                    else
                    {   // Add response to ListView
                        MessageBox.Show(response);
                    }
                }
            }
        }
    }
}
