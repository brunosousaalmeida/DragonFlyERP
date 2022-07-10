using DragonFlyERP.DAL;
using DragonFlyERP.DTO;

namespace DragonFlyERP.BLL
{
    public class BLLUsuarios
    {
        public void Teste(UsuarioDTO novoUsuario) //UsuarioDTO novoUsuario
        {
            DALUsuarios DalUsuario = new DALUsuarios();

            //var teste = DalUsuario.InserirUsuario(novoUsuario);
            var teste = DalUsuario.ExcluirUsuario(novoUsuario);
        }
    }
}