using drhipocratesCore.Model;using drhipocratesCore.Repository;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Business{    public class FabricantesBusiness    {        public List<Fabricantes> List()        {            return new FabricantesRepository().List();        }        public Fabricantes Get(int idfabricantes)        {            return new FabricantesRepository().Get(idfabricantes);        }        public Int32 Update(Fabricantes fabricantes)        {            return new FabricantesRepository().Put(fabricantes);        }        public Int32 Insert(Fabricantes fabricantes)        {            return new FabricantesRepository().Post(fabricantes);        }        public Int32 Delete(Int32 idfabricantes)        {            return new FabricantesRepository().Delete(idfabricantes);        }    }}