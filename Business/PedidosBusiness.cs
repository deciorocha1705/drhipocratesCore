using drhipocratesCore.Model;using drhipocratesCore.Repository;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Business{    public class PedidosBusiness    {        public List<Pedidos> List()        {            return new PedidosRepository().List();        }        public Pedidos Get(int idpedidos)        {            return new PedidosRepository().Get(idpedidos);        }        public Int32 Update(Pedidos pedidos)        {            return new PedidosRepository().Put(pedidos);        }        public Int32 Insert(Pedidos pedidos)        {            return new PedidosRepository().Post(pedidos);        }        public Int32 Delete(Int32 idpedidos)        {            return new PedidosRepository().Delete(idpedidos);        }    }}