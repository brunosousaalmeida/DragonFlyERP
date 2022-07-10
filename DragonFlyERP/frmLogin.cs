using DragonFlyERP.BLL;
using DragonFlyERP.DTO;

namespace DragonFlyERP
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {
            BLLUsuarios bllUsuario = new BLLUsuarios();

            UsuarioDTO novoUsuario = new UsuarioDTO()
            {
                Codigo = 9,
                Login = "Teste3",
                Senha = "010203",
                IsAdm = true
            };

            bllUsuario.Teste(novoUsuario);
            //bllUsuario.Teste();
        }
    }
}