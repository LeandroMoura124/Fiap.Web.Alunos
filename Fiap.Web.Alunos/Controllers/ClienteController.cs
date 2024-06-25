using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Alunos.Controllers
{
    public class ClienteController : Controller
    {
        //Lista para armazenar os clientes
        public IList<ClienteModel> clientes { get; set; }

        //Lista para armazenar os representantes
        public IList<RepresentanteModel> representantes { get; set; }

        private readonly DatabaseContext _databaseContext;

        public ClienteController(DatabaseContext databaseContext)
        {

            _databaseContext = databaseContext;

            representantes = _databaseContext.Representantes.ToList();

            clientes = databaseContext.Clientes.ToList();
        }


        public IActionResult Index()
        {
            // Evitando valores null
            if (clientes == null)
            {
                clientes = new List<ClienteModel>();
            }
            return View(clientes);
        }

        // Anota��o de uso do Verb HTTP Get
        [HttpGet]
        // 0 references | Flavio Moreni, 13 days ago | 1 author, 2 changes
        public IActionResult Create()
        {
            Console.WriteLine("Executou a Action Cadastrar()");
            // Cria a vari�vel para armazenar o SelectList
            var selectListRepresentantes =
                new SelectList(representantes,
                    nameof(RepresentanteModel.RepresentanteId),
                    nameof(RepresentanteModel.RepresentanteNome));

            // Adiciona o SelectList a ViewBag para ser enviado para a View
            // A propriedade Representantes � criada de forma din�mica na ViewBag
            ViewBag.Representantes = selectListRepresentantes;

            // Retorna para a View Create um 
            // objeto modelo com as propriedades em branco
            return View(new ClienteModel());
        }
        // Anota��o de uso do Verb HTTP Post
        [HttpPost]
        public IActionResult Create(ClienteModel clienteModel)
        {
            _databaseContext.Clientes.Add(clienteModel);
            _databaseContext.SaveChanges();

            // Criando a mensagem de sucesso que ser� exibida para o Cliente
            TempData["mensagemSucesso"] = $"O cliente {clienteModel.Nome} foi cadastrado com sucesso!";

            return RedirectToAction(nameof(Index));
        }
        // ... Metodos para gerar clientes e representantes mockados
        private IList<ClienteModel> GerarClientesMocados()
        {
            return new List<ClienteModel>();
            // ... implementa��o para gerar clientes mockados
        }
    }
}