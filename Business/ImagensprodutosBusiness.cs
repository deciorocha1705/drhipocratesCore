using drhipocratesCore.Model;using drhipocratesCore.Repository;using System;using System.Collections.Generic;using System.Linq;using System.Threading.Tasks;namespace drhipocratesCore.Business{    public class ImagensprodutosBusiness    {        public List<Imagensprodutos> List()        {            return new ImagensprodutosRepository().List();        }        public Imagensprodutos Get(int idimagensprodutos)        {            return new ImagensprodutosRepository().Get(idimagensprodutos);        }        public Int32 Update(Imagensprodutos imagensprodutos)        {            return new ImagensprodutosRepository().Put(imagensprodutos);        }        public Int32 Insert(Imagensprodutos imagensprodutos)        {            return new ImagensprodutosRepository().Post(imagensprodutos);        }        public Int32 Delete(Int32 idimagensprodutos)        {            return new ImagensprodutosRepository().Delete(idimagensprodutos);        }    }}