using drhipocratesCore.Model;using drhipocratesCore.Repository;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Business{    public class PrecosBusiness    {        public List<Precos> List()        {            return new PrecosRepository().List();        }        public Precos Get(int idprecos)        {            return new PrecosRepository().Get(idprecos);        }        public Int32 Update(Precos precos)        {            return new PrecosRepository().Put(precos);        }        public Int32 Insert(Precos precos)        {            return new PrecosRepository().Post(precos);        }        public Int32 Delete(Int32 idprecos)        {            return new PrecosRepository().Delete(idprecos);        }    }}