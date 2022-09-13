using LancamentosFinanceiroApi.Data.Context;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LancamentosFinanceiroApi.Repository.Implementations
{
    public class UsuarioRepositoryImplementations : IUsuarioRepository
    {
        private readonly FinancaContextoAPI _context;

        public UsuarioRepositoryImplementations(FinancaContextoAPI context)
        {
            _context = context;
        }


        public Usuario ObterUsuario(int id)
        {

            var usuario = _context.Usuarios.Include(U=> U.Lancamentos).SingleOrDefault(C => C.Id.Equals(id));


            return usuario;

        }

        public Usuario ObterUsuarioCPF(string cpf)
        {
            var Usuario = _context.Usuarios.Include(U => U.Lancamentos).SingleOrDefault(C => C.CPF == cpf);

            return Usuario;
        }

        public Usuario ObterUsuarioEmail(string email)
        {
            var Usuario = _context.Usuarios.Include(U => U.Lancamentos).SingleOrDefault(C => C.Email == email);

            return Usuario;
        }

        public void SalvarUsuario(Usuario usuario)
        {

            usuario.Senha = ComputeHash(usuario.Senha, new SHA256CryptoServiceProvider());

            Login login = new Login(usuario.Email, usuario.Senha , "teste", DateTime.Now);

            _context.Add(usuario);
            _context.Add(login);

            _context.SaveChanges();


        }

        public Usuario UpdateUsuario(Usuario usuario)
        {

            var result = _context.Usuarios.SingleOrDefault(C => C.Id.Equals(usuario.Id));

            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(usuario);

                _context.SaveChanges();

                return usuario;

            }

            return null;


        }

        private string ComputeHash(string password, SHA256CryptoServiceProvider algoritm)
        {

            Byte[] inputBytes = Encoding.UTF8.GetBytes(password);

            Byte[] hashedBytes = algoritm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);



        }
    }
}
