using drhipocratesCore.Model;using drhipocratesCore.Business;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Service{    public class TipousuarioService    {        public List<Tipousuario> List()        {            return new TipousuarioBusiness().List();        }        public Tipousuario Get(int idtipousuario)        {            return new TipousuarioBusiness().Get(idtipousuario);        }        public Int32 Update(Tipousuario tipousuario)        {            return new TipousuarioBusiness().Update(tipousuario);        }        public Int32 Insert(Tipousuario tipousuario)        {            return new TipousuarioBusiness().Insert(tipousuario);        }        public Int32 Delete(Int32 idtipousuario)        {            return new TipousuarioBusiness().Delete(idtipousuario);        }    }}