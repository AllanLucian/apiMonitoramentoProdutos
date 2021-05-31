using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.Extensions;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DevIO.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/vender")]
    public class ProdutoVendaController : MainController
    {
        private readonly IProdutoService _produtoService;
        private readonly IEntradaSaidaProdutoService _entradaSaidaProdutoService;
        private readonly IMapper _mapper;
        private readonly IUser _user;

        public ProdutoVendaController(INotificador notificador,
                                  IProdutoService produtoService,
                                  IEntradaSaidaProdutoService entradaSaidaProdutoService,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _produtoService = produtoService;
            _entradaSaidaProdutoService = entradaSaidaProdutoService;
            _mapper = mapper;
            _user = user;
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Produto", "VenderProduto")]
        [HttpPut("{id:guid}/{quantidade:int}")]
        public async Task<ActionResult> VenderProduto(Guid id, int quantidade)
        {
            try
            {
                var produto = await ObterProdutoPorId(id);

                if (produto != null)
                {
                    NotificarErro("O produto não existe, verificar (id) informado!");
                    return CustomResponse();
                }

                if (!ModelState.IsValid) return CustomResponse(ModelState);

                if (produto.Quantidade >= quantidade)
                {
                    produto.Quantidade = produto.Quantidade - quantidade;
                    await _produtoService.Atualizar(_mapper.Map<Produto>(produto));

                    var entradaSaida = new EntradaSaidaProduto()
                    {
                        ProdutoId = id,
                        Operacao = string.Concat("Venda de ", quantidade, " unidades"),
                        Responsavel = _user.GetUserEmail(),
                        Quantidade = produto.Quantidade,
                        Data = DateTime.Now
                    };

                    await _entradaSaidaProdutoService.Adicionar(entradaSaida);

                    return CustomResponse();
                }
                else
                {
                    NotificarErro("O produto informado possui apenas {0} em seu estoque!");
                    return CustomResponse();
                }
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
    }
}
