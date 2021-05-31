using AutoMapper;
using DevIO.Api.Controllers;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/relatorio")]
    public class RelatorioProdutoController : MainController
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly IEntradaSaidaProdutoRepository _entradaSaidaProdutoRepository;
        private readonly IMapper _mapper;

        public RelatorioProdutoController(INotificador notificador,
                                  ICategoriaProdutoRepository categoriaProdutoRepository,
                                  IEntradaSaidaProdutoRepository entradaSaidaProdutoRepository,
                                  IMapper mapper,
                                  IUser user) : base(notificador, user)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _entradaSaidaProdutoRepository = entradaSaidaProdutoRepository;
            _mapper = mapper;
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public async Task<IEnumerable<CategoriaProdutoViewModel>> ObterTodos()
        //{
        //    return _mapper.Map<IEnumerable<CategoriaProdutoViewModel>>(await _categoriaProdutoRepository.ObterTodos());
        //}

        [AllowAnonymous]
        [HttpGet]
        private async Task<IEnumerable<EntradaSaidaProdutoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EntradaSaidaProdutoViewModel>>(await _entradaSaidaProdutoRepository.ObterEntradaSaidaPorProdutos());
        }
    }
}
