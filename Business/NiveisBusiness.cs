using drhipocratesCore.Model;using drhipocratesCore.Repository;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Business{    public class NiveisBusiness    {        public List<Niveis> List()        {            return new NiveisRepository().List();        }        public Niveis Get(int idniveis)        {            return new NiveisRepository().Get(idniveis);        }        public Int32 Update(Niveis niveis)        {            return new NiveisRepository().Put(niveis);        }        public Int32 Insert(Niveis niveis)        {            return new NiveisRepository().Post(niveis);        }        public Int32 Delete(Int32 idniveis)        {            return new NiveisRepository().Delete(idniveis);        }    }}