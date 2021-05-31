using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.Extensions;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/produto")]
    public class ProdutoController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(INotificador notificador,
                                  IProdutoService produtoService, 
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterTodos());
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> ObterPorId(Guid id)
        {
            var produtoViewModel = await ObterProdutoPorId(id);

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel;
        }

        //[ClaimsAuthorize("Produto", "Atualizar")]
        [AllowAnonymous]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, ProdutoViewModel produtoViewModel)
        {
            var produtoAtualizacao = await ObterProdutoPorId(id);

            if (produtoAtualizacao != null)
            {
                NotificarErro("O produto não foi encontrado, verificar se os dados informados estão corretos!");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            produtoAtualizacao.Nome = produtoViewModel.Nome;
            produtoAtualizacao.Valor = produtoViewModel.Valor;

            await _produtoService.Atualizar(_mapper.Map<Produto>(produtoAtualizacao));

            return CustomResponse(produtoViewModel);
        }

        //[ClaimsAuthorize("Produto", "Excluir")]
        [AllowAnonymous]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid id)
        {
            var produto = await ObterProdutoPorId(id);

            if (produto == null) return NotFound("O produto não foi encontrado, verificar se os dados informados estão corretos!");

            await _produtoService.Remover(id);

            return CustomResponse(produto);
        }

        //[ClaimsAuthorize("Produto", "Adicionar")]
        [AllowAnonymous]
        [HttpPost("adicionar")]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoViewModel));

            return CustomResponse(produtoViewModel);
        }

        //[ClaimsAuthorize("Produto", "AplicarDescontoPorCategoria")]
        [AllowAnonymous]
        [HttpPut("desconto/{categoriaId:guid}/{valorDesconto:int}")]
        public async Task<ActionResult> AplicarDescontoPorCategoria(Guid categoriaId, int valorDesconto, ProdutoViewModel produtoViewModel)
        {
            try
            {
                var produtosPorCategorias = await ObterProdutosPorCategoria(categoriaId);

                if (produtosPorCategorias == null)
                {
                    NotificarErro("Não foram encontrados produtos para essa categoria, verificar se os dados informados estão corretos!");
                    return CustomResponse();
                }

                var porcentagem = (decimal)valorDesconto / 100;

                foreach (var produto in produtosPorCategorias)
                {
                    produto.Valor = Convert.ToDecimal((produto.Valor - ((porcentagem) * produto.Valor)).ToString("N2"));

                    await _produtoService.Atualizar(_mapper.Map<Produto>(produto));
                }

                return CustomResponse("Desconto aplicado com sucesso!");
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        //[ClaimsAuthorize("Produto", "AplicarAcrescimoPorCategoria")]
        [AllowAnonymous]
        [HttpPut("acrescimo/{categoriaId:guid}/{valorAcrescimo:int}")]
        public async Task<ActionResult> AplicarAcrescimoPorCategoria(Guid categoriaId, int valorAcrescimo)
        {
            try
            {
                var produtosPorCategorias = await ObterProdutosPorCategoria(categoriaId);

                if (produtosPorCategorias == null)
                {
                    NotificarErro("Não foram encontrados produtos para essa categoria, verificar se os dados informados estão corretos!");
                    return CustomResponse();
                }

                var porcentagem = (decimal)valorAcrescimo / 100;

                foreach (var produto in produtosPorCategorias)
                {
                    produto.Valor = Convert.ToDecimal((produto.Valor + ((porcentagem) * produto.Valor)).ToString("N2"));

                    await _produtoService.Atualizar(_mapper.Map<Produto>(produto));
                }

                return CustomResponse("Acrescimo aplicado com sucesso!");
            }
            catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
        }

        private async Task<ProdutoViewModel> ObterProdutoPorId(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoService.ObterPorId(id));
        }

        private async Task<IEnumerable<ProdutoViewModel>> ObterProdutosPorCategoria(Guid categoriaId)
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoService.ObterProdutosPorCategoria(categoriaId));
        }
    }
}