using drhipocratesCore.Model;using drhipocratesCore.Repository;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Business{    public class MovimentacoesBusiness    {        public List<Movimentacoes> List()        {            return new MovimentacoesRepository().List();        }        public Movimentacoes Get(int idmovimentacoes)        {            return new MovimentacoesRepository().Get(idmovimentacoes);        }        public Int32 Update(Movimentacoes movimentacoes)        {            return new MovimentacoesRepository().Put(movimentacoes);        }        public Int32 Insert(Movimentacoes movimentacoes)        {            return new MovimentacoesRepository().Post(movimentacoes);        }        public Int32 Delete(Int32 idmovimentacoes)        {            return new MovimentacoesRepository().Delete(idmovimentacoes);        }    }}