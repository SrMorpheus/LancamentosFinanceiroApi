using LancamentosFinanceiroApi.Data.Context;
using LancamentosFinanceiroApi.DataObjects.Converter.Contract;
using LancamentosFinanceiroApi.Models;
using LancamentosFinanceiroApi.Models.Enum;
using LancamentosFinanceiroApi.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace LancamentosFinanceiroApi.Repository.Implementations
{
    public class LancamentoRepositoryImplementations : ILancamentoRepository
    {

        private readonly FinancaContextoAPI _context;


        public LancamentoRepositoryImplementations(FinancaContextoAPI context)
        {
            _context = context;
        }

        public void DeletarLancamento(int id)
        {

            var result = _context.Lancamentos.SingleOrDefault(C => C.Id.Equals(id));

            if (result != null)
            {
                _context.Lancamentos.Remove(result);

                _context.SaveChanges();

            }


        }


        public List<Lancamento> ListasLancamentosTiposUsuario(int IdUsuarios, int IdTipoLancamento)
        {

            var Lancamentos = _context.Lancamentos.Include(T => T.TipoLancamento).Include(U => U.UsuarioLacamento).Where(C => C.UsuarioId.Equals(IdUsuarios) && C.TipoLancamentoId.Equals(IdTipoLancamento)  );

            return Lancamentos.ToList();
        }

        public List<Lancamento> ListasLancamentosTiposUsuario(string username, int IdTipoLancamento)

        {
            var user = _context.Usuarios.SingleOrDefault(u => (u.Email == username));

            if (user == null) return null;

            var Lancamentos = _context.Lancamentos.Include(T => T.TipoLancamento).Include(U => U.UsuarioLacamento).Where(C => C.UsuarioId.Equals(user.Id) && C.TipoLancamentoId.Equals(IdTipoLancamento));

            return Lancamentos.ToList();


        }

        public List<Lancamento> ListasLancamentosUsuario(string username)
        {

            var user = _context.Usuarios.SingleOrDefault(u => (u.Email == username));

            if (user == null) return null;

            var Lancamentos = _context.Lancamentos.Include(T => T.TipoLancamento).Include(U => U.UsuarioLacamento).Where(C => C.UsuarioId.Equals(user.Id));

            return Lancamentos.ToList();
        }

        public void NovoLancamento(Lancamento lancamento, string username)
        {

            
            var user = _context.Usuarios.SingleOrDefault(u => (u.Email == username));


            if(user !=null)
            {

                lancamento.UsuarioId = user.Id;

                _context.Add(lancamento);

                _context.SaveChanges();

            }

        
        }

        public Lancamento ObterLancamento(int id)
        {

            var Lancamento = _context.Lancamentos.Include(T => T.TipoLancamento).Include(U => U.UsuarioLacamento).SingleOrDefault(L => L.Id.Equals(id));

            return Lancamento;


        }

        public Lancamento UpdateLancamento(Lancamento lancamento)
        {

            var result = _context.Lancamentos.SingleOrDefault(C => C.Id.Equals(lancamento.Id));

            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(lancamento);

                _context.SaveChanges();

                return lancamento;

            }

            return null;
            
             

        }
    }
}
