using Atacado.DAL.Model;
using Atacado.POCO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace AtacadoRestApi.Controllers
{
    /// <summary>
    /// Serviços para a tabela Categoria.
    /// </summary>
    [RoutePrefix("AtacadoRestApi")]
    public class CategoriaController : ApiController
    {
        /// <summary>
        /// Obter todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(List<CategoriaPoco>))]
        public List<CategoriaPoco> Get()
        {
            AtacadoModel contexto = new AtacadoModel();

            List<CategoriaPoco> categoriasPoco = contexto.Categorias.Select(
                novo => new CategoriaPoco()
                {
                    catid = novo.catid,
                    descricao = novo.descricao,
                    dataInclusao = novo.datainsert
                }).ToList();

            return categoriasPoco;
        }

        /// <summary>
        /// Obter registro, baseado na chave primária.
        /// </summary>
        /// <param name="id">Chave primaria do registro.</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Get(int id)
        {
            AtacadoModel contexto = new AtacadoModel();

            CategoriaPoco categoriaPoco = (
                 from novo in contexto.Categorias
                 where novo.catid == id
                 select new CategoriaPoco()
                 {
                     catid = novo.catid,
                     descricao = novo.descricao,
                     dataInclusao = novo.datainsert
                 }).FirstOrDefault();

            return categoriaPoco;
        }

        /// <summary>
        /// Criar um registro na tabela.
        /// </summary>
        /// <param name="poco">Objeto que será incluído.</param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Post([FromBody] CategoriaPoco poco)
        {
            categoria categoria = new categoria();
            categoria.descricao = poco.descricao;
            categoria.datainsert = DateTime.Now;

            AtacadoModel contexto = new AtacadoModel();
            contexto.Categorias.Add(categoria);
            contexto.SaveChanges();

            CategoriaPoco novoPoco = new CategoriaPoco();
            novoPoco.catid = categoria.catid;
            novoPoco.descricao = categoria.descricao;
            novoPoco.dataInclusao = categoria.datainsert;

            return novoPoco;

        }

        /// <summary>
        /// Atualizar um registro na tabela.
        /// </summary>
        /// <param name="id">Chave primaria do registro.</param>
        /// <param name="poco">Objeto que será atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Put(int id, [FromBody] CategoriaPoco poco)
        {
            AtacadoModel contexto = new AtacadoModel();
            categoria categoria = contexto.Categorias.SingleOrDefault(reg => reg.catid == id);
            categoria.descricao = poco.descricao;
            contexto.Entry<categoria>(categoria).State = System.Data.Entity.EntityState.Modified;
            contexto.SaveChanges();

            CategoriaPoco novoPoco = new CategoriaPoco();
            novoPoco.catid = categoria.catid;
            novoPoco.descricao = categoria.descricao;
            novoPoco.dataInclusao = categoria.datainsert;

            return novoPoco;
        }

        /// <summary>
        /// Excluir um registro na tabela.
        /// </summary>
        /// <param name="id">Chave primaria do registro.</param>
        /// <returns></returns>
       [HttpDelete]
        [ResponseType(typeof(CategoriaPoco))]
        public CategoriaPoco Delete(int id)
        {
            AtacadoModel contexto = new AtacadoModel();
            categoria categoria = contexto.Categorias.SingleOrDefault(reg => reg.catid == id);
            contexto.Entry<categoria>(categoria).State = System.Data.Entity.EntityState.Deleted;
            contexto.SaveChanges();

            CategoriaPoco novoPoco = new CategoriaPoco();
            novoPoco.catid = categoria.catid;
            novoPoco.descricao = categoria.descricao;
            novoPoco.dataInclusao = categoria.datainsert;

            return novoPoco;


        }
    }
}
